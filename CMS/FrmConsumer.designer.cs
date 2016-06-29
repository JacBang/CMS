namespace 商品消费查询
{
    partial class FrmConsumer
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
            this.dtg = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dte = new System.Windows.Forms.DateTimePicker();
            this.cbos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txts = new System.Windows.Forms.TextBox();
            this.btns = new System.Windows.Forms.Button();
            this.btnd = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // dtg
            // 
            this.dtg.Location = new System.Drawing.Point(84, 19);
            this.dtg.Name = "dtg";
            this.dtg.Size = new System.Drawing.Size(121, 21);
            this.dtg.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "起始时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "结束时间:";
            // 
            // dte
            // 
            this.dte.Location = new System.Drawing.Point(297, 19);
            this.dte.Name = "dte";
            this.dte.Size = new System.Drawing.Size(121, 21);
            this.dte.TabIndex = 2;
            // 
            // cbos
            // 
            this.cbos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbos.FormattingEnabled = true;
            this.cbos.Items.AddRange(new object[] {
            "全部",
            "餐台号",
            "消费项目"});
            this.cbos.Location = new System.Drawing.Point(84, 56);
            this.cbos.Name = "cbos";
            this.cbos.Size = new System.Drawing.Size(121, 20);
            this.cbos.TabIndex = 4;
            this.cbos.SelectedIndexChanged += new System.EventHandler(this.cbos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "查询条件:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "关 键 字:";
            // 
            // txts
            // 
            this.txts.Location = new System.Drawing.Point(297, 55);
            this.txts.Name = "txts";
            this.txts.Size = new System.Drawing.Size(121, 21);
            this.txts.TabIndex = 7;
            // 
            // btns
            // 
            this.btns.Location = new System.Drawing.Point(476, 19);
            this.btns.Name = "btns";
            this.btns.Size = new System.Drawing.Size(75, 56);
            this.btns.TabIndex = 8;
            this.btns.Text = "搜  索";
            this.btns.UseVisualStyleBackColor = true;
            this.btns.Click += new System.EventHandler(this.btns_Click);
            // 
            // btnd
            // 
            this.btnd.Location = new System.Drawing.Point(580, 19);
            this.btnd.Name = "btnd";
            this.btnd.Size = new System.Drawing.Size(75, 56);
            this.btnd.TabIndex = 9;
            this.btnd.Text = "打  印";
            this.btnd.UseVisualStyleBackColor = true;
            this.btnd.Click += new System.EventHandler(this.btnd_Click);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.Location = new System.Drawing.Point(21, 97);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(634, 328);
            this.lv.TabIndex = 10;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "餐台号";
            this.columnHeader1.Width = 53;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "消费项目";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "单  价";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 109;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "数  量";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 111;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "消费时间";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 237;
            // 
            // FrmConsumer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 437);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.btnd);
            this.Controls.Add(this.btns);
            this.Controls.Add(this.txts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsumer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品消费查询";
            this.Load += new System.EventHandler(this.FrmConsumer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dte;
        private System.Windows.Forms.ComboBox cbos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txts;
        private System.Windows.Forms.Button btns;
        private System.Windows.Forms.Button btnd;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lv;
    }
}

