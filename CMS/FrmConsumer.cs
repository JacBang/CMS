using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 商品消费查询.Model;
using CMS.BLL;

namespace 商品消费查询
{
    public partial class FrmConsumer : DevComponents.DotNetBar.Office2007Form
    {
        public FrmConsumer()
        {
            this.EnableGlass = false; 
            InitializeComponent();
        }

        private void FrmConsumer_Load(object sender, EventArgs e)
        {
            //让时间赋值为一天前
            DateTime yestoday = DateTime.Now.AddDays(-1);
            this.dtg.Text = yestoday.ToString("yyyy-MM-dd");
            //获取数据
            string name = this.txts.Text;
            DateTime now1 = this.dtg.Value;
            DateTime now2 = this.dte.Value;
            this.cbos.SelectedIndex = 0;
            //在加载的时候显示全部
            List<ConsumerDetails> list = CDBLL.Select(now1 .ToString (),now2 .ToString ());
            foreach (var item in list)
            {
                ListViewItem lvi = new ListViewItem(item.Tname .ToString () );
                lvi.SubItems.Add(item.Pname  .ToString ());
                lvi.SubItems.Add(item.CDPrice .ToString ());
                lvi.SubItems.Add(item.CDAmount .ToString ());
                lvi.SubItems.Add(item.CDDate .ToString ());
                this.lv.Items.Add(lvi );
            }

 
        }

        private void btns_Click(object sender, EventArgs e)
        {
            //获取数据
              string name = this.txts.Text;
              DateTime now1 = this.dtg.Value;
              DateTime now2 = this.dte.Value;

            
            //如果下标等于零就查询全部
              if (cbos.SelectedIndex == 0)
              {
                  this.lv.Items.Clear();
                  List<ConsumerDetails> list = CDBLL.Select(now1.ToString(), now2.ToString());
                  foreach (var item in list)
                  {
                      ListViewItem lvi = new ListViewItem(item.Tname.ToString());
                      lvi.SubItems.Add(item.Pname.ToString());
                      lvi.SubItems.Add(item.CDPrice.ToString());
                      lvi.SubItems.Add(item.CDAmount.ToString());
                      lvi.SubItems.Add(item.CDDate.ToString());
                      this.lv.Items.Add(lvi);
                  }
              }
               //如果下标等于一就根据餐台号查询
              else if (cbos.SelectedIndex == 1)
              {

                  this.lv.Items.Clear();
                  List<ConsumerDetails> list = CDBLL.SelectbyTname(now1.ToString () ,now2.ToString () ,name );
                  foreach (var item in list)
                  {
                      ListViewItem lvi = new ListViewItem(item.Tname.ToString());
                      lvi.SubItems.Add(item.Pname.ToString());
                      lvi.SubItems.Add(item.CDPrice.ToString());
                      lvi.SubItems.Add(item.CDAmount.ToString());
                      lvi.SubItems.Add(item.CDDate.ToString());
                      this.lv.Items.Add(lvi);
                  }
              }
                  //如果下标等于二就根据消费项目查询
              else if (cbos.SelectedIndex == 2)
              {

                  this.lv.Items.Clear();
                  List<ConsumerDetails> list = CDBLL.SelectbyPname(now1.ToString () ,now2.ToString (),name);
                  foreach (var item in list)
                  {
                      ListViewItem lvi = new ListViewItem(item.Tname.ToString());
                      lvi.SubItems.Add(item.Pname.ToString());
                      lvi.SubItems.Add(item.CDPrice.ToString());
                      lvi.SubItems.Add(item.CDAmount.ToString());
                      lvi.SubItems.Add(item.CDDate.ToString());
                      this.lv.Items.Add(lvi);
                  }
              }

        }

        private void btnd_Click(object sender, EventArgs e)
        {
            if (this.lv.SelectedItems.Count >= 1)
                MessageBox.Show("打印成功");
            else
                MessageBox.Show("没有数据");
        }

        private void cbos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果下拉框的下标等于零 就让文本框置灰
            if (cbos.SelectedIndex == 0)
                this.txts.ReadOnly = true;
            else
                this.txts.ReadOnly = false;
            
        }
    }
}
