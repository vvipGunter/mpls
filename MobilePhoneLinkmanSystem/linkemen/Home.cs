using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace linkemen
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
        private void 修改用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdduserForm adduserfrm = new AdduserForm();
            adduserfrm.Show();
        }

        private void 修改用户密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUserPassword aaa = new UpdateUserPassword();
            aaa.Show();
        }

        private void 查看所有用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LookAllLinkmenInfo loook = new LookAllLinkmenInfo();
            loook.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
