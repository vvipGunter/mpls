using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using System.Web;
using System.Xml.XPath;
using System.Xml.Xsl;
//using new
using DAL;
using BLL;
using JZHQLibrary.Controls;
using System.Xml;
using System.Threading;

namespace linkemen
{
    public partial class commonlogin : Form
    {
        public commonlogin()
        {
            InitializeComponent();
        }
        //定义变量
        XmlDocument doc;
        XmlNode xmlnode;
        XmlElement xmlelem;
        XmlElement xmlelem2;
        private void ShowHomeForm()
        {
            Application.Run(new Home());
        }
        private void btnLogin_Click(object sender, EventArgs e)   //普通用户登陆
        {
            bool flag = false;
            UserManager myusermanger = new UserManager();
            string username = txtUserID.Text.Trim();
            string pwd = txtPassWord.Text.Trim();
            if (username == "" || pwd == "")
            {
                ShowDefineMSG(" 用户名或密码为空！");
                return;
            }

            flag=myusermanger.IsUsereExists(username,pwd);
            if (flag)
            {
                //建立一个线程，他的作用是打开(HomeForm)窗口
                Thread mythread = new Thread(new ThreadStart(ShowHomeForm));
                if (mythread.ThreadState == ThreadState.Unstarted)
                {
                    mythread.Start();
                    //MessageBox.Show("Login success!");
                    //保存信息到Session以便随时使用


                    SaveToXML();
                    //AddUserToXML();
                    //结束当前进程，就是关闭登陆窗口，这里不用Hide，直接退出进程
                    Application.Exit();
                }
                else
                {
                    ShowDefineMSG("程序已经在运行！");
                }
            }
            else
            {
                ShowDefineMSG("用户名或密码错误，不能让您登陆！");
            }
          
        }
        private void temp()
        {
            //XmlDocument doc = new XmlDocument();

            //XmlElement prentnode = doc.CreateElement("userinfolist");

            //XmlElement ele1 = doc.CreateElement("username");
            //ele1.InnerText = username;

            //prentnode.AppendChild(ele1);
            //doc.AppendChild(prentnode);

            //doc.Save("userinfo.xml");
        }
        private void CreateXML()    //创建xml 保存用户信息
        {
             doc = new XmlDocument();
            //加入XML的声明段落
             //string xmlnodetype = "<? version='1.0' encoding='UTF-8' standalone='yes' ?>";
             
             //XmlNodeType xmlnodetype = new XmlNodeType();
            // xmlnode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");

            //doc.AppendChild(xmlnode);
            //加入一个根元素

            xmlelem = doc.CreateElement("", "userinfolist", "");
            doc.AppendChild(xmlelem);
            //加入另外一个元素
            xmlelem2 = doc.CreateElement("user");

            XmlElement ele3 = doc.CreateElement("username");
            ele3.InnerText = "aaa";
            xmlelem2.AppendChild(ele3);

            xmlelem.AppendChild(xmlelem2);

           //doc.ChildNodes.Item(1).AppendChild(xmlelem2);
            //保存创建好的XML文档
            doc.Save("D:/userinfo.xml");
        }       
        //加载xml
        private void LoadXML()
        {
            doc = new XmlDocument();
            doc.LoadXml("D:/userinfo.xml");

        }         
        private void SaveToXML()        //登陆成功则将用户信息保存到xml文件
        {
            //doc = new XmlDocument();
            //XmlNode root = doc.DocumentElement;
            //XmlElement myuser = doc.CreateElement("user");
            //XmlElement myusername = doc.CreateElement("username");
            //myusername.InnerText = txtUserID.Text.Trim();
            //myuser.AppendChild(myusername);
            //root.AppendChild(myuser);
            //doc.Save("C:/userinfo.xml");


            doc = new XmlDocument();
            //加入XML的声明段落
            //string xmlnodetype = "<? version='1.0' encoding='UTF-8' standalone='yes' ?>";

            ////XmlNodeType xmlnodetype = new XmlNodeType();
            // xmlnode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");

            //doc.AppendChild(xmlnode);
            //加入一个根元素

            xmlelem = doc.CreateElement("", "userinfolist", "");
            doc.AppendChild(xmlelem);
            //加入另外一个元素
            xmlelem2 = doc.CreateElement("user");

            XmlElement ele3 = doc.CreateElement("username");
           if(txtUserID.Text.Trim()=="")
               ele3.InnerText="";
            else 
               ele3.InnerText=txtUserID.Text.Trim();
            xmlelem2.AppendChild(ele3);

            xmlelem.AppendChild(xmlelem2);

            //doc.ChildNodes.Item(1).AppendChild(xmlelem2);
            //保存创建好的XML文档
            doc.Save("D:/userinfo.xml");
        }
        private void AddUserToXML()             //???根级别上的数据无效
        {
            doc = new XmlDocument();
            doc.LoadXml("D:/userinfo.xml");     

            XmlNode root = doc.DocumentElement;
            XmlElement myuser = doc.CreateElement("user");

            XmlElement myuserID = doc.CreateElement("userID");
            myuserID.InnerText = txtUserID.Text.Trim().ToLower();
            myuser.AppendChild(myuserID);

            root.AppendChild(myuser);
            doc.Save("D:/userinfo.xml");
        }
        private void ShowDefineMSG(string strMSG)
        {
            MessageBox.Show(strMSG);
        }
        private void btnCancel_Click(object sender, EventArgs e) //取消
        {
            txtPassWord.Text = txtUserID.Text = "";
        }

        private void commonlogin_Load(object sender, EventArgs e)
        {
            //CreateXML();
        }
    }
}
