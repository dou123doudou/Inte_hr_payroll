using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace IntegratedHrPayroll
{
    public partial class totalholiday : System.Web.UI.Page
    {
        ConnectMysql2 connmysql = new ConnectMysql2();
        ConnectSqlServer consqlsv = new ConnectSqlServer();
        private void loaddashboard1()
        {
            string sql = "select Personal.Employee_ID,Personal.First_Name + ' ' + Personal.Middle_Initial + ' ' + Personal.Last_Name as fullname, Personal.Ethnicity, Personal.Gender,Job_History.Department from Personal, Job_History where Personal.Employee_ID = Job_History.Employee_ID and Job_History.End_Date is null ";
            DataTable dt1 = consqlsv.getData(sql);
            dt1.Columns.Add("Vacation_Days", typeof(int));
            dt1.Columns.Add("maximumday", typeof(int));

            foreach (DataRow row in dt1.Rows)
            {
                string Employee_Number = row[0].ToString();
                string sql2 = "select Vacation_Days from employee where Employee_Number = " + Employee_Number;
                DataTable dt2 = connmysql.gettable(sql2);
                foreach (DataRow row2 in dt2.Rows)
                {
                    row["Vacation_Days"] = row2[0];
                    row["maximumday"] = "25";
                }
            }
            //lay du lieu tu bang employee
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loaddashboard1();
        }
    }
}