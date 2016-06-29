using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using 商品消费查询.Model;
using DevComponents.DotNetBar;
using 商品管理.UI;
using CMS;
using System.Diagnostics;
using 商品消费查询;

namespace CMS
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnItemKaiDan_Click(object sender, EventArgs e)
        {
            //顾客开单
            KD();
        }

        #region 开单
        /// <summary>
        /// 开单
        /// </summary>
        private void KD()
        {
            TabItem tabItem = this.tabMain.SelectedTab;
            ListView lv = tabItem.AttachedControl.Controls[0] as ListView;
            //TabPage tab = this.tab.SelectedTab;
            //ListView lv = tab.Controls[0] as ListView;

            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "请选择一个餐台", "提示");
            }
            else
            {
                Tables table = lv.SelectedItems[0].Tag as Tables;
                if (table.TState == "1")
                    MessageBox.Show(this, "该餐台已被占用!", "提示");
                else if (table.TState == "3")
                    MessageBox.Show(this, "该餐台已停用!", "提示");
                else
                {
                    FrmBill frm = new FrmBill();
                    frm.table = table;
                    frm.admin = admin;
                    frm.ShowDialog();

                    Sx();

                    JK();
                }
            }
        }
        #endregion

        #region 餐厅状态监控
        /// <summary>
        /// 餐厅状态监控
        /// </summary>
        private void JK()
        {
            //查询餐台总数
            this.lblsum.Text = CMS.BLL.TablesBLL.Count().ToString();
            //查询当前占用
            this.lblzy.Text = CMS.BLL.TablesBLL.Count(1).ToString();
            //查询当前可供
            this.lblky.Text = CMS.BLL.TablesBLL.Count(0).ToString();
            //查询当前预定
            this.lblyd1.Text = CMS.BLL.TablesBLL.Count(2).ToString();
            //查询当前停用
            this.lblty.Text = CMS.BLL.TablesBLL.Count(3).ToString();
            //查询当前上座率
            String Sz = CMS.BLL.TablesBLL.Szl().ToString();
            if (Sz.Length >= 3)
                this.lblsz.Text = int.Parse(Sz.ToString().Substring(2, 2)) + "%";
            if (Sz.ToString().Length < 3)
                this.lblsz.Text = int.Parse(Sz.ToString().Substring(0, 1)) + "%";
        }
        #endregion

        #region 刷新
        /// <summary>
        /// 餐桌界面刷新
        /// </summary>
        private void Sx()
        {
            //for (int i = 0; i < this.tab.TabPages.Count; i++)
            for (int i = 0; i < this.tabMain.Tabs.Count; i++)
            {
                //TabPage tabs = this.tab.TabPages[i];
                TabItem tabs = this.tabMain.Tabs[i];

                RoomType r = tabs.Tag as RoomType;
                List<Tables> list = CMS.BLL.TablesBLL.SelectAll(r.RTID);
                //ListView lvs = tabs.Controls[0] as ListView;
                ListView lvs = tabs.AttachedControl.Controls[0] as ListView;

                lvs.Items.Clear();
                foreach (var item in list)
                {
                    ListViewItem lvi = new ListViewItem(item.TName);
                    if (item.TState == "0")
                        lvi.ImageIndex = 0;
                    else if (item.TState == "1")
                        lvi.ImageIndex = 1;
                    else if (item.TState == "2")
                        lvi.ImageIndex = 2;
                    else if (item.TState == "3")
                        lvi.ImageIndex = 3;
                    lvi.Tag = item;
                    lvs.Items.Add(lvi);
                }
            }
        }
        #endregion

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Admins admin { get; set; }
        private void FormMain_Load(object sender, EventArgs e)
        {            
            //加载状态
            this.txtadmin.Text = admin.UserCompellation;
            FrmMainRefresh();
            #region 老代码
            //List<RoomType> list = CMS.BLL.RoomTypeBLL.Select();
            //foreach (var item in list)
            //{
            //    TabPage tab = new TabPage();
            //    //TabItem tabItem = new TabItem();
            //    //TabControlPanel tcp = new TabControlPanel();
            //    //tabItem.AttachedControl = tcp;
            //    //tcp.TabItem = tabItem;
            //    //tcp.Dock = DockStyle.Fill;
            //    //tabMain.Controls.Add(tcp);
            //    //tabMain.SelectedTab = tabItem;  

            //    tab.Text = item.RTName;
            //    tab.Tag = item;
            //    this.tab.TabPages.Add(tab);
            //}
            //Zt();

            //JK();
            #endregion  
            //加载下部与头部
            using (FileStream fs = new FileStream("bt.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<String> lists = bf.Deserialize(fs) as List<String>;
                this.lvlname.Text = lists[0];
                //系统标题名称
                this.ribbonControl1.TitleText = "<b><font size = \"12\">" + lists[0] + "</font></b>";
            }
            this.lv.Columns[2].Width = 0;
            this.lv.Columns[4].Width = 0;

            //当前时间
            this.lbItemNowTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") + "  ";
        }

        #region 加载餐桌状态
        /// <summary>
        /// 餐桌状态
        /// </summary>
        private void Zt()
        {
            for (int i = 0; i < this.tabMain.Tabs.Count; i++)
            {
                TabItem tabItem = this.tabMain.Tabs[i];
                RoomType r = tabItem.Tag as RoomType;
                List<Tables> list = CMS.BLL.TablesBLL.SelectAll(r.RTID);
                ListView lv = new ListView();
                lv.LargeImageList = this.imglist;
                lv.SmallImageList = this.imglist2;
                lv.View = View.LargeIcon;
                lv.ContextMenuStrip = this.cms1;
                lv.Dock = DockStyle.Fill;
                foreach (var item in list)
                {
                    ListViewItem lvi = new ListViewItem(item.TName);
                    if (item.TState == "0")
                        lvi.ImageIndex = 0;
                    else if (item.TState == "1")
                        lvi.ImageIndex = 1;
                    else if (item.TState == "2")
                        lvi.ImageIndex = 2;
                    else if (item.TState == "3")
                        lvi.ImageIndex = 3;
                    lvi.Tag = item;
                    lv.Items.Add(lvi);
                }

                //tab.Controls.Add(lv);
                tabItem.AttachedControl.Controls.Add(lv);
                lv.Click += new EventHandler(lv_Click);
            }            
        }

        void lv_Click(object sender, EventArgs e)
        {
            //单击显示
            //TabPage tab = this.tab.SelectedTab;
            //ListView lv = tab.Controls[0] as ListView;

            TabItem tabItem = this.tabMain.SelectedTab;
            ListView lv = tabItem.AttachedControl.Controls[0] as ListView;

            if (lv.SelectedItems.Count == 0) return;
            Tables table = lv.SelectedItems[0].Tag as Tables;
            if (table.TState == "1")
            {
                //显示当前选中
                this.toolStripLabel4.Text = table.TName;

                this.lv.Items.Clear();
                String cbid = CMS.BLL.ConsumerBillBLL.SelectCBID(table.TID);
                if (cbid == "") return;
                List<ConsumerDetails> listc = CMS.BLL.CDBLL.SelectX(cbid);
                if (listc != null)
                {
                    foreach (var item in listc)
                    {//循环添加消费信息
                        ListViewItem lvi = new ListViewItem(item.ProName);
                        lvi.SubItems.Add(item.CDAmount.ToString());
                        lvi.SubItems.Add(item.CDPrice.ToString());
                        lvi.SubItems.Add(item.CDMoney.ToString());
                        lvi.SubItems.Add(item.CDDate);
                        lvi.Tag = item;
                        this.lv.Items.Add(lvi);
                    }

                }
                //显示消费金额与数量
                if (this.lv.Items.Count > 0)
                {
                    int sum = 0;
                    int sum2 = 0;
                    for (int i = 0; i < this.lv.Items.Count; i++)
                    {
                        sum = sum + int.Parse(this.lv.Items[i].SubItems[1].Text);
                        sum2 = sum2 + int.Parse(this.lv.Items[i].SubItems[3].Text);
                    }
                    this.toolStripLabel8.Text = sum.ToString();
                    this.toolStripLabel11.Text = sum2.ToString();
                }
            }
            else
            {
                this.lv.Items.Clear();
                this.toolStripLabel4.Text = table.TName;
                this.toolStripLabel8.Text = "-";
                this.toolStripLabel11.Text = "-";
            }
        }
        #endregion

        private void btnItemZengJia_Click(object sender, EventArgs e)
        {
            //添加消费
            Tjxf();
        }

        #region 添加消费show
        /// <summary>
        /// 添加消费
        /// </summary>
        private void Tjxf()
        {
            //TabPage tab = this.tab.SelectedTab;
            //ListView lv = tab.Controls[0] as ListView;
            TabItem tabItem = this.tabMain.SelectedTab;
            ListView lv = tabItem.AttachedControl.Controls[0] as ListView;

            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "请选择一个餐台", "提示");
                return;
            }
            Tables table = lv.SelectedItems[0].Tag as Tables;
            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "请选择一个餐台", "提示");
                return;
            }
            else
            {
                if (table.TState == "0")
                    MessageBox.Show(this, "该餐台尚未使用!", "提示");
                else if (table.TState == "3")
                    MessageBox.Show(this, "该餐台已停用!", "提示");
                else if (table.TState == "2")
                    MessageBox.Show(this, "该餐台已预定,尚未使用!", "提示");
                else
                {
                    FrmAddConsumer frm = new FrmAddConsumer();
                    frm.Zd = CMS.BLL.ConsumerBillBLL.SelectCBID(table.TID);
                    frm.Ct = table.TName;
                    frm.ShowDialog();
                }

            }
        }
        #endregion

        private void btnItemJZ_Click(object sender, EventArgs e)
        {
            //宾客结账
            Bkjz();
        }

        #region 宾客结账
        /// <summary>
        /// 宾客结账
        /// </summary>
        private void Bkjz()
        {
            //TabPage tab = this.tab.SelectedTab;
            //ListView lv = tab.Controls[0] as ListView;
            TabItem tabItem = this.tabMain.SelectedTab;
            ListView lv = tabItem.AttachedControl.Controls[0] as ListView;
            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "请选择一个餐台", "提示");
                return;
            }
            Tables table = lv.SelectedItems[0].Tag as Tables;
            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "请选择一个餐台", "提示");
                return;
            }
            else
            {
                if (table.TState == "0")
                    MessageBox.Show(this, "该餐台尚未使用!", "提示");
                else if (table.TState == "3")
                    MessageBox.Show(this, "该餐台已停用!", "提示");
                else if (table.TState == "2")
                    MessageBox.Show(this, "该餐台已预定,尚未使用!", "提示");
                else
                {
                    FrmJz frm = new FrmJz();
                    frm.Zd = CMS.BLL.ConsumerBillBLL.SelectCBID(table.TID);
                    frm.Ct = table.TName;
                    frm.Ctid = table.TID;
                    frm.ShowDialog();
                    this.lv.Items.Clear();
                    Sx();
                    JK();
                }

            }
        }
        #endregion

        private void btnItemXTSZ_Click(object sender, EventArgs e)
        {
            //系统设置
            FrmSystem frm = new FrmSystem();
            frm.ShowDialog();
            //this.Text = Comm.bt;
            this.ribbonControl1.TitleText = "<b><font size = \"12\">" + Comm.bt + "</font></b>";
            this.lvlname.Text = Comm.bt;
        }

        private void btnItemCT_Click(object sender, EventArgs e)
        {
            //房间餐台设置
            FrmRoomTable frm = new FrmRoomTable();
            frm.ShowDialog();
        }

        private void btnItemHY_Click(object sender, EventArgs e)
        {
            //会员管理
            FrmVIp frm = new FrmVIp();
            frm.ShowDialog();
        }

        private void btnItemSPGL_Click(object sender, EventArgs e)
        {
            //商品管理
            FrmProduct frm = new FrmProduct();
            frm.ShowDialog();
        }

        private void 顾客预订ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //顾客预订
            updateZT("2");
            Sx();
            JK();
        }
        #region 修改餐桌状态
        /// <summary>
        /// 修改餐桌状态 0-可用 1-占用 2-预定 3-停用
        /// </summary>
        private void updateZT(String Zt)
        {
            //TabPage tab = this.tab.SelectedTab;
            //ListView lv = tab.Controls[0] as ListView;
            TabItem tabItem = this.tabMain.SelectedTab;
            ListView lv = tabItem.AttachedControl.Controls[0] as ListView;

            Tables table = lv.SelectedItems[0].Tag as Tables;
            if (CMS.BLL.TablesBLL.Zt(table.TID) != int.Parse(Zt))
            {
                Boolean b = CMS.BLL.TablesBLL.UPdate(table.TID, Zt);
                if (b == true)
                {

                    this.改为可用ToolStripMenuItem.Enabled = false;
                    lv.SelectedItems[0].ImageIndex = int.Parse(Zt);
                    table.TState = Zt;
                }
            }
            JK();
        }
        #endregion

        private void cms1_Opening(object sender, CancelEventArgs e)
        {//右键菜单打开时
            //TabPage tab = this.tab.SelectedTab;
            //ListView lv = tab.Controls[0] as ListView;
            TabItem tabItem = this.tabMain.SelectedTab;
            ListView lv = tabItem.AttachedControl.Controls[0] as ListView;
            if (lv.SelectedItems.Count == 0)
            {
                //e.Cancel = true;
                this.顾客预订ToolStripMenuItem.Visible = false;
                this.顾客退订ToolStripMenuItem.Visible = false;
                this.顾客开单ToolStripMenuItem.Visible = false;
                this.增加消费ToolStripMenuItem.Visible = false;
                this.宾客结账ToolStripMenuItem.Visible = false;
                this.餐台状态ToolStripMenuItem.Visible = false;
            }
            else
            {
                this.餐台状态ToolStripMenuItem.Visible = true;

                Tables table = lv.SelectedItems[0].Tag as Tables;
                int zt = CMS.BLL.TablesBLL.Zt(table.TID);
                //int zt = int.Parse(lv.SelectedItems[0].Tag.ToString());
                if (zt == 0)
                {
                    this.顾客预订ToolStripMenuItem.Visible = true;
                    this.顾客退订ToolStripMenuItem.Visible = false;
                    this.顾客开单ToolStripMenuItem.Visible = true;
                    this.增加消费ToolStripMenuItem.Visible = false;
                    this.宾客结账ToolStripMenuItem.Visible = false;
                    this.改为可用ToolStripMenuItem.Enabled = false;
                    this.改为停用ToolStripMenuItem.Enabled = true;
                    this.改为占用ToolStripMenuItem.Enabled = true;
                    this.改为预定ToolStripMenuItem.Enabled = true;
                    this.餐台状态ToolStripMenuItem1.Text = "餐台状态:可用";
                }
                else if (zt == 1)
                {
                    this.顾客预订ToolStripMenuItem.Visible = false;
                    this.顾客退订ToolStripMenuItem.Visible = false;
                    this.顾客开单ToolStripMenuItem.Visible = false;
                    this.增加消费ToolStripMenuItem.Visible = true;
                    this.宾客结账ToolStripMenuItem.Visible = true;
                    this.改为可用ToolStripMenuItem.Enabled = true;
                    this.改为停用ToolStripMenuItem.Enabled = true;
                    this.改为占用ToolStripMenuItem.Enabled = false;
                    this.改为预定ToolStripMenuItem.Enabled = true;
                    this.餐台状态ToolStripMenuItem1.Text = "餐台状态:占用";
                }
                else if (zt == 2)
                {
                    this.顾客预订ToolStripMenuItem.Visible = false;
                    this.顾客退订ToolStripMenuItem.Visible = true;
                    this.顾客开单ToolStripMenuItem.Visible = true;
                    this.增加消费ToolStripMenuItem.Visible = false;
                    this.宾客结账ToolStripMenuItem.Visible = false;
                    this.改为可用ToolStripMenuItem.Enabled = true;
                    this.改为停用ToolStripMenuItem.Enabled = true;
                    this.改为占用ToolStripMenuItem.Enabled = true;
                    this.改为预定ToolStripMenuItem.Enabled = false;
                    this.餐台状态ToolStripMenuItem1.Text = "餐台状态:预定";
                }
                else if (zt == 3)
                {
                    this.顾客预订ToolStripMenuItem.Visible = false;
                    this.顾客退订ToolStripMenuItem.Visible = false;
                    this.顾客开单ToolStripMenuItem.Visible = false;
                    this.增加消费ToolStripMenuItem.Visible = false;
                    this.宾客结账ToolStripMenuItem.Visible = false;
                    this.改为可用ToolStripMenuItem.Enabled = true;
                    this.改为停用ToolStripMenuItem.Enabled = false;
                    this.改为占用ToolStripMenuItem.Enabled = true;
                    this.改为预定ToolStripMenuItem.Enabled = true;
                    this.餐台状态ToolStripMenuItem1.Text = "餐台状态:停用";
                }
                e.Cancel = false;
            }

        }


        private void 顾客退订ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //顾客退订
            updateZT("0");
            Sx();
            JK();
        }

        private void 顾客开单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //右键开单
            KD();
        }

        private void 增加消费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //右键添加消费
            Tjxf();
        }

        private void 宾客结账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //右键结账
            Bkjz();
        }

        private void 改为可用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateZT("0");
            this.餐台状态ToolStripMenuItem1.Text = "餐桌状态:可用";
        }

        private void 改为占用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KD();
        }

        private void 改为预定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateZT("2");
            this.餐台状态ToolStripMenuItem1.Text = "餐桌状态:预定";
        }

        private void 改为停用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateZT("3");
            this.餐台状态ToolStripMenuItem1.Text = "餐桌状态:停用";
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //捕捉窗体Close事件,关闭窗口时提示
            if (MessageBox.Show("请您确认是否退出(Y/N)", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;//阻止退出系统
            }
        }

        private void buttonItem41_Click(object sender, EventArgs e)
        {

        }

        private void btnItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        { 
            StringFormat format = new StringFormat();
            format.FormatFlags |= StringFormatFlags.DirectionVertical;
            format.Alignment = StringAlignment.Near; 
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(tabMain.Tabs[e.Index].Text, e.Font, new SolidBrush(Color.Black), e.Bounds.Left + 20, e.Bounds.Top + 8, format);
        }

        private void FrmMainRefresh()
        {            
            this.tabMain.Tabs.Clear();
            
            List<RoomType> list = CMS.BLL.RoomTypeBLL.Select();
            foreach (var item in list)
            {
                #region 新的TabControl控件
                TabItem tabItem = tabMain.CreateTab(item.RTName);
                tabItem.Tag = item;
                TabControlPanel tcp = new TabControlPanel();
                tabMain.Controls.Add(tcp);
                tabItem.AttachedControl = tcp;
                tcp.TabItem = tabItem;
                tcp.Dock = DockStyle.Fill;                
                //tcp.Style.BackColor1.Color = Color.FromArgb(142, 179, 231);
                //tcp.Style.BackColor2.Color = Color.FromArgb(223, 237, 254);
                //tcp.Style.GradientAngle = 90;
                //tcp.Style.Border = eBorderType.SingleLine;
                //tcp.Style.BorderColor.Color = Color.FromArgb(59, 97, 156);
                #endregion
            }
            
            //this.tabMain.Tabs.RemoveAt(0); 

            Zt();

            JK();

            this.tabMain.SelectedTabIndex = 1;
            this.tabMain.SelectedTabIndex = 0;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMainRefresh();
        }

        private void btnItemXGMM_Click(object sender, EventArgs e)
        {
            FrmPwdX frm = new FrmPwdX();
            frm.admin = this.admin;
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //当前时间
            this.lbItemNowTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss") + "  ";
        }

        private void btnItemHT_Click(object sender, EventArgs e)
        {
            HT();
        }

        /// <summary>
        /// 更换餐台
        /// </summary>
        private void HT()
        {
            //TabPage tab = this.tab.SelectedTab;
            //ListView lv = tab.Controls[0] as ListView;
            TabItem tabItem = this.tabMain.SelectedTab;
            ListView lv = tabItem.AttachedControl.Controls[0] as ListView;

            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "请选择一个餐台", "提示");
            }
            else
            {
                Tables table = lv.SelectedItems[0].Tag as Tables;
                if (table.TState == "0")
                    MessageBox.Show(this, "该餐台可用，不需更换!", "提示");
                else if (table.TState == "3")
                    MessageBox.Show(this, "该餐台预定，不需更换!", "提示");
                else if (table.TState == "3")
                    MessageBox.Show(this, "该餐台已停用!", "提示");
                else
                {
                    FrmChangeTable FrmCT = new FrmChangeTable();
                    FrmCT.table = table;
                    FrmCT.admin = admin;
                    FrmCT.ShowDialog();

                    //刷新
                    Sx();
                    JK();
                }
            }

        }

        private void btnItemJSQ_Click(object sender, EventArgs e)
        {
            //打开计算器
            Process.Start("calc.exe");
        }

        private void btnItemJSB_Click(object sender, EventArgs e)
        {
            //打开记事本
            System.Diagnostics.Process.Start("notepad.exe");
        }

        private void btnItemXTJS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否锁定系统(Y/N)", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                FrmBColor frmBC = new FrmBColor();
                frmBC.Show();
                FrmLock frmLock = new FrmLock();
                frmLock.admin = this.admin;
                frmLock.ShowDialog();
                frmBC.Close();
            }
            else
            {
                
            }            
        }

        private void btnItemZDCX_Click(object sender, EventArgs e)
        {
            //账单查询
            FrmCB frm = new FrmCB();
            frm.ShowDialog();
        }

        private void btnItemXFCX_Click(object sender, EventArgs e)
        {
            //消费查询
            FrmConsumer frm = new FrmConsumer();
            frm.ShowDialog();
        }

        private void btnItemSJBF_Click(object sender, EventArgs e)
        {
            FrmDbBackUp fm_database_backups = new FrmDbBackUp();
            fm_database_backups.ShowDialog();
        }

        private void btnItemRL_Click(object sender, EventArgs e)
        {
            FrmCalendar frmCalender = new FrmCalendar();
            frmCalender.ShowDialog();
        }

        private void btnItemSJHF_Click(object sender, EventArgs e)
        {
            FrmDbRestore frmDbRestore = new FrmDbRestore();
            frmDbRestore.ShowDialog();
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            预订管理 ydgl = new 预订管理();
            ydgl.ShowDialog();
        }

        private void btnItemWMDB_Click(object sender, EventArgs e)
        {
            new 快餐外买().Show();
        }

        private void btnItemKSKD_Click(object sender, EventArgs e)
        {
            new 餐饮快速开单().Show();
        }

        private void btnItemTCCX_Click(object sender, EventArgs e)
        {
            TuiCaichaxunFrm tcxx = new TuiCaichaxunFrm();
            tcxx.ShowDialog();
        }

        private void btnItemGY_Click(object sender, EventArgs e)
        {
            ProDuctAboutBox proBox = new ProDuctAboutBox();
            proBox.ShowDialog();
        }

        private void btnItemCD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请您确认是否要重新登录(Y/N)", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //this.Close();
                this.Dispose();
                FrmLoginNew frmLogin = new FrmLoginNew();
                frmLogin.ShowDialog();
            }            
        }

        private void btnItemBZ_Click(object sender, EventArgs e)
        {
            string tmpPath = System.Windows.Forms.Application.StartupPath + "\\使用说明书.doc";
            if (File.Exists(tmpPath))
            {
                System.Diagnostics.Process.Start(tmpPath);
            }
            else
            {
                MessageBox.Show("您的说明书没有在安装目录下?请拷贝《使用说明书.doc》到安装目录下！");
            }
        }
    }
}
