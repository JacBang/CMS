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
    public partial class FrmRoomTypeX : DevComponents.DotNetBar.Office2007Form
    {
        public FrmRoomTypeX()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmRoomTypeX_Load(object sender, EventArgs e)
        {
            this.txtRname.Text = Comm.name;
            this.txtcount.Text = Comm.shu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = Comm.name;
            string newname = this.txtRname.Text;
            string shu = this.txtcount.Text;
            if (newname == "" && shu == "")
            {
                MessageBox.Show(this, "数据不能为空!", "提示");
                return;
            }
            bool count = RoomTypeBLL.update(name, shu,newname);
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
