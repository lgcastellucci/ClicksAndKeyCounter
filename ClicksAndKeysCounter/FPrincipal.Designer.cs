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
            dateTimePicker1 = new DateTimePicker();
            groupBox1 = new GroupBox();
            TimeMoveMouse = new NumericUpDown();
            chkMoveMouse = new CheckBox();
            timerMoveMouse = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxMapClicks).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TimeMoveMouse).BeginInit();
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
            pictureBoxMapClicks.Location = new Point(12, 73);
            pictureBoxMapClicks.Name = "pictureBoxMapClicks";
            pictureBoxMapClicks.Size = new Size(696, 339);
            pictureBoxMapClicks.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMapClicks.TabIndex = 4;
            pictureBoxMapClicks.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 52);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 5;
            label1.Text = "Map of Clicks";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(101, 44);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(95, 23);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TimeMoveMouse);
            groupBox1.Controls.Add(chkMoveMouse);
            groupBox1.Location = new Point(378, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(330, 36);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // TimeMoveMouse
            // 
            TimeMoveMouse.Location = new Point(246, 11);
            TimeMoveMouse.Name = "TimeMoveMouse";
            TimeMoveMouse.Size = new Size(62, 23);
            TimeMoveMouse.TabIndex = 10;
            TimeMoveMouse.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // chkMoveMouse
            // 
            chkMoveMouse.AutoSize = true;
            chkMoveMouse.Location = new Point(6, 12);
            chkMoveMouse.Name = "chkMoveMouse";
            chkMoveMouse.Size = new Size(223, 19);
            chkMoveMouse.TabIndex = 9;
            chkMoveMouse.Text = "Move mouse randomly for X minutes";
            chkMoveMouse.UseVisualStyleBackColor = true;
            chkMoveMouse.CheckedChanged += chkMoveMouse_CheckedChanged;
            // 
            // timerMoveMouse
            // 
            timerMoveMouse.Interval = 60000;
            timerMoveMouse.Tick += timerMoveMouse_Tick;
            // 
            // FPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 426);
            Controls.Add(groupBox1);
            Controls.Add(dateTimePicker1);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TimeMoveMouse).EndInit();
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
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox1;
        private NumericUpDown TimeMoveMouse;
        private CheckBox chkMoveMouse;
        private System.Windows.Forms.Timer timerMoveMouse;
    }
}