using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMS.Model;

namespace CMS
{
    public partial class FrmBill : DevComponents.DotNetBar.Office2007Form
    {
        public FrmBill()
        {
            this.EnableGlass = false; 
            InitializeComponent();
        }
        public Tables table { get; set; }
        public Admins admin { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {//取消添加 关闭窗体
            this.Close();
        }

        private void txtsum_KeyPress(object sender, KeyPressEventArgs e)
        {//人数输入判断  非数字阻止输入 判断人数是否相符
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
            if (this.txtsum.Text.Length > 2&&e.KeyChar!=8)
                e.Handled = true;

        }

        private void FrmBill_Load(object sender, EventArgs e)
        {//窗体加载时显示餐台信息 默认选中添加消费
            this.lblTName.Text = table.TName;
            List<String> list = CMS.BLL.RoomTypeBLL.Select(table.TID.ToString());
            this.lblRName.Text = list[0];
            this.cbbool.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {//确定添加
            String ZDID = null;
            if (this.txtsum.Text == "")
            {
                MessageBox.Show(this,"请输入顾客人数!","提示");
                return;
            }
            //添加账单并且添加消费
            if (this.txtsum.Text != "" && this.cbbool.Checked == true)
            {
                String cbid = CMS.BLL.ConsumerBillBLL.SelectCBID();
                //判断月份
                String mm = cbid.Substring(6, 2);
                String tmm = DateTime.Now.ToString("MM");
                if (mm == tmm)
                {//在同一月份分
                    String lsh = cbid.Substring(10, 4);
                    int id = int.Parse(lsh) + 1;
                    lsh = id.ToString().PadLeft(4, '0');
                    ZDID = "ZD" + DateTime.Now.ToString("yyyyMMdd") + lsh;
                }
                else
                {//不在同一月份
                    ZDID = "ZD" + DateTime.Now.ToString("yyyyMMdd") + "0000";
                }

                //判断是否是会员与折扣率
                String vipid = "";
                String CBD = "";
                if (this.txtvipid.Text == "")
                {
                    vipid = "-1";
                    CBD = "1";
                }
                else
                {//判断会员是否存在 如果存在获取折扣率
                    vipid = this.txtvipid.Text;
                    if (CMS.BLL.VipsBLL.SelectID(vipid) == true)
                        CBD = CMS.BLL.VipsBLL.SelectCBD(vipid);
                    else
                    {
                        MessageBox.Show(this, "会员不存在,请核对后输入!", "提示");
                        return;
                    }
                }
                if (this.txtsum.Text == "0")
                {
                    MessageBox.Show(this, "请输入正确的顾客人数!", "提示");
                    return;
                }
                //增加账单
                Boolean b = CMS.BLL.ConsumerBillBLL.InsertALL(ZDID, table.TID, this.txtsum.Text, vipid, CBD, DateTime.Now.ToString(), admin.UserID, "0", "0");
                if (true == b)
                {
                    //MessageBox.Show(this, "开单成功!", "提示");
                    //将餐桌改为占用
                    Boolean boo = CMS.BLL.TablesBLL.UPdate(table.TID, "1");
                    if (boo == true)
                    {//完成显示添加消费 关闭当前窗体
                        FrmAddConsumer frm = new FrmAddConsumer();
                        frm.Zd = ZDID;
                        frm.Ct = table.TName;
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "出现错误,请重新开单!", "提示");
                    }
                }
                else
                    MessageBox.Show(this, "出现错误,请重新开单!", "提示");

            }
            else
            {
                String cbid = CMS.BLL.ConsumerBillBLL.SelectCBID();
                //判断月份
                String mm = cbid.Substring(6, 2);
                String tmm = DateTime.Now.ToString("MM");
                if (mm == tmm)
                {//在同一月份分
                    String lsh = cbid.Substring(10, 4);
                    int id = int.Parse(lsh) + 1;
                    lsh = id.ToString().PadLeft(4, '0');
                    ZDID = "ZD" + DateTime.Now.ToString("yyyyMMdd") + lsh;
                }
                else
                {//不在同一月份
                    ZDID = "ZD" + DateTime.Now.ToString("yyyyMMdd") + "0000";
                }

                //判断是否是会员与折扣率
                String vipid = "";
                String CBD = "";
                if (this.txtvipid.Text == "")
                {
                    vipid = "-1";
                    CBD = "1";
                }
                else
                {//判断会员是否存在 如果存在获取折扣率
                    vipid = this.txtvipid.Text;
                    if (CMS.BLL.VipsBLL.SelectID(vipid) == true)
                        CBD = CMS.BLL.VipsBLL.SelectCBD(vipid);
                    else
                    {
                        MessageBox.Show(this, "会员不存在,请核对后输入!", "提示");
                        return;
                    }
                }
                if (this.txtsum.Text == "0")
                {
                    MessageBox.Show(this, "请输入正确的顾客人数!", "提示");
                    return;
                }
                //增加账单
                Boolean b = CMS.BLL.ConsumerBillBLL.InsertALL(ZDID, table.TID, this.txtsum.Text, vipid, CBD, DateTime.Now.ToString(), admin.UserID, "0", "0");
                if (true == b)
                {
                    //MessageBox.Show(this, "开单成功!", "提示");
                    //将餐桌改为占用
                    Boolean boo = CMS.BLL.TablesBLL.UPdate(table.TID, "1");
                    if (boo == true)
                    {//完成显示添加消费 关闭当前窗体
                        MessageBox.Show("开单成功!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "出现错误,请重新开单!", "提示");
                    }
                }
                else
                    MessageBox.Show(this, "出现错误,请重新开单!", "提示");
            }
        }

        private void cbvip_CheckedChanged(object sender, EventArgs e)
        {//是否会员
            if (this.cbvip.Checked == true)
            {
                this.txtvipid.ReadOnly = false;
            }
            else
            {
                this.txtvipid.ReadOnly = true;
                this.txtvipid.Text = "";
            }
        }

        private void txtsum_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtvipid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
            if (this.txtvipid.Text.Length >= 9&& e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
