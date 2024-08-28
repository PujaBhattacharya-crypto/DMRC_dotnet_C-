using System;
using System.Data;
using System.Data.SqlClient;

namespace dmrc
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                BindMostUsedStations();
            }
        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {
            BindGridView();
            BindMostUsedStations();
        }

        private void BindGridView()
        {
            try
            {
                // Fetch data from the database based on the selected time period
                DataTable dtQRfare = FetchQRfareData(ddlTimePeriod.SelectedValue);

                // Bind the fetched data to the GridView
                GridView1.DataSource = dtQRfare;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                
                Response.Write("An error occurred: " + ex.Message);
            }
        }

        private DataTable FetchQRfareData(string timePeriod)
        {
            string connectionString = "Data Source=DESKTOP-VK86AMV\\SQLEXPRESS; Initial Catalog=metro; Integrated Security=True";
            string query = "";
            switch (timePeriod)
            {
                case "Month":
                    query = "SELECT YEAR(QR.TransactionDate) AS [Year], MONTH(QR.TransactionDate) AS [Month], QR.TransactionDate, " +
                            "STRING_AGG(QR.EndStation, ', ') AS StationNames, SUM(QR.FareAmount) AS TotalFare " +
                            "FROM QRfare QR " +
                            "GROUP BY YEAR(QR.TransactionDate), MONTH(QR.TransactionDate), QR.TransactionDate";
                    break;
                case "Week":
                    query = "SELECT YEAR(QR.TransactionDate) AS [Year], DATEPART(WEEK, QR.TransactionDate) AS [Week], QR.TransactionDate, " +
                            "STRING_AGG(QR.EndStation, ', ') AS StationNames, SUM(QR.FareAmount) AS TotalFare " +
                            "FROM QRfare QR " +
                            "GROUP BY YEAR(QR.TransactionDate), DATEPART(WEEK, QR.TransactionDate), QR.TransactionDate";
                    break;
                case "Year":
                    query = "SELECT YEAR(QR.TransactionDate) AS [Year], QR.TransactionDate, " +
                            "STRING_AGG(QR.EndStation, ', ') AS StationNames, SUM(QR.FareAmount) AS TotalFare " +
                            "FROM QRfare QR " +
                            "GROUP BY YEAR(QR.TransactionDate), QR.TransactionDate";
                    break;
                default:
                    query = "SELECT QR.TransactionDate, " +
                            "STRING_AGG(QR.EndStation, ', ') AS StationNames, SUM(QR.FareAmount) AS TotalFare " +
                            "FROM QRfare QR " +
                            "GROUP BY QR.TransactionDate";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // Method to fetch most used stations
        private DataTable FetchMostUsedStations()
        {
            string connectionString = "Data Source=DESKTOP-VK86AMV\\SQLEXPRESS; Initial Catalog=metro; Integrated Security=True";
            string query = "SELECT TOP 5 StationName AS Station, COUNT(*) AS UsageCount " +
                           "FROM VisitedStations " +
                           "GROUP BY StationName " +
                           "ORDER BY COUNT(*) DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        // Method to bind most used stations to GridView
        private void BindMostUsedStations()
        {
            try
            {
                // Fetch most used stations
                DataTable dtMostUsedStations = FetchMostUsedStations();

                // Bind the fetched data to the GridView
                gvMostUsedStations.DataSource = dtMostUsedStations;
                gvMostUsedStations.DataBind();
            }
            catch (Exception ex)
            {
               
                Response.Write("An error occurred while fetching most used stations: " + ex.Message);
            }
        }
    }
}
