//===============================================================================
// This file is based on the Microsoft Data Access Application Block for .NET
// For more information please go to 
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//===============================================================================

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Service
{

    /// <summary>
    /// The SqlHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.
    /// </summary>
    public class SQLHelper
    {

        public static string str = "Data Source=.;Initial Catalog=WCF;Integrated Security=True";

        public static SqlConnection conn = new SqlConnection(str);
        public static SqlCommand cmd = new SqlCommand();
        //查询
        public static DataSet GetAdmin(string sql)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        //查询 返回结果
        //执行命令
        public static bool ExcuteSql(string sql)
        {
            int result = 0;
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            result=cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
           
        }
    }
}