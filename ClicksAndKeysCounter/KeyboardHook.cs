using System.Runtime.InteropServices;

namespace ClicksAndKeysCounter
{
    public static class KeyboardHook
    {
        private static IntPtr hookId = IntPtr.Zero;
        private static Win32.LowLevelKeyboardProc proc = HookCallback;

        public static event EventHandler KeyDown;

        public static void Start()
        {
            hookId = SetHook(proc);
        }

        public static void Stop()
        {
            Win32.UnhookWindowsHookEx(hookId);
        }

        private static IntPtr SetHook(Win32.LowLevelKeyboardProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            {
                using (var curModule = curProcess.MainModule)
                {
                    return Win32.SetWindowsHookEx(Win32.WH_KEYBOARD_LL, proc, Win32.GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)Win32.WM_KEYDOWN)
            {
                KeyDown?.Invoke(null, EventArgs.Empty);
            }
           
            return Win32.CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        private static class Win32
        {
            // Constants from trigger of keyboard
            public const int WH_KEYBOARD_LL = 13;
            public const int WM_KEYDOWN = 0x0100;

            // Importa a função da API do Windows para instalar um gancho de teclado
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

            // Importa a função da API do Windows para desinstalar um gancho de teclado
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            // Importa a função da API do Windows para chamar o próximo gancho na cadeia
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            // Importa a função da API do Windows para obter o módulo atual
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);

            // Delegado para o procedimento de gancho de teclado de baixo nível
            public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        }

    }
}
