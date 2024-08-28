using System;
using System.Data;
using System.Data.SqlClient;

namespace dmrc
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void route_Click(object sender, EventArgs e)
        {
            
            string startstationId = StartDropDownList.SelectedValue;
            string endstationId = EndDropDownList.SelectedValue;
            string connectionString = "Data Source=DESKTOP-VK86AMV\\SQLEXPRESS; Initial Catalog=metro; Integrated Security=True";
            string query = @"
               Select StationId,Stations,line from Red where StationId between @StartStationId AND @EndStationId
               Union
               Select StationId,Stations,line from Yellow where StationId between @StartStationId AND @EndStationId
               Union
               Select StationId,Stations,line from Blue where StationId between @StartStationId AND @EndStationId
               Union
               Select StationId,Stations,line from Blue1 where StationId between @StartStationId AND @EndStationId
               Union
               Select StationId,Stations,line from Green where StationId between @StartStationId AND @EndStationId
               Union
               Select StationId,Stations,line from Violet where StationId between @StartStationId AND @EndStationId
               Union
               Select StationId,Stations,line from Pink where StationId between @StartStationId AND @EndStationId
               Union
               Select StationId,Stations,line from Margenta where StationId between @StartStationId AND @EndStationId
               Union
               Select StationId,Stations,line from Grey where StationId between @StartStationId AND @EndStationId

             ";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@StartStationId", startstationId);
                    command.Parameters.AddWithValue("@EndStationId", endstationId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        gridview.DataSource = dataTable;
                        gridview.DataBind();
                    }
                }
            }
        }

        protected void fare_Click(object sender, EventArgs e)
        {
            string startstation = StartDropDownList.SelectedValue;
            string endstation = EndDropDownList.SelectedValue;
            string connectionString = "Data Source=DESKTOP-VK86AMV\\SQLEXPRESS; Initial Catalog=metro; Integrated Security=True";

            
            int stationCount = CountStations(startstation, endstation, connectionString);

           
            decimal fare = CalculateFare(stationCount);

            
            StoreFare(startstation, endstation, fare, connectionString);

           
            string popupScript = $@"<script>window.alert('Total Fare: ₹{fare.ToString("0.00")}');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", popupScript);
        }

        protected int CountStations(string startstation, string endstation, string connectionString)
        {
            int totalStationCount = 0;

            string[] tableNames = { "Red", "Yellow", "Blue", "Blue1", "Green", "Violet", "Margenta", "Pink", "Grey" };

            foreach (string tableName in tableNames)
            {
                string countQuery = $@"
            SELECT COUNT(*) FROM {tableName}
            WHERE StationId BETWEEN @StartStationId AND @EndStationId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                    {
                        countCommand.Parameters.AddWithValue("@StartStationId", startstation);
                        countCommand.Parameters.AddWithValue("@EndStationId", endstation);
                        totalStationCount += (int)countCommand.ExecuteScalar();
                    }
                }
            }

            return totalStationCount;
        }

        protected decimal CalculateFare(int stationCount)
        {
            decimal farePerStation = 2; // Fare per station

            // Calculating fare based on the number of stations
            return stationCount * farePerStation;
        }

        protected void StoreFare(string startstation, string endstation, decimal fare, string connectionString)
        {
            string insertQuery = @"
        INSERT INTO FareTransactions (StartStation, EndStation, Fare)
        VALUES (@StartStationId, @EndStationId, @Fare)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@StartStationId", startstation);
                    insertCommand.Parameters.AddWithValue("@EndStationId", endstation);
                    insertCommand.Parameters.AddWithValue("@Fare", fare);
                    insertCommand.ExecuteNonQuery();
                }
            }
        }

       
            
        }
    }



