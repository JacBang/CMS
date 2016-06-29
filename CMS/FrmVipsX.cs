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
    public partial class FrmVipsX : DevComponents.DotNetBar.Office2007Form
    {
        public FrmVipsX()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVipsX_Load(object sender, EventArgs e)
        {
            
            //用无间道显示会员等级
            List<VIPGrades> list = VipsBLL.selVG();
            this.cbograde.DisplayMember = "VGName";
            this.cbograde.ValueMember = "VGID";
            this.cbograde.DataSource = list;
            //在窗体加载的时候将数据传过来
            this.txtid.Text = publlei.VipID.ToString ();
            this.txtname.Text = publlei.VipName;
            this.txttel.Text = publlei.VipTel;
            this.cbograde.Text = publlei.Grname .ToString ();
            this.cbosex.Text = publlei.VipSex ;
            this.dt.Text = publlei.VipEndDate;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vips v = new Vips();
            v.VipName   = this.txtname.Text;
            v.VipSex  = this.cbosex.Text; 
            v.GradeID  = this.cbograde.SelectedValue.ToString();
            v.VipTel  = this.txttel.Text; 
            v.VipEndDate  = this.dt.Value.ToString () ;
            v.VipID = this.txtid.Text.ToString();
            bool bl = VipsBLL.upbyid(v);
            if (true == bl)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }

        }
    }
}
