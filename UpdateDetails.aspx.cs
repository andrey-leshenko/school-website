using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string firstName;
    public string lastName;
    public string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["submit"] != null)
        {

        }
    }
}