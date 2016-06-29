using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CMS;
using CMS.Model;

namespace CMS
{
    public partial class FrmLoginNew : Form
    {
        public FrmLoginNew()
        {
            InitializeComponent();
        }

        private void FrmLoginNew_Load(object sender, EventArgs e)
        {
            this.pBorder.BackColor = Color.FromArgb(243, 243, 243);
            pBorder.Paint += new PaintEventHandler(panel1_Paint);
            label1.MouseUp += new MouseEventHandler(NoBoderForm_MouseUp);
            label1.MouseMove += new MouseEventHandler(NoBoderForm_MouseMove);
            label1.MouseDown += new MouseEventHandler(NoBoderForm_MouseDown);

            //读取标题
            using (FileStream fs = new FileStream("bt.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<String> lists = bf.Deserialize(fs) as List<String>;
                //this.lbldl.Text = lists[0] + "登录";
                this.label1.Text = lists[0].ToString();
            }
            //读取历史登陆用户
            using (FileStream fs = new FileStream("Admin.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                String name = bf.Deserialize(fs) as String;
                this.txtname.Text = name;
            }
        }

        private static bool isMouseDown = false;
        private static System.Drawing.Point FormLocation;     //form的location
        private static System.Drawing.Point mouseOffset;      //鼠标的按下位置
        public void NoBoderForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            isMouseDown = false;
        }

        public void NoBoderForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int _x = 0;
                int _y = 0;
                System.Drawing.Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new System.Drawing.Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }

        public void NoBoderForm_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
                this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                        this.pBorder.ClientRectangle,
                                        Color.FromArgb(61, 180, 251),         //left
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.FromArgb(61, 180, 251),         //top
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.FromArgb(61, 180, 251),        //right
                                        1,
                                        ButtonBorderStyle.Solid,
                                        Color.FromArgb(61, 180, 251),        //bottom
                                        1,
                                        ButtonBorderStyle.Solid);
        }

        private void picdl_Click(object sender, EventArgs e)
        {
            //登录
            DL();
        }

        private void DL()
        {
            String Name = this.txtname.Text; ;
            String Pwd = this.txtpwd.Text;
            if (Name == "" || Pwd == "")
            {
                MessageBox.Show(this, "账号或密码不能为空", "提示");
                return;
            }
            Admins a = CMS.BLL.AdminsBLL.Login(Name, Pwd);
            if (a != null)
            {
                //MessageBox.Show(this, "欢迎 " + a.UserCompellation);

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPwdX frm = new FrmPwdX();
            frm.ShowDialog();
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

        private void picdl_MouseHover(object sender, EventArgs e)
        {
            this.picdl.BackgroundImage = Properties.Resources.登录1经过;
        }

        private void picdl_MouseLeave(object sender, EventArgs e)
        {
            this.picdl.BackgroundImage = Properties.Resources.登录1;
        }

        private void picqx_MouseHover(object sender, EventArgs e)
        {
            this.picqx.BackgroundImage = Properties.Resources.取消1经过;
        }

        private void picqx_MouseLeave(object sender, EventArgs e)
        {
            this.picqx.BackgroundImage = Properties.Resources.取消1;
        }

        private void picqx_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
