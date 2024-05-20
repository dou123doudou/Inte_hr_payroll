using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace IntegratedHrPayroll
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        ConnectSqlServer kn = new ConnectSqlServer();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            string sql = "select * from product";
            GridView1.DataSource = kn.getData(sql);
            GridView1.DataBind();
        }
    }
}