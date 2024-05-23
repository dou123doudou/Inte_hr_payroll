using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedHrPayroll
{
    public partial class Default : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string hardcodedUsername = "admin";
            string hardcodedPassword = "123";

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == hardcodedUsername && password == hardcodedPassword)
            {
                
                Response.Redirect("dashbord.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
                lblErrorMessage.Visible = true;
            }
        }
    }
}