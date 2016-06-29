using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.Model;

namespace CMS
{
    public partial class FrmPwdX : DevComponents.DotNetBar.Office2007Form
    {
        public FrmPwdX()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {//取消
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {//确定
            if (this.txtname.Text == "")
            {
                MessageBox.Show(this, "用户名不能为空!", "提示");
                this.txtname.Focus();
                return;
            }
            else if (this.txtpwd.Text == "")
            {
                MessageBox.Show(this, "密码不能为空!", "提示");
                this.txtpwd.Focus();
                return;
            }
            else if (this.txtxpwd.Text == "" )
            {
                MessageBox.Show(this, "新密码不能为空!", "提示");
                this.txtxpwd.Focus();
                return;
            }
            else if (this.txtxpwds.Text == "")
            {
                MessageBox.Show(this, "新密码不能为空!", "提示");
                this.txtxpwds.Focus();
                return;
            }
            if (this.txtxpwds.Text != this.txtxpwd.Text)
            {
                if (this.txtxpwd.Text == "")
                {
                    MessageBox.Show(this, "两次输入的密码不相符,请重新输入!", "提示");
                    this.txtxpwd.Focus();
                    return;
                }
            }
            Boolean b=CMS.BLL.AdminsBLL.Update(this.txtname.Text, this.txtpwd.Text, this.txtxpwd.Text);
            if (b == true)
            {
                MessageBox.Show(this, "密码修改成功!", "提示");
                this.Close();
            }
            else
                MessageBox.Show(this, "用户名或旧密码错误,修改失败!", "提示");
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Admins admin { get; set; }
        private void FrmPwdX_Load(object sender, EventArgs e)
        {
            this.txtname.Text = admin.UserName;
        }
    }
}
