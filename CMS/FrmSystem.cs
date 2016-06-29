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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CMS
{
    public partial class FrmSystem : DevComponents.DotNetBar.Office2007Form
    {
        public FrmSystem()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void FrmSystem_Load(object sender, EventArgs e)
        {

            //////白道表一
            sx();
           ////白道二
            SX();
            //读取文件
            using (FileStream fs = new FileStream("bt.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                List<String> list = bf.Deserialize(fs) as List<String>;
                this.txtdl.Text = list[0];
                this.txtbz.Text = list[1];
            }
        }

        private void SX()
        {
            this.lv2.Items.Clear();
            List<VipGrade> vip = VipsBLL.selectvip();
            foreach (var item in vip)
            {
                ListViewItem lvi = new ListViewItem(item.VGID.ToString());
                lvi.SubItems.Add(item.VGName);
                lvi.SubItems.Add(item.VGDiscount.ToString());
                this.lv2.Items.Add(lvi);

            }
        }

        private void sx()
        {
            List<Admins> list = AdminsBLL.selectall();

            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.UserID.ToString());

                lvi.SubItems.Add(item.UserName);
                lvi.SubItems.Add(item.UserCompellation);
                this.lv1.Items.Add(lvi);

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            FrmAdminT fm = new FrmAdminT();
            fm.ShowDialog();
            this.lv1.Items.Clear();
            sx();
        
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lv1.SelectedItems.Count != 1) { MessageBox.Show("还没选择项"); }
            else
            {
               
                string b = this.lv1.SelectedItems[0].Text;
                Comm.id = b;
                string a = this.lv1.SelectedItems[0].SubItems[1].Text;
                Comm.name = a;
                string c = this.lv1.SelectedItems[0].SubItems[2].Text;
                Comm.pname = c;
                FrmAdminX fm = new FrmAdminX();
                fm.ShowDialog();
                this.lv1.Items.Clear();
                sx();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.lv1.SelectedItems.Count != 1) { MessageBox.Show("还没选择项"); }
            else
            {
                DialogResult a = MessageBox.Show(this, "是否删除", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (a == DialogResult.Yes)
                {
                    string b = this.lv1.SelectedItems[0].Text;
                    bool bb = AdminsBLL.database(b);
                    if (bb == true)
                    {
                        this.lv1.Items.Clear();
                        sx();
                        MessageBox.Show("删除成功");
                    }
                    else
                    {

                        MessageBox.Show("删除失败");
                    }
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FrmVipGradeT fm = new FrmVipGradeT();
            fm.ShowDialog();
            SX();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.lv2.SelectedItems.Count != 1) { MessageBox.Show("还没选择项"); }
            else
            {
                string b = this.lv2.SelectedItems[0].Text;
                Comm.VGID = b;
                string bb = this.lv2.SelectedItems[0].SubItems[1].Text;
                Comm.VGName = bb;
                string a = this.lv2.SelectedItems[0].SubItems[2].Text;
                Comm.VGDiscount = a;
                FrmVipGradeX  fm = new FrmVipGradeX();
                fm.ShowDialog();
                this.lv2.Items.Clear();
                SX();

              
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.lv2.SelectedItems.Count != 1) { MessageBox.Show("还没选择项"); }
            else
            {
                 DialogResult a = MessageBox.Show(this, "是否删除", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                 if (a == DialogResult.Yes)
                 {
                     string b = this.lv2.SelectedItems[0].Text;
                     bool id = VipsBLL.database(b);
                     if (id == true)
                     {
                         this.lv2.Items.Clear();
                         SX();
                         MessageBox.Show("删除成功");
                     }
                     else
                     {

                         MessageBox.Show("删除失败");
                     }
                 }


            }
        }

        private void button9_Click(object sender, EventArgs e)
        {//保存
            List<String> list = new List<String>();
            list.Add(this.txtdl.Text);
            list.Add(this.txtbz.Text);
            Comm.bt = this.txtdl.Text;
            using (FileStream fs = new FileStream("bt.dat", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, list);
            }
            MessageBox.Show(this, "保存成功!","提示");
            this.Close();
        }
    }
}
