using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.Model;
using 商品消费查询.Model;

namespace CMS
{
    public partial class FrmJz : DevComponents.DotNetBar.Office2007Form
    {
        public FrmJz()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        /// <summary>
        /// 账单编号
        /// </summary>
        public String Zd { get; set; }
        /// <summary>
        /// 餐台号
        /// </summary>
        public String Ct { get; set; }
        /// <summary>
        /// 餐台编号
        /// </summary>
        public String Ctid { get; set; }
        private void FrmJz_Load(object sender, EventArgs e)
        {//加载信息
            //结账单号 餐台号
            this.lblct.Text = Ct;
            this.lblzd.Text = Zd;
            Vips v = CMS.BLL.VipsBLL.Select(Zd);
            if (v.VipID == null)
                this.lblvip.Text = "否";
            else
            {
                this.lblvip.Text = "是";
                this.lblvipname.Text = v.VipName;
                this.lblvipj.Text = v.VipGname;
                this.lblvipzk.Text = v.VipGD;
            }

            //加载消费消费项目
            this.lv2.Items.Clear();
            List<ConsumerDetails> listc = CMS.BLL.CDBLL.SelectX(Zd);
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

            //加载实收金额 优惠金额 消费总金额
            double sum = 0;
            for (int i = 0; i < this.lv2.Items.Count; i++)
            {
                sum = sum + double.Parse(this.lv2.Items[i].SubItems[3].Text);
            }
            this.lblzje.Text = sum.ToString();
            double ss = sum * double.Parse(this.lblvipzk.Text);
            this.lblss.Text = ss.ToString();
            this.lblyh.Text = (sum - ss).ToString();
        }

        private void lv2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtmoney_TextChanged(object sender, EventArgs e)
        {//宾客支付计算
            try
            {
                Double ss = Double.Parse(this.lblss.Text);
                Double money = Double.Parse(this.txtmoney.Text);
                if (money > ss)
                    this.lblzl.Text = (money - ss).ToString();
                else
                    this.lblzl.Text = "0";
            }
            catch
            {
                this.txtmoney.Text = "";
            }
            
           

        }

        private void txtmoney_KeyPress(object sender, KeyPressEventArgs e)
        {//按键
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8&&e.KeyChar!='.')
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要结账吗？(Y/N)", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //结账
                if (this.txtmoney.Text == "" || double.Parse(this.txtmoney.Text) < double.Parse(this.lblss.Text)) return;
                Boolean b = CMS.BLL.ConsumerBillBLL.Update(Zd);
                Boolean bo = CMS.BLL.TablesBLL.UPdate(Ctid, "0");
                if (b == true && bo == true)
                {
                    MessageBox.Show(this, "结账成功!", "提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "结账失败,请重试!", "提示");
                }  
            }                          
        }
    }
}
