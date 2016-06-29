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
    public partial class FrmChangeTable : DevComponents.DotNetBar.Office2007Form
    {
        public FrmChangeTable()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        public Tables table { get; set; }
        public Admins admin { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //取消添加 关闭窗体
            this.Close();
        }

        private void FrmChangeTable_Load(object sender, EventArgs e)
        {
            this.tbOldName.Text = table.TName;            
            this.cboArea.Text = "一楼";
            List<RoomType> list = RoomTypeBLL.selectall();
            this.cboRoomType.DisplayMember = "RTNAME";
            string id = Comm.id;
            this.cboRoomType.ValueMember = "RTID";
            //  this.cboRlou.DisplayMember = "TableArea";
            this.cboRoomType.DataSource = list;            
        }

        private void cboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingCboChangeTable();
        }

        private void BindingCboChangeTable()
        {
            this.cboChangeTable.DataSource = null;
            List<RoomType> changeTableList = TablesBLL.ChangeTable(Convert.ToInt32(this.cboRoomType.SelectedValue), this.cboArea.Text.ToString());
            this.cboChangeTable.DisplayMember = "RTName";
            this.cboChangeTable.ValueMember = "RTID";
            this.cboChangeTable.DataSource = changeTableList;
        }

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingCboChangeTable();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboRoomType.Text == "")
            {
                MessageBox.Show("请选择房间类型！");
            }
            else if (cboArea.Text == "")
            {
                MessageBox.Show("请选择所在区域！");
            }
            else if (cboChangeTable.Text == "")
            {
                MessageBox.Show("请选择更换餐桌！");
            }
            else
            {
                string tableId = this.cboChangeTable.SelectedValue.ToString();
                string oldTableId = table.TID.ToString();
                #region 这里应该写一个事务，可以回滚
                //查看旧餐台的账单号
                string cbId = BLL.ConsumerBillBLL.SelectCBID(oldTableId);
                //把旧餐台的详细物品放到新的餐台
                bool change = BLL.ConsumerBillBLL.ChangeTable(cbId, tableId);
                //改变新旧餐台的状态
                bool change1 = BLL.TablesBLL.UPdate(oldTableId, "0");
                bool change2 = BLL.TablesBLL.UPdate(tableId, table.TState);
                #endregion                

                if (change)
                {
                    //MessageBox.Show("餐桌"+this.tbOldName.Text+" 更换到餐桌"+this.cboChangeTable.Text.ToString()+" ,已成功。");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("换桌失败!");
                }
            }
        }


    }
}
