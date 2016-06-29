using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CMS
{
    public partial class POS结帐 : Form
    {
        快餐外买 f;
        string money="";
        string nomber = "";
        public POS结帐(string money1,string nomber1,快餐外买 f)
        {
            money = money1;
            nomber = nomber1;
            InitializeComponent();
            this.f = f;
        }

        private void POS结帐_Load(object sender, EventArgs e)
        {
            label2.Text = nomber;
            label4.Text = money;
            label6.Text = money;
            label8.Text = money;
            textBox1.Text = money;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9';
            if (e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            double yy = Convert.ToDouble(textBox1.Text) - Convert.ToDouble(money);
            label12.Text = yy.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f.dataGridView1.DataSource = null;
            f.dataygp();
            this.Close();
        }
    }
}