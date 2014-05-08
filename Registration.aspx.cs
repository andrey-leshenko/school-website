using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class _Default : System.Web.UI.Page
{
    public string serverResponse = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["submit"] != null)
        {
            string firstName        = Request["firstName"];
            string lastName         = Request["lastName"];
            string password         = Request["userPassword"];
            string email            = Request["email"];
            string id               = Request["id"];


            DataLink.AddUser(email, firstName, lastName, password, id);

            if (DataLink.IsEmailRegistered(email))
                serverResponse = string.Format("'{0}' is already registered", email);
            else if (DataLink.IsIDRegistered(id))
                serverResponse = string.Format("'{0}' is already registered", id);
            else
            {
                DataLink.AddUser(email, firstName, lastName, password, id);
                serverResponse = "User created";
                Session["user"] = email;
            }
        }
    }
}