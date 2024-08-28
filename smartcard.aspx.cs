using System;
using System.Data.SqlClient;

namespace dmrc
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int Cardnumber;
            if (int.TryParse(card.Text, out Cardnumber))
            {
                if (IsMetroCardValid(Cardnumber)) 
                {
                    int Rechargeamount;
                if (int.TryParse(amount.Text, out Rechargeamount))
                {
                    int existingbalance = GetExistingBalance(Cardnumber);
                    int newbalance = existingbalance + Rechargeamount;
                    InsertTransaction(Cardnumber, Rechargeamount, newbalance);

                 string script = $"alert('Recharge successful!Your total balance is now Rs. {newbalance}');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Recharge Success", script, true);
                }
                else
                {
                    Response.Write("Please enter a valid recharge amount.");
                }
            }
            else
            {
                    cardError.Text = "Invalid card number.";
                
            }
        }
            else
            {
                cardError.Text = "Invalid card number.";
            }
        }
        private bool IsMetroCardValid(int cardnumber)
        {
            return cardnumber.ToString().Length == 8; 
        }

        void InsertTransaction(int cardnumber, int rechargeamount, int totalbalance)
        {
            string connectionstring = "Data Source=DESKTOP-VK86AMV\\SQLEXPRESS; Initial Catalog=metro; Integrated Security=True ";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO RechargeInfo (CardNumber,RechargeAmount,TotalBalance, TransactionDate) Values (@CardNumber,@RechargeAmount, @totalbalance, GETDATE())", connection);
                insertCommand.Parameters.AddWithValue("@CardNumber", cardnumber);
                insertCommand.Parameters.AddWithValue("@RechargeAmount", rechargeamount);
                insertCommand.Parameters.AddWithValue("@TotalBalance", totalbalance);
                insertCommand.ExecuteNonQuery();
            }
        }
        private int GetExistingBalance(int cardnumber)
        {
            int existingbalance = 0;
            string connectionstring = "Data Source=DESKTOP-VK86AMV\\SQLEXPRESS; Initial Catalog=metro; Integrated Security=True ";
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ISNULL(SUM(RechargeAmount),0)FROM RechargeInfo WHERE CardNumber=@CardNumber", connection);
                command.Parameters.AddWithValue("@CardNumber", cardnumber);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    existingbalance = Convert.ToInt32(result);
                }
            }
            return existingbalance;
        }
    } 
}