using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CMS
{
    public partial class FrmUserLogion : Form
    {
        public FrmUserLogion()
        {
            InitializeComponent();
        }

        private void FrmUserLogin_Load(object sender, EventArgs e)
        {
            //读取标题
            using (FileStream fs = new FileStream("bt.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<String> lists = bf.Deserialize(fs) as List<String>;
                this.lbldl.Text = lists[0] + "登录";
            }
            //读取历史登陆用户
            using (FileStream fs = new FileStream("Admin.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                String name = bf.Deserialize(fs) as String;
                this.txtname.Text = name;
            }
        }
        private void picdl_MouseEnter(object sender, EventArgs e)
        {//确定悬浮
            this.picdl.Image = CMS.Properties.Resources.确定2;
        }

        private void picdl_MouseLeave(object sender, EventArgs e)
        {//确定移出
            this.picdl.Image = CMS.Properties.Resources.确定;
        }

        private void picqx_MouseEnter(object sender, EventArgs e)
        {//取消悬浮
            this.picqx.Image = CMS.Properties.Resources.取消2;
        }

        private void picqx_MouseLeave(object sender, EventArgs e)
        {//取消移出
            this.picqx.Image = CMS.Properties.Resources.取消;
        }

        private void picqx_Click(object sender, EventArgs e)
        {//退出
            Application.Exit();
        }

        private void picdl_Click(object sender, EventArgs e)
        {//登录
            DL();
        }

        private void DL()
        {
            String Name = this.txtname.Text;;
            String Pwd = this.txtpwd.Text;
            if (Name == "" || Pwd == "")
            {
                MessageBox.Show(this, "账号或密码不能为空", "提示");
                return;
            }
            Admins a = CMS.BLL.AdminsBLL.Login(Name, Pwd);
            if (a != null)
            {
                MessageBox.Show(this,"欢迎 "+a.UserCompellation);

                //保存历史登陆用户;
                using (FileStream fs = new FileStream("Admin.dat", FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, this.txtname.Text);
                }

                //FrmCMS frm = new FrmCMS();//原来系统主界面
                FormMain frm = new FormMain();
                frm.admin = a;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(this, "账号或密码有误,登录失败!", "登录提示");
            }
        }

        private void FrmUserLogin_KeyPress(object sender, KeyPressEventArgs e)
        {//按键事件
            if (e.KeyChar == 13)
            {
                DL();
            }
                
        }

        private void txtpwd_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            //MessageBox.Show(e.KeyValue.ToString());
        }

        private void txtpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DL();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPwdX frm = new FrmPwdX();
            frm.ShowDialog();
        }
    }
}
