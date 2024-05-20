using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedHrPayroll
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ConnectMysql con = new ConnectMysql();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM ITEM";
            GridView1.DataSource = con.gettable(sql);
            GridView1.DataBind();
        }
    }
}