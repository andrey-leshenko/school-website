using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public string serverResponse = "";
    public string formInputs = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AccessControl.IsLoggedIn(this))
        {
            Response.Redirect("Homepage.aspx");
            return;
        }
        DataTable user = DataLink.GetUser(AccessControl.GetLoggedUser(this));

        formInputs = ContructInputs(
            GetFirstFromTable(user, "FirstName"),
            GetFirstFromTable(user, "LastName"),
            GetFirstFromTable(user, "ID"),
            GetFirstFromTable(user, "Email")
            );
        
        if (Request["submit"] != null)
        {
            string firstName = Request["firstName"];
            string lastName = Request["lastName"];
            string password = Request["userPassword"];
            string email = Request["email"];
            string id = Request["id"];

            if (email != GetFirstFromTable(user, "Email") && DataLink.IsEmailRegistered(email))
                serverResponse = string.Format("'{0}' is already registered", email);
            else if (id != GetFirstFromTable(user, "ID") && DataLink.IsIDRegistered(id))
                serverResponse = string.Format("'{0}' is already registered", id);
            else
            {
                DataLink.UpdateUser(GetFirstFromTable(user, "Email"), email, firstName, lastName, password, id);
                serverResponse = "Data Updated";
                AccessControl.LogIn(this, email, DataLink.IsAdmin(email));
            }
        }
    }

    private string ContructInputs(string first, string last, string id, string email)
    {
        HtmlInputText inputFirst = new HtmlInputText();
        inputFirst.ID = "firstName";
        inputFirst.Value = first;

        HtmlInputText inputLast = new HtmlInputText();
        inputLast.ID = "lastName";
        inputLast.Value = last;

        HtmlInputText inputId = new HtmlInputText();
        inputId.ID = "id";
        inputId.Value = id;

        HtmlInputPassword inputPass = new HtmlInputPassword();
        inputPass.ID = "userPassword";

        HtmlInputPassword inputRepeatPass = new HtmlInputPassword();
        inputRepeatPass.ID = "repeatPassword";

        HtmlInputText inputEmail = new HtmlInputText();
        inputEmail.ID = "email";
        inputEmail.Value = email;

        string br = "<br />";


        return
            RenderControlToHtml(inputFirst)         + br +
            RenderControlToHtml(inputLast)          + br +
            RenderControlToHtml(inputId)            + br +
            RenderControlToHtml(inputPass)          + br +
            RenderControlToHtml(inputRepeatPass)    + br +
            RenderControlToHtml(inputEmail);
    }

    private string RenderControlToHtml(Control ControlToRender)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
        System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
        ControlToRender.RenderControl(htmlWriter);
        return sb.ToString();
    }

    private string GetFirstFromTable(DataTable dt, string columnName)
    {
        return dt.Rows[0][columnName].ToString().Trim();
    }
}