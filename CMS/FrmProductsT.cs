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
    public partial class FrmProductsT : DevComponents.DotNetBar.Office2007Form
    {
        public FrmProductsT()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmProductsT_Load(object sender, EventArgs e)
        {
            List<ProductType> list = ProductTypeBLL.selectall();
            this.cbotype.DisplayMember = "name";
            this.cbotype.ValueMember = "id";

            this.cbotype.DataSource = list;
        }

        /// <summary>
        /// /添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtjp.Text == "" || this.txtname.Text == "" || this.txtprice.Text == "")
            {
                MessageBox.Show("未插入数据");

            }
            else
            {
                string name = this.txtname.Text;
                string xue = this.txtjp.Text;
                int lei = Convert.ToInt32(this.cbotype.SelectedValue);
                double jia = Convert.ToDouble(this.txtprice.Text);
                Products list = new Products();
                list.ProductName = name;
                list.ProductJP = xue;
                list.PTID = lei;
                list.ProductPrice = jia;
                bool b = ProductsBLL.insert(list);
                if (b == true)
                {
                    MessageBox.Show("添加成功");
                    this.Close();
                 
                }
                else
                    MessageBox.Show("添加失败");



            }
        }

        private void cbotype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        { //商品价格按键
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


    }
}
