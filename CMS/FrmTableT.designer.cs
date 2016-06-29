namespace CMS
{
    partial class FrmTableT
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
            this.txtTname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRname = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cboRlou = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtTname
            // 
            this.txtTname.Location = new System.Drawing.Point(93, 24);
            this.txtTname.Name = "txtTname";
            this.txtTname.Size = new System.Drawing.Size(124, 21);
            this.txtTname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "餐桌名称:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添  加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "所在区域:";
            // 
            // cboRname
            // 
            this.cboRname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRname.FormattingEnabled = true;
            this.cboRname.Location = new System.Drawing.Point(93, 68);
            this.cboRname.Name = "cboRname";
            this.cboRname.Size = new System.Drawing.Size(124, 20);
            this.cboRname.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "房间类型:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "取  消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboRlou
            // 
            this.cboRlou.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRlou.FormattingEnabled = true;
            this.cboRlou.Items.AddRange(new object[] {
            "一楼",
            "二楼",
            "三楼",
            "四楼"});
            this.cboRlou.Location = new System.Drawing.Point(93, 110);
            this.cboRlou.Name = "cboRlou";
            this.cboRlou.Size = new System.Drawing.Size(124, 20);
            this.cboRlou.TabIndex = 8;
            // 
            // FrmTableT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 195);
            this.Controls.Add(this.cboRlou);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboRname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTname);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTableT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "餐台添加";
            this.Load += new System.EventHandler(this.FrmTableT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboRlou;
    }
}