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
    public partial class sign : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study_material\C#_Project\Brosale\Project_brosale\BrosaleDB.mdf;Integrated Security=True;Connect Timeout=30";
        

        void connection()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
        public sign()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (txtfname.Text == "" || txtlname.Text == "" || txtuname.Text == "" || txtphone.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;  // Stop further execution
            }

            // Connect to the database
            connection();

            // SQL query to insert data
            string query = "INSERT INTO user_tbl (U_Fname, U_Lname, U_Uname, U_Phone, U_Pass) VALUES (@firstName, @lastName, @username, @phone, @password)";
            cmd = new SqlCommand(query, con);

            // Add parameters to the query
            cmd.Parameters.AddWithValue("@firstName", txtfname.Text);
            cmd.Parameters.AddWithValue("@lastName", txtlname.Text);
            cmd.Parameters.AddWithValue("@username", txtuname.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@password", txtpass.Text);

            try
            {
                // Execute the command
                cmd.ExecuteNonQuery();
                MessageBox.Show("Signup successful!");

                // Redirect to login page
                log log = new log();
                log.Show();
                this.Hide();
            }
            catch (SqlException ex)
            {
                // SQL-specific error handling
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Generic error handling
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure that the connection is closed properly
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            log log = new log();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    
}
