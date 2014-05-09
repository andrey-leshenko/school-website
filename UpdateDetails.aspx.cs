using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public string serverResponse = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Homepage.aspx");
            return;
        }

        DataTable user = DataLink.GetUser((string)Session["user"]);

        firstNameInput.Attributes.Add("value", user.Rows[0]["FirstName"].ToString().Trim());
        lastNameInput.Attributes.Add("value", user.Rows[0]["LastName"].ToString().Trim());
        idInput.Attributes.Add("value", user.Rows[0]["ID"].ToString().Trim());
        emailInput.Attributes.Add("value", user.Rows[0]["Email"].ToString().Trim());

        if (Request["submit"] != null)
        {
            string firstName = Request["firstName"];
            string lastName = Request["lastName"];
            string password = Request["userPassword"];
            string email = Request["email"];
            string id = Request["id"];

            if (email != user.Rows[0]["Email"].ToString().Trim() && DataLink.IsEmailRegistered(email))
                serverResponse = string.Format("'{0}' is already registered", email);
            else if (id != user.Rows[0]["ID"].ToString().Trim() && DataLink.IsIDRegistered(id))
                serverResponse = string.Format("'{0}' is already registered", id);
            else
            {
                DataLink.UpdateUser(user.Rows[0]["Email"].ToString().Trim(), email, firstName, lastName, password, id);
                serverResponse = "Data Updated";
                Session["user"] = email;
            }
        }
    }
}