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
    public partial class FrmLock : DevComponents.DotNetBar.Office2007Form
    {
        public FrmLock()
        {
            this.EnableGlass = false; 
            InitializeComponent();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (this.tbPwd.Text == admin.UserPwd)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误,请重新输入！");
                this.tbPwd.Text = "";
            }
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        public Admins admin { get; set; }
        private void FrmLock_Load(object sender, EventArgs e)
        {
            
        }
    }
}
