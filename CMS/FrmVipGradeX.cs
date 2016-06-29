using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.BLL;
using CMS.Model;
using 商品管理.UI;

namespace CMS
{
    public partial class FrmVipGradeX : DevComponents.DotNetBar.Office2007Form
    {
        public FrmVipGradeX()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmVipGradeX_Load(object sender, EventArgs e)
        {
            this.txtid.Text = Comm.VGID;


            this.txtGrade.Text= Comm.VGName;
            this.txtD.Text = Comm.VGDiscount;
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          
            if (this.txtGrade.Text == "" || this.txtD.Text == "")
            {
                MessageBox.Show("数据部能为空");

            }
           else {


               int  a =Convert.ToInt32( this.txtid.Text);
            
               string b = this.txtGrade.Text;
            
               double c = Convert.ToDouble(this.txtD.Text);
            
               VipGrade v = new VipGrade();
               v.VGID = a;
               v.VGName = b;
               v.VGDiscount = c;

                bool bb = VipsBLL.update(v);
                if (bb == true)
                {
                   this.Close();

                   // MessageBox.Show("成功");
                }

                else {

                    MessageBox.Show("失败");
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
