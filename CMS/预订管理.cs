using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMS.BLL;

namespace CMS
{
    public partial class 预订管理 : Form
    {
        DataSet objset;
        DataSet objset1;
        DataTable objtable;
        DataSet objsettable;
        int ty = 0;
        int ty0 = 0;
        DataTable objtable0;
        DataTable objtable1;
        string rt = "0";
        string rt0 = "0";
        public 预订管理()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new 单台预订(this).Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new 批量预订(this).Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    string[] yy = { "姓名", "地址或餐台" };
                    string[] ss = { objtable.Rows[ty][0].ToString(), objtable.Rows[ty][6].ToString() };
                    //objset = Program.DBOpertor.Select("预订", yy, ss);
                    objset = CMS.BLL.BookManageBLL.Select("预订", yy, ss);
                    单台预订 objrr = new 单台预订(this);
                    objrr.Show();
                    objrr.ygpshow(objset, rt);
                    string[] yy1 = { "单台或批量" };
                    string[] ss1 = { "单台" };
                    //objset = Program.DBOpertor.Select("预订", yy1, ss1);
                    objset = CMS.BLL.BookManageBLL.Select("预订", yy1, ss1);
                    this.ygp(objset);
                }
                else
                {
                    string[] yy = { "姓名" };
                    string[] ss = { objtable0.Rows[ty0][0].ToString() };
                    //objset = Program.DBOpertor.Select("预订", yy, ss);
                    objset = CMS.BLL.BookManageBLL.Select("预订", yy, ss);
                    批量预订 objrr = new 批量预订(this);
                    objrr.Show();
                    objrr.ygpshow(objset, rt);
                }
            }
            catch (Exception) { }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (MessageBox.Show("确定要取消预订吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        string[] yy = { "姓名", "地址或餐台", "单台或批量" };
                        string[] ss = { objtable.Rows[ty][0].ToString(), objtable.Rows[ty][6].ToString(), "单台" };
                        //Program.DBOpertor.Delete("预订", yy, ss);
                        CMS.BLL.BookManageBLL.Delete("预订", yy, ss);

                        string[] yy0 = { "餐台状态" };
                        string[] ss0 = { "可供" };
                        string[] rr0 = { "餐台号" };
                        string[] ee0 = { objtable.Rows[ty][6].ToString() };
                        //Program.DBOpertor.Updata("餐房", yy0, ss0, rr0, ee0);
                        CMS.BLL.BookManageBLL.Updata("餐房", yy0, ss0, rr0, ee0);

                        string[] yy1 = { "单台或批量" };
                        string[] ss1 = { "单台" };
                        //objset = Program.DBOpertor.Select("预订", yy1, ss1);
                        objset = CMS.BLL.BookManageBLL.Select("预订", yy1, ss1);
                        this.ygp(objset);
                        MessageBox.Show("预订取消成功!", "提示");
                        ty = 0;
                    }
                }
                else
                {
                    if (MessageBox.Show("确定要取消预订吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        for (int i = 0; i < objtable1.Rows.Count; i++)
                        {
                            string[] yy0 = { "餐台状态" };
                            string[] ss0 = { "可供" };
                            string[] rr0 = { "餐台号" };
                            string[] ee0 = { objtable1.Rows[i][1].ToString() };
                            //Program.DBOpertor.Updata("餐房", yy0, ss0, rr0, ee0);
                            CMS.BLL.BookManageBLL.Updata("餐房", yy0, ss0, rr0, ee0);
                        }
                        string[] yy = { "姓名", "单台或批量" };
                        string[] ss = { objtable0.Rows[ty0][0].ToString(), "批量" };
                        //Program.DBOpertor.Delete("预订", yy, ss);                        
                        CMS.BLL.BookManageBLL.Delete("预订", yy, ss);
                        string[] yy1 = { "单台或批量" };
                        string[] ss1 = { "批量" };
                        //objset = Program.DBOpertor.Select("预订", yy1, ss1);
                        objset = CMS.BLL.BookManageBLL.Select("预订", yy1, ss1);
                        MessageBox.Show("预订取消成功!", "提示");
                    }
                }
                this.qwe0();
            }
            catch (Exception) { }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string[] yy = { "姓名", "手机", "电话" };
            string[] ss = { textBox1.Text, textBox1.Text, textBox1.Text };
            //Program.DBOpertor.ygpselect("预订",yy,ss);
            CMS.BLL.BookManageBLL.ygpselect("预订", yy, ss);
        }

        private void 预订管理_Load(object sender, EventArgs e)
        {
            CMS.BLL.BookManageBLL bm = new BLL.BookManageBLL();
            try
            {
                string[] yy = { "单台或批量" };
                string[] ss = { "单台" };
                //objset = Program.DBOpertor.Select("预订", yy, ss);
                objset = CMS.BLL.BookManageBLL.Select("预订", yy, ss);
                this.ygp(objset);
                string[] ss0 = { "批量" };
                //objset1 = Program.DBOpertor.Select("预订", yy, ss0);
                objset = CMS.BLL.BookManageBLL.Select("预订", yy, ss0);
                this.ygp0(objset);

                objsettable = new DataSet();
                objtable1 = new DataTable("表2");
                DataColumn objcolumn = objtable1.Columns.Add("RTID", typeof(string));
                objtable1.Columns.Add("TableName", typeof(string));
                objtable1.Columns.Add("TableState", typeof(int));
                objsettable.Tables.Add(objtable1);
                dataGridView2.DataSource = objsettable;
                dataGridView2.DataMember = "表2";
                for (int i = 0; i < 3; i++)
                {
                    dataGridView2.Columns[i].Width = 270;
                }
            }
            catch (Exception ex) { }
        }

        public void qwe0()
        {
            string[] yy = { "单台或批量" };
            string[] ss0 = { "批量" };
            //objset1 = Program.DBOpertor.Select("预订", yy, ss0);
            objset1 = CMS.BLL.BookManageBLL.Select("预订", yy, ss0);
            this.ygp0(objset1);
        }

        public void ygp0(DataSet objset0)
        {
            bool no = false;
            try
            {
                objsettable = new DataSet();
                objtable0 = new DataTable("表1");
                DataColumn objcolumn = objtable0.Columns.Add("姓名", typeof(string));
                objtable0.Columns.Add("联系手机", typeof(string));
                objtable0.Columns.Add("联系电话", typeof(string));
                objtable0.Columns.Add("预订日期", typeof(string));
                objtable0.Columns.Add("预订时间", typeof(string));
                objtable0.Columns.Add("状态", typeof(string));
                objtable0.Columns.Add("客户留言", typeof(string));
                objsettable.Tables.Add(objtable0);
                dataGridView1.DataSource = objsettable;
                dataGridView1.DataMember = "表1";
                for (int i = 0; i < 7; i++)
                {
                    dataGridView1.Columns[i].Width = 116;
                }
                for (int i = 0; i < objset0.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        DataRow objrow = objtable0.NewRow();
                        objrow[0] = objset0.Tables[0].Rows[i][1];
                        objrow[1] = objset0.Tables[0].Rows[i][2];
                        objrow[2] = objset0.Tables[0].Rows[i][3];
                        objrow[3] = objset0.Tables[0].Rows[i][5].ToString().Substring(0, 10);
                        objrow[4] = objset0.Tables[0].Rows[i][4];
                        objrow[5] = "已订";
                        objrow[6] = objset0.Tables[0].Rows[i][10];
                        objtable0.Rows.Add(objrow);
                        continue;
                    }
                    for (int r = 0; r < objtable0.Rows.Count; r++)
                    {
                        if (objset0.Tables[0].Rows[i][1].ToString().Equals(objtable0.Rows[r][0].ToString()))
                        {
                            no = false;
                            break;
                        }
                        no = true;
                    }
                    if (no)
                    {
                        DataRow objrow = objtable0.NewRow();
                        objrow[0] = objset0.Tables[0].Rows[i][1];
                        objrow[1] = objset0.Tables[0].Rows[i][2];
                        objrow[2] = objset0.Tables[0].Rows[i][3];
                        objrow[3] = objset0.Tables[0].Rows[i][5].ToString().Substring(0, 10);
                        objrow[4] = objset0.Tables[0].Rows[i][4];
                        objrow[5] = "已订";
                        objrow[6] = objset0.Tables[0].Rows[i][10];
                        objtable0.Rows.Add(objrow);
                    }


                }
                rt0 = objset0.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex) { }
        }

        public void ygp(DataSet objset0)
        {
            try
            {
                objsettable = new DataSet();
                objtable = new DataTable("表");
                DataColumn objcolumn = objtable.Columns.Add("姓名", typeof(string));
                objtable.Columns.Add("联系手机", typeof(string));
                objtable.Columns.Add("联系电话", typeof(string));
                objtable.Columns.Add("预订日期", typeof(string));
                objtable.Columns.Add("预订时间", typeof(string));
                objtable.Columns.Add("房间类型", typeof(string));
                objtable.Columns.Add("餐台名", typeof(string));
                objtable.Columns.Add("状态", typeof(string));
                objtable.Columns.Add("客户留言", typeof(string));
                objsettable.Tables.Add(objtable);
                dataGridView3.DataSource = objsettable;
                dataGridView3.DataMember = "表";
                for (int i = 0; i < 9; i++)
                {
                    dataGridView3.Columns[i].Width = 90;
                }
                for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
                {
                    DataRow objrow = objtable.NewRow();
                    objrow[0] = objset0.Tables[0].Rows[i][1];
                    objrow[1] = objset0.Tables[0].Rows[i][2];
                    objrow[2] = objset0.Tables[0].Rows[i][3];
                    objrow[3] = objset0.Tables[0].Rows[i][5].ToString().Substring(0, 10);
                    objrow[4] = objset0.Tables[0].Rows[i][4];
                    objrow[5] = objset0.Tables[0].Rows[i][8];
                    objrow[6] = objset0.Tables[0].Rows[i][9];
                    objrow[7] = "已订";
                    objrow[8] = objset0.Tables[0].Rows[i][10];
                    objtable.Rows.Add(objrow);
                }
                rt = objset0.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex) { }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ty = e.RowIndex;
                rt = objset.Tables[0].Rows[ty][0].ToString();
            }
            catch (Exception) { }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.ygpupdate();
        }

        public void ygpupdate()
        {
            int pp = 0;
            string[] yy = { "姓名", "手机", "电话" };
            string[] ss = { textBox1.Text, textBox1.Text, textBox1.Text };
            //objset = Program.DBOpertor.ygpselect("预订", yy, ss);
            objset = CMS.BLL.BookManageBLL.ygpselect("预订", yy, ss);
            if (tabControl1.SelectedIndex == 0)
            {
                //this.ygp(objset);
                objsettable = new DataSet();
                objtable = new DataTable("表");
                DataColumn objcolumn = objtable.Columns.Add("姓名", typeof(string));
                objtable.Columns.Add("联系手机", typeof(string));
                objtable.Columns.Add("联系电话", typeof(string));
                objtable.Columns.Add("预订日期", typeof(string));
                objtable.Columns.Add("预订时间", typeof(string));
                objtable.Columns.Add("房间类型", typeof(string));
                objtable.Columns.Add("餐台名", typeof(string));
                objtable.Columns.Add("状态", typeof(string));
                objtable.Columns.Add("客户留言", typeof(string));
                objsettable.Tables.Add(objtable);
                dataGridView3.DataSource = objsettable;
                dataGridView3.DataMember = "表";
                for (int i = 0; i < 9; i++)
                {
                    dataGridView3.Columns[i].Width = 90;
                }
                for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
                {
                    if (objset.Tables[0].Rows[i][11].Equals("单台"))
                    {
                        DataRow objrow = objtable.NewRow();
                        objrow[0] = objset.Tables[0].Rows[i][1];
                        objrow[1] = objset.Tables[0].Rows[i][2];
                        objrow[2] = objset.Tables[0].Rows[i][3];
                        objrow[3] = objset.Tables[0].Rows[i][5].ToString().Substring(0, 10);
                        objrow[4] = objset.Tables[0].Rows[i][4];
                        objrow[5] = objset.Tables[0].Rows[i][8];
                        objrow[6] = objset.Tables[0].Rows[i][9];
                        objrow[7] = "已订";
                        objrow[8] = objset.Tables[0].Rows[i][10];
                        objtable.Rows.Add(objrow);
                    }
                }
            }
            else
            {
                int uuu = 0;
                bool no = false;
                //try
                //{
                objsettable = new DataSet();
                objtable0 = new DataTable("表1");
                DataColumn objcolumn = objtable0.Columns.Add("姓名", typeof(string));
                objtable0.Columns.Add("联系手机", typeof(string));
                objtable0.Columns.Add("联系电话", typeof(string));
                objtable0.Columns.Add("预订日期", typeof(string));
                objtable0.Columns.Add("预订时间", typeof(string));
                objtable0.Columns.Add("状态", typeof(string));
                objtable0.Columns.Add("客户留言", typeof(string));
                objsettable.Tables.Add(objtable0);
                dataGridView1.DataSource = objsettable;
                dataGridView1.DataMember = "表1";
                for (int i = 0; i < 7; i++)
                {
                    dataGridView1.Columns[i].Width = 116;
                }
                for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
                {
                    if (objset.Tables[0].Rows[i][11].ToString().Equals("批量"))
                    {
                        if (uuu == 0)
                        {
                            uuu++;
                            DataRow objrow = objtable0.NewRow();
                            objrow[0] = objset.Tables[0].Rows[i][1];
                            objrow[1] = objset.Tables[0].Rows[i][2];
                            objrow[2] = objset.Tables[0].Rows[i][3];
                            objrow[3] = objset.Tables[0].Rows[i][5].ToString().Substring(0, 10);
                            objrow[4] = objset.Tables[0].Rows[i][4];
                            objrow[5] = "已订";
                            objrow[6] = objset.Tables[0].Rows[i][10];
                            objtable0.Rows.Add(objrow);
                            continue;
                        }
                        for (int r = 0; r < objtable0.Rows.Count; r++)
                        {
                            if (objset.Tables[0].Rows[i][1].ToString().Equals(objtable0.Rows[r][0].ToString()))
                            {
                                no = false;
                                break;
                            }
                            no = true;
                        }
                        if (no)
                        {
                            DataRow objrow = objtable0.NewRow();
                            objrow[0] = objset.Tables[0].Rows[i][1];
                            objrow[1] = objset.Tables[0].Rows[i][2];
                            objrow[2] = objset.Tables[0].Rows[i][3];
                            objrow[3] = objset.Tables[0].Rows[i][5].ToString().Substring(0, 10);
                            objrow[4] = objset.Tables[0].Rows[i][4];
                            objrow[5] = "已订";
                            objrow[6] = objset.Tables[0].Rows[i][10];
                            objtable0.Rows.Add(objrow);
                        }

                    }
                }
                rt0 = objset.Tables[0].Rows[0][0].ToString();
                //}
                //catch (Exception) { } 
            }
        }

        public void ygpupdate0()//查询预订的餐台
        {
            string[] yy = { "单台或批量" };
            string[] ss = { "单台" };
            //objset = Program.DBOpertor.Select("预订", yy, ss);
            objset = CMS.BLL.BookManageBLL.Select("预订", yy, ss);
            this.ygp(objset);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ty0 = e.RowIndex;
            try
            {
                string[] yy = { "姓名" };
                string[] ss = { objtable0.Rows[e.RowIndex][0].ToString() };
                //objset = Program.DBOpertor.Select("预订", yy, ss);
                objset = CMS.BLL.BookManageBLL.Select("预订", yy, ss);
                objsettable = new DataSet();
                objtable1 = new DataTable("表2");
                DataColumn objcolumn = objtable1.Columns.Add("房间类型", typeof(string));
                objtable1.Columns.Add("餐台编号", typeof(string));
                objtable1.Columns.Add("状态", typeof(string));
                objsettable.Tables.Add(objtable1);
                dataGridView2.DataSource = objsettable;
                dataGridView2.DataMember = "表2";
                for (int i = 0; i < 3; i++)
                {
                    dataGridView2.Columns[i].Width = 270;
                }
                for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
                {
                    DataRow objrow = objtable1.NewRow();
                    objrow[0] = objset.Tables[0].Rows[i][8].ToString();
                    objrow[1] = objset.Tables[0].Rows[i][9].ToString();
                    objrow[2] = "已订";
                    objtable1.Rows.Add(objrow);
                }
            }
            catch (Exception) { }
        }

        private void 预订管理_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Program.f.GetUpToDate();

        }
    }
}