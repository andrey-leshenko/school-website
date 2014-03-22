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
        if (Request["deletedUser"] != "")
            DataLink.Delete(Request["deletedUser"]);

        DataTable table = DataLink.GetAllUsers();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            usersTable += "<tr>";
            
            for (int j = 0; j < table.Columns.Count; j++)
            {
                usersTable += "<td>" + table.Rows[i][j] + @"</td>";
            }
            usersTable += @"<td><button onClick(deleteUser(" + table.Rows[i][0] + @"))>Delete</button></td>";
            usersTable += @"</tr>";
        }
    }
}