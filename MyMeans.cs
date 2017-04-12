using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PWMS__EnterpriseManagePeopleSystem.DataClass
{
    class MyMeans
    {
        public static string Login_ID = "";
        public static string Login_Name = "";
        public static string Mean_SQL="", Mean_Table = "",Mean_Field="";
        public static SqlConnection My_conn;
        public static string M_str_sqlcon = "Data Source=ADMIN-PC;database=db_PWMS;User id=Tsui;PWD=463500";
        //public static string M_str_sqlcon = @"Data Source=LVSHUANG0927\\HCDY;Initial Catalog=db_PWMS;Integrated Security=True";
        public static int Login_n = 0;
        public static string AllSql = "Select * from tb_Stuffbasic";

        #region 连接方法
        public static  SqlConnection getcon()
        {
            My_conn = new SqlConnection(M_str_sqlcon);
            My_conn.Open();
            return My_conn;
        }
        #endregion
        /// <summary>
        /// 测试数据库
        /// </summary>
        public void con_open()
        {
            getcon();
            //con_close();
        }
        #region 关闭数据库连接
        public void conn_close()
        {
            if(My_conn.State==ConnectionState.Open)
            {
                My_conn.Close();
            }
        }
        #endregion

        #region 获取指定表中的信息
        public SqlDataReader getcom(string SQLstr)
        {
            getcon();
            SqlCommand My_com = new SqlCommand(SQLstr, My_conn);
            SqlDataReader My_read = My_com.ExecuteReader();
            return My_read;
        }
        #endregion

        #region 执行数据库sqlcommand命令
        public void getsqlcom(string SQLstr)
        {
            getcon();
            SqlCommand SQLcom = new SqlCommand(SQLstr, My_conn);
            SQLcom.ExecuteNonQuery();
            SQLcom.Dispose();
            conn_close();
        }
        #endregion

        #region 创建dataset数据表
        public DataSet getDataSet(string SQLstr, string tableName)
        {
            getcon();
            SqlDataAdapter SQLda = new SqlDataAdapter(SQLstr, My_conn);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet, tableName);
            conn_close();
            return My_DataSet;
        }
        #endregion
    }
}
