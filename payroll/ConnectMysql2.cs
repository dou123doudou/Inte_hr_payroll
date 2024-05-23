using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
namespace IntegratedHrPayroll
{
    public class ConnectMysql2
    {
        string strconn = "Server=localhost;Port=3306;Database=mydb;Uid=root;Pwd=123456789;";

        private MySqlConnection connection;
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
        public DataTable gettable(string sql)
        {
            connection = Connectsql();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Connection = connection;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int UpdateData(string sql)
        {
            int row = 0;
            try
            {
                if (connection == null)
                {
                    connection = Connectsql();
                }
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                e.ToString();
            }
            finally
            {
                connection.Close();
            }
            return row;
        }

        internal DataTable getData(string sqlMySql, Dictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}