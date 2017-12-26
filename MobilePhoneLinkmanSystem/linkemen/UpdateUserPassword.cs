using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace linkemen
{
    public partial class UpdateUserPassword : Form
    {
        public UpdateUserPassword()
        {
            InitializeComponent();
        }

        private void UpdateUserPassword_Load(object sender, EventArgs e)
        {
            textBox3.Text = "gunter";
            textBox3.Enabled = false;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool FLAG = false;
            string pwd = textBox1.Text.Trim();
            string newpwd = textBox2.Text.Trim();
            if (pwd == "" || newpwd == "")
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            if (!pwd.Equals(newpwd))
            {
                MessageBox.Show("前后密码不一致！");
                return;
            }
            FLAG = new UserManager().UpdateUserPassWordByUserID("gunter", newpwd);
            if (FLAG)
            {
                MessageBox.Show("修改密码成功！");
            }
        }
    }
}
