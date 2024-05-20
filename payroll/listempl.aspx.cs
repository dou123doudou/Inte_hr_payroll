using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace IntegratedHrPayroll.payroll
{
    public partial class listempl : System.Web.UI.Page
    {
        ConnectMysql2 connmysql = new ConnectMysql2();
        ConnectSqlServer consqlsv = new ConnectSqlServer();
        private void loadlistemp()
        {
            try
            {
                string sql = @"SELECT p.PERSONAL_ID ,p.CURRENT_FIRST_NAME + ' ' + p.CURRENT_MIDDLE_NAME + ' ' + p.CURRENT_LAST_NAME AS EmployeeName, 
                                      p.CURRENT_GENDER as Gender, p.CURRENT_COUNTRY as Nation, j.DEPARTMENT, 
                                      ewt.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH as Workingday, 
                                      ewt.TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH as MaximumofNumberdayoff 
                               FROM PERSONAL p 
                               INNER JOIN JOB_HISTORY_ j ON p.PERSONAL_ID = j.EMPLOYMENT_ID
                               INNER JOIN EMPLOYMENT_WORKING_TIME ewt ON p.PERSONAL_ID = ewt.EMPLOYMENT_ID";
                string sql1 = @"SELECT p.PERSONAL_ID,
                                       MAX(p.CURRENT_FIRST_NAME + ' ' + p.CURRENT_MIDDLE_NAME + ' ' + p.CURRENT_LAST_NAME) AS EmployeeName,
                                       MAX(p.CURRENT_GENDER) as Gender,
                                       MAX(p.CURRENT_COUNTRY) as Nation,
                                       MAX(j.DEPARTMENT) as Department,
                                       SUM(ewt.NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH) as Workingday,
                                       MAX(ewt.TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH) as MaximumofNumberdayoff
                                FROM PERSONAL p
                                INNER JOIN JOB_HISTORY_ j ON p.PERSONAL_ID = j.EMPLOYMENT_ID
                                INNER JOIN EMPLOYMENT_WORKING_TIME ewt ON p.PERSONAL_ID = ewt.EMPLOYMENT_ID
                                GROUP BY p.PERSONAL_ID";

                DataTable dt = consqlsv.getData(sql1);
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
            loadlistemp();
        }
    }
}