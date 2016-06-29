using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.Model;
using CMS.BLL;
using 商品管理.UI;

namespace CMS
{
    public partial class FrmTableX : DevComponents.DotNetBar.Office2007Form
    {
        public FrmTableX()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmTableX_Load(object sender, EventArgs e)
        {
            ///显示组合框
            this.txtTname.Text = Comm.name;
            List<RoomType> list = RoomTypeBLL.selectall();
            this.cboRname.DisplayMember = "RTNAME";
            string id = Comm.id;
            this.cboRname.ValueMember = "RTID";
           
            ///默认显示
            ///
            //this.comblou.Text = comm.qu;
            //this.cboRname.Text = comm.qu;
            this.comblou.Text = Comm.qu;
            this.cboRname.DataSource = list;

            //for (int i = 0; i < this.cboRname.Items.Count; i++)
            //{
            //    //this.cboRname.SelectedIndex = i;
            //    if (this.cboRname.SelectedValue.ToString() == comm.leibie.ToString())
            //    {
            //        //this.cboRname.ValueMember
            //        if (i != 0)
            //            this.cboRname.SelectedIndex = i - 1;
            //        else
            //            this.cboRname.SelectedIndex = i;
            //    }

            //}

            string newname = this.txtTname.Text;
           // string lei = this.cboRname.Text;
            string shi = this.cboRname.DisplayMember;
         
            
          //  int yin=Convert.ToInt32(this.cboRname.ValueMember);

            //查找类别
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string a = this.txtTname.Text;
            string lou = this.comblou.Text;
            if (a == "")
            {
                MessageBox.Show(this, "数据不能为空!", "提示");
                return;
            }
            int lei = Convert.ToInt32(this.cboRname.SelectedValue);
          //  MessageBox.Show(lei.ToString());
            bool b = TablesBLL.updata(Comm.name, a, lou, lei);
          if (b == true)
          {
              MessageBox.Show("成功");
              this.Close();
          }
          else
          {
              MessageBox.Show("失败");


          }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
