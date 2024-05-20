using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IntegratedHrPayroll.payroll
{
    public partial class warning : System.Web.UI.Page
    {
        ConnectMysql2 connmysql = new ConnectMysql2();
        ConnectSqlServer consqlsv = new ConnectSqlServer();

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            loadlistemp1();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int employeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            GridViewRow row = GridView1.Rows[e.RowIndex];
            string[] employeeName = ((TextBox)row.Cells[1].Controls[0]).Text.Split(' '); // full name = first + mid + last
            string firstName = "", middleName = "", lastName = "";
            // lâu ko code hơi gà
            if (employeeName.Length >= 2) // cái ni đúng với tên 2 chữ luôn
            {
                firstName = employeeName[0];
                lastName = employeeName[employeeName.Length - 1];
                employeeName.SetValue("", 0);
                employeeName.SetValue("", employeeName.Length - 1);
                middleName = string.Join(" ", employeeName);
            }
            else if (employeeName.Length == 1)
            {
                firstName = employeeName[0];
            }
            string gender = ((TextBox)row.Cells[2].Controls[0]).Text;
            string nation = ((TextBox)row.Cells[3].Controls[0]).Text;
            string department = ((TextBox)row.Cells[4].Controls[0]).Text;
            string workingDay = ((TextBox)row.Cells[5].Controls[0]).Text;
            string maximumOfNumberDayOff = ((TextBox)row.Cells[6].Controls[0]).Text;


            string updateSql = "UPDATE PERSONAL SET CURRENT_FIRST_NAME=@firstName,CURRENT_MIDDLE_NAME=@middleName,CURRENT_LAST_NAME=@lastName,CURRENT_GENDER=@gender,CURRENT_COUNTRY=@nation WHERE PERSONAL_ID = @employeeId";

            using (SqlConnection conn = new SqlConnection(consqlsv.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(updateSql, conn);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@middleName", middleName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@nation", nation);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            string updateSqlj = "UPDATE JOB_HISTORY_ SET DEPARTMENT=@department WHERE EMPLOYMENT_ID = @employeeId";

            using (SqlConnection conn = new SqlConnection(consqlsv.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(updateSqlj, conn);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@department", department);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            string updateSqlewt = "UPDATE EMPLOYMENT_WORKING_TIME SET TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH=@maximumOfNumberDayOff, NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH=@workingDay WHERE EMPLOYMENT_ID = @employeeId";

            using (SqlConnection conn = new SqlConnection(consqlsv.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(updateSqlewt, conn);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@maximumOfNumberDayOff", maximumOfNumberDayOff);
                cmd.Parameters.AddWithValue("@workingDay", workingDay);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            GridView1.EditIndex = -1;
            loadlistemp1(); // Tải lại dữ liệu
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Hủy chế độ chỉnh sửa
            GridView1.EditIndex = -1;
            loadlistemp1();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int employeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            // trước khi xóa trong ông personal thì phải xóa trong cái chấm công
            // tức là ông employment
            string deleteSql_employment = "DELETE from EMPLOYMENT WHERE PERSONAL_ID = @employeeId";
            string deleteSql_personal = "DELETE from PERSONAL WHERE PERSONAL_ID = @employeeId";


            using (SqlConnection conn = new SqlConnection(consqlsv.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(deleteSql_employment, conn);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(consqlsv.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(deleteSql_personal, conn);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            loadlistemp1(); // Tải lại dữ liệu
        }

        protected void HandleFindEmployee(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox1.Text.Trim();
            string name = TextBox1.Text + "";
            loadlistemp1(name);
        }

        protected void HandleAddEmployee(object sender, EventArgs e)
        {
            Panel2.Visible = !Panel2.Visible;
            Panel1.Visible = !Panel1.Visible;

            // reset text thành rỗng
            TB_EmployeeID.Text = "";
            TB_FirstName.Text = "";
            TB_LastName.Text = "";
            TB_MiddleName.Text = "";
            TB_Gender.Text = "";
            TB_Nation.Text = "";
            TB_Department.Text = "";
            TB_Workingday.Text = "";
            TB_Dayoff.Text = "";
        }

        protected void HandleResetEmployee(object sender, EventArgs e)
        {
            TB_EmployeeID.Text = "";
            TB_FirstName.Text = "";
            TB_LastName.Text = "";
            TB_MiddleName.Text = "";
            TB_Gender.Text = "";
            TB_Nation.Text = "";
            TB_Department.Text = "";
            TB_Workingday.Text = "";
            TB_Dayoff.Text = "";
            loadlistemp1();
        }
        
        protected void AddEmployee(object sender, EventArgs e)
        {

            string employeeId = TB_EmployeeID.Text;
            string firstName = TB_FirstName.Text;
            string middleName = TB_MiddleName.Text;
            string lastName = TB_LastName.Text;
            string gender = TB_Gender.Text;
            string nation = TB_Nation.Text;
            string department = TB_Department.Text;
            string workingday = TB_Workingday.Text;
            string dayoff = TB_Dayoff.Text;

            // viết sql thêm vào db
            int rdId = new Random().Next(0, 1000000);
            string sql = "INSERT INTO PERSONAL(PERSONAL_ID, CURRENT_FIRST_NAME,CURRENT_MIDDLE_NAME,CURRENT_LAST_NAME,CURRENT_GENDER,CURRENT_COUNTRY )"+ " VALUES(@employeeId,@firstName,@middleName,@lastName,@gender,@nation)";
            string sqlj = "INSERT INTO JOB_HISTORY_(DEPARTMENT,JOB_HISTORY_ID)" + " VALUES(@department,@rdId)";
            string sqlewt = "INSERT INTO EMPLOYMENT_WORKING_TIME(NUMBER_DAYS_ACTUAL_OF_WORKING_PER_MONTH,TOTAL_NUMBER_VACATION_WORKING_DAYS_PER_MONTH,EMPLOYMENT_WORKING_TIME_ID )" + " VALUES(@workingday,@dayoff,@rdId)";

            using (SqlConnection conn = new SqlConnection(consqlsv.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@middleName", middleName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@nation", nation);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmdj = new SqlCommand(sqlj, conn);
                cmdj.Parameters.AddWithValue("@department", department);
                cmdj.Parameters.AddWithValue("@rdId", rdId);
                conn.Open();
                cmdj.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmdewt = new SqlCommand(sqlewt, conn);
                cmdewt.Parameters.AddWithValue("@workingday", workingday);
                cmdewt.Parameters.AddWithValue("@dayoff", dayoff);
                cmdewt.Parameters.AddWithValue("@rdId", rdId);
                conn.Open();
                cmdewt.ExecuteNonQuery();
                conn.Close();
            }

            // load lại
            TB_EmployeeID.Text = "";
            TB_FirstName.Text = "";
            TB_LastName.Text = "";
            TB_MiddleName.Text = "";
            TB_Gender.Text = "";
            TB_Nation.Text = "";
            TB_Department.Text = "";
            TB_Workingday.Text = "";
            TB_Dayoff.Text = "";
            loadlistemp1();

            HandleAddEmployee(sender, e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TB_EmployeeID.Attributes.Add("placeholder", "Enter ID");
            TB_FirstName.Attributes.Add("placeholder", "Enter F Name");
            TB_MiddleName.Attributes.Add("placeholder", "Enter M Name");
            TB_LastName.Attributes.Add("placeholder", "Enter L Name");
            TB_Gender.Attributes.Add("placeholder", "Enter Gender");
            TB_Nation.Attributes.Add("placeholder", "Enter Nation");
            TB_Department.Attributes.Add("placeholder", "Enter Department");
            TB_Workingday.Attributes.Add("placeholder", "Enter Working day");
            TB_Dayoff.Attributes.Add("placeholder", "Enter Day off");
            if (!IsPostBack)
            {
                loadlistemp1();
            }
        }

        private void loadlistemp1(string name = "")
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
                                left JOIN JOB_HISTORY_ j ON p.PERSONAL_ID = j.EMPLOYMENT_ID
                                left JOIN EMPLOYMENT_WORKING_TIME ewt ON p.PERSONAL_ID = ewt.EMPLOYMENT_ID";

                if (!string.IsNullOrEmpty(name))
                {
                    sql1 = sql1 + $" Where p.CURRENT_FIRST_NAME + ' ' + p.CURRENT_MIDDLE_NAME + ' ' + p.CURRENT_LAST_NAME like '%{name}%'";
                }
                sql1 = sql1 + " GROUP BY p.PERSONAL_ID";

                DataTable dt = consqlsv.getData(sql1);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}