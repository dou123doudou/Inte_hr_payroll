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
        private void loadlistoff()
        {
            try
            {
                string sql = @"SELECT p.PERSONAL_ID ,p.CURRENT_FIRST_NAME + ' ' + p.CURRENT_MIDDLE_NAME + ' ' + p.CURRENT_LAST_NAME AS EmployeeName, 
                                      p.CURRENT_GENDER as Gender, p.CURRENT_COUNTRY as Nation, j.DEPARTMENT, 
                                      ewt.TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH as MaximumofNumberdayoff 
                               FROM PERSONAL p 
                               INNER JOIN JOB_HISTORY_ j ON p.PERSONAL_ID = j.EMPLOYMENT_ID
                               INNER JOIN EMPLOYMENT_WORKING_TIME ewt ON p.PERSONAL_ID = ewt.EMPLOYMENT_ID";
                string sql1 = @"SELECT p.PERSONAL_ID,
                                       MAX(p.CURRENT_FIRST_NAME + ' ' + p.CURRENT_MIDDLE_NAME + ' ' + p.CURRENT_LAST_NAME) AS EmployeeName,
                                       MAX(p.CURRENT_GENDER) as Gender,
                                       MAX(p.CURRENT_COUNTRY) as Nation,
                                       MAX(j.DEPARTMENT) as Department,
                                       MAX(ewt.TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH) as MaximumofNumberdayoff
                                FROM PERSONAL p
                                INNER JOIN JOB_HISTORY_ j ON p.PERSONAL_ID = j.EMPLOYMENT_ID
                                INNER JOIN EMPLOYMENT_WORKING_TIME ewt ON p.PERSONAL_ID = ewt.EMPLOYMENT_ID
                                GROUP BY p.PERSONAL_ID";

                DataTable dt = consqlsv.getData(sql1);
                dt.Columns.Add("Vacation_Days", typeof(int));
                foreach (DataRow row in dt.Rows)
                {
                    string Employee_Number = row[0].ToString();
                    string sql2 = "select Vacation_Days from employee where Employee_Number = " + Employee_Number;
                    DataTable dt2 = connmysql.gettable(sql2);
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        row["Vacation_Days"] = row2[0];
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loadlistoff();
        }
    }
}