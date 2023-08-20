
namespace ClicksAndKeysCounter
{
    public partial class FPrincipal : Form
    {
        private int leftButtonClickCount = 0; // Variável para contar os cliques do botão esquerdo
        private int rightButtonClickCount = 0; // Variável para contar os cliques do botão direito
        private int keyPressCount = 0; // Variável para contar as teclas pressionadas

        private bool counting = false; // Variável para indicar se a contagem está em andamento

        public FPrincipal()
        {
            InitializeComponent();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (!counting)
            {
                counting = true;
                btnToggle.Text = "Parar";
                MouseHook.Start(); // Inicia o monitoramento de cliques
                KeyboardHook.Start(); // Inicia o monitoramento de teclas
            }
            else
            {
                counting = false;
                btnToggle.Text = "Iniciar";
                MouseHook.Stop(); // Para o monitoramento de cliques
                KeyboardHook.Stop(); // Para o monitoramento de cliques
            }
        }

        private void UpdateClickCountLabel(string button)
        {
            lbLeftClickCount.Text = $"Left Button Clicks: {leftButtonClickCount}";
            lbRightClickCount.Text = $"Right Button Clicks: {rightButtonClickCount}";

            if (button == "L")
                RegistraLog.LogDetalhado($"Left Button Clicks: {leftButtonClickCount}");
            if (button == "R")
                RegistraLog.LogDetalhado($"Right Button Clicks: {rightButtonClickCount}");

            UpdateNotifyIconText(); // Atualize o texto do ícone na bandeja do sistema
        }

        private void UpdateNotifyIconText()
        {
            notifyIcon1.Text = $"Cliques: {leftButtonClickCount + rightButtonClickCount}";
        }

        private void MouseHook_LeftButtonDown(object sender, EventArgs e)
        {
            if (counting)
            {
                leftButtonClickCount++;
                UpdateClickCountLabel("L");
            }
        }

        private void MouseHook_RightButtonDown(object sender, EventArgs e)
        {
            if (counting)
            {
                rightButtonClickCount++;
                UpdateClickCountLabel("R");
            }
        }

        private void MouseHook_PositionButtonDown(object sender, EventArgs e)
        {
            if (counting)
            {
                if (sender != null)
                {
                    try
                    {
                        var point = (MouseHook.POINT)sender;
                        RegistraLog.LogDetalhado($"Mouse clicked at X: {point.x}, Y: {point.y}");
                        SaveImage.UpdateImage(point.x, point.y);
                    }
                    catch { }
                }
            }
        }

        private void KeyboardHook_KeyDown(object sender, EventArgs e)
        {
            if (counting)
            {
                keyPressCount++;
                UpdatKeyCountLabel();
            }
        }

        private void UpdatKeyCountLabel()
        {
            lbKeyPressCount.Text = $"Keys Pressed: {keyPressCount}";
            RegistraLog.LogDetalhado($"Keys Pressed: {keyPressCount}");
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            leftButtonClickCount = RegistraLog.GetLastCountLeftClicks();
            rightButtonClickCount = RegistraLog.GetLastCountRightClicks();

            MouseHook.LeftButtonDown += MouseHook_LeftButtonDown;
            MouseHook.RightButtonDown += MouseHook_RightButtonDown;
            MouseHook.PositionButtonDown += MouseHook_PositionButtonDown;

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;

            btnToggle_Click(null, null); // Inicia a contagem ao carregar o formulário (opcional)
        }

        private void FPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            MouseHook.Stop();
        }

        private void FPrincipal_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide(); // Esconde o formulário quando é minimizado
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); // Exibe o formulário quando o ícone na bandeja é clicado duas vezes
            WindowState = FormWindowState.Normal;
        }

    }
}