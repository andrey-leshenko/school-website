using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public string usersTable = "";
    public int visiterCounter;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] == null || (bool)Session["admin"] == false)
            Response.Redirect("Homepage.aspx");

        if (Request["deleteUser"] != null)
        {
            string email = Request["deleteUser"];
            DataLink.Delete(email);
        }

        if (Request["setAdmin"] != null)
            DataLink.SetAdmin(Request["setAdmin"], true);

        if (Request["unsetAdmin"] != null)
            DataLink.SetAdmin(Request["unsetAdmin"], false);

        DataTable table;

        string str = Request["search"];

        if (Request["search"] != "")
            table = DataLink.GetUsers(Request["search"]);
        else
            table = DataLink.GetUsers();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["Email"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["ID"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["FirstName"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["LastName"]);
            if ((bool)table.Rows[i]["Admin"])
                usersTable += "<td><input type='checkbox' onclick='unsetAdmin(\"" + table.Rows[i]["Email"] + "\")' checked></input></td>";
            else
                usersTable += "<td><input type='checkbox' onclick='setAdmin(\"" + table.Rows[i]["Email"] + "\")'></input></td>";
            usersTable += "<td><button onclick='deleteUser(\"" + table.Rows[i]["Email"] + "\")'>X</button></td>";
            usersTable += @"</tr>";
        }
    }

    // This will load after MasterPage.On_Load()
    protected override void OnLoadComplete(EventArgs e)
    {
        if (Application["visiters"] != null)
            visiterCounter = (int)Application["visiters"];
        base.OnLoadComplete(e);
    }

    private string userSearch = "";
}