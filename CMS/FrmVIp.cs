using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.Model;
using CMS.BLL;
using 商品消费查询.Model;

namespace CMS
{
    public partial class FrmVIp : DevComponents.DotNetBar.Office2007Form
    {
        public FrmVIp()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FrmVipsT frm = new FrmVipsT();
            frm.ShowDialog();
            查询所有会员();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //判断是否选择数据
            if (this.lv3.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择数据");
                return;
            }
            //将白道的数据保存到相应的属性中
            publlei.VipID = Convert.ToInt32(this.lv3.SelectedItems[0].SubItems[0].Text);
            publlei.VipName = this.lv3.SelectedItems[0].SubItems[1].Text;
            publlei.VipSex = this.lv3.SelectedItems[0].SubItems[2].Text;
            publlei.Grname = this.lv3.SelectedItems[0].SubItems[3].Text;
            publlei.VipTel = this.lv3.SelectedItems[0].SubItems[5].Text;
            publlei.VipStartDate = this.lv3.SelectedItems[0].SubItems[6].Text;
            publlei.VipEndDate = this.lv3.SelectedItems[0].SubItems[7].Text;

            FrmVipsX frm = new FrmVipsX();
            frm.ShowDialog();
            查询所有会员();
        }

        private void FrmVIp_Load(object sender, EventArgs e)
        {
            //让时间赋值为一天前
            DateTime yestoday = DateTime.Now.AddDays(-1);
            this.dtg.Text = yestoday.ToString("yyyy-MM-dd");
            查询会员消费();
            查询所有会员();
        }

        private void 查询会员消费()
        {
            this.lv1.Items.Clear();
            List<ConsumerBill> list = VipsConsumerBillBLL.select();
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.VID.ToString());
                lvi.SubItems.Add(item.VipName.ToString());
                lvi.SubItems.Add(item.CBID.ToString());
                lvi.SubItems.Add(item.money.ToString());
                lvi.SubItems.Add(item.CBSale.ToString());
                this.lv1.Items.Add(lvi);
            }
        }

        private void 查询所有会员()
        {
            this.lv3.Items.Clear();
            List<Vips> list = VipsBLL.select();
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.VipID.ToString());
                lvi.SubItems.Add(item.VipName.ToString());
                lvi.SubItems.Add(item.VipSex.ToString());
                lvi.SubItems.Add(item.VGName.ToString());
                lvi.SubItems.Add(item.VGDiscount.ToString());
                lvi.SubItems.Add(item.VipTel.ToString());
                lvi.SubItems.Add(item.VipStartDate.ToString());
                lvi.SubItems.Add(item.VipEndDate.ToString());
                this.lv3.Items.Add(lvi);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //判断是否选择数据
            if (this.lv3.SelectedItems.Count <= 0)
            {
                MessageBox.Show("未选中任何数据!请选择!");
                return;
            }
            DialogResult dr = MessageBox.Show(this, "确定要删除该条数据吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;
            int id = Convert.ToInt32(this.lv3.SelectedItems[0].SubItems[0].Text);
            bool bl = VipsBLL.delete(id);
            if (true == bl)
            {
                MessageBox.Show(this, "删除成功!", "提示");
                查询所有会员();
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean b = false; //判断是否为int类型 false-否 true-是
            string Sid = this.txtname2.Text;
            int Sidi = 0;
            List<Vips> list;
            try
            {
                Sidi = int.Parse(Sid);
                b = true;
            }
            catch (Exception)
            {
                b = false;
            }
            if (b == true)
            {
                list = VipsBLL.Sel(Sidi);
            }
            else
            {
                list = VipsBLL.Sel(Sid);
            }
            this.lv3.Items.Clear();
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.VipID.ToString());
                lvi.SubItems.Add(item.VipName.ToString());
                lvi.SubItems.Add(item.VipSex.ToString());
                lvi.SubItems.Add(item.VGName.ToString());
                lvi.SubItems.Add(item.VGDiscount.ToString());
                lvi.SubItems.Add(item.VipTel.ToString());
                lvi.SubItems.Add(item.VipStartDate.ToString());
                lvi.SubItems.Add(item.VipEndDate.ToString());
                this.lv3.Items.Add(lvi);
            }
        }

        private void lv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lv2.Items.Clear();

            if (this.lv1.SelectedItems.Count == 0) return;
            //获取消费项目编号
            string Cid = this.lv1.SelectedItems[0].SubItems[2].Text;
            List<ConsumerDetail> list = VipsConsumerDetailsBLL.SelCD(Cid);
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.Name.ToString());
                lvi.SubItems.Add(item.CDAmount.ToString());
                lvi.SubItems.Add(item.CDPrice.ToString());
                this.lv2.Items.Add(lvi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //接收数据
            string sji = this.dte.Value.ToString();
            string sj = this.dtg.Value.ToString();
            Boolean b = false; //判断是否为int类型 false-否 true-是
            string name = this.txtname.Text;
            int bid = 0;
            List<ConsumerBill> list;
            try
            {
                bid = int.Parse(name);
                b = true;
            }
            catch (Exception)
            {
                b = false;
            }
            if (b == true)
            {

                list = VipsConsumerBillBLL.Selbid(bid, sj, sji);
            }
            else
            {
                list = VipsConsumerBillBLL.Selname(name, sj, sji);
            }
            this.lv1.Items.Clear();
            this.lv2.Items.Clear();
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.VID.ToString());
                lvi.SubItems.Add(item.VipName.ToString());
                lvi.SubItems.Add(item.CBID.ToString());
                lvi.SubItems.Add(item.money.ToString());
                lvi.SubItems.Add(item.CBSale.ToString());
                this.lv1.Items.Add(lvi);
            }
        }
    }
}
