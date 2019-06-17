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

    protected void generate_Click(object sender, EventArgs e)
    {
        ListBox1.Items.Clear();
        feedback.Text = "";
        int start = 0;
        int count = 0;
        if (int.TryParse(startIntBox.Text, out start) && int.TryParse(countBox.Text, out count))
        {
            if((start >= 0 && start <= 1000000000) && (count >= 1 && count <= 100))
            {
                int i = 0;
                while(i < count)
                {
                    string orig = start.ToString();
                    string rev = new string(orig.ToCharArray().Reverse().ToArray());
                    if(orig.Equals(rev))
                    {
                        ListBox1.Items.Add(start.ToString());
                        i++;
                    }
                    start++;
                }
            }
            else
            {
                feedback.Text = "Please enter a positive integer within range.";
            }
        }
        else
        {
            feedback.Text = "Please enter a positive integer within range.";
        }
    }
}