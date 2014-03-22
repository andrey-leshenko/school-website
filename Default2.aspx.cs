using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string email = "a@b.c";
        string password = "ADMIN";
        string fname = "a";
        string lname = "b";
        string id = "322026528";

        DataLink.OperationResault resault = DataLink.AddUser(email, fname, lname, password, id);

        Session["user"] = null;
        if (Session["user"] != null)
        {
            Response.Write("You are already loged on as "+ Session["user"]);
        }
        if (DataLink.LogIn(email, password))
        {
            Session["user"] = email;
            Response.Write("Login Successful");
        }
        else
        {
            Response.Write("Login failed");
        }

        //Session["var"] = 15;
    }

    
}