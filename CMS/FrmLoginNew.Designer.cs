namespace CMS
{
    partial class FrmLoginNew
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pBorder = new System.Windows.Forms.Panel();
            this.picqx = new System.Windows.Forms.PictureBox();
            this.picdl = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtpwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1.SuspendLayout();
            this.pBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picqx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picdl)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::CMS.Properties.Resources.LoginTitle;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 79);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "餐饮管理系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBorder
            // 
            this.pBorder.BackColor = System.Drawing.Color.White;
            this.pBorder.Controls.Add(this.picqx);
            this.pBorder.Controls.Add(this.picdl);
            this.pBorder.Controls.Add(this.panel2);
            this.pBorder.Controls.Add(this.panel1);
            this.pBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBorder.Location = new System.Drawing.Point(0, 0);
            this.pBorder.Name = "pBorder";
            this.pBorder.Size = new System.Drawing.Size(486, 339);
            this.pBorder.TabIndex = 2;
            // 
            // picqx
            // 
            this.picqx.BackgroundImage = global::CMS.Properties.Resources.取消1;
            this.picqx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picqx.Location = new System.Drawing.Point(270, 270);
            this.picqx.Name = "picqx";
            this.picqx.Size = new System.Drawing.Size(142, 33);
            this.picqx.TabIndex = 3;
            this.picqx.TabStop = false;
            this.picqx.Click += new System.EventHandler(this.picqx_Click);
            this.picqx.MouseLeave += new System.EventHandler(this.picqx_MouseLeave);
            this.picqx.MouseHover += new System.EventHandler(this.picqx_MouseHover);
            // 
            // picdl
            // 
            this.picdl.BackgroundImage = global::CMS.Properties.Resources.登录1;
            this.picdl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picdl.Location = new System.Drawing.Point(89, 270);
            this.picdl.Name = "picdl";
            this.picdl.Size = new System.Drawing.Size(142, 33);
            this.picdl.TabIndex = 2;
            this.picdl.TabStop = false;
            this.picdl.Click += new System.EventHandler(this.picdl_Click);
            this.picdl.MouseLeave += new System.EventHandler(this.picdl_MouseLeave);
            this.picdl.MouseHover += new System.EventHandler(this.picdl_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::CMS.Properties.Resources.UserName;
            this.panel2.Controls.Add(this.txtpwd);
            this.panel2.Controls.Add(this.txtname);
            this.panel2.Location = new System.Drawing.Point(67, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 114);
            this.panel2.TabIndex = 1;
            // 
            // txtpwd
            // 
            // 
            // 
            // 
            this.txtpwd.Border.Class = "TextBoxBorder";
            this.txtpwd.Location = new System.Drawing.Point(130, 73);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(189, 21);
            this.txtpwd.TabIndex = 1;
            // 
            // txtname
            // 
            // 
            // 
            // 
            this.txtname.Border.Class = "TextBoxBorder";
            this.txtname.Location = new System.Drawing.Point(130, 17);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(189, 21);
            this.txtname.TabIndex = 0;
            // 
            // FrmLoginNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(486, 339);
            this.Controls.Add(this.pBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLoginNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmLoginNew_Load);
            this.panel1.ResumeLayout(false);
            this.pBorder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picqx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picdl)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pBorder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picqx;
        private System.Windows.Forms.PictureBox picdl;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtpwd;
        private DevComponents.DotNetBar.Controls.TextBoxX txtname;







    }
}