using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    public string loginResponse;

    protected void Page_Load(object sender, EventArgs e)
    {
        string email = Request["loginEmail"];
        string password = Request["loginPassword"];

        if (email != null && password != null && Request["submit"] != null)
        {
            if (DataLink.Exists(email, password))
            {
                AccessControl.LogIn(this, email, DataLink.IsAdmin(email));
                loginResponse = "You have logged in successfully.";
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                loginResponse = "Email and password don't match";
            }
        }
    }
}