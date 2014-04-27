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

            if (DataLink.LogIn(email, password))
            {
                Session["user"] = email;
                Session["admin"] = DataLink.IsAdmin(email);
                loginResponse = "You have loged in successfully.";
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                loginResponse = "login failed. Remember letter case is important.";
            }

        }
    }
}