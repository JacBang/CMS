using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMS.BLL;
using CMS.Model;
using System.IO;

namespace CMS
{
    public partial class TuiCaichaxunFrm : Form
    {
        public TuiCaichaxunFrm()
        {
            InitializeComponent();
        }

        //private ConsumerDetailManager cm = new ConsumerDetailManager();
        private void TuiCaichaxunFrm_Load(object sender, EventArgs e)
        {
          
        }
       
        //查询
        string startTime=null ;
        string stopTime=null ;
        private void btnShaomiao_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                if (mktStartTime.Text == "  :" || mktStopTime.Text == "  :")
                {
                    startTime = dtpStartTime.Text+" "+"0:0:00.000";
                    stopTime=dtpStopTime.Text+" "+"0:0:00.000";
                }
                else
                {
                    startTime = dtpStartTime.Text+" "+mktStartTime.Text;
                    stopTime = dtpStopTime.Text+" "+mktStopTime.Text;
                }
                lvTuicaichaxun.Items.Clear();
                
                //List<ConsumerDetailandPidServices> lstconn = cm.LstTuiCai(startTime, stopTime);
                //if (lstconn.Count == 0)
                //{
                //    MessageBox.Show("此范围内没有你要查的数据");
                //    return;
                //}
                //else
                //{
                //    foreach (ConsumerDetailandPidServices consum in lstconn)
                //    {
                //        ListViewItem lv = new ListViewItem(consum.ProductType);
                //        lv.SubItems.Add(consum.ProductName1);
                //        lv.SubItems.Add(consum.CdAmount.ToString());
                //        lv.SubItems.Add(consum.CdDate.ToString());
                //        lvTuicaichaxun.Items.Add(lv);
                //    }
                //}
            }
            catch (Exception )
            {
                MessageBox.Show("系统升级中。。。。。请等待");
            }          
        }
        /// <summary>
        /// 打印退菜信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvTuicaichaxun.SelectedItems.Count > 0)
                {
                    FileStream file = new FileStream("F://tuicai.txt", FileMode.Create);
                    StreamWriter writer = new StreamWriter(file);
                    //writer.WriteLine("                     ********" + Helper.Biaoti + "*******");
                    writer.WriteLine("                     ********" + "标题" + "*******");
                    writer.WriteLine();
                    writer.WriteLine("             　　　　　　　退菜情况如下：");
                    int count = 0;
                    foreach (ListViewItem lv in lvTuicaichaxun.Items)
                    {
                        string s = lv.SubItems[0].Text;
                        string s2 = lv.SubItems[1].Text;
                        string s3 = lv.SubItems[2].Text;
                        string s4 = lv.SubItems[3].Text;

                        writer.WriteLine();
                        writer.WriteLine("                    -----" + count + "------");
                        writer.WriteLine();
                        writer.WriteLine("                       　　项目类别: " + s);
                        writer.WriteLine();
                        writer.WriteLine("                      　　 项目名称: " + s2);
                        writer.WriteLine();
                        writer.WriteLine("                       　　退出数量: " + s3 + " 个");
                        writer.WriteLine();
                        writer.WriteLine("                      　　 退菜时间: " + s4);
                        writer.WriteLine();

                        
                        writer.Flush();
                        count++;

                    }
                    writer.WriteLine("                   -----**====**====**------------");
                    writer.WriteLine("                           时间范围:" + startTime + " 至 " + stopTime);
                    writer.WriteLine("                           打印时间: " + DateTime.Now.ToString());
                    writer.Close();
                    file.Close();
                }
                MessageBox.Show("打印成功,请到F盘查看","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("系统繁忙,请稍候打印","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}