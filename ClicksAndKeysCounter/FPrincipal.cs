
namespace ClicksAndKeysCounter
{
    public partial class FPrincipal : Form
    {
        private int leftButtonClickCount = 0; // Variável para contar os cliques do botão esquerdo
        private int rightButtonClickCount = 0; // Variável para contar os cliques do botão direito
        private int keyPressCount = 0; // Variável para contar as teclas pressionadas

        private bool counting = false; // Variável para indicar se a contagem está em andamento

        private DateTime today = DateTime.Now.Date; // Variável para obter a data atual

        public FPrincipal()
        {
            InitializeComponent();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            ChangeCounting();
        }

        private void ChangeCounting()
        {
            if (counting)
            {
                counting = false;
                btnToggle.Text = "Start";
                MouseHook.Stop(); // Para o monitoramento de cliques
                KeyboardHook.Stop(); // Para o monitoramento de cliques
            }
            else
            {
                counting = true;
                btnToggle.Text = "Stop";
                MouseHook.Start(); // Inicia o monitoramento de cliques
                KeyboardHook.Start(); // Inicia o monitoramento de teclas
            }
        }

        private void UpdateCountLabel(string button)
        {
            lbLeftClickCount.Text = RegistraLog.messageLeftButtonClick + " : " + leftButtonClickCount.ToString();
            lbRightClickCount.Text = RegistraLog.messageRightButtonClick + " : " + rightButtonClickCount.ToString();
            lbKeyPressCount.Text = RegistraLog.messageKeyPress + " : " + keyPressCount.ToString();

            if (button == "L")
                RegistraLog.RegisterSetCount(button, leftButtonClickCount);
            if (button == "R")
                RegistraLog.RegisterSetCount(button, rightButtonClickCount);
            if (button == "K")
                RegistraLog.RegisterSetCount(button, keyPressCount);

            UpdateNotifyIconText(); // Atualize o texto do ícone na bandeja do sistema
        }

        private void UpdateNotifyIconText()
        {
            notifyIconMain.Text = $"Cliques: {leftButtonClickCount + rightButtonClickCount}";
        }

        private void ClearCounts()
        {
            leftButtonClickCount = 0;
            rightButtonClickCount = 0;
            keyPressCount = 0;

            UpdateCountLabel("L");
            UpdateCountLabel("R");
            UpdateCountLabel("K");
        }

        private void MouseHook_LeftButtonDown(object sender, EventArgs e)
        {
            if (today != DateTime.Now.Date)
            {
                ClearCounts();
                today = DateTime.Now.Date;
            }

            if (counting)
            {
                leftButtonClickCount++;
                UpdateCountLabel("L");
            }
        }

        private void MouseHook_RightButtonDown(object sender, EventArgs e)
        {
            if (today != DateTime.Now.Date)
            {
                ClearCounts();
                today = DateTime.Now.Date;
            }

            if (counting)
            {
                rightButtonClickCount++;
                UpdateCountLabel("R");
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
            if (today != DateTime.Now.Date)
            {
                ClearCounts();
                today = DateTime.Now.Date;
            }

            if (counting)
            {
                keyPressCount++;
                UpdateCountLabel("K");
            }
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            leftButtonClickCount = RegistraLog.GetLastCount("L");
            rightButtonClickCount = RegistraLog.GetLastCount("R");
            keyPressCount = RegistraLog.GetLastCount("K");
            UpdateCountLabel("");

            MouseHook.LeftButtonDown += MouseHook_LeftButtonDown;
            MouseHook.RightButtonDown += MouseHook_RightButtonDown;
            MouseHook.PositionButtonDown += MouseHook_PositionButtonDown;

            KeyboardHook.KeyDown += KeyboardHook_KeyDown;

            //the status create false, now change to true to start the counting
            ChangeCounting();
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

        private void NotifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); // Exibe o formulário quando o ícone na bandeja é clicado duas vezes
            WindowState = FormWindowState.Normal;
        }

    }
}