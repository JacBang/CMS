using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CMS
{
    public partial class 批量预订 : Form
    {
        DataSet objset;
        string text1="";
        string text2="";
        DataSet objset0;
        DataTable objtable;
        int nom1 = 0;
        int nom2 = 0;
        int ty = 0;
        string ty0 = "0";
        预订管理 objform;
        public 批量预订(预订管理 objfor)
        {
            objform = objfor;
            InitializeComponent();
        }

        private void 批量预订_Load(object sender, EventArgs e)
        {
            CMS.BLL.BookManageBLL bm = new BLL.BookManageBLL();
            int sum=0;
            comboBox1.SelectedIndex = 0;
            //objset = Program.DBOpertor.Getselect("房间类型");
            objset = CMS.BLL.BookManageBLL.Getselect("RoomType");
            TreeNode chNode=new TreeNode ("节点");
            for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
            {
                this.treeView1.Nodes.Add(objset.Tables[0].Rows[i][1].ToString());
                this.treeView1.Nodes[i].Tag = objset.Tables[0].Rows[i]["RTID"].ToString();
                sum=i;
            }
            comboBox1.SelectedIndex = 0;
            //objset = Program.DBOpertor.Getselect("餐房");
            objset = CMS.BLL.BookManageBLL.Getselect("Tables");
            for (int j = 0; j <=sum; j++)
            {
                for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
                {                   
                    if (this.treeView1.Nodes[j].Tag.ToString().Equals(objset.Tables[0].Rows[i]["RTID"].ToString()))
                    {
                        this.treeView1.Nodes[j].Nodes.Add(objset.Tables[0].Rows[i]["TableName"].ToString());
                    }
                }
            }
            objset0 = new DataSet();
            objtable = new DataTable("table");
            objtable.Columns.Add("房间名称");
            objtable.Columns.Add("餐台编号");
            objset0.Tables.Add(objtable);
            dataGridView1.DataSource = objset0;
            dataGridView1.DataMember = "table";
            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].Width = 170;
            comboBox5.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Text = dateTimePicker1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox6.Items.Clear();
            string time0 = comboBox1.SelectedItem.ToString().Substring(3, 2);
            string time1 = comboBox1.SelectedItem.ToString().Substring(12, 2);
            int qwe0 = Convert.ToInt32(time0);
            int qwe1 = Convert.ToInt32(time1);
            for (; qwe0 <= qwe1; qwe0++)
            {
                if (qwe0 / 10 == 0)
                {
                    comboBox4.Items.Add("0" + qwe0);
                    comboBox6.Items.Add("0" + qwe0);
                }
                else
                {
                    comboBox4.Items.Add("" + qwe0);
                    comboBox6.Items.Add("" + qwe0);
                }
            }
            comboBox4.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
        }

        public void box()
        {
            if (!comboBox4.SelectedItem.ToString().Equals("06") && !comboBox4.SelectedItem.ToString().Equals("15")
                && !comboBox4.SelectedItem.ToString().Equals("10") && !comboBox4.SelectedItem.ToString().Equals("21"))
            {
                string yy = comboBox4.SelectedItem.ToString();
                string ss = comboBox6.SelectedItem.ToString();
                if (Convert.ToInt32(yy) > Convert.ToInt32(ss))
                {
                    MessageBox.Show("取消时间应迟于预抵时间!", "提示");
                    comboBox4.SelectedIndex = 0;
                }
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.box();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.box();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox5.SelectedItem.ToString().Equals("00"))
            {
                if (Convert.ToInt32(comboBox5.SelectedItem.ToString()) > Convert.ToInt32(comboBox7.SelectedItem.ToString()))
                {
                    MessageBox.Show("取消时间应迟于预抵时间!", "提示");
                    comboBox5.SelectedIndex = 0;
                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox5.SelectedItem.ToString().Equals("00"))
            {
                if (Convert.ToInt32(comboBox5.SelectedItem.ToString()) > Convert.ToInt32(comboBox7.SelectedItem.ToString()))
                {
                    MessageBox.Show("取消时间应迟于预抵时间!", "提示");
                    comboBox5.SelectedIndex = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!text1.Equals(""))
                {
                    DataRow objrow = objtable.NewRow();
                    objrow[0] = text1;
                    objrow[1] = text2;
                    objtable.Rows.Add(objrow);
                    treeView1.Nodes[nom1].Nodes[nom2].Remove();
                   
                }                
            }
            catch (Exception) { }
        }
        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                text1 = e.Node.Parent.Text;
                text2 = e.Node.Text;
                nom1 = e.Node.Parent.Index;
                nom2 = e.Node.Index;                
            }
            catch (Exception) {  }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] yy1 ={"姓名"};
            string[] ss1 ={textBox1.Text};
            //Program.DBOpertor.Delete("预订",yy1,ss1);
            CMS.BLL.BookManageBLL.Delete("预订", yy1, ss1);

            for (int i = 0; i < objtable.Rows.Count; i++)
            {
                string[] yy ={ "姓名", "手机", "电话", "预订时段", "抵达时间", "取消时间", "预订押金", "预订类型", "地址或餐台", "客户留言", "单台或批量" };
                string[] ss ={ textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString(), dateTimePicker1.Text+" "+comboBox4.SelectedItem.ToString()+":"+comboBox5.SelectedItem.ToString(),
                          dateTimePicker2.Text+" "+comboBox6.SelectedItem.ToString()+":"+comboBox7.SelectedItem.ToString(),textBox6.Text,objtable.Rows[i][0].ToString(),objtable.Rows[i][1].ToString(),textBox7.Text,"批量"};
                //Program.DBOpertor.Add("预订", yy, ss);
                CMS.BLL.BookManageBLL.Add("预订", yy, ss);
                string[] yy0 ={ "餐台状态" };
                string[] ss0 ={ "预订" };
                string[] rr0 ={ "餐台号" };
                string[] ee0 ={ objtable.Rows[i][1].ToString() };
                //Program.DBOpertor.Updata("餐房", yy0, ss0, rr0, ee0);
                CMS.BLL.BookManageBLL.Updata("餐房", yy0, ss0, rr0, ee0);
            }
            MessageBox.Show("修改成功!", "提示");
            objform.qwe0();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < objtable.Rows.Count; i++)
            {
                string[] yy ={ "姓名", "手机", "电话", "预订时段", "抵达时间", "取消时间", "预订押金", "预订类型", "地址或餐台", "客户留言", "单台或批量" };
                string[] ss ={ textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString(), dateTimePicker1.Text+" "+comboBox4.SelectedItem.ToString()+":"+comboBox5.SelectedItem.ToString(),
                          dateTimePicker2.Text+" "+comboBox6.SelectedItem.ToString()+":"+comboBox7.SelectedItem.ToString(),textBox6.Text,objtable.Rows[i][0].ToString(),objtable.Rows[i][1].ToString(),textBox7.Text,"批量"};
                //Program.DBOpertor.Add("预订", yy, ss);
                CMS.BLL.BookManageBLL.Add("预订", yy, ss);
                string[] yy0 ={ "餐台状态" };
                string[] ss0 ={ "预订" };
                string[] rr0 ={ "餐台号" };
                string[] ee0 ={ objtable.Rows[i][1].ToString() };
                //Program.DBOpertor.Updata("餐房", yy0, ss0, rr0, ee0);
                CMS.BLL.BookManageBLL.Updata("餐房", yy0, ss0, rr0, ee0);
            }
            MessageBox.Show("预订成功!", "提示");
            objform.qwe0();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!text1.Equals(""))
            {
                try
                {
                    for (int i = 0; i < treeView1.Nodes.Count; i++)
                    {
                        if (treeView1.Nodes[i].Text.Equals(text1))
                        {
                            treeView1.Nodes[i].Nodes.Add(text2);
                            objtable.Rows.RemoveAt(ty);
                            text1 = "";
                            text2 = "";
                        }
                    }
                    
                }
                catch (Exception) { }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ty = e.RowIndex;
                text1 = objtable.Rows[ty][0].ToString();
                text2 = objtable.Rows[ty][1].ToString();
            }
            catch (Exception) { }
        }

        public void ygpshow(DataSet objset,string t)
        {
            ty0 = t;
            this.button4.Visible = true;            
            this.button2.Visible = false;
            this.textBox1.Enabled = false;
            this.AcceptButton = button4;
            textBox1.Text = objset.Tables[0].Rows[0][1].ToString();
            textBox2.Text = objset.Tables[0].Rows[0][2].ToString();
            textBox3.Text = objset.Tables[0].Rows[0][3].ToString();
            comboBox1.Text = objset.Tables[0].Rows[0][4].ToString();
            dateTimePicker1.Text = objset.Tables[0].Rows[0][5].ToString().Substring(0, 10);
            dateTimePicker2.Text = dateTimePicker1.Text;
            comboBox4.Text = objset.Tables[0].Rows[0][5].ToString().Substring(11, 2);
            comboBox5.Text = objset.Tables[0].Rows[0][5].ToString().Substring(14, 2);
            comboBox6.Text = objset.Tables[0].Rows[0][6].ToString().Substring(11, 2);
            comboBox7.Text = objset.Tables[0].Rows[0][6].ToString().Substring(14, 2);            
            textBox6.Text = objset.Tables[0].Rows[0][7].ToString();
            textBox7.Text = objset.Tables[0].Rows[0][10].ToString();
            for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
            {
                DataRow objrow = objtable.NewRow();
                objrow[0] = objset.Tables[0].Rows[i][8];
                objrow[1] = objset.Tables[0].Rows[i][9];
                objtable.Rows.Add(objrow);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
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

    }
}