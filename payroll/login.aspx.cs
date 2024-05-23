using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedHrPayroll.payroll
{
	public partial class login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void Submit_Click(object sender, EventArgs e)
		{
			if (username.Text== "admin" && password.Text== "123")
			{
				Response.Redirect("dashboard.aspx");
			}
			else
			{
				Response.Write("<script>alert('Invalid username or password');</script>");
			}
		}
	}
}