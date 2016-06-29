using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.BLL;
//using 商品管理.BLL;

namespace 商品管理.UI
{
    public partial class ProductsTypeX : DevComponents.DotNetBar.Office2007Form
    {
        public ProductsTypeX()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtname.Text == "")
            {
                MessageBox.Show("未插入数据");
            }
            ///修改类别
            // MessageBox.Show(Comm.TypeID);
            else
            {
                string name = this.txtname.Text;
                //   Comm.TypeID;
                string id = Comm.TypeID;
                bool b = ProductTypeBLL.update(id, name);
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

        private void ProductsTypeX_Load(object sender, EventArgs e)
        {
            this.txtname.Text = Comm.TypeName;
           
        }
    }
}
