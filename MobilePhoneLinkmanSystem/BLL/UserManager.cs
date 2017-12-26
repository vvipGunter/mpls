using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class UserManager
    {
        private UserDAO udao = null;
        public UserManager()
        {
            udao = new UserDAO();
        }
        public bool IsUsereExists(string userid, string pwd)
        {
            return udao.IsUsereExists(userid, pwd);
        }
        public DataTable SelectUserByUserID(string userid)
        {
            return udao.SelectUserByUserID(userid);
        }
        public bool UpdateUserInfoByUserID(string userid, int maxlinkmennum, int maxgroupnum, string realname)
        {
            return udao.UpdateUserInfoByUserID(userid, maxlinkmennum, maxgroupnum, realname);
        }
        public DataTable SelectAllLinkmenInfo()
        {
            return udao.SelectAllLinkmenInfo();
        }
                public bool UpdateUserPassWordByUserID(string userid, string password)
                {
                    return udao.UpdateUserPassWordByUserID(userid,password);
                }
    }
}
