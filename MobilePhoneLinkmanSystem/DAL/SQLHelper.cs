/*
 * 创建人：
 * 时间：
 * 第一修改时间：
 * 第二修改时间：
 * 说明：数据库助手类
 * 版权声明：****
*/

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class SQLHelper
    {
        private static string staticConnStr = ConfigurationManager.ConnectionStrings["connectionsqlserver"].ConnectionString;
        private SqlCommand cmd = null;
        private SqlConnection conn = null;
        private SqlDataReader sdr = null;
        private SqlDataAdapter sda = null;  

        #region 实例化数据库助手类sqlhelper
        /// <summary>
        /// 实例化数据库助手类sqlhelper
        /// </summary>
        public SQLHelper()
        {
            conn = new SqlConnection(staticConnStr);
        }
        #endregion

        #region 打开数据库连接
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
        public void OpenSQLServer()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        #endregion

        #region 关闭数据库连接
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <returns></returns>
        public void CloseSQLServer()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        #endregion

        #region 返回SqlConnection连接字符串的方法，以后可以调用
        /// <summary>
        ///返回SqlConnection连接字符串
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnectionString()
        {
            conn = new SqlConnection(staticConnStr);
            return conn;
        }
        #endregion

        #region 构建SqlCommand对象，传入参数，并进行填充
        /// <summary>
        /// 创建SqlCommand对象，传入参数，并进行填充
        /// </summary>
        /// <param name="conn">提供一个可用的连接对象</param>
        /// <param name="cmdText">文本名称或者是存储过程名</param>
        /// <param name="cmdType">执行的类型</param>
        /// <param name="cmdParameters">参数列表</param>
        /// <returns>返回创建完整的SqlCommand</returns>
        protected SqlCommand CreateSqlCommand(SqlConnection conn, string cmdText,CommandType cmdType, params SqlParameter[] cmdParameters)
        {
            cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = cmdType;
            if (cmdParameters != null)
            {
                foreach (SqlParameter param in cmdParameters)
                {
                    cmd.Parameters.Add(param);
                }
            }
            return cmd;
        }
        #endregion

        #region 执行cmdText(可为Sql语句或存储过程)，返回一个DataSet结果集(一个DataSet由多个DataTable组成)
        ///// <summary>
        ///// 执行cmdText(可为Sql语句或存储过程)，返回一个DataSet结果集
        ///// </summary>
        ///// <param name="cmdText">查询语句或者是存储过程名</param>
        ///// <param name="cmdType">SqlCommand执行的方式，是文本还是存储过程</param>
        ///// <param name="cmdParameters">附带的参数列表</param>
        ///// <returns>返回一个DataSet结果集</returns>
        public DataSet GetDataSet(string cmdText, CommandType cmdType, SqlParameter[] cmdParameters)
        {
            cmd = CreateSqlCommand(GetConnectionString(), cmdText, cmdType, cmdParameters);
            DataSet ds = new DataSet();
            OpenSQLServer();
            sda= new SqlDataAdapter(cmd);
            sda.Fill(ds);
            CloseSQLServer();
            cmd.Parameters.Clear();
            return ds;
        }

        #endregion

        #region 执行cmdText(可为Sql语句或存储过程)，返回一个DataTable(一张表，即从数据库查到的结果集)
        /// <summary>
        /// 执行cmdText(可为Sql语句或存储过程)，返回一个DataTable(一张表，即从数据库查到的结果集)Y
        /// </summary>
        /// <param name="cmdText">查询语句或者是存储过程名</param>
        /// <param name="cmdType">SqlCommand执行的方式，是文本还是存储过程</param>
        /// <param name="cmdParameters">附代的参数列表</param>
        /// <returns>返回一个DataTable结果集</returns>
        public DataTable GetDataTable(string cmdText, CommandType cmdType,params SqlParameter[] cmdParameters)
        {
                cmd = CreateSqlCommand(GetConnectionString(), cmdText, cmdType,cmdParameters);
                DataTable dt = new DataTable();
                OpenSQLServer();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                CloseSQLServer();
                cmd.Parameters.Clear();
                return dt;
        }
        #endregion

        //#region 执行无参数的存储过程
        // /// <summary>
        ///// 执行无参数的存储过程
        ///// </summary>
        ///// <param name="procName">存储过程名称</param>
        ///// <returns>返回Datatable</returns>
        //public DataTable ExecuteStoredProc(string procName)
        //{
        //    DataTable dt = new DataTable();
        //    cmd = new SqlCommand(procName, GetConnectionString());
        //    OpenSQLServer();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        //    {
        //        dt.Load(sdr);
        //    }
        //    return dt;
        //}
        //#endregion

        //#region 执行有1个参数的存储过程
        ///// <summary>
        ///// 执行有1个参数的存储过程
        ///// </summary>
        ///// <param name="procName">存储过程名称</param>
        ///// <param name="cmdParameters">可选参数列表</param>
        ///// <returns>返回Datatable</returns>
        //public DataTable ExecuteStoredProc(string procName, SqlParameter[] cmdParameters)
        //{
        //    DataTable dt = new DataTable();
        //    cmd = new SqlCommand(procName, GetConnectionString());
        //    OpenSQLServer();
        //    cmd.Parameters.AddRange(cmdParameters);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        //    {
        //        dt.Load(sdr);
        //    }
        //    return dt;
        //}
        //#endregion

        #region 该方法执行传入的SQL增删改语句(无参数),返回受影响的记录的行数
        ///<summary>  
        ///该方法执行传入的SQL增删改语句
        ///</summary>
        ///<para name="sql">要执行的SQL增删改语句</para>
        ///<return>返回受影响的记录的行数</return> 
        public int ExecuteNonQuery(string sql)
        {
            int affectrows=-1;
            try
            {
                cmd = new SqlCommand(sql, GetConnectionString());
                cmd = CreateSqlCommand(GetConnectionString(),sql,CommandType.Text,null);
                OpenSQLServer();
                affectrows = cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                CloseSQLServer();
                cmd.Dispose();
            }
            return affectrows;
        }
        #endregion

        #region 执行带参数(数组)的SQL语句,返回受影响的行数
        /// <summary>
        /// 执行带参数(数组)的SQL语句
        /// </summary>
        /// <param name="sql">传入的sql</param>
        /// <param name="cmdParameters">sqlparameters 参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sql,SqlParameter [] cmdParameters)   //重构方法
        {
            int affectrows = -1;
            try
            {
                cmd = new SqlCommand(sql, GetConnectionString());
                cmd = CreateSqlCommand(GetConnectionString(), sql, CommandType.Text, cmdParameters);
                OpenSQLServer();
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddRange(cmdParameters);   //传入一个数组
                affectrows = cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                CloseSQLServer();
                cmd.Dispose();
            }
            return affectrows;
        }
        #endregion
        
        #region 该方法执行查询单纯SQL语句,无参数
        /// <summary>
        /// 该方法执行查询sql语句,无参数
        /// </summary>
        /// <param name="sql">传入的sql</param>
        /// <returns>返回结果集，datatable</returns>
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand(sql, GetConnectionString());
            OpenSQLServer();
            cmd.CommandType = CommandType.Text;
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))              //using 2种用法
            {
                dt.Load(sdr);
            }
            return dt;
        }
        #endregion
        
        #region 该方法执行查询SQL语句,有可选参数列表
         /// <summary>
        /// 该方法执行查询SQL语句,有可选参数列表
        /// </summary>
        /// <param name="sql">传入的SQL</param>
        /// <returns>返回结果集，datatable</returns>
        public DataTable ExecuteSqlQuery(string sql, SqlParameter[] cmdParameters)
        {
            DataTable dt = new DataTable();
            cmd = CreateSqlCommand(GetConnectionString(), sql, CommandType.Text, cmdParameters);
            OpenSQLServer();
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        #endregion
       
        #region  返回受影响的行数
        /// <summary>
        /// 影响的行数
        /// </summary>
        /// <param name="cmdText">执行的cmdText</param>
        /// <param name="cmdType">文本or存储过程</param>
        /// <param name="cmdParameters">可选参数列表</param>
        /// <returns>返回受影响的行数</returns>
        public int AffectRows(string cmdText, CommandType cmdType,SqlParameter[] cmdParameters)
        {
            int AffectRows = -1;
            cmd = CreateSqlCommand(GetConnectionString(),cmdText, cmdType, cmdParameters);
            OpenSQLServer();
            AffectRows = cmd.ExecuteNonQuery();
            CloseSQLServer();
            cmd.Dispose();
            return AffectRows;
        }
        #endregion

        #region 执行一条计算查询结果语句，返回查询结果（object）,需要进行装箱和拆箱
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object），即必须进行类型之间的转换，需要消耗一定的内存
        /// </summary>
        /// <param name="cmdText">查询语句</param>
        /// <param name="cmdType">查询的方式，文本or存储过程</param>
        /// <param name="cmdParameters">可选参数列表</param>
        /// <returns>查询结果（object）</returns>
        public object ExecuteScalarAndReturnObject(string cmdText, CommandType cmdType,SqlParameter[] cmdParameters)
        {
                cmd = CreateSqlCommand(GetConnectionString(), cmdText, cmdType, cmdParameters);
                OpenSQLServer();
                object result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                CloseSQLServer();
                cmd.Dispose();
                return result;
        }
        #endregion

        #region 返回查询到的记录总条数
        /// <summary>
        /// 返回查询到的记录总条数
        /// </summary>
        /// <param name="cmdText">查询语句</param>
       ///<param name="cmdType">文本or存储过程查询</param>
       ///<param name="cmdParameters">可选参数列表</param>
        /// <returns>返回查询到的记录总条数</returns>
        public int GetRecordCount(string cmdText,CommandType cmdType,SqlParameter[] cmdParameters)
        {
            int recordCount = 0;
            cmd = new SqlCommand(cmdText, GetConnectionString());
            OpenSQLServer();
            cmd.CommandType = cmdType;
            using (sdr=cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while(sdr.Read())
                {
                    recordCount++;
                }
            }
            return recordCount;
        }
        #endregion

        #region 通过SQL查询，取回Datatable记录集
        /// <summary>
        /// 通过SQL查询，取回Datatable记录集
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="cmdParameters">可选参数列表</param>
        /// <returns>返回Datatable</returns>
        public DataTable ReturnDataTabelByText(string sql,SqlParameter[] cmdParameters)
        {
            DataTable dt = new DataTable();
            cmd = CreateSqlCommand(GetConnectionString(), sql, CommandType.Text, cmdParameters);
            OpenSQLServer();
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        #endregion

        #region 执行存储过程，取回Datatable记录集
        /// <summary>
        /// 执行存储过程，取回Datatable记录集
        /// </summary>
        /// <param name="ProcName">存储过程名称</param>
        /// <param name="cmdParameters">可选参数列表</param>
        /// <returns>返回Datatable</returns>
        public DataTable ReturnDataTabelByProc(string ProcName, SqlParameter[] cmdParameters)
        {
            DataTable dt = new DataTable();
            cmd = CreateSqlCommand(GetConnectionString(), ProcName, CommandType.StoredProcedure, cmdParameters);
            OpenSQLServer();
            using (sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                dt.Load(sdr);
            }
            return dt;
        }
        #endregion
    
    }
}
