using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace IntegratedHrPayroll.payroll
{
    public partial class dashboard : System.Web.UI.Page
    {

        ConnectMysql2 connmysql = new ConnectMysql2();
        ConnectSqlServer consqlsv = new ConnectSqlServer();
        private void loaddashboard1()
        {
            // benefit = 1 tức là ông là cổ đông 
            string sql = "select PERSONAL_ID, CURRENT_FIRST_NAME + ' ' + CURRENT_MIDDLE_NAME + ' ' + CURRENT_LAST_NAME AS FULLNAME, BIRTH_DATE, SOCIAL_SECURITY_NUMBER, DRIVERS_LICENSE, CURRENT_ADDRESS_1,CURRENT_ADDRESS_2,CURRENT_CITY,CURRENT_COUNTRY,CURRENT_ZIP,CURRENT_GENDER as Gender,CURRENT_PHONE_NUMBER,CURRENT_PERSONAL_EMAIL,CURRENT_MARITAL_STATUS,ETHNICITY,SHAREHOLDER_STATUS,BENEFIT_PLAN_ID from Personal where BENEFIT_PLAN_ID = 1";
            DataTable dt1 = consqlsv.getData(sql);
            dt1.Columns.Add("payrate", typeof(string));
            dt1.Columns.Add("paid_to_date", typeof(float));
            dt1.Columns.Add("tax_percentage", typeof(float));
            dt1.Columns.Add("payamount", typeof(Double));
            dt1.Columns.Add("total_income", typeof(Double));
            dt1.Columns.Add("value", typeof(Double));


            foreach (DataRow row in dt1.Rows)
            {
                string Employee_Number = row[0].ToString();
                string sql2 = "select employee.Pay_Rate,pay_rates.value,employee.Paid_To_Date, pay_rates.Tax_Percentage, pay_rates.Pay_Amount from employee,pay_rates where employee.Pay_Rates_idPay_Rates = pay_rates.idPay_Rates and Employee_Number = " + Employee_Number;
                DataTable dt2 = connmysql.gettable(sql2);
                foreach (DataRow row2 in dt2.Rows)
                {
                    var x = row["payrate"];
                    var x2 = row2["Pay_Rate"];
                    row["payrate"] = row2["Pay_Rate"];
                    row["value"] = row2["value"];
                    row["paid_to_date"] = row2["Paid_To_Date"];
                    row["tax_percentage"] = row2["Tax_Percentage"];
                    row["payamount"] = row2["Pay_Amount"];
                    double amount = Convert.ToDouble(row["payamount"]);
                    double value = Convert.ToDouble(row["value"]);
                    double tax_percentage = Convert.ToDouble(row["tax_percentage"]);
                    row["total_income"] = Math.Round(amount * value * (100 - tax_percentage) / 100f, 3);
                    //row["total_income"] = (double) row2[3] * ((double)row2[0] - (double)row2[2]);
                    //row[10] = (double)row[9] * ((double)row[6] - (double)row[8]);
                }
            }
            //lay du lieu tu bang employee
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        private void loaddashboard2()
        {
            //load all employee
            string sql = "select PERSONAL_ID, CURRENT_FIRST_NAME+' '+CURRENT_MIDDLE_NAME+' '+CURRENT_LAST_NAME as fullname, BENEFIT_PLAN_ID, ETHNICITY, CURRENT_GENDER from Personal";
            DataTable dt1 = consqlsv.getData(sql);
            dt1.Columns.Add("payrate", typeof(string));
            dt1.Columns.Add("paid_to_date", typeof(float));
            dt1.Columns.Add("tax_percentage", typeof(float));
            dt1.Columns.Add("payamount", typeof(Double));
            dt1.Columns.Add("total_income", typeof(Double));
            dt1.Columns.Add("value", typeof(Double));


            foreach (DataRow row in dt1.Rows)
            {
                string Employee_Number = row[0].ToString();
                string sql2 = "select employee.Pay_Rate,pay_rates.value,employee.Paid_To_Date, pay_rates.Tax_Percentage, pay_rates.Pay_Amount from employee,pay_rates where employee.Pay_Rates_idPay_Rates = pay_rates.idPay_Rates  and Employee_Number = " + Employee_Number;
                DataTable dt2 = connmysql.gettable(sql2);
                foreach (DataRow row2 in dt2.Rows)
                {
                    row["payrate"] = row2["Pay_Rate"];
                    row["paid_to_date"] = row2["Paid_To_Date"];
                    row["tax_percentage"] = row2["Tax_Percentage"];
                    row["payamount"] = row2["Pay_Amount"];
                    row["value"] = row2["value"];
                    double amount = Convert.ToDouble(row["payamount"]);
                    double tax_percentage = Convert.ToDouble(row["tax_percentage"]);
                    double value = Convert.ToDouble(row["value"]);
                    row["total_income"] = Math.Round(amount * value * (100 - tax_percentage) / 100f, 3);
                    //row["total_income"] = (double) row2[3] * ((double)row2[0] - (double)row2[2]);
                    //row[10] = (double)row[9] * ((double)row[6] - (double)row[8]);
                }
            }
            ///
            string sql3 = "select Benefit_Plans_ID,Plan_Name from Benefit_Plans";
            DataTable dt3 = consqlsv.getData(sql3);
            dt3.Columns.Add("total_income", typeof(Double));
            foreach (DataRow row in dt3.Rows)
            {
                string Benefit_Plan_ID = row[0].ToString();
                double totalincome = 0;
                //roww 1 duyet bang benefitplan row 2 duyệt bảng tổng số nhân viên để tính tổng lợi nhuận
                foreach (DataRow row2 in dt1.Rows)
                {
                    double income = 0;
                    if (row2["BENEFIT_PLAN_ID"].ToString().Equals(Benefit_Plan_ID))
                    {
                        if (row2["total_income"].ToString().Equals(""))
                        {
                            income = 0;
                        }
                        else
                        {
                            income = Convert.ToDouble(row2["total_income"]);
                        }
                    }
                    totalincome += income;
                }
                row["total_income"] = totalincome.ToString();

            }
            GridView2.DataSource = dt3;
            GridView2.DataBind();
        }
        private void loadEarningsByBenefitPlan()
        {
            string query = "SELECT BENEFIT_PLANS.PLAN_NAME, SUM(Employee.Pay_Amount * Pay_Rates.Value * (100 - Pay_Rates.Tax_Percentage) / 100) AS Total_Earnings FROM Employee " +
                            "JOIN Pay_Rates ON Employee.Pay_Rates_idPay_Rates = Pay_Rates.idPay_Rates " +
                            "JOIN Personal on Employee.Employee_Number = Personal.PERSONAL_ID " +
                            "JOIN Benefit_Plans ON Personal.BENEFIT_PLAN_ID = Benefit_Plans.Benefit_Plans_ID " +
                            "GROUP BY Benefit_Plans.Plan_Name";

            DataTable dt = consqlsv.getData(query);

            List<string> planNames = new List<string>();
            List<double> earnings = new List<double>();

            foreach (DataRow row in dt.Rows)
            {
                planNames.Add(row["Plan_Name"].ToString());
                earnings.Add(double.Parse(row["Total_Earnings"].ToString()));
            }

            Session["planNames"] = JsonConvert.SerializeObject(planNames.ToArray());
            Session["earnings"] = JsonConvert.SerializeObject(earnings.ToArray());
        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            loaddashboard1();
            //lay du lieu tu bang personal
            loaddashboard2();
            // code demo truyền data qua bên giao diện
            // load data nhân viên ra bằng sql
            loadEarningsByBenefitPlan();
            DataTable dt3 = consqlsv.getData("SELECT count(*) as total FROM [HRM].[dbo].[PERSONAL]");
            // get cột ra
            List<int> arr = new List<int>();
            foreach (DataRow row in dt3.Rows) {
                arr.Add(Convert.ToInt32(row["total"]));
            }
            // nhớ lúc code ở đây phải chạy lại project
            arr.Add(20);
            arr.Add(30);
            arr.Add(50);
            arr.Add(10);
            // bỏ dô session
            Session["totalEmployee"] = JsonConvert.SerializeObject(arr.ToArray());
            // qua kia

            // tốt nhất nên xử lý bên ni hết
            // sau đó tryền Session["data"], Session["options"]
            string[] labels = { "Nhân Viên", "Cổ Đông"};
            Session["labels"] = JsonConvert.SerializeObject(labels);
            int[] data = { 146889934, 114809508};
            Session["data"] = JsonConvert.SerializeObject(data);
            // random đại gì đó
            string[] backgroundColor = { "blue", "orange" };
            Session["backgroundColor"] = JsonConvert.SerializeObject(backgroundColor);
        }


    }
}