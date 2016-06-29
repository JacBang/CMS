namespace CMS
{
    partial class FrmChangeTable
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
            this.tbOldName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cboRoomType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboArea = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.cboChangeTable = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // tbOldName
            // 
            // 
            // 
            // 
            this.tbOldName.Border.Class = "TextBoxBorder";
            this.tbOldName.Enabled = false;
            this.tbOldName.Location = new System.Drawing.Point(116, 33);
            this.tbOldName.Name = "tbOldName";
            this.tbOldName.Size = new System.Drawing.Size(121, 21);
            this.tbOldName.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(38, 33);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "当前餐桌：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Location = new System.Drawing.Point(38, 77);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "房间类型：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.Location = new System.Drawing.Point(38, 129);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "所在区域：";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.Location = new System.Drawing.Point(38, 181);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "更换餐桌：";
            // 
            // cboRoomType
            // 
            this.cboRoomType.DisplayMember = "Text";
            this.cboRoomType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRoomType.FormattingEnabled = true;
            this.cboRoomType.ItemHeight = 15;
            this.cboRoomType.Location = new System.Drawing.Point(116, 77);
            this.cboRoomType.Name = "cboRoomType";
            this.cboRoomType.Size = new System.Drawing.Size(121, 21);
            this.cboRoomType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboRoomType.TabIndex = 3;
            this.cboRoomType.SelectedIndexChanged += new System.EventHandler(this.cboRoomType_SelectedIndexChanged);
            // 
            // cboArea
            // 
            this.cboArea.DisplayMember = "Text";
            this.cboArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboArea.FormattingEnabled = true;
            this.cboArea.ItemHeight = 15;
            this.cboArea.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
            this.cboArea.Location = new System.Drawing.Point(116, 129);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(124, 21);
            this.cboArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboArea.TabIndex = 4;
            this.cboArea.SelectedIndexChanged += new System.EventHandler(this.cboArea_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "一楼";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "二楼";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "三楼";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "四楼";
            // 
            // cboChangeTable
            // 
            this.cboChangeTable.DisplayMember = "Text";
            this.cboChangeTable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboChangeTable.FormattingEnabled = true;
            this.cboChangeTable.ItemHeight = 15;
            this.cboChangeTable.Location = new System.Drawing.Point(116, 181);
            this.cboChangeTable.Name = "cboChangeTable";
            this.cboChangeTable.Size = new System.Drawing.Size(124, 21);
            this.cboChangeTable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboChangeTable.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnOK.Location = new System.Drawing.Point(48, 233);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(162, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmChangeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 289);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboChangeTable);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.cboArea);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cboRoomType);
            this.Controls.Add(this.tbOldName);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更换餐台";
            this.Load += new System.EventHandler(this.FrmChangeTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX tbOldName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboRoomType;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboArea;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboChangeTable;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
    }
}