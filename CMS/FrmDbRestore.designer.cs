namespace CMS
{
    partial class FrmDbRestore
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
            this.bt_esc = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_openpath = new System.Windows.Forms.TextBox();
            this.bt_open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // bt_esc
            // 
            this.bt_esc.Location = new System.Drawing.Point(201, 88);
            this.bt_esc.Name = "bt_esc";
            this.bt_esc.Size = new System.Drawing.Size(75, 23);
            this.bt_esc.TabIndex = 9;
            this.bt_esc.Text = "取消";
            this.bt_esc.UseVisualStyleBackColor = true;
            this.bt_esc.Click += new System.EventHandler(this.bt_esc_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(81, 88);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 8;
            this.bt_ok.Text = "确定";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "备份文件读取路径：";
            // 
            // tb_openpath
            // 
            this.tb_openpath.Location = new System.Drawing.Point(36, 51);
            this.tb_openpath.Name = "tb_openpath";
            this.tb_openpath.Size = new System.Drawing.Size(192, 21);
            this.tb_openpath.TabIndex = 6;
            // 
            // bt_open
            // 
            this.bt_open.Location = new System.Drawing.Point(244, 49);
            this.bt_open.Name = "bt_open";
            this.bt_open.Size = new System.Drawing.Size(64, 23);
            this.bt_open.TabIndex = 5;
            this.bt_open.Text = "浏览";
            this.bt_open.UseVisualStyleBackColor = true;
            this.bt_open.Click += new System.EventHandler(this.bt_open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fm_database_restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 136);
            this.Controls.Add(this.bt_esc);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_openpath);
            this.Controls.Add(this.bt_open);
            this.Name = "fm_database_restore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库恢复";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_esc;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_openpath;
        private System.Windows.Forms.Button bt_open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}