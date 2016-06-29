using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商品管理.Model;
using 商品消费查询.Model;
using CMS.Model;
using CMS.BLL;
namespace CMS
{
    public partial class FrmAddConsumer : DevComponents.DotNetBar.Office2007Form
    {
        public FrmAddConsumer()
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

        #region 已消费信息查询
        private void Xf()
        {//清空白道
            this.lv2.Items.Clear();
            List<ConsumerDetails> listc = CMS.BLL.CDBLL.SelectX(this.txtzd.Text);
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
            //获取商品数量以及金额
            int sum = 0;
            double sum2 = 0;
            for (int i = 0; i < this.lv2.Items.Count; i++)
            {
                sum = sum+int.Parse(this.lv2.Items[i].SubItems[2].Text);
                sum2 = sum2 + double.Parse(this.lv2.Items[i].SubItems[3].Text);
            }
            this.lblsl.Text = sum.ToString();
            this.lblmoney.Text = sum2.ToString();

        }
        #endregion
        private void FrmAddConsumer_Load(object sender, EventArgs e)
        {//加载信息
            //账单号与餐桌名
            this.txtzd.Text = Zd;
            this.txtct.Text = Ct;
            //加载商品信息到白道
            List<Products> list = CMS.BLL.ProductsBLL.selectAll();
            if (list != null)
            {
                foreach (var item in list)
                {
                    ListViewItem lvi = new ListViewItem(item.ProductName);
                    lvi.SubItems.Add(item.ProductPrice.ToString());
                    lvi.Tag = item;
                    this.lv1.Items.Add(lvi);
                }
            }

            //加载商品类别与商品到树控件
            //加载商品类别
            List<ProductType> lists = CMS.BLL.ProductTypeBLL.selectall();
            if (lists != null)
            {
                foreach (var item in lists)
                {
                    TreeNode node = new TreeNode();
                    node.Text = item.name;
                    node.Tag = item.id;
                    this.tv.Nodes.Add(node);
                }
            }
            //加载商品
            int count = this.tv.Nodes.Count;
            for (int i = 0; i < count; i++)
            {
                List<Products> listpro = CMS.BLL.ProductsBLL.selectname(int.Parse(this.tv.Nodes[i].Tag.ToString()));
                TreeNode node = this.tv.Nodes[i];
                foreach (var item in listpro)
                {
                   node.Nodes.Add(item.ProductName);
                   node.Tag = item; 
                }
                
            }
            

            //加载已消费的信息到白道
            Xf();


        }
        

        private void txtname_TextChanged(object sender, EventArgs e)
        {//简拼搜索

            List<Products> list = ProductsBLL.selectjp(this.txtname.Text);
            this.lv1.Items.Clear();
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.ProductName);
                lvi.SubItems.Add(item.ProductPrice.ToString());
                lvi.Tag = item;
                this.lv1.Items.Add(lvi);
            }
        }

        private void lv1_Click(object sender, EventArgs e)
        {//单击显示当前选择项
            if (this.lv1.SelectedItems.Count == 0) return;
            this.lbldq.Text = this.lv1.SelectedItems[0].SubItems[0].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {//点单
            if (this.lv1.SelectedItems.Count == 0)
            {
                MessageBox.Show(this,"请选择商品!","提示");
                return;
            }
            if (int.Parse(this.sum.Value.ToString()) == 0)
            {
                MessageBox.Show(this,"请输入正确的商品数量!","提示");
                return;
            }
            Products p =this.lv1.SelectedItems[0].Tag as Products;
            ConsumerDetails c = new ConsumerDetails();
            c.CBID = this.txtzd.Text;
            c.ProdcutID = p.ProductID;
            c.CDPrice = p.ProductPrice;
            c.CDAmount = int.Parse(this.sum.Value.ToString());
            c.CDSale = 0;
            c.CDMoney = c.CDAmount * c.CDPrice;
            c.CDType = 0;
            c.CDDate = DateTime.Now.ToString();
            Boolean b = CMS.BLL.CDBLL.Insert(c);
            if (b == true)
                //加载已消费的信息到白道
                Xf();
            else
                MessageBox.Show(this,"点单失败，请重试!","提示");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {//退菜
            if (this.lv2.SelectedItems.Count == 0)
            {
                MessageBox.Show(this,"没有选中任何菜品,请选择!","提示");
                return;
            }
            ConsumerDetails c=this.lv2.SelectedItems[0].Tag as ConsumerDetails;
            Boolean b = CMS.BLL.CDBLL.Update(c.CDID.ToString());
            if (b == true)
                MessageBox.Show(this, "退菜成功!", "提示");
            else
                MessageBox.Show(this,"退菜失败,请重试!","提示");

            Xf();
        }

        private void button3_Click(object sender, EventArgs e)
        {//点单结束
            this.Close();
        }
    }
}
