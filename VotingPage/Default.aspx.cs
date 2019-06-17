using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(RadioButtonList1.SelectedIndex > -1)
        {
            SqlDataSource1.Update();
            Response.Redirect("Votes.aspx");
        }
        else
        {
            Label1.Text = "Error: No Candidate Selected. Please Try Again.";
        }
    }
}