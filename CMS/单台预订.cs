using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CMS
{
    public partial class 单台预订 : Form
    {
        DataSet objset;
        string ty = "0";
        预订管理 objform;
        public 单台预订(预订管理 objfor)
        {
            objform = objfor;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("客户姓名不能为空!", "提示");
            }
            else
            {
                string[] yy ={ "地址或餐台" };
                //string[] ss ={ comboBox3.SelectedItem.ToString() };
                string[] ss = { comboBox3.Text.ToString() };
                //objset = Program.DBOpertor.Select("预订", yy, ss);
                objset = CMS.BLL.BookManageBLL.Select("预订", yy, ss);
                if (objset.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
                    {
                        if (objset.Tables[0].Rows[i][4].ToString().Equals(comboBox1.SelectedItem.ToString()) && objset.Tables[0].Rows[i][5].ToString().Substring(0, 10).Equals(dateTimePicker1.Text))
                        {
                            MessageBox.Show("这餐台在这个时段有人预订了!", "提示");
                            break;
                        }
                        else
                        {
                            this.mmm();
                        }
                    }
                }
                else
                {
                    this.mmm();
                }
            }
        }

        public void mmm()
        {
            string[] yy ={ "姓名", "手机", "电话", "预订时段", "抵达时间", "取消时间", "预订押金", "预订类型", "地址或餐台", "客户留言", "单台或批量" };
            string[] ss ={ textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString(), dateTimePicker1.Text+" "+comboBox4.SelectedItem.ToString()+":"+comboBox5.SelectedItem.ToString(),
                          dateTimePicker2.Text+" "+comboBox6.SelectedItem.ToString()+":"+comboBox7.SelectedItem.ToString(),textBox6.Text,comboBox2.Text.ToString(),comboBox3.Text.ToString(),textBox7.Text,"单台"};
            //Program.DBOpertor.Add("预订", yy, ss);
            CMS.BLL.BookManageBLL.Add("预订", yy, ss);
            string[] yy0 ={"TableState"};
            string[] ss0 ={"2"};
            string[] rr0 ={ "TableName" };
            string[] ee0 ={ comboBox3.Text.ToString()};
            //Program.DBOpertor.Updata("餐房",yy0,ss0,rr0,ee0);
            CMS.BLL.BookManageBLL.Updata("RoomType", yy0, ss0, rr0, ee0);
            MessageBox.Show("预订成功!","提示");
            objform.ygpupdate0();
            this.Close();
        }

        private void 单台预订_Load(object sender, EventArgs e)
        {
            CMS.BLL.BookManageBLL bm = new BLL.BookManageBLL();
          //objset=  Program.DBOpertor.Getselect("房间类型");
            objset = CMS.BLL.BookManageBLL.Getselect("RoomType");
                        
            comboBox2.DataSource = objset.Tables[0];
            comboBox2.DisplayMember = "RTName";
            comboBox2.ValueMember = "RTID";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            
            //for(int i=0;i<objset.Tables[0].Rows.Count;i++)
            //{
            //    comboBox2.Items.Add(objset.Tables[0].Rows[i][1]);
            //}
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = null;
            string[] yy = { "RTID" };
            string[] ss = { comboBox2.SelectedValue.ToString() };
            //objset = Program.DBOpertor.Select("餐房",yy,ss);
            objset = CMS.BLL.BookManageBLL.Select("Tables", yy, ss);
            //for (int i = 0; i < objset.Tables[0].Rows.Count; i++)
            //{
            //    comboBox3.Items.Add(objset.Tables[0].Rows[i][0]);
            //}
            comboBox3.DataSource = objset.Tables[0];
            comboBox3.DisplayMember = "TableName";
            comboBox3.ValueMember = "TableId";
            comboBox3.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox6.Items.Clear();
           string time0= comboBox1.SelectedItem.ToString().Substring(3,2);
            string time1=comboBox1.SelectedItem.ToString().Substring(12,2);
            int qwe0=Convert.ToInt32(time0);
            int qwe1=Convert.ToInt32(time1);
           for(;qwe0<=qwe1;qwe0++)
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.box();     
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

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.box();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           dateTimePicker2.Text= dateTimePicker1.Text;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
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
        public void ygpshow(DataSet objset,string t)
        {
            ty = t;
            this.button4.Visible = true;
            this.button1.Visible = false;
            this.button2.Visible = false;
            this.textBox1.Enabled = false;
            this.AcceptButton = button4;
            textBox1.Text = objset.Tables[0].Rows[0][1].ToString();
            textBox2.Text = objset.Tables[0].Rows[0][2].ToString();
            textBox3.Text = objset.Tables[0].Rows[0][3].ToString();
            comboBox1.Text = objset.Tables[0].Rows[0][4].ToString();
            dateTimePicker1.Text = objset.Tables[0].Rows[0][5].ToString().Substring(0,10);
            dateTimePicker2.Text = dateTimePicker1.Text;
            comboBox4.Text = objset.Tables[0].Rows[0][5].ToString().Substring(11, 2);
            comboBox5.Text = objset.Tables[0].Rows[0][5].ToString().Substring(14, 2);
            comboBox6.Text = objset.Tables[0].Rows[0][6].ToString().Substring(11, 2);
            comboBox7.Text = objset.Tables[0].Rows[0][6].ToString().Substring(14, 2);
            comboBox2.Text = objset.Tables[0].Rows[0][8].ToString();
            comboBox3.Text = objset.Tables[0].Rows[0][9].ToString();
            textBox6.Text = objset.Tables[0].Rows[0][7].ToString();
            textBox7.Text = objset.Tables[0].Rows[0][10].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要修改吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string[] yy ={ "手机", "电话", "预订时段", "抵达时间", "取消时间", "预订押金", "预订类型", "地址或餐台", "客户留言", "单台或批量" };
                string[] ss ={textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString(), dateTimePicker1.Text+" "+comboBox4.SelectedItem.ToString()+":"+comboBox5.SelectedItem.ToString(),
                          dateTimePicker2.Text+" "+comboBox6.SelectedItem.ToString()+":"+comboBox7.SelectedItem.ToString(),textBox6.Text,comboBox2.SelectedItem.ToString(),comboBox3.SelectedItem.ToString(),textBox7.Text,"单台"};
                string[] rr ={ "预订编号" };
                string[] ee ={ ty };
                //Program.DBOpertor.Updata("预订", yy, ss, rr, ee);
                CMS.BLL.BookManageBLL.Updata("预订", yy, ss, rr, ee);
                MessageBox.Show("修改成功!","提示");
                objform.ygpupdate();
                this.Close();
            }
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
            new 批量预订(new 预订管理() ).Show();
        }
        
    }
}