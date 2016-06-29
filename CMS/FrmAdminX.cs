using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.BLL;
using 商品管理.UI;

namespace CMS
{
    public partial class FrmAdminX : DevComponents.DotNetBar.Office2007Form
    {
        public FrmAdminX()
        {
            this.EnableGlass = false; 
            InitializeComponent();
        }

        private void FrmAdminX_Load(object sender, EventArgs e)
        {

            this.txtid.Text = Comm.id;
            this.txtname.Text = Comm.pname;
            this.txtAname.Text = Comm.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtAname.Text == "" || this.txtname.Text == "")
            {
                MessageBox.Show("数据部能为空");
                return;
            }
            else{
            
            string id = this.txtid.Text;
                string name = this.txtname.Text;
                string pname = this.txtAname.Text;
                bool b = AdminsBLL.update(pname,name , id);
                if (b == true)
                {
                    this.Close();
                    MessageBox.Show("修改成功");
                }
                else
                {

                    MessageBox.Show("修改失败");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
