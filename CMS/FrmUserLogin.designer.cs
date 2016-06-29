namespace CMS
{
    partial class FrmUserLogion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserLogion));
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.picqx = new System.Windows.Forms.PictureBox();
            this.picdl = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbldl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picqx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(248, 120);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(151, 21);
            this.txtname.TabIndex = 0;
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(248, 166);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(151, 21);
            this.txtpwd.TabIndex = 1;
            this.txtpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpwd_KeyDown);
            this.txtpwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpwd_KeyPress);
            // 
            // picqx
            // 
            this.picqx.BackColor = System.Drawing.Color.Transparent;
            this.picqx.BackgroundImage = global::CMS.Properties.Resources.取消;
            this.picqx.Location = new System.Drawing.Point(327, 209);
            this.picqx.Name = "picqx";
            this.picqx.Size = new System.Drawing.Size(49, 20);
            this.picqx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picqx.TabIndex = 3;
            this.picqx.TabStop = false;
            this.picqx.Click += new System.EventHandler(this.picqx_Click);
            this.picqx.MouseEnter += new System.EventHandler(this.picqx_MouseEnter);
            this.picqx.MouseLeave += new System.EventHandler(this.picqx_MouseLeave);
            // 
            // picdl
            // 
            this.picdl.BackColor = System.Drawing.Color.Transparent;
            this.picdl.BackgroundImage = global::CMS.Properties.Resources.确定;
            this.picdl.Location = new System.Drawing.Point(261, 209);
            this.picdl.Name = "picdl";
            this.picdl.Size = new System.Drawing.Size(49, 20);
            this.picdl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picdl.TabIndex = 2;
            this.picdl.TabStop = false;
            this.picdl.Click += new System.EventHandler(this.picdl_Click);
            this.picdl.MouseEnter += new System.EventHandler(this.picdl_MouseEnter);
            this.picdl.MouseLeave += new System.EventHandler(this.picdl_MouseLeave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(361, 244);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "修改密码";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbldl
            // 
            this.lbldl.AutoSize = true;
            this.lbldl.BackColor = System.Drawing.Color.Transparent;
            this.lbldl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbldl.Location = new System.Drawing.Point(97, 47);
            this.lbldl.Name = "lbldl";
            this.lbldl.Size = new System.Drawing.Size(16, 24);
            this.lbldl.TabIndex = 5;
            this.lbldl.Text = "-";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::CMS.Properties.Resources.chushimao1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(43, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 109);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(195, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "账号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(195, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "密码：";
            // 
            // FrmUserLogion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CMS.Properties.Resources.DengLu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 285);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbldl);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.picdl);
            this.Controls.Add(this.picqx);
            this.Controls.Add(this.txtpwd);
            this.Controls.Add(this.txtname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUserLogion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.FrmUserLogin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmUserLogin_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.picqx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.PictureBox picqx;
        private System.Windows.Forms.PictureBox picdl;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lbldl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}