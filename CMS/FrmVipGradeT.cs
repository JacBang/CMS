using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.BLL;

namespace CMS
{
    public partial class FrmVipGradeT : DevComponents.DotNetBar.Office2007Form
    {
        public FrmVipGradeT()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jiname = this.txtGrade.Text;
           
            string zhe = this.txtD.Text;
            if (jiname == "" || zhe == "")
            {
                MessageBox.Show("数据不能为空");
            }
            else
            {
                /////判断是否
                bool b = VipsBLL.insert(jiname, zhe);
                if (b == true)
                {
                    this.Close();

                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
