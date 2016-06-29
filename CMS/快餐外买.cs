using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace CMS
{
    public partial class 快餐外买 : Form
    {
        DataSet objset;
        DataSet objdataset;        
        DataTable objtable;
        string CurrenAccount = "ygp";
        string Stime = "";
        DateTime objtime = DateTime.Now;
        string name = "";
        string moneys = "0";
        double sum = 0;
        int ty = 0;
        public 快餐外买()
        {
            Stime = objtime.ToString();
            InitializeComponent();
        }

        private void 快餐外买_Load(object sender, EventArgs e)
        {
            CMS.BLL.BookManageBLL bookBll = new BLL.BookManageBLL();
            this.dataygp();
        }
        public void dataygp()
        {
            objdataset = new DataSet();
            objtable = new DataTable("开单");
            DataColumn objcolumn = objtable.Columns.Add("项目名称", typeof(string));           
            objtable.Columns.Add("单价", typeof(string));
            objtable.Columns.Add("折扣", typeof(string));
            objtable.Columns.Add("数量", typeof(string));
            objtable.Columns.Add("金额", typeof(string));
            objtable.Columns.Add("开单时间", typeof(string));
            objtable.Columns.Add("记帐人", typeof(string));
            objdataset.Tables.Add(objtable);
            dataGridView1.DataSource = objdataset;
            dataGridView1.DataMember = "开单";
            for (int i = 0; i < 7; i++)
            {
                dataGridView1.Columns[i].Width = 80;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            //string yy = "餐牌 where 项目编号 LIKE'" + textBox2.Text + "%'";
            string yy = "Products where ProductName LIKE'%" + textBox2.Text + "%'";
            //objset = Program.DBOpertor.Getselect(yy);
            objset = CMS.BLL.BookManageBLL.Getselect(yy);
            dataGridView3.DataMember = "table";
            dataGridView3.DataSource = objset;
            panel2.Visible = true;
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //objset = Program.DBOpertor.Getselect("餐牌");
            objset = CMS.BLL.BookManageBLL.Getselect("Products");
            dataGridView3.DataSource = objset;
            dataGridView3.DataMember = "table";
            panel2.Visible = true;
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

        public void Insert()
        {
            double money = Convert.ToDouble(moneys) * Convert.ToDouble(textBox3.Text);
            sum += money;
            label4.Text = "合计金额:" + sum;
            DataRow objrow = objtable.NewRow();           
            objrow[0] = name;
            objrow[1] = moneys;
            objrow[2] = "1";
            objrow[3] = textBox3.Text;
            objrow[4] = money.ToString();
            objrow[5] = Stime;
            objrow[6] = CurrenAccount;
            objtable.Rows.Add(objrow);
            textBox2.Text="";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Insert();
            panel2.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                    label9.Text = objtable.Rows[ty][0].ToString();
                    textBox5.Text = objtable.Rows[ty][3].ToString();
                    panel3.Visible = true;              
            }
            catch (Exception)
            { }
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
                    MessageBox.Show("已添加菜品不能执行此操作!", "提示");
                }
            }
            catch (Exception)
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                double yy = (Convert.ToDouble(textBox5.Text) * Convert.ToDouble(objtable.Rows[ty][1]));
                objtable.Rows[ty][3] = textBox5.Text;
                objtable.Rows[ty][4] = yy.ToString();
                panel3.Visible = false;
            }
            catch (Exception) { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (objtable.Rows.Count != 0)
            {
                string ss = label4.Text.Substring(5);
                new POS结帐(ss, textBox1.Text, this).Show();
                
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           ty= e.RowIndex;
        }       
    }
}