using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
namespace IntegratedHrPayroll
{
    public class ConnectMysql
    {
        string strconn = "Server=localhost;Port=3306;Database=test;Uid=root;Pwd=040220;";

        MySqlConnection connection;
        public MySqlConnection Connectsql()
        {
            connection = new MySqlConnection(strconn);
            try
            {
                connection.Open();
                return connection;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataSet gettable(string sql)
        {
            connection = Connectsql();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Connection = connection;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}