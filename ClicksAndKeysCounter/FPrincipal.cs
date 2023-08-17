
namespace ClicksAndKeysCounter
{
    public partial class FPrincipal : Form
    {
        private int leftButtonClickCount = 0; // Vari�vel para contar os cliques do bot�o esquerdo
        private int rightButtonClickCount = 0; // Vari�vel para contar os cliques do bot�o direito
        private bool counting = false; // Vari�vel para indicar se a contagem est� em andamento

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
            }
            else
            {
                counting = false;
                btnToggle.Text = "Iniciar";
                MouseHook.Stop(); // Para o monitoramento de cliques
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

            UpdateNotifyIconText(); // Atualize o texto do �cone na bandeja do sistema
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

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            leftButtonClickCount = RegistraLog.GetLastCountLeftClicks();
            rightButtonClickCount = RegistraLog.GetLastCountRightClicks();

            MouseHook.LeftButtonDown += MouseHook_LeftButtonDown;
            MouseHook.RightButtonDown += MouseHook_RightButtonDown;

            btnToggle_Click(null, null); // Inicia a contagem ao carregar o formul�rio (opcional)
        }

        private void FPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            MouseHook.Stop();
        }

        private void FPrincipal_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide(); // Esconde o formul�rio quando � minimizado
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); // Exibe o formul�rio quando o �cone na bandeja � clicado duas vezes
            WindowState = FormWindowState.Normal;
        }
    }
}