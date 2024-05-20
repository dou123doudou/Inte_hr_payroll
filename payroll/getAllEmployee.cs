using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace IntegratedHrPayroll.payroll
{

    public class getAllEmployee
    {
        ConnectMysql2 connmysql = new ConnectMysql2();
        ConnectSqlServer consqlsv = new ConnectSqlServer();
        public DataTable getAll()
        {
            string sql = "select * from Personal";
            DataTable dt1 = consqlsv.getData(sql);
            dt1.Columns.Add("payrate", typeof(float));
            dt1.Columns.Add("paid_to_date", typeof(float));
            dt1.Columns.Add("tax_percentage", typeof(float));
            dt1.Columns.Add("payamount", typeof(Double));
            dt1.Columns.Add("total_income", typeof(Double));


            foreach (DataRow row in dt1.Rows)
            {
                string Employee_Number = row[0].ToString();
                string sql2 = "select employee.Pay_Rate,employee.Paid_To_Date, pay_rates.Tax_Percentage, pay_rates.Pay_Amount from employee,pay_rates where employee.PayRates_id = pay_rates.idPay_Rates  and Employee_Number = " + Employee_Number;
                DataTable dt2 = connmysql.gettable(sql2);
                foreach (DataRow row2 in dt2.Rows)
                {
                    row["payrate"] = row2["Pay_Rate"];
                    row["paid_to_date"] = row2["Paid_To_Date"];
                    row["tax_percentage"] = row2["Tax_Percentage"];
                    row["payamount"] = row2["Pay_Amount"];
                    row["total_income"] = Math.Round((Convert.ToDouble(row["payamount"]) * (Convert.ToDouble(row["tax_percentage"]) - Convert.ToDouble(row["payrate"]))), 3);
                   
                }
            }
            return dt1;

        }
    }
}