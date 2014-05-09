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
            registrationButton.Visible = false;
        }
        else
        {
            logoutButton.Visible = false;
            UpdateButton.Visible = false;
        }

        if (Session["admin"] == null || (bool)Session["admin"] == false)
            adminButton.Visible = false;

        if (Application["visiters"] == null)
            Application["visiters"] = 0;

        if (Session["countedVisiter"] == null)
        {
            Application["visiters"] = (int)Application["visiters"] + 1;
            Session["countedVisiter"] = true;
        }
    }
}
