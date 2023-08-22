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
            lbLeftClickCount = new Label();
            lbRightClickCount = new Label();
            notifyIconMain = new NotifyIcon(components);
            lbKeyPressCount = new Label();
            pictureBoxMapClicks = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMapClicks).BeginInit();
            SuspendLayout();
            // 
            // lbLeftClickCount
            // 
            lbLeftClickCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbLeftClickCount.Location = new Point(12, 9);
            lbLeftClickCount.Name = "lbLeftClickCount";
            lbLeftClickCount.Size = new Size(228, 19);
            lbLeftClickCount.TabIndex = 1;
            lbLeftClickCount.Text = "lbLeftClickCount";
            lbLeftClickCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbRightClickCount
            // 
            lbRightClickCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbRightClickCount.Location = new Point(246, 9);
            lbRightClickCount.Name = "lbRightClickCount";
            lbRightClickCount.Size = new Size(228, 19);
            lbRightClickCount.TabIndex = 2;
            lbRightClickCount.Text = "lbRightClickCount";
            lbRightClickCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // notifyIconMain
            // 
            notifyIconMain.Icon = (Icon)resources.GetObject("notifyIconMain.Icon");
            notifyIconMain.Text = "notifyIconMain";
            notifyIconMain.Visible = true;
            notifyIconMain.MouseDoubleClick += NotifyIconMain_MouseDoubleClick;
            // 
            // lbKeyPressCount
            // 
            lbKeyPressCount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lbKeyPressCount.Location = new Point(480, 9);
            lbKeyPressCount.Name = "lbKeyPressCount";
            lbKeyPressCount.Size = new Size(228, 19);
            lbKeyPressCount.TabIndex = 3;
            lbKeyPressCount.Text = "lbKeyPressCount";
            lbKeyPressCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxMapClicks
            // 
            pictureBoxMapClicks.Location = new Point(12, 98);
            pictureBoxMapClicks.Name = "pictureBoxMapClicks";
            pictureBoxMapClicks.Size = new Size(696, 339);
            pictureBoxMapClicks.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMapClicks.TabIndex = 4;
            pictureBoxMapClicks.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 80);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 5;
            label1.Text = "Map of Clicks";
            // 
            // FPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 449);
            Controls.Add(label1);
            Controls.Add(pictureBoxMapClicks);
            Controls.Add(lbKeyPressCount);
            Controls.Add(lbRightClickCount);
            Controls.Add(lbLeftClickCount);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClicksAndKeysCounter";
            FormClosing += FPrincipal_FormClosing;
            Load += FPrincipal_Load;
            Resize += FPrincipal_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBoxMapClicks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbLeftClickCount;
        private Label lbRightClickCount;
        private NotifyIcon notifyIconMain;
        private Label lbKeyPressCount;
        private PictureBox pictureBoxMapClicks;
        private Label label1;
    }
}