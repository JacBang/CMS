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
    public partial class ProductsTypeT : DevComponents.DotNetBar.Office2007Form
    {
        public ProductsTypeT()
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
            //添加类型
            else
            {
                string name = this.txtname.Text;

                bool count = ProductTypeBLL.insert(name);
                if (count == true)
                {
                    MessageBox.Show("添加成功");
                    this.Close();
                }
                else
                    MessageBox.Show("添加失败");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
