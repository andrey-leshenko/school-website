using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public string usersTable = "";
    public int visiterCounter;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AccessControl.IsAdmin(this))
            Response.Redirect("Homepage.aspx");

        if (Request["deleteUser"] != null)
            DataLink.Delete(Request["deleteUser"]);

        if (Request["setAdmin"] != null)
            DataLink.SetAdmin(Request["setAdmin"], true);

        if (Request["unsetAdmin"] != null)
            DataLink.SetAdmin(Request["unsetAdmin"], false);

        usersTable = ConstructTable(DataLink.GetUsers(searchString.Value));
    }

    // This will load after MasterPage.On_Load()
    protected override void OnLoadComplete(EventArgs e)
    {
        if (Application["visiters"] != null)
            visiterCounter = (int)Application["visiters"];
        base.OnLoadComplete(e);
    }

    private string ConstructTable(DataTable dt)
    {
        HtmlTableCell emailHeader   = new HtmlTableCell("th");
        HtmlTableCell idHeader      = new HtmlTableCell("th");
        HtmlTableCell firstHeader   = new HtmlTableCell("th");
        HtmlTableCell lastHeader    = new HtmlTableCell("th");
        HtmlTableCell adminHeader   = new HtmlTableCell("th");
        HtmlTableCell deleteHeader  = new HtmlTableCell("th");

        emailHeader     .InnerText = "Email";
        idHeader        .InnerText = "ID";
        firstHeader     .InnerText = "First Name";
        lastHeader      .InnerText = "Last Name";
        adminHeader     .InnerText = "Admin";
        deleteHeader    .InnerText = "Email";

        HtmlTableRow headerRow = new HtmlTableRow();
        headerRow.Cells.Add(emailHeader);
        headerRow.Cells.Add(idHeader);
        headerRow.Cells.Add(firstHeader);
        headerRow.Cells.Add(lastHeader);
        headerRow.Cells.Add(adminHeader);
        headerRow.Cells.Add(deleteHeader);

        HtmlTable table = new HtmlTable();
        table.Rows.Add(headerRow);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HtmlTableCell emailCell         = new HtmlTableCell();
            HtmlTableCell idCell            = new HtmlTableCell();
            HtmlTableCell firstNameCell     = new HtmlTableCell();
            HtmlTableCell lastNameCell      = new HtmlTableCell();
            HtmlTableCell adminCell         = new HtmlTableCell();
            HtmlTableCell deleteCell        = new HtmlTableCell();

            HtmlInputCheckBox adminCheckbox = new HtmlInputCheckBox();
            string onClickFunction = ((bool)dt.Rows[i]["Admin"]) ? "unsetAdmin" : "setAdmin";
            adminCheckbox.Attributes.Add("onclick", string.Format("{0}('{1}')", onClickFunction, dt.Rows[i]["Email"]));
            adminCheckbox.Checked = (bool)dt.Rows[i]["Admin"];

            HtmlButton deleteButton = new HtmlButton();
            deleteButton.Attributes.Add("onclick", string.Format("deleteUser('{0}')", dt.Rows[i]["Email"]));
            deleteButton.InnerText = "X";



            emailCell       .InnerText = (string)dt.Rows[i]["Email"];
            idCell          .InnerText = (string)dt.Rows[i]["ID"];
            firstNameCell   .InnerText = (string)dt.Rows[i]["FirstName"];
            lastNameCell    .InnerText = (string)dt.Rows[i]["LastName"];
            adminCell.InnerHtml = RenderControlToHtml(adminCheckbox);
            deleteCell.InnerHtml = RenderControlToHtml(deleteButton);

            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(emailCell);
            row.Cells.Add(idCell);
            row.Cells.Add(firstNameCell);
            row.Cells.Add(lastNameCell);
            row.Cells.Add(adminCell);
            row.Cells.Add(deleteCell);

            table.Rows.Add(row);
        }
        return RenderControlToHtml(table);
    }

    private string RenderControlToHtml(Control ControlToRender)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
        System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
        ControlToRender.RenderControl(htmlWriter);
        return sb.ToString();
    }
}