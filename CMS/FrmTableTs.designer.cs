namespace CMS
{
    partial class FrmTableTs
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
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTtype = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comblou = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(163, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "取  消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "房 间 类 型:";
            // 
            // cboRname
            // 
            this.cboRname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRname.FormattingEnabled = true;
            this.cboRname.Location = new System.Drawing.Point(114, 109);
            this.cboRname.Name = "cboRname";
            this.cboRname.Size = new System.Drawing.Size(124, 20);
            this.cboRname.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "餐台编号范围:";
            // 
            // txtTtype
            // 
            this.txtTtype.Location = new System.Drawing.Point(114, 67);
            this.txtTtype.Name = "txtTtype";
            this.txtTtype.Size = new System.Drawing.Size(44, 21);
            this.txtTtype.TabIndex = 11;
            this.txtTtype.TextChanged += new System.EventHandler(this.txtTtype_TextChanged);
            this.txtTtype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTtype_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "添  加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "餐台编号前缀:";
            // 
            // txtTname
            // 
            this.txtTname.Location = new System.Drawing.Point(114, 22);
            this.txtTname.Name = "txtTname";
            this.txtTname.Size = new System.Drawing.Size(124, 21);
            this.txtTname.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "至";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(190, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 21);
            this.textBox1.TabIndex = 17;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "所 在 区 域:";
            // 
            // comblou
            // 
            this.comblou.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comblou.FormattingEnabled = true;
            this.comblou.Items.AddRange(new object[] {
            "一楼",
            "二楼",
            "三楼",
            "四楼"});
            this.comblou.Location = new System.Drawing.Point(114, 149);
            this.comblou.Name = "comblou";
            this.comblou.Size = new System.Drawing.Size(124, 20);
            this.comblou.TabIndex = 18;
            // 
            // FrmTableTs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 237);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comblou);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboRname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTtype);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTname);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTableTs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "餐台批量添加";
            this.Load += new System.EventHandler(this.FrmTableTs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTtype;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comblou;
    }
}