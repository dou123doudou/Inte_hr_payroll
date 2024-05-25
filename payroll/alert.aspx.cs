using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedHrPayroll.payroll
{
    public partial class alert : System.Web.UI.Page
    {
        ConnectMysql2 connmysql = new ConnectMysql2();
        ConnectSqlServer consqlsv = new ConnectSqlServer();
        private void listalert()
        {
            try
            {
                string sql = @"SELECT p.PERSONAL_ID ,
                     p.CURRENT_FIRST_NAME + ' ' + p.CURRENT_MIDDLE_NAME + ' ' + p.CURRENT_LAST_NAME AS EmployeeName, 
                     p.CURRENT_GENDER as Gender, p.CURRENT_COUNTRY as Nation, 
                    'Month IS THEY BIRTHDAY' AS INFO
                FROM PERSONAL p 
				WHERE DATEPART(MONTH, GETDATE()) = DATEPART(MONTH, P.BIRTH_DATE) ";

                DataTable dt = consqlsv.getData(sql);
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
            listalert();
        }
    }
}