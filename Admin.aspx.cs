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
        if (Request.QueryString["deleteEmail"] != null)
        {
            string email = Request.QueryString["deleteEmail"];

            DataLink.Delete(email);
        }

        DataTable table = DataLink.GetAllUsers();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["Email"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["ID"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["FirstName"]);
            usersTable += string.Format(@"<td>{0}</td>", table.Rows[i]["LastName"]);
            
            usersTable += "<td><button onclick ='window.location.href=\"Admin.aspx?deleteEmail=" + table.Rows[i]["Email"] + "\"'>X</button></td>";
            usersTable += @"</tr>";
        }
    }
}