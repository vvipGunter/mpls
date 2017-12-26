using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class UserDAO
    {
        private SQLHelper mysqlhelper = null;

        public UserDAO()
        {
            mysqlhelper = new SQLHelper();
        }
        public bool IsUsereExists(string userid,string pwd)
        {
            bool flag = false;
            int affectrow = -1;
            SqlParameter[] sqlpm = new SqlParameter[]
            {
                new SqlParameter("@UserID",userid),
                new SqlParameter("@PassWord",pwd)
            };
            affectrow=(int)mysqlhelper.ExecuteScalarAndReturnObject("SelectFromUserInfoByUserIDAndpwd", CommandType.StoredProcedure, sqlpm);
            if (affectrow == 1)
            {
                flag = true;
            }
            return flag;
 
        }

        public DataTable SelectUserByUserID(string userid)
        {
            DataTable dt = new DataTable();
            SqlParameter [] aaaa=new SqlParameter[]
            {
                new SqlParameter("@UserID",userid)
            };
            dt = mysqlhelper.GetDataTable("procViewUserInfoByUserID", CommandType.StoredProcedure, aaaa);
            return dt;

        }

        public bool UpdateUserInfoByUserID(string userid, int maxlinkmennum, int maxgroupnum, string realname)
        {
            bool flag = false;
            SqlParameter[] bbbb = new SqlParameter[]
            {
                new SqlParameter("@UserID",userid),
                new SqlParameter("@MAXlinkmenNum",maxlinkmennum),
                new SqlParameter("@MaxGroupNum",maxgroupnum),
                new SqlParameter("@RealName",realname)
            };
            int result = mysqlhelper.AffectRows("procUpdateUserInfoByUserID", CommandType.StoredProcedure, bbbb);
            if (result > 0)
            {
                flag = true;
            }
            return flag;
        }
        public DataTable SelectAllLinkmenInfo()
        {
            DataTable dt = new DataTable();
            dt = mysqlhelper.GetDataTable("procViewLinkmenInfo", CommandType.StoredProcedure, null);
            return dt;
 
        }
        public bool UpdateUserPassWordByUserID(string userid, string password)
        {
            bool flag = false;
            int result = -1;
            SqlParameter[] cccc = new SqlParameter[]
            {
                new SqlParameter("@UserID",userid),
                new SqlParameter("@PassWord",password)
            };
            result = mysqlhelper.AffectRows("procUpdateUserPasswordByUserID",CommandType.StoredProcedure,cccc);
            if (result > 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}
