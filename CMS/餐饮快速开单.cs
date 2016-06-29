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
    public partial class 餐饮快速开单 : Form
    {
        DataSet objset;
        DataSet objdataset;
        DataSet objset1;
        DataTable objtable;
        float sum1 = 0;
        //string CurrenAccount = Program.Admin;
        string CurrenAccount = "";
        string Stime = "";
        DateTime objtime = DateTime.Now;
        string name = "";
        string moneys = "0";
        double sum = 0;
        int ty=0;
        public 餐饮快速开单()
        {
            Stime = objtime.ToString();
            InitializeComponent();
        }     

        private void 餐饮快速开单_Load(object sender, EventArgs e)
        {
            BookManageBLL bookManageBLL = new BookManageBLL();
            this.dataGridViews1();
            this.dataygp();
            
        }

        private void textBox3_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {            
            //objset = Program.DBOpertor.Getselect("餐牌");
            objset = CMS.BLL.BookManageBLL.Getselect("Products");
            dataGridView3.DataSource = objset;
            dataGridView3.DataMember = "table";
            panel2.Visible = true;
                       
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Insert();            
            panel2.Visible = false;            
        }

        private void 餐牌BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.餐牌BindingSource.EndEdit();
            this.餐牌TableAdapter.Update(this.dieteticManagementDataSet.餐牌);

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {            
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("餐台号不能为空!", "提示");
            }
            else
            {
                string[] yy ={ "餐台号"};
                string[] ss ={ textBox1.Text };
                //objset = Program.DBOpertor.Select("餐房", yy, ss);
                objset = CMS.BLL.BookManageBLL.Select("Products", yy, ss);
                if (objset.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("没有这个餐台号!请重新输入!", "提示");
                    textBox1.Focus();
                }
                else
                {                    
                    textBox1.Enabled = false;
                    label5.Text += objset.Tables[0].Rows[0][3]+" ";
                    label5.Text += objset.Tables[0].Rows[0][2];
                    this.dataGridViews1();
                }
            }
        }

        private void 餐饮快速开单_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("此消费清单还没保存!是否保存?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.dataqwe();               
            }
        }      

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            //string yy = "餐牌 where 项目编号 LIKE'" + textBox3.Text + "%'";
            string yy = "Products where ProductID LIKE'" + textBox3.Text + "%'";
            //objset = Program.DBOpertor.Getselect(yy);
            objset = CMS.BLL.BookManageBLL.Getselect(yy);
            dataGridView3.DataMember = "table";
            dataGridView3.DataSource = objset;
            panel2.Visible = true;
            
        }


        public void Insert()
        {
            double money = Convert.ToDouble(moneys) * Convert.ToDouble(textBox4.Text);
            sum += money;
            label6.Text = "合计金额:" + sum;            

            DataRow objrow = objtable.NewRow();
            objrow[0]=textBox1.Text;
            objrow[1]=name;
            objrow[2]=moneys;
            objrow[3]="1";
            objrow[4]=textBox4.Text;
            objrow[5]=money.ToString();
            objrow[6]=Stime;
            objrow[7]=CurrenAccount;
            objtable.Rows.Add(objrow);
            textBox3.Text = "";
        }       
      

        public void dataGridViews1()
        {
            string[] yy1 ={ "TableID" };
            string[] ss1 ={ textBox1.Text};
            //objset1 = Program.DBOpertor.Select("开单", yy1, ss1);
            objset = CMS.BLL.BookManageBLL.Select("ConsumerBill", yy1, ss1);
            dataGridView1.DataSource = objset1;
            dataGridView1.DataMember = "ConsumerBill";
            //for (int i = 0; i < 8; i++)
            //{
            //    dataGridView1.Columns[i].Width = 80;
            //}
        }       
      
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                moneys = objset.Tables[0].Rows[e.RowIndex][2].ToString();
                name = objset.Tables[0].Rows[e.RowIndex][1].ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                moneys = objset.Tables[0].Rows[e.RowIndex][2].ToString();
                name = objset.Tables[0].Rows[e.RowIndex][1].ToString();
                this.Insert();
                panel2.Visible = false;
            }
            catch (Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
        public void dataygp()
        {
            objdataset = new DataSet();
            objtable = new DataTable("开单");
            DataColumn objcolumn = objtable.Columns.Add("餐台号", typeof(string));
            objtable.Columns.Add("项目名称", typeof(string));
            objtable.Columns.Add("单价", typeof(string));
            objtable.Columns.Add("折扣", typeof(string));
            objtable.Columns.Add("数量", typeof(string));
            objtable.Columns.Add("金额", typeof(string));
            objtable.Columns.Add("开单时间", typeof(string));
            objtable.Columns.Add("记帐人", typeof(string));
            objdataset.Tables.Add(objtable);
            dataGridView2.DataSource = objdataset;
            dataGridView2.DataMember = "开单";
            for (int i = 0; i < 8; i++)
            {
                dataGridView2.Columns[i].Width = 80;
            }
        }

        public void dataqwe()
        {
            for (int i = 0; i < objtable.Rows.Count; i++)
            {
                string[] yy ={ "餐台号", "项目名称", "单价", "折扣", "数量", "金额", "开单时间", "记帐人","是否已添","状态" };
                string[] ss ={ objtable.Rows[i][0].ToString(), objtable.Rows[i][1].ToString(),
                    objtable.Rows[i][2].ToString(),objtable.Rows[i][3].ToString(),objtable.Rows[i][4].ToString(),
               objtable.Rows[i][5].ToString(),objtable.Rows[i][6].ToString(),objtable.Rows[i][7].ToString(),"是","Black"};
                //Program.DBOpertor.Add("开单", yy, ss);
                CMS.BLL.BookManageBLL.Select("开单", yy, ss);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string[] yy ={ "餐台号" };
            string[] ss ={ textBox1.Text};
            //objset = Program.DBOpertor.Select("餐房", yy, ss);        
            objset = CMS.BLL.BookManageBLL.Select("Products", yy, ss);
            
                string ty = objset.Tables[0].Rows[0][2].ToString();
                if (ty.Equals("可供") || ty.Equals("预订"))
                {
                    //Program.DBOpertor.ygpupdate(textBox1.Text, "占用");
                    CMS.BLL.BookManageBLL.ygpupdate(textBox1.Text, "占用");
                }
            
            this.dataqwe();
            this.dataygp();
            this.dataGridViews1();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (tabControl1.SelectedIndex == 0)
            {
                try
                {
                    double mon = 0;
                    for (int i = 0; i < objtable.Rows.Count; i++)
                    {
                        mon += Convert.ToDouble(objtable.Rows[i][5].ToString());
                    }
                   
                    label6.Text = "合计金额:" + mon;
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    double mon = 0;
                    for (int i = 0; i < objset1.Tables[0].Rows.Count; i++)
                    {
                        mon += Convert.ToDouble(objset1.Tables[0].Rows[i][6].ToString());
                    }
                    sum1 = Convert.ToSingle(mon);
                    label6.Text = "合计金额:" + mon;

                }
                catch (Exception) { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    objtable.Rows[ty].Delete();
                }
                else
                {
                    MessageBox.Show("已添加菜品不能执行此操作!","提示");
                }
            }
            catch (Exception)
            { }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ty = e.RowIndex;
            }
            catch (Exception)
            {
                ty = -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    label9.Text = objtable.Rows[ty][1].ToString();
                    textBox5.Text = objtable.Rows[ty][4].ToString();
                    panel3.Visible = true;
                }
                else
                {
                    MessageBox.Show("已添加菜品不能执行此操作!", "提示");
                }
            }
            catch (Exception)
            { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                double yy = (Convert.ToDouble(textBox5.Text) * Convert.ToDouble(objtable.Rows[ty][2]));
                objtable.Rows[ty][4] = textBox5.Text;
                objtable.Rows[ty][5] = yy.ToString();
                panel3.Visible = false;
            }
            catch (Exception) { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button4_Click(sender, e);
            //try
            //{

                double mon = 0;
                for (int i = 0; i < objset1.Tables[0].Rows.Count; i++)
                {
                    mon += Convert.ToDouble(objset1.Tables[0].Rows[i][6].ToString());
                }
                sum1 = Convert.ToSingle(mon);
                label6.Text = "合计金额:" + mon;
            //}
            //catch (Exception) { }
            
            //结账界面
            //new frmCheckOut(textBox1.Text, sum1, DateTime.Now.ToString()).Show();
        }

      
    }
}