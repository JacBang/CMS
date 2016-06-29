using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CMS
{
    public partial class FrmDbBackUp : DevComponents.DotNetBar.Office2007Form
    {
        public FrmDbBackUp()
        {
            this.EnableGlass = false; 
            InitializeComponent();
        }

        //数据库备份
        public static void DbBackup(string savefilepath)
        {
            SQLDMO.Backup oBackup = new SQLDMO.BackupClass();
            SQLDMO.SQLServer oSQLServer = new SQLDMO.SQLServerClass();
            try
            {
                oSQLServer.LoginSecure = true;
                oSQLServer.Connect(".", "sa", "sa");//服务器名、账号、密码
                oBackup.Action = SQLDMO.SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
                oBackup.Database = "EatingTradDB";
                oBackup.Files = savefilepath;
                oBackup.BackupSetName = "EatingTradDB";
                oBackup.BackupSetDescription = "数据库备份";
                oBackup.Initialize = true;
                oBackup.SQLBackup(oSQLServer);
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

        private void bt_save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "备份文件(*.bak)|*.xls|所有文件(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savepath = saveFileDialog1.FileName;
                tb_savepath.Text = savepath;
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if ( tb_savepath.Text=="")
            {
                MessageBox.Show("保存路径错误！/(ㄒoㄒ)/~~ ");
                return;
            }
            DbBackup(tb_savepath.Text);            
        }

        private void bt_esc_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
