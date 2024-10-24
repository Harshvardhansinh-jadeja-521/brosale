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
    public partial class Login : Form
    {
        SqlConnection con; // use for connection
        SqlCommand cmd; // insert , update , delete
        SqlDataAdapter da; //select 
        DataSet ds; // container

        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study_material\C#_Project\Brosale\Project_brosale\BrosaleDB.mdf;Integrated Security=True;Connect Timeout=30";



        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            connection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* connection();
            cmd = new SqlCommand("insert into Login_tbl (Username , Password) values ('"+txtuname.Text +"' , '"+txtpass.Text +"')",con);
            cmd.ExecuteNonQuery();*/
                try
                {
                    connection();

                    // Using parameterized queries to prevent SQL injection
                    string query = "SELECT COUNT(*) FROM Login_tbl WHERE Username = @Username AND Password = @Password";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtuname.Text);
                    cmd.Parameters.AddWithValue("@Password", txtpass.Text);

                    int userCount = (int)cmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Login successfully...", "Login");
                    DashBoard b = new DashBoard();
                    b.Show();
                        
                        this.Hide(); // Hide the login form if login is successful
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Login Failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                }
                finally
                {
                    if (con != null && con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Ask a = new Ask();
            a.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Signup s = new Signup();
            s.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ask a = new Ask();
            a.Show();
            this.Hide();
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
