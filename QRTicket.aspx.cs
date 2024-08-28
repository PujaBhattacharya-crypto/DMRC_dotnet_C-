using System;
using System.Drawing;
using System.IO;
using ZXing;
using ZXing.QrCode;

using System.Data.SqlClient;

namespace dmrc
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void qr_ticket_button_Click(object sender, EventArgs e)
        {
            GenerateQRCode();
        }

        private void GenerateQRCode()
        {
            string startStation = DropDownList1.SelectedValue;
            string endStation = DropDownList2.SelectedValue;

            // Calculate fare based on the number of stations traveled
            int fare = CalculateFare(startStation, endStation);
            string transactionDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            
            string data = $"{startStation}-{endStation} Fare: {fare} DateTime: {transactionDateTime}";
            


            // Generate QR code writer
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = 300,
                    Height = 300
                }
            };

            // Generate QR code bitmap
            Bitmap qrCodeBitmap = writer.Write(data);

            // Convert QR code bitmap to byte array
            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();

                // Convert byte array to Base64 string
                string base64String = Convert.ToBase64String(byteImage);

                // Display the QR code image
                qrCodeImage.ImageUrl = "data:image/png;base64," + base64String;
            }
        }

        private int CalculateFare(string startStation, string endStation)
        {

            int startIndex = DropDownList1.SelectedIndex;
            int endIndex = DropDownList2.SelectedIndex;
            int numberOfStations = Math.Abs(endIndex - startIndex);
            int farePerStation = 2;
            int fare = numberOfStations * farePerStation;
            InsertFareData(startStation, endStation, fare);
            return fare;
        }
        private void InsertFareData(string startStation, string endStation, int fare)
        {
            string connectionString = "Data Source=DESKTOP-VK86AMV\\SQLEXPRESS; Initial Catalog=metro; Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO QRfare (StartStation, EndStation, FareAmount,TransactionDate) VALUES (@StartStation, @EndStation, @FareAmount,@TransactionDate); SELECT SCOPE_IDENTITY()";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartStation", startStation);
                command.Parameters.AddWithValue("@EndStation", endStation);
                command.Parameters.AddWithValue("@FareAmount", fare);
                command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                connection.Open();
                int transactionID = Convert.ToInt32(command.ExecuteScalar());
            }
        }
        }
    }

