namespace CMS
{
    partial class FrmDbBackUp
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
            this.bt_save = new System.Windows.Forms.Button();
            this.tb_savepath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_ok = new System.Windows.Forms.Button();
            this.bt_esc = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(238, 53);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(64, 23);
            this.bt_save.TabIndex = 0;
            this.bt_save.Text = "浏览";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // tb_savepath
            // 
            this.tb_savepath.Location = new System.Drawing.Point(30, 55);
            this.tb_savepath.Name = "tb_savepath";
            this.tb_savepath.Size = new System.Drawing.Size(192, 21);
            this.tb_savepath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "备份文件保存路径：";
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(75, 92);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 3;
            this.bt_ok.Text = "确定";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // bt_esc
            // 
            this.bt_esc.Location = new System.Drawing.Point(195, 92);
            this.bt_esc.Name = "bt_esc";
            this.bt_esc.Size = new System.Drawing.Size(75, 23);
            this.bt_esc.TabIndex = 4;
            this.bt_esc.Text = "取消";
            this.bt_esc.UseVisualStyleBackColor = true;
            this.bt_esc.Click += new System.EventHandler(this.bt_esc_Click);
            // 
            // fm_database_backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 136);
            this.Controls.Add(this.bt_esc);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_savepath);
            this.Controls.Add(this.bt_save);
            this.Name = "fm_database_backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库备份";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.TextBox tb_savepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button bt_esc;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}