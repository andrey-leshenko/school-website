using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string user = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (AccessControl.IsLoggedIn(this.Page))
        {
            user = "Logged in as " + AccessControl.GetLoggedUser(this.Page);
            // all the buttons are invisible ar first
            logoutButton.Visible = true;
            updateButton.Visible = true;            
        }
        else
        {
            loginButton.Visible = true;
            registrationButton.Visible = true;
        }

        if (AccessControl.IsAdmin(this.Page))
            adminButton.Visible = true;

        VisitorCounter.LogPageLoad(this.Page);
    }
}
