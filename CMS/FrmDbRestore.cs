using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMS
{
    public partial class FrmDbRestore : DevComponents.DotNetBar.Office2007Form
    {
        public FrmDbRestore()
        {
            this.EnableGlass = false; 
            InitializeComponent();
        }

        //数据库恢复
        public static void DbRestore(string openfilepath)
        {
            SQLDMO.Restore oRestore = new SQLDMO.RestoreClass();
            SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
            try
            {
                oSQLServer.LoginSecure = true;
                oSQLServer.Connect(".", "", "");
                oRestore.Action = SQLDMO.SQLDMO_RESTORE_TYPE.SQLDMORestore_Database;
                oRestore.Database = "FoodManage_database";
                oRestore.Files = openfilepath;
                oRestore.FileNumber = 1;
                oRestore.ReplaceDatabase = true;
                oRestore.SQLRestore(oSQLServer);
            }
            catch
            {
                throw;
            }
            finally
            {
                oSQLServer.DisConnect();
            }
        }

        private void bt_open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "备份文件(*.bak)|*.xls|所有文件(*.*)|*.*"; ;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string openfilepath = openFileDialog1.FileName;
                tb_openpath.Text = openfilepath;
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if(tb_openpath.Text=="")
            {
                MessageBox.Show("读取路径错误！/(ㄒoㄒ)/~~ ");
                return;
            }
            DbRestore(tb_openpath.Text.Trim());
        }

        private void bt_esc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
