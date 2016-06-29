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
    public partial class FrmTableT : DevComponents.DotNetBar.Office2007Form
    {
        public FrmTableT()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmTableT_Load(object sender, EventArgs e)
        {
            this.cboRlou.Text = "一楼";
            List<RoomType> list = RoomTypeBLL.selectall();

            this.cboRname.DisplayMember = "RTNAME";

            string id = Comm.id;
            this.cboRname.ValueMember = "RTID";
          //  this.cboRlou.DisplayMember = "TableArea";
            this.cboRname.DataSource = list;
           // this.cboRlou.DataSource = list;
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtTname.Text == "" )
            {

                MessageBox.Show("数据不能为空");
            }
            else {

                string name = this.txtTname.Text;
                string qu = this.cboRlou.Text;
                int lei = Convert.ToInt32(this.cboRname.SelectedValue); 
                bool b=TablesBLL.insert(name,qu,lei);

                if (b == true)
                {
                    
                    MessageBox.Show("添加成功");
                    this.Close();
                }
                else {

                    MessageBox.Show("添加失败");
                }

            
            }
        }
    }
}
