namespace CMS
{
    partial class TuiCaichaxunFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TuiCaichaxunFrm));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnShaomiao = new System.Windows.Forms.Button();
            this.dtpStopTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mktStartTime = new System.Windows.Forms.MaskedTextBox();
            this.mktStopTime = new System.Windows.Forms.MaskedTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsZuoTian = new System.Windows.Forms.ToolStripMenuItem();
            this.tsJinTian = new System.Windows.Forms.ToolStripMenuItem();
            this.tsQianTian = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBenZhou = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBenYue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsShangYue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSuoYouTime = new System.Windows.Forms.ToolStripMenuItem();
            this.lvTuicaichaxun = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(402, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 43);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnShaomiao
            // 
            this.btnShaomiao.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShaomiao.BackgroundImage")));
            this.btnShaomiao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShaomiao.Location = new System.Drawing.Point(321, 19);
            this.btnShaomiao.Name = "btnShaomiao";
            this.btnShaomiao.Size = new System.Drawing.Size(75, 43);
            this.btnShaomiao.TabIndex = 24;
            this.btnShaomiao.UseVisualStyleBackColor = true;
            this.btnShaomiao.Click += new System.EventHandler(this.btnShaomiao_Click);
            // 
            // dtpStopTime
            // 
            this.dtpStopTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStopTime.Location = new System.Drawing.Point(71, 46);
            this.dtpStopTime.Name = "dtpStopTime";
            this.dtpStopTime.Size = new System.Drawing.Size(106, 21);
            this.dtpStopTime.TabIndex = 16;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(71, 14);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(106, 21);
            this.dtpStartTime.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "起始时间";
            // 
            // mktStartTime
            // 
            this.mktStartTime.Location = new System.Drawing.Point(183, 14);
            this.mktStartTime.Mask = "90:00";
            this.mktStartTime.Name = "mktStartTime";
            this.mktStartTime.Size = new System.Drawing.Size(41, 21);
            this.mktStartTime.TabIndex = 27;
            this.mktStartTime.ValidatingType = typeof(System.DateTime);
            // 
            // mktStopTime
            // 
            this.mktStopTime.Location = new System.Drawing.Point(183, 46);
            this.mktStopTime.Mask = "90:00";
            this.mktStopTime.Name = "mktStopTime";
            this.mktStopTime.Size = new System.Drawing.Size(41, 21);
            this.mktStopTime.TabIndex = 28;
            this.mktStopTime.ValidatingType = typeof(System.DateTime);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(236, 44);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(37, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "..";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsZuoTian,
            this.tsJinTian,
            this.tsQianTian,
            this.toolStripSeparator1,
            this.tsBenZhou,
            this.tsBenYue,
            this.tsShangYue,
            this.toolStripSeparator2,
            this.tsSuoYouTime});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(29, 20);
            this.toolStripMenuItem1.Text = "..";
            // 
            // tsZuoTian
            // 
            this.tsZuoTian.Name = "tsZuoTian";
            this.tsZuoTian.Size = new System.Drawing.Size(118, 22);
            this.tsZuoTian.Text = "昨天";
            // 
            // tsJinTian
            // 
            this.tsJinTian.Name = "tsJinTian";
            this.tsJinTian.Size = new System.Drawing.Size(118, 22);
            this.tsJinTian.Text = "今天";
            // 
            // tsQianTian
            // 
            this.tsQianTian.Name = "tsQianTian";
            this.tsQianTian.Size = new System.Drawing.Size(118, 22);
            this.tsQianTian.Text = "前天";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(115, 6);
            // 
            // tsBenZhou
            // 
            this.tsBenZhou.Name = "tsBenZhou";
            this.tsBenZhou.Size = new System.Drawing.Size(118, 22);
            this.tsBenZhou.Text = "本周";
            // 
            // tsBenYue
            // 
            this.tsBenYue.Name = "tsBenYue";
            this.tsBenYue.Size = new System.Drawing.Size(118, 22);
            this.tsBenYue.Text = "本月";
            // 
            // tsShangYue
            // 
            this.tsShangYue.Name = "tsShangYue";
            this.tsShangYue.Size = new System.Drawing.Size(118, 22);
            this.tsShangYue.Text = "上月";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // tsSuoYouTime
            // 
            this.tsSuoYouTime.Name = "tsSuoYouTime";
            this.tsSuoYouTime.Size = new System.Drawing.Size(118, 22);
            this.tsSuoYouTime.Text = "所有时间";
            // 
            // lvTuicaichaxun
            // 
            this.lvTuicaichaxun.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvTuicaichaxun.Font = new System.Drawing.Font("隶书", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvTuicaichaxun.ForeColor = System.Drawing.Color.Lime;
            this.lvTuicaichaxun.FullRowSelect = true;
            this.lvTuicaichaxun.GridLines = true;
            this.lvTuicaichaxun.Location = new System.Drawing.Point(14, 91);
            this.lvTuicaichaxun.Name = "lvTuicaichaxun";
            this.lvTuicaichaxun.Size = new System.Drawing.Size(572, 181);
            this.lvTuicaichaxun.TabIndex = 30;
            this.lvTuicaichaxun.UseCompatibleStateImageBehavior = false;
            this.lvTuicaichaxun.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目类别";
            this.columnHeader1.Width = 122;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 139;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "退出数量";
            this.columnHeader3.Width = 122;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "退菜时间";
            this.columnHeader4.Width = 187;
            // 
            // TuiCaichaxunFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 318);
            this.Controls.Add(this.lvTuicaichaxun);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mktStopTime);
            this.Controls.Add(this.mktStartTime);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnShaomiao);
            this.Controls.Add(this.dtpStopTime);
            this.Controls.Add(this.dtpStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TuiCaichaxunFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "退菜查询";
            this.Load += new System.EventHandler(this.TuiCaichaxunFrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnShaomiao;
        private System.Windows.Forms.DateTimePicker dtpStopTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mktStartTime;
        private System.Windows.Forms.MaskedTextBox mktStopTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsZuoTian;
        private System.Windows.Forms.ToolStripMenuItem tsJinTian;
        private System.Windows.Forms.ToolStripMenuItem tsQianTian;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsBenZhou;
        private System.Windows.Forms.ToolStripMenuItem tsBenYue;
        private System.Windows.Forms.ToolStripMenuItem tsShangYue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsSuoYouTime;
        private System.Windows.Forms.ListView lvTuicaichaxun;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}