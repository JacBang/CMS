using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商品管理.Model;
//using 商品管理.BLL;
using CMS.BLL;
using CMS.Model;

namespace 商品管理.UI
{
    public partial class FrmProduct : DevComponents.DotNetBar.Office2007Form
    {
        public FrmProduct()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        /// <summary>
        /// ///加载时查询所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 表一
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            ////添加组合框
            sx();
           ////表二
            //List<Products> listt = ProductsBLL.selectAll();
            //foreach (var item in listt)
            //{
            //    ListViewItem lvi = new ListViewItem(item.ProductID.ToString());

            //    lvi.SubItems.Add(item.ProductName);
            //    lvi.SubItems.Add(item.PTID.ToString());
            //    lvi.SubItems.Add(item.ProductPrice.ToString());
            //    this.lv2.Items.Add(lvi);
                
            //}


        }

        //刷新
        private void sx()
        {
            List<ProductType> list = ProductTypeBLL.selectall();
            ProductType p = new ProductType();
            p.id = 0;
            p.name = "全部";
            list.Add(p);
            list.Reverse();
            this.cbotype.DisplayMember = "name";
            this.cbotype.ValueMember = "id";
            this.cbotype.DataSource = list;
            //  显示白道一
            foreach (var item in list)
            {
                if (item.id != 0)
                {
                    ListViewItem lvi = new ListViewItem(item.id.ToString());

                    if (item.id != 0)
                    {
                        lvi.SubItems.Add(item.name);
                    }
                    this.lv.Items.Add(lvi);
                }
            }
        }
        //添加类别
        private void button1_Click(object sender, EventArgs e)
        {


         
            ProductsTypeT fm = new ProductsTypeT();
             
            
       
            fm.ShowDialog();
            this.lv.Items.Clear();
            sx();
           

        }
/// <summary>
/// /修改类别
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
         
            if (this.lv.SelectedItems.Count !=1 ) { MessageBox.Show("还没选择项"); }
            else
            {
                
                string b = this.lv.SelectedItems[0].SubItems[1].Text;
                Comm.TypeName = b;
                string a = this.lv.SelectedItems[0].Text;
                Comm.TypeID = a;
               
                ProductsTypeX fm = new ProductsTypeX();
                fm.ShowDialog();
                  this.lv.Items.Clear();
                sx();

              

            }
          
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

            if (this.lv2.SelectedItems.Count != 1) { MessageBox.Show("还没选择项"); }
            else
            {
                string  a = this.lv2.SelectedItems[0].Text;
                Comm.ProductID = a;
                //显示简xie            
                int  jp = Convert.ToInt32( this.lv2.SelectedItems[0].Text);
                Products f = ProductsBLL.select(jp);
                Comm.ProductJP = f.ProductJP;

                ////显示其他
                string name = this.lv2.SelectedItems[0].SubItems[1].Text;
                Comm.ProductName = name;
                string jia = this.lv2.SelectedItems[0].SubItems[3].Text;
                Comm.ProductPrice = jia;
                FrmProductsX fm = new FrmProductsX();
                fm.ShowDialog();
                this.lv.Items.Clear();
                sx();
            }
                       
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.lv.SelectedItems.Count == 0) { MessageBox.Show("还没选择项"); }
            else
            {
                DialogResult dr = MessageBox.Show(this,"确定要删除该条数据吗?","删除提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string id = this.lv.SelectedItems[0].Text;
                    bool b = ProductTypeBLL.database(id);
                    if (b == true)
                    {
                        MessageBox.Show("删除成功");
                        this.lv.Items.Clear();
                        sx();
                    }
                    else
                        MessageBox.Show("删除失败");
                }
            }
        }
        //添加商品
        private void button6_Click(object sender, EventArgs e)
        {
            FrmProductsT fm = new FrmProductsT();
            fm.ShowDialog();
            this.lv2.Items.Clear();
            this.lv.Items.Clear();
            sx();
        }

        private void cbotype_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cbotype.Text == "全部")
            {
                this.lv2.Items.Clear();
                List<Products> listt = ProductsBLL.selectAll();
                foreach (var item in listt)
                {
                    ListViewItem lvi = new ListViewItem(item.ProductID.ToString());

                    lvi.SubItems.Add(item.ProductName);
                    lvi.SubItems.Add(item.PTID.ToString());
                    lvi.SubItems.Add(item.ProductPrice.ToString());
                    this.lv2.Items.Add(lvi);

                }

            }

          ///判断组合框选中文本
            if (this.cbotype.Text != "全部")
            {
                this.lv2.Items.Clear();
                int leiid = Convert.ToInt32(this.cbotype.SelectedValue);


                List<Products> a = ProductsBLL.selectname(leiid);
                foreach (var item in a)
                {
                    ListViewItem lvi = new ListViewItem(item.ProductID.ToString());

                    lvi.SubItems.Add(item.ProductName);
                    lvi.SubItems.Add(item.PTID.ToString());
                    lvi.SubItems.Add(item.ProductPrice.ToString());
                    this.lv2.Items.Add(lvi);
                }
            }

           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //删除类别
            if (this.lv2.SelectedItems.Count == 0) { MessageBox.Show("还没选择项"); }
            else
            {
                DialogResult dr = MessageBox.Show(this, "确定要删除该条数据吗?", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string id = this.lv2.SelectedItems[0].Text;
                    bool b = ProductsBLL.database(id);
                    if (b == true)
                    {
                        MessageBox.Show(this,"删除成功","提示");
                        this.lv2.Items.Clear();
                        this.lv.Items.Clear();
                        sx();
                    }
                    else
                        MessageBox.Show(this,"删除失败","提示");

                }
            }
        }

        /// <summary>
        /// 显示文本变化到白道上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtjp_TextChanged(object sender, EventArgs e)
        {

            string jp = this.txtjp.Text;

            List<Products> a = ProductsBLL.selectjp(jp);
            this.lv2.Items.Clear();
            foreach (var item in a)
            {
                ListViewItem lvi = new ListViewItem(item.ProductID.ToString());

                lvi.SubItems.Add(item.ProductName);
                lvi.SubItems.Add(item.PTID.ToString());
                lvi.SubItems.Add(item.ProductPrice.ToString());
                this.lv2.Items.Add(lvi);
            }
        }
    }
}
