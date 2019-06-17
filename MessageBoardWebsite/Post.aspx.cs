using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post : System.Web.UI.Page
{
    private const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Registrations.mdf;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (commentBox.Text == "")
        {
            msg.Text = "Enter a comment.";
            return;
        }
        else
        {
            DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            DateTime localDate = DateTime.Now;
            String now = localDate.ToString("MM'/'dd'/'yyyy hh':'mm tt");
            String commString = commentBox.Text;
            commString  = commString.Replace("\r\n", "<br /> ");
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            String user = User.Identity.Name;
            SqlCommand insertcmd = new SqlCommand("Insert INTO Posts (UserName, DateTime, Comment) VALUES(@username,@date,@comment)", conn);
            insertcmd.Parameters.AddWithValue("@username", user);
            insertcmd.Parameters.AddWithValue("@date", now);
            insertcmd.Parameters.AddWithValue("@comment", commString);
            insertcmd.ExecuteNonQuery();
            conn.Close();
            FormsAuthentication.RedirectFromLoginPage(user, false);

        }
    }
}