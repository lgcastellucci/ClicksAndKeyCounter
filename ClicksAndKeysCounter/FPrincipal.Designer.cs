namespace ClicksAndKeysCounter
{
    partial class FPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipal));
            btnToggle = new Button();
            lbLeftClickCount = new Label();
            lbRightClickCount = new Label();
            notifyIcon1 = new NotifyIcon(components);
            SuspendLayout();
            // 
            // btnToggle
            // 
            btnToggle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnToggle.Location = new Point(12, 12);
            btnToggle.Name = "btnToggle";
            btnToggle.Size = new Size(228, 35);
            btnToggle.TabIndex = 0;
            btnToggle.Text = "Iniciar";
            btnToggle.UseVisualStyleBackColor = true;
            btnToggle.Click += btnToggle_Click;
            // 
            // lbLeftClickCount
            // 
            lbLeftClickCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbLeftClickCount.Location = new Point(12, 60);
            lbLeftClickCount.Name = "lbLeftClickCount";
            lbLeftClickCount.Size = new Size(228, 19);
            lbLeftClickCount.TabIndex = 1;
            lbLeftClickCount.Text = "lbLeftClickCount";
            lbLeftClickCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbRightClickCount
            // 
            lbRightClickCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbRightClickCount.Location = new Point(12, 85);
            lbRightClickCount.Name = "lbRightClickCount";
            lbRightClickCount.Size = new Size(228, 19);
            lbRightClickCount.TabIndex = 2;
            lbRightClickCount.Text = "lbRightClickCount";
            lbRightClickCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // FPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 113);
            Controls.Add(lbRightClickCount);
            Controls.Add(lbLeftClickCount);
            Controls.Add(btnToggle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += FPrincipal_FormClosing;
            Load += FPrincipal_Load;
            Resize += FPrincipal_Resize;
            ResumeLayout(false);
        }

        #endregion

        private Button btnToggle;
        private Label lbLeftClickCount;
        private Label lbRightClickCount;
        private NotifyIcon notifyIcon1;
    }
}