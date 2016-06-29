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
    public partial class FrmRoomTypeT : DevComponents.DotNetBar.Office2007Form
    {
        public FrmRoomTypeT()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = this.txtRname.Text;
            string shu = this.txtcount.Text;
            if (name == "" && shu == "")
            {
                MessageBox.Show(this,"数据不能为空!","提示");
                return;
            }
        bool count = RoomTypeBLL.insert(name, shu);
            if (count == true)
            {
                MessageBox.Show("成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("失败");


            }
        }

        private void txtcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '1' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
