namespace CMS
{
    partial class FrmLock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnUnlock = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // tbPwd
            // 
            // 
            // 
            // 
            this.tbPwd.Border.Class = "TextBoxBorder";
            this.tbPwd.Location = new System.Drawing.Point(118, 35);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(119, 21);
            this.tbPwd.TabIndex = 0;
            // 
            // btnUnlock
            // 
            this.btnUnlock.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnlock.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnUnlock.Location = new System.Drawing.Point(256, 35);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(75, 23);
            this.btnUnlock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUnlock.TabIndex = 1;
            this.btnUnlock.Text = "解锁";
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(13, 35);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(103, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "当前登录员密码：";
            // 
            // FrmLock
            // 
            this.AcceptButton = this.btnUnlock;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 89);
            this.ControlBox = false;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.tbPwd);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLock";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统锁定中...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmLock_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX tbPwd;
        private DevComponents.DotNetBar.ButtonX btnUnlock;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}