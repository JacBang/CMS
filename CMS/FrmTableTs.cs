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
    public partial class FrmTableTs : DevComponents.DotNetBar.Office2007Form
    {
        public FrmTableTs()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmTableTs_Load(object sender, EventArgs e)
        {
            this.comblou.Text = "一楼";
            List<RoomType> list = RoomTypeBLL.selectall();

            this.cboRname.DisplayMember = "RTNAME";

            string id = Comm.id;
            this.cboRname.ValueMember = "RTID";
            //  this.cboRlou.DisplayMember = "TableArea";
            this.cboRname.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string A = this.txtTname.Text;
            string qu = this.comblou.Text;
            int lei = Convert.ToInt32(this.cboRname.SelectedValue);
            if (A == "" || this.textBox1.Text == "" || this.txtTtype.Text == "")
            {
                MessageBox.Show("数据不能为空");

            }
            else
            {
                int B = Convert.ToInt32(this.txtTtype.Text);
                int C = Convert.ToInt32(this.textBox1.Text);

                if (B > C)
                {
                    MessageBox.Show("编号范围输入有误");

                }

                else
                {



                    for (int i = B; i <= C; i++)
                    {
                        string name = A + i.ToString();
                        bool b = TablesBLL.insert(name, qu, lei);

                        if (i == C)
                        {
                            if (b == true)
                            {
                                MessageBox.Show("添加成功");
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("添加失败");
                            }

                        }
                    }

                }
            
            }

        }

        private void txtTtype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (this.txtTtype.Text.Length > 2 && e.KeyChar!=8)
                e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (this.txtTtype.Text.Length > 2 && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtTtype_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
