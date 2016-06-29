namespace CMS
{
    partial class FrmBill
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbbool = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsum = new System.Windows.Forms.TextBox();
            this.lblTName = new System.Windows.Forms.Label();
            this.lblRName = new System.Windows.Forms.Label();
            this.cbvip = new System.Windows.Forms.CheckBox();
            this.txtvipid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "餐台编号:";
            // 
            // cbbool
            // 
            this.cbbool.AutoSize = true;
            this.cbbool.Location = new System.Drawing.Point(38, 168);
            this.cbbool.Name = "cbbool";
            this.cbbool.Size = new System.Drawing.Size(96, 16);
            this.cbbool.TabIndex = 2;
            this.cbbool.Text = "立即添加消费";
            this.cbbool.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "餐台类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "顾客人数:";
            // 
            // txtsum
            // 
            this.txtsum.Location = new System.Drawing.Point(101, 121);
            this.txtsum.Name = "txtsum";
            this.txtsum.Size = new System.Drawing.Size(124, 21);
            this.txtsum.TabIndex = 5;
            this.txtsum.TextChanged += new System.EventHandler(this.txtsum_TextChanged);
            this.txtsum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsum_KeyPress);
            // 
            // lblTName
            // 
            this.lblTName.AutoSize = true;
            this.lblTName.Location = new System.Drawing.Point(101, 37);
            this.lblTName.Name = "lblTName";
            this.lblTName.Size = new System.Drawing.Size(11, 12);
            this.lblTName.TabIndex = 6;
            this.lblTName.Text = "-";
            // 
            // lblRName
            // 
            this.lblRName.AutoSize = true;
            this.lblRName.Location = new System.Drawing.Point(101, 80);
            this.lblRName.Name = "lblRName";
            this.lblRName.Size = new System.Drawing.Size(11, 12);
            this.lblRName.TabIndex = 8;
            this.lblRName.Text = "-";
            // 
            // cbvip
            // 
            this.cbvip.AutoSize = true;
            this.cbvip.Location = new System.Drawing.Point(140, 168);
            this.cbvip.Name = "cbvip";
            this.cbvip.Size = new System.Drawing.Size(72, 16);
            this.cbvip.TabIndex = 9;
            this.cbvip.Text = "是否会员";
            this.cbvip.UseVisualStyleBackColor = true;
            this.cbvip.CheckedChanged += new System.EventHandler(this.cbvip_CheckedChanged);
            // 
            // txtvipid
            // 
            this.txtvipid.Location = new System.Drawing.Point(103, 210);
            this.txtvipid.Name = "txtvipid";
            this.txtvipid.ReadOnly = true;
            this.txtvipid.Size = new System.Drawing.Size(124, 21);
            this.txtvipid.TabIndex = 11;
            this.txtvipid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtvipid_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "会员编号:";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(37, 257);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 12;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(150, 257);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 13;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 314);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.txtvipid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbvip);
            this.Controls.Add(this.lblRName);
            this.Controls.Add(this.lblTName);
            this.Controls.Add(this.txtsum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbool);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "顾客开单";
            this.Load += new System.EventHandler(this.FrmBill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbbool;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsum;
        private System.Windows.Forms.Label lblTName;
        private System.Windows.Forms.Label lblRName;
        private System.Windows.Forms.CheckBox cbvip;
        private System.Windows.Forms.TextBox txtvipid;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}