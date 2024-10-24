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
    public partial class log : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
      //  SqlDataAdapter da;
        DataTable dt;
        private string adminUsername = "admin";
        private string adminPassword = "123";

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study_material\C#_Project\Brosale\Project_brosale\BrosaleDB.mdf;Integrated Security=True;Connect Timeout=30";


        void connection()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
        public log()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            sign log = new sign();
            log.Show();
            this.Hide();
        }

        private void log_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtuname.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;  // Stop further execution
            }

            // Connect to the database
            connection();

            try
            {
                // SQL query to check if the username and password match
                string query = "SELECT * FROM user_tbl WHERE U_Uname = @username AND U_Pass = @password";
                cmd = new SqlCommand(query, con);

                // Add parameters to avoid SQL injection
                cmd.Parameters.AddWithValue("@username", txtuname.Text);
                cmd.Parameters.AddWithValue("@password", txtpass.Text);

                // Execute query and store result in a DataTable
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // Check if any rows are returned (i.e., the credentials are correct)
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login successful!");
                    Ask log = new Ask();
                    log.Show();
                    this.Hide();

                    // You can redirect to the next form or dashboard here
                    // Example:
                    // Dashboard dashboard = new Dashboard();
                    // dashboard.Show();
                    // this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (SqlException ex)
            {
                // SQL-specific error handling
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General error handling
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the database connection is closed
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (txtuname.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Please enter both username and password.");
                return;  // Stop further execution
            }

            // Check if the entered credentials match the admin credentials
            if (txtuname.Text == adminUsername && txtpass.Text == adminPassword)
            {
                MessageBox.Show("Admin login successful!");

                // Redirect to admin dashboard or any other form
                DashBoard dashboard = new DashBoard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid admin username or password.");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
