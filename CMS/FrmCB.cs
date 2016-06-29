using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商品消费查询.Model;
using CMS.Model;

namespace CMS
{
    public partial class FrmCB : DevComponents.DotNetBar.Office2007Form
    {
        public FrmCB()
        {
            this.EnableGlass = false; 
            InitializeComponent();
        }

        private void lv2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmCB_Load(object sender, EventArgs e)
        {//加载

            //让时间赋值为一天前
            DateTime yestoday = DateTime.Now.AddDays(-1);
            this.dtg.Text = yestoday.ToString("yyyy-MM-dd");

            //将账单信息放入ListView1
            List<ConsumerBill> list = CMS.BLL.ConsumerBillBLL.SelectAll(this.dtg.Value.ToString(),this.dte.Value.ToString());
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.CBID);
                lvi.SubItems.Add(item.TName);
                lvi.SubItems.Add(item.CBEndDate);
                lvi.SubItems.Add(item.CBSale.ToString());
                lvi.SubItems.Add(item.CBSale.ToString());
                if (item.VipID == "-1")
                    lvi.SubItems.Add("非会员");
                else
                {
                    List<Vips> listv = CMS.BLL.VipsBLL.Sel(int.Parse(item.VipID));
                    lvi.SubItems.Add(listv[0].VipName);
                }
                this.lv1.Items.Add(lvi);
            }

            //加载收银员
            List<Admins> lista = CMS.BLL.AdminsBLL.selectall();
            this.cbos.DisplayMember = "UserCompellation";
            this.cbos.ValueMember = "UserID";
            this.cbos.DataSource = lista;

        }

        private void btns_Click(object sender, EventArgs e)
        {//搜索
            this.lv1.Items.Clear();
            String dateg = this.dtg.Value.ToString();
            String datee = this.dte.Value.ToString();
            String Sk = this.cbos.SelectedValue.ToString();
            String Ct = this.txts.Text;
            List<ConsumerBill> list = CMS.BLL.ConsumerBillBLL.SelectAll(dateg,datee,Sk,Ct);
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.CBID);
                lvi.SubItems.Add(item.TName);
                lvi.SubItems.Add(item.CBEndDate);
                lvi.SubItems.Add(item.CBSale.ToString());
                lvi.SubItems.Add(item.CBSale.ToString());
                if (item.VipID == "-1")
                    lvi.SubItems.Add("非会员");
                else
                {
                    List<Vips> listv = CMS.BLL.VipsBLL.Sel(int.Parse(item.VipID));
                    lvi.SubItems.Add(listv[0].VipName);
                }
                this.lv1.Items.Add(lvi);
            }
        }

        private void lv1_Click(object sender, EventArgs e)
        {//单击显示消费信息
            if(this.lv1.SelectedItems.Count==0)return;
            String cbid=this.lv1.SelectedItems[0].SubItems[0].Text;
            this.lv2.Items.Clear();
            List<ConsumerDetails> listc = CMS.BLL.CDBLL.SelectX(cbid);
            if (listc != null)
            {
                foreach (var item in listc)
                {//循环添加消费信息
                    ListViewItem lvi = new ListViewItem(item.ProName);
                    lvi.SubItems.Add(item.CDPrice.ToString());
                    lvi.SubItems.Add(item.CDAmount.ToString());
                    lvi.SubItems.Add(item.CDMoney.ToString());
                    lvi.SubItems.Add(item.CDDate);
                    lvi.Tag = item;
                    this.lv2.Items.Add(lvi);
                }
            }
        }
    }
}
