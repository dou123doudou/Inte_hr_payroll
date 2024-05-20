using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace IntegratedHrPayroll
{
    public class ConnectSqlServer
    {
        SqlConnection conn;
        public ConnectSqlServer()
        {
            string sqlCon = ConnectionString;
            conn = new SqlConnection(sqlCon);
        }

        public string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=HRM;Integrated Security=True";

        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            catch { }
            return dt;
        }

        public int UpdateData(string sql)
        {
            int row = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception e){
                e.ToString();
            }
            finally
            {
                conn.Close();
            }
            return row;
        }
    }
}