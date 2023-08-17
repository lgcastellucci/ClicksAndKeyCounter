using System.Runtime.InteropServices;

namespace ClicksAndKeysCounter
{
    public static class MouseHook
    {
        private static IntPtr hookId = IntPtr.Zero;
        private static Win32.LowLevelMouseProc proc = HookCallback;

        public static event EventHandler LeftButtonDown;
        public static event EventHandler RightButtonDown;

        public static void Start()
        {
            hookId = SetHook(proc);
        }

        public static void Stop()
        {
            Win32.UnhookWindowsHookEx(hookId);
        }

        private static IntPtr SetHook(Win32.LowLevelMouseProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return Win32.SetWindowsHookEx(Win32.WH_MOUSE_LL, proc, Win32.GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)Win32.WM_LBUTTONDOWN)
            {
                LeftButtonDown?.Invoke(null, EventArgs.Empty);
            }
            else if (nCode >= 0 && wParam == (IntPtr)Win32.WM_RBUTTONDOWN)
            {
                RightButtonDown?.Invoke(null, EventArgs.Empty);
            }
            return Win32.CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        private static class Win32
        {
            public const int WH_MOUSE_LL = 14;
            public const int WM_LBUTTONDOWN = 0x0201;
            public const int WM_RBUTTONDOWN = 0x0204;

            public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);
        }
    }
}
