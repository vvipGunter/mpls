using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using new 
using BLL;

namespace linkemen
{
    public partial class AdduserForm : Form
    {
        public AdduserForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)  //刚开始绑定，只读，现在变为可修改
        {
            //不可操作
            textBox1.Enabled =false;
            textBox2.Enabled = false;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
              
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string userid = textBox1.Text.Trim();
            int maxlinkmennum = Convert.ToInt32(textBox3.Text.Trim());
            int maxgroupnum =Convert.ToInt32(textBox4.Text.Trim());
            string realname = textBox5.Text.Trim();
            flag = new UserManager().UpdateUserInfoByUserID(userid,maxlinkmennum,maxgroupnum,realname);
            if (flag)
            {
                Bingding();
                MessageBox.Show("成功保存！");

            }

        }

        private void AdduserForm_Load(object sender, EventArgs e)
        {
              //不可操作
              textBox1.Enabled=false;
              textBox2.Enabled=false;
              textBox3.Enabled=false;
              textBox4.Enabled=false;
              textBox5.Enabled=false;
            //绑定
              Bingding();
        }
        private void Bingding()
        {
            string userid = "gunter";
            DataTable dt = new DataTable();
            dt = new UserManager().SelectUserByUserID(userid);
            //绑定字段
            textBox1.Text = dt.Rows[0]["UserID"].ToString();
            textBox2.Text = dt.Rows[0]["PassWord"].ToString();
            textBox3.Text = dt.Rows[0]["MAXlinkmenNum"].ToString();
            textBox4.Text = dt.Rows[0]["MaxGroupNum"].ToString();
            textBox5.Text = dt.Rows[0]["RealName"].ToString();
        }
    }
}
