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

namespace CMS
{
    public partial class FrmVipsT : DevComponents.DotNetBar.Office2007Form
    {
        public FrmVipsT()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVipsT_Load(object sender, EventArgs e)
        {
            //用无间道显示会员等级
            List<VIPGrades> list = VipsBLL.selVG();
            this.cbograde.DisplayMember = "VGName";
            this.cbograde.ValueMember = "VGID";
            this.cbograde.DataSource = list;
            //用单值查询显示id 
            this.txtid.Text = (VipsBLL.selectID()+1).ToString ();
            //默认性别为男
            this.cbosex.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取数据
         
           //判断是否为空
            if (this.txtname.Text == "" || this.txttel.Text == "")
            {
                MessageBox.Show("请输入完整的信息");
                return;
            }
                //获取数据
                string name = this.txtname.Text;
                string sex = this.cbosex.Text;
                string gid = this.cbograde.SelectedValue.ToString();
                string tel = this.txttel.Text;
                string sj = this.dt.Value.ToString();
                //赋值数据
                Vips v = new Vips();
                v.VipName = name;
                v.VipSex = sex;
                v.GradeID = gid.ToString(); ;
                v.VipTel = tel;
                v.VipEndDate = sj;
                bool bl = VipsBLL.Insert(v);
                if (true == bl)
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
