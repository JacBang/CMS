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
    public partial class FrmProductsX : DevComponents.DotNetBar.Office2007Form
    {
        public FrmProductsX()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            string id = Comm.ProductID;


            this.txtjp.Text = Comm.ProductJP;
            this.txtname.Text = Comm.ProductName;
            this.txtprice.Text = Comm.ProductPrice;
           
                List<ProductType> list = ProductTypeBLL.selectall();
                this.cbotype.DisplayMember = "name";
                this.cbotype.ValueMember = "id";

                this.cbotype.DataSource = list;
            
        }


        /// <summary>
        /// 商品修改
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
                int id = Convert.ToInt32(Comm.ProductID);

                Products list = new Products();
                list.ProductID = id;
                list.ProductName = name;
                list.ProductJP = xue;
                list.PTID = lei;
                list.ProductPrice = jia;
                bool b = ProductsBLL.update(list);
                if (b == true)
                {
                    MessageBox.Show("修改成功");

                    this.Close();
                }
                else
                    MessageBox.Show("修改失败");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
