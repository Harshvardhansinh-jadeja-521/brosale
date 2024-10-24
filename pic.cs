using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Project_brosale
{
    public partial class pic : Form
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study_material\C#_Project\Brosale\Project_brosale\BrosaleDB.mdf;Integrated Security=True;Connect Timeout=30";

       
        private void pic_Load(object sender, EventArgs e)
        {

            LoadAllImagesFromDatabase();

        }
        private void LoadAllImagesFromDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Query to get the image data from your table
                    string query = "SELECT  B_Image from Book_tbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int x = 20; // Starting x position for PictureBox
                    int y = 20; // Starting y position for PictureBox
                    int spacing = 20; // Spacing between PictureBoxes

                    // Loop through the images retrieved from the database
                    while (reader.Read())
                    {
                        byte[] imageData = (byte[])reader["B_Image"]; // Assuming "ImageData" is the column name

                        if (imageData != null && imageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                PictureBox pictureBox = new PictureBox
                                {
                                    Image = Image.FromStream(ms), // Convert byte array to image
                                    Size = new Size(100, 100), // Set PictureBox size
                                    Location = new Point(x, y), // Set PictureBox location
                                    SizeMode = PictureBoxSizeMode.StretchImage // Make sure the image fits the box
                                };

                                // Add the new PictureBox to the panel instead of the form
                                this.panel1.Controls.Add(pictureBox);

                                // Move the x position for the next PictureBox
                                x += pictureBox.Width + spacing;

                                // If x exceeds panel width, move to the next row
                                if (x + pictureBox.Width > this.panel1.ClientSize.Width)
                                {
                                    x = 20; // Reset x position
                                    y += pictureBox.Height + spacing; // Move y down for the new row
                                }

                                pictureBox.Location = new Point(x, y); // Update PictureBox location after calculating
                            }
                        }
                    }

                    reader.Close(); // Close the reader after use
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message);
            }
        }

            private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoadImages_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
