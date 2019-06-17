using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Votes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        int totalVotes = 0;
        foreach(DataRow dR in dv.Table.Rows)
        {
            totalVotes += int.Parse(dR["Vote_Count"].ToString());
        }
        TableRow r1 = new TableRow();
        TableCell nc1 = new TableCell();
        TableCell nc2 = new TableCell();
        TableCell nc3 = new TableCell();
        r1.Cells.Add(nc1);
        r1.Cells.Add(nc2);
        r1.Cells.Add(nc3);
        nc1.BorderWidth = 1;
        nc1.BorderColor = Color.Black;
        nc1.Font.Size = 14;
        nc1.Font.Bold = true;
        nc1.Width = 100;
        nc2.BorderWidth = 1;
        nc2.BorderColor = Color.Black;
        nc2.Font.Size = 14;
        nc2.Font.Bold = true;
        nc2.Width = 100;
        nc3.BorderWidth = 1;
        nc3.BorderColor = Color.Black;
        nc3.Font.Bold = true;
        nc3.Font.Size = 14;
        nc3.Width = 100;
        nc1.Text = "Candidate";
        nc2.Text ="Votes";
        nc3.Text = "Percentage";
        Table1.Rows.Add(r1);
        foreach (DataRow dr in dv.Table.Rows)
        {
            TableRow r = new TableRow();
            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();
            TableCell c3 = new TableCell();
            r.Cells.Add(c1);
            r.Cells.Add(c2);
            r.Cells.Add(c3);
            c1.BorderWidth = 1;
            c1.BorderColor = Color.Black;
            c1.Width = 100;
            c2.BorderWidth = 1;
            c2.BorderColor = Color.Black;
            c2.Width = 100;
            c3.BorderWidth = 1;
            c3.BorderColor = Color.Black;
            c3.Width = 100;
            c1.Text = dr["Candidate"].ToString();
            c2.Text = dr["Vote_Count"].ToString();
            float percentage = 100*int.Parse(dr["Vote_Count"].ToString()) / totalVotes;
            c3.Text = percentage.ToString() + "%";
            Table1.Rows.Add(r);
        }
    }
}