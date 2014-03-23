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
        System.Data.SqlClient.SqlConnection conn = MyAdoHelper.ConnectToDb("Database.mdf");
        conn.Open();
        if (Request["submit"] != null)
        {
            string firstName        = Request["firstName"];
            string lastName         = Request["lastName"];
            string password    = Request["userPassword"];
            string email            = Request["email"];
            string id               = Request["id"];


            DataLink.OperationResault resault = DataLink.AddUser(email, firstName, lastName, password, id);

            if (!resault.succeded)
            {
                serverResponse = resault.message;
            }
            else
            {
                serverResponse = "User created";
                Session["user"] = email;
            }
        }
    }
}