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
        if (Session["user"] != null)
        {
            user = "Loged in as " + (string)Session["user"];
            loginButton.Visible = false;
            //Page.FindControl("registerd-links").Visible = false;
        }
        else
        {
            logoutButton.Visible = false;
        }
    }
}
