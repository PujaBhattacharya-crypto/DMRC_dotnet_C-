using System;

using System.Web.UI;


namespace dmrc
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = nametxt.Text;
            string password = pass.Text;
            bool isValid = ValidateUser(username, password);
        if (isValid)
            {
                Response.Redirect("Reportgeneration.aspx");
            }
            else
            {
                
                Response.Write("Invalid username or password");
            }
        }

        private bool ValidateUser(string username, string password)
{
    return username == "Puja Bhattacharya" && password == "Puja@123";
}

       
    }
}