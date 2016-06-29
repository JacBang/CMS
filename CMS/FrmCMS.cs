using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CMS.Model;
using 商品管理.UI;
using 商品消费查询;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using 商品消费查询.Model;

namespace CMS
{
    public partial class FrmCMS : Form
    {
        public FrmCMS()
        {
            InitializeComponent();
            
        }
        
        #region 加载餐桌状态
        /// <summary>
        /// 餐桌状态
        /// </summary>
        private void Zt()
        {
            for (int i = 0; i < this.tab.TabPages.Count; i++)
            {
                TabPage tab = this.tab.TabPages[i];
                RoomType r = tab.Tag as RoomType;
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
                tab.Controls.Add(lv);
                lv.Click += new EventHandler(lv_Click);
            }
        }

        void lv_Click(object sender, EventArgs e)
        {
            //单击显示
            TabPage tab = this.tab.SelectedTab;
            ListView lv = tab.Controls[0] as ListView;
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
        #region 显示指定状态的餐桌
        /// <summary>
        /// 显示指定状态的餐桌 0-可用 1-占用 2-预定 3-停用 4-全部
        /// </summary>
        private void Zdzt(int Zt)
        {
            for (int i = 0; i < this.tab.TabPages.Count; i++)
            {
                TabPage tab = this.tab.TabPages[i];
                RoomType r = tab.Tag as RoomType;
                List<Tables> list = CMS.BLL.TablesBLL.SelectAll(r.RTID);
                ListView lv = this.tab.TabPages[i].Controls[0] as ListView;
                lv.Items.Clear();
                foreach (var item in list)
                {
                    if (int.Parse(item.TState) == Zt)
                    {
                        ListViewItem lvi = new ListViewItem(item.TName);
                        lvi.Tag = item;
                        lvi.ImageIndex = int.Parse(item.TState);
                        lv.Items.Add(lvi);
                    }
                    else if (Zt == 4)
                    {
                        ListViewItem lvi = new ListViewItem(item.TName);
                        lvi.Tag = item;
                        lvi.ImageIndex = int.Parse(item.TState);
                        lv.Items.Add(lvi);
                    }
                }
            }
        }
        #endregion
        #region 修改餐桌状态
        /// <summary>
        /// 修改餐桌状态 0-可用 1-占用 2-预定 3-停用
        /// </summary>
        private void updateZT(String Zt)
        {
            TabPage tab = this.tab.SelectedTab;
            ListView lv = tab.Controls[0] as ListView;
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
            this.lblyd.Text = CMS.BLL.TablesBLL.Count(2).ToString();
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
        #region 开单
        /// <summary>
        /// 开单
        /// </summary>
        private void KD()
        {
            TabPage tab = this.tab.SelectedTab;
            ListView lv = tab.Controls[0] as ListView;

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
        #region 刷新
        /// <summary>
        /// 餐桌界面刷新
        /// </summary>
        private void Sx()
        {
            for (int i = 0; i < this.tab.TabPages.Count; i++)
            {
                TabPage tabs = this.tab.TabPages[i];
                RoomType r = tabs.Tag as RoomType;
                List<Tables> list = CMS.BLL.TablesBLL.SelectAll(r.RTID);
                ListView lvs = tabs.Controls[0] as ListView;
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
        #region 添加消费show
        /// <summary>
        /// 添加消费
        /// </summary>
        private void Tjxf()
        {
            TabPage tab = this.tab.SelectedTab;
            ListView lv = tab.Controls[0] as ListView;
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
        #region 宾客结账
        /// <summary>
        /// 宾客结账
        /// </summary>
        private void Bkjz()
        {
            TabPage tab = this.tab.SelectedTab;
            ListView lv = tab.Controls[0] as ListView;
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
        #region 清空当前选中餐桌信息
        /// <summary>
        /// 清空当前选中餐桌信息
        /// </summary>
        private void qkxs()
        {
            this.toolStripLabel4.Text = "-";
            this.toolStripLabel8.Text = "-";
            this.toolStripLabel11.Text = "-";
            this.lv.Items.Clear();
        }
#endregion
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Admins admin { get; set; }
        private void FrmCMS_Load(object sender, EventArgs e)
        {//加载状态
            this.txtadmin.Text = admin.UserCompellation;
            List<RoomType> list = CMS.BLL.RoomTypeBLL.Select();
            foreach (var item in list)
            {
                TabPage tab = new TabPage();
                tab.Text = item.RTName;
                tab.Tag = item;
                this.tab.TabPages.Add(tab);
            }
            Zt();

            //加载下部与头部
            using (FileStream fs = new FileStream("bt.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<String> lists = bf.Deserialize(fs) as List<String>;
                this.Text = this.lvlname.Text = lists[0];
                
            }
            this.lv.Columns[2].Width = 0;
            this.lv.Columns[4].Width = 0;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {//退出
            DialogResult dr= MessageBox.Show(this,"确定要退出管理系统?","询问",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void tim1_Tick(object sender, EventArgs e)
        {
            //获取当前时间
            this.txtdatetime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            JK();
        }
        
        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {//插入日期
            this.lb1.Items.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));

        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {//打开计算器
            Process.Start("calc.exe");
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {//清除日期
            this.lb1.Items.Clear();
        }

        private void tab_Selecting(object sender, TabControlCancelEventArgs e)
        {//餐桌状态
            Zt();
        }

        private void cms1_Opening(object sender, CancelEventArgs e)
        {//右键菜单打开时
            TabPage tab = this.tab.SelectedTab;
            ListView lv = tab.Controls[0] as ListView;
            if (lv.SelectedItems.Count == 0)
            {
                e.Cancel = true;
            }
            else
            {
                Tables table = lv.SelectedItems[0].Tag as Tables;
                int zt = CMS.BLL.TablesBLL.Zt(table.TID);
                //int zt = int.Parse(lv.SelectedItems[0].Tag.ToString());
                if (zt == 0)
                {
                    this.顾客预订ToolStripMenuItem.Visible=true  ;
                    this.顾客退订ToolStripMenuItem.Visible=false ;
                    this.顾客开单ToolStripMenuItem.Visible=true  ;
                    this.增加消费ToolStripMenuItem.Visible=false   ;
                    this.宾客结账ToolStripMenuItem.Visible=false  ;
                    this.改为可用ToolStripMenuItem.Enabled=false ;
                    this.改为停用ToolStripMenuItem.Enabled=true ;
                    this.改为占用ToolStripMenuItem.Enabled=true ;
                    this.改为预定ToolStripMenuItem.Enabled=true ;
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
                    this.顾客退订ToolStripMenuItem.Visible = true ;
                    this.顾客开单ToolStripMenuItem.Visible = true ;
                    this.增加消费ToolStripMenuItem.Visible = false ;
                    this.宾客结账ToolStripMenuItem.Visible = false ;
                    this.改为可用ToolStripMenuItem.Enabled = true;
                    this.改为停用ToolStripMenuItem.Enabled = true;
                    this.改为占用ToolStripMenuItem.Enabled = true ;
                    this.改为预定ToolStripMenuItem.Enabled = false ;
                    this.餐台状态ToolStripMenuItem1.Text = "餐台状态:预定";
                }
                else if (zt == 3)
                {
                    this.顾客预订ToolStripMenuItem.Visible = false;
                    this.顾客退订ToolStripMenuItem.Visible = false ;
                    this.顾客开单ToolStripMenuItem.Visible = false ;
                    this.增加消费ToolStripMenuItem.Visible = false;
                    this.宾客结账ToolStripMenuItem.Visible = false;
                    this.改为可用ToolStripMenuItem.Enabled = true;
                    this.改为停用ToolStripMenuItem.Enabled = false ;
                    this.改为占用ToolStripMenuItem.Enabled = true;
                    this.改为预定ToolStripMenuItem.Enabled = true ;
                    this.餐台状态ToolStripMenuItem1.Text = "餐台状态:停用";
                }
                e.Cancel = false;
            }
            
        }

        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {//显示小图标
            for (int i = 0; i < this.tab.TabPages.Count; i++)
            {
                if (this.tab.TabPages[i].Controls.Count == 0)
                    continue;
                ListView lv = this.tab.TabPages[i].Controls[0] as ListView;
                lv.View = View.SmallIcon;
            }
            this.tlblck.Text = "当前显示：小图标";
        }

        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {//显示大图标
            for (int i = 0; i < this.tab.TabPages.Count; i++)
            {
                if (this.tab.TabPages[i].Controls.Count == 0)
                    continue;
                ListView lv = this.tab.TabPages[i].Controls[0] as ListView;
                lv.View = View.LargeIcon;
            }
            this.tlblck.Text = "当前显示：大图标";
        }

        
        private void 显示全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {//显示全部
            Zdzt(4);
            this.tlblzt.Text = "当前过滤：全部";
            qkxs();
        }

        private void 显示占用ToolStripMenuItem_Click(object sender, EventArgs e)
        {//显示可用
            Zdzt(0);
            this.tlblzt.Text = "当前过滤：可用";
            qkxs();
        }
        

        private void 显示可用ToolStripMenuItem_Click(object sender, EventArgs e)
        {//显示占用
            Zdzt(1);
            this.tlblzt.Text = "当前过滤：占用";
            qkxs();
        }

        private void 显示预定ToolStripMenuItem_Click(object sender, EventArgs e)
        {//显示预定
            Zdzt(2);
            this.tlblzt.Text = "当前过滤：预定";
            qkxs();
        }

        private void 显示停用ToolStripMenuItem_Click(object sender, EventArgs e)
        {//显示停用
            Zdzt(3);
            this.tlblzt.Text = "当前过滤：停用";
            qkxs();
        }

        private void 改为可用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateZT("0");
            this.餐台状态ToolStripMenuItem1.Text = "餐桌状态:可用";

        }
        

        private void 改为占用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //updateZT("1");
            //this.餐台状态ToolStripMenuItem1.Text = "餐桌状态:占用";
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {//商品管理
            FrmProduct frm = new FrmProduct();
            frm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {//顾客开单
            KD();
        }
        

        private void 顾客开单ToolStripMenuItem_Click(object sender, EventArgs e)
        {//右键开单
            KD();
        }

        private void 商品消费查询SToolStripMenuItem_Click(object sender, EventArgs e)
        {//消费查询
            FrmConsumer frm = new FrmConsumer();
            frm.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {//系统设置
            FrmSystem frm = new FrmSystem();
            frm.ShowDialog();
            this.Text = Comm.bt;
            this.lvlname.Text = Comm.bt;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {//添加消费
            Tjxf();
        }
        
        private void 增加消费ToolStripMenuItem_Click(object sender, EventArgs e)
        {//右键添加消费
            Tjxf();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {//宾客结账
            Bkjz();
        }

        private void 宾客结账ToolStripMenuItem_Click(object sender, EventArgs e)
        {//右键结账
            Bkjz();
        }

        private void 顾客退订ToolStripMenuItem_Click(object sender, EventArgs e)
        {//顾客退订
            updateZT("0");
            Sx();
            JK();
        }

        private void 顾客预订ToolStripMenuItem_Click(object sender, EventArgs e)
        {//顾客预订
            updateZT("2");
            Sx();
            JK();
        }

        private void tab_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {//会员管理
            FrmVIp frm = new FrmVIp();
            frm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {//房间餐台设置
            FrmRoomTable frm = new FrmRoomTable();
            frm.ShowDialog();
        }

        private void 账单查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {//账单查询
            FrmCB frm = new FrmCB();
            frm.ShowDialog();
        }

        private void FrmCMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }

    }
}
