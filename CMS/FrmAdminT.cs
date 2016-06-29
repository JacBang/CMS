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
    public partial class FrmAdminT : DevComponents.DotNetBar.Office2007Form
    {
        public FrmAdminT()
        {
            this.EnableGlass = false; 
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.txtAname.Text;
              string pwd=this.txtpwd.Text;
              string qpwd = this.txtQpwd.Text;
              string qname = this.txtname.Text;
              if (pwd != qpwd)
              {

                  MessageBox.Show("输入两次密码不相同");
                  return;
              }
              if (this.txtAname.Text == "" || this.txtname.Text == "" || this.txtpwd.Text == "")
              {
                  MessageBox.Show("数据部能为空");
                  return;

              }

              else
              {

                  bool b = AdminsBLL.insert(name, pwd, qname);
                  if (b == true)
                  {
                      this.Close();
                     MessageBox.Show(this,"注册成功!","提示");
                  }
                  else {
                      MessageBox.Show(this, "注册失败，请重试!", "提示");
                  }

              }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
