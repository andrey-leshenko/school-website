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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["delete"] != null)
        {
            string email = Request.QueryString["delete"];

            DataLink.Delete(email);
        }

        if (Request.QueryString["setAdmin"] != null)
        {
            string email = Request.QueryString["setAdmin"];

            DataLink.OperationResult result = DataLink.SetAdmin(email);
            int i = 0;
        }

        if (Request.QueryString["unsetAdmin"] != null)
        {
            string email = Request.QueryString["unsetAdmin"];

            DataLink.OperationResult result = DataLink.UnsetAdmin(email);
            int i = 0;
        }

        DataTable table = DataLink.GetAllUsers();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["Email"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["ID"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["FirstName"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["LastName"]);
            if ((bool)table.Rows[i]["Admin"])
                usersTable += "<td><input type='checkbox' onclick ='window.location.href=\"Admin.aspx?unsetAdmin="
                    + table.Rows[i]["Email"] + "\"' checked></input></td>";
            else
                usersTable += "<td><input type='checkbox' onclick ='window.location.href=\"Admin.aspx?setAdmin="
                    + table.Rows[i]["Email"] + "\"'></input></td>";
            usersTable += "<td><button onclick ='window.location.href=\"Admin.aspx?delete=" + table.Rows[i]["Email"] + "\"'>X</button></td>";
            usersTable += @"</tr>";
        }
    }
}