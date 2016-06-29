using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace CMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TabItem tabItem = tabControl2.CreateTab("tabItem123");
            TabControlPanel tcp = new TabControlPanel(); 
            tabControl2.Controls.Add(tcp); 
            tabItem.AttachedControl = tcp; 
            tcp.TabItem = tabItem; 
            tcp.Dock = DockStyle.Fill;
            tcp.Style.BackColor1.Color = Color.FromArgb(142, 179, 231);
            tcp.Style.BackColor2.Color = Color.FromArgb(223, 237, 254);
            tcp.Style.GradientAngle = 90;
            tcp.Style.Border = eBorderType.SingleLine;
            tcp.Style.BorderColor.Color = Color.FromArgb(59, 97, 156);

            Button btn = new Button();
            btn.Text = "12312";
            tcp.Controls.Add(btn);
        }
    }
}
