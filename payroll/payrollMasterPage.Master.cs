﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegratedHrPayroll.payroll
{
    public partial class payrollMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //listempl.ServerClick += empclick;
        }
        protected void empclick(object sender, EventArgs e)
        {
            Response.Redirect("listempl.aspx");
        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}