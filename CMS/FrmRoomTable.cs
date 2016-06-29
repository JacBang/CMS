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
    public partial class FrmRoomTable : DevComponents.DotNetBar.Office2007Form
    {
        public FrmRoomTable()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//添加房间类型
            FrmRoomTypeT frm = new FrmRoomTypeT();
            frm.ShowDialog();
            this.lv1.Items.Clear();
            SX();
        }

        private void button2_Click(object sender, EventArgs e)
        {//修改房间类型

            if (this.lv1.SelectedItems.Count != 1) { MessageBox.Show("还没选择项"); }
            else
            {
                Comm.name = this.lv1.SelectedItems[0].Text;
                Comm.shu = this.lv1.SelectedItems[0].SubItems[1].Text;
                FrmRoomTypeX frm = new FrmRoomTypeX();
                frm.ShowDialog();
                this.lv1.Items.Clear();
                SX();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {//单个添加餐台

            FrmTableT frm = new FrmTableT();
            frm.ShowDialog();
            this.lv2.Items.Clear();
            sxx();
        }

        private void button5_Click(object sender, EventArgs e)
        {//批量添加餐台
            FrmTableTs frm = new FrmTableTs();
            frm.ShowDialog();
            this.lv2.Items.Clear();
            sxx();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {//修改餐台

            if (this.lv2.SelectedItems.Count != 1) { MessageBox.Show("还没选择项"); }
            else
            {
                //房名
                Comm.name = this.lv2.SelectedItems[0].Text;
               // MessageBox.Show(comm.name);
               //房子的楼层
                Comm.qu = this.lv2.SelectedItems[0].SubItems[3].Text;
                Comm.shu = this.lv2.SelectedItems[0].SubItems[2].Text;

                Comm.leibie = Convert.ToInt32(this.lv2.SelectedItems[0].SubItems[4].Text);
               //MessageBox.Show(comm.leibie.ToString());
                FrmTableX frm = new FrmTableX();
                frm.ShowDialog();
                this.lv2.Items.Clear();
                sxx();
        }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ////白道一
            SX();
            ////组合框显示


            /////白道二
            sxx();

        }

        private void sxx()
        {
            this.lv2.Items.Clear();
            List<Tables> listt = TablesBLL.selectall();
            foreach (var item in listt)
            {

                ListViewItem lvi = new ListViewItem(item.TName.ToString());
                lvi.SubItems.Add(item.idname);
                // lvi.SubItems.Add(item.RTID);

                lvi.SubItems.Add(item.TState);
                lvi.SubItems.Add(item.TArea);
                lvi.SubItems.Add(item.RTID);
                this.lv2.Items.Add(lvi);
            }

        }

        private void SX()
        {
            List<RoomType> list = RoomTypeBLL.selectall();
            RoomType p = new RoomType();
            p.RTID = "0";
            p.RTName = "全部";
            list.Add(p);
            list.Reverse();
            this.cbotype.DisplayMember = "RTNAME";
            //this.cbotype.ValueMember = " RTID";
            string id = Comm.id;
            this.cbotype.ValueMember = "RTID";
            this.cbotype.DataSource = list;
            foreach (var item in list)
            {
                

                    ListViewItem lvi = new ListViewItem(item.RTName.ToString());

                    lvi.SubItems.Add(item.RTMount);

                    this.lv1.Items.Add(lvi);

                
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
                    Comm.name = this.lv1.SelectedItems[0].Text;
                    // MessageBox.Show(comm.name);
                    bool b = RoomTypeBLL.database(Comm.name);
                    if (b == true)
                    {
                        MessageBox.Show("成功");
                        this.lv1.Items.Clear();
                        SX();
                    }

                    else
                    {
                        MessageBox.Show("失败");
                    }
                }

            }
        }

        private void cbotype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbotype.Text == "全部")
            {
                sxx();


            }
            else
            {
                this.lv2.Items.Clear();
                int leiid = Convert.ToInt32(this.cbotype.SelectedValue);


                //string name = this.cbotype.Text;
                //// MessageBox.Show(name);
                List<Tables> listt = TablesBLL.selectid(leiid);
                foreach (var item in listt)
                {

                    ListViewItem lvi = new ListViewItem(item.TName.ToString());
                    lvi.SubItems.Add(item.idname);
                    //lvi.SubItems.Add(item.RTID);

                    lvi.SubItems.Add(item.TState);
                    lvi.SubItems.Add(item.TArea);

                    this.lv2.Items.Add(lvi);
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.lv2.SelectedItems.Count != 1) { MessageBox.Show("还没选择项"); }
            else
            {
                DialogResult a = MessageBox.Show(this, "是否删除", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (a == DialogResult.Yes)
                {
                    string id = this.lv2.SelectedItems[0].Text;
                    bool b = TablesBLL.database(id);
                    if (b == true)
                    {
                        MessageBox.Show("成功");
                        this.lv2.Items.Clear();
                        sxx();
                    }

                    else
                    {

                        MessageBox.Show("失败");
                    }
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
