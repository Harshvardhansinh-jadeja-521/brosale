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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        int id;
        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study_material\C#_Project\Brosale\Project_brosale\BrosaleDB.mdf;Integrated Security=True;Connect Timeout=30";
        
        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }
        void fillg()
        {
            connection();
            da = new SqlDataAdapter("select B_Image from Book_tbl", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("B_Image1", Type.GetType("System.Byte[]"));

            foreach (DataRow drow in dt.Rows)
            {
                drow["B_Image1"] = File.ReadAllBytes(drow["B_Image"].ToString());
            }
            dataGridView1.DataSource = dt;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            connection();
            fillg();
        }

        private void DashBoard_Paint(object sender, PaintEventArgs e)
        {
            
            
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DashBoard l = new DashBoard();
            l.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Book l = new Book();
            l.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            User l = new User();
            l.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            log l = new log();
            l.Show();
            this.Hide();
        }
    }
}
