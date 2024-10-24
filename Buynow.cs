using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace Project_brosale
{
    public partial class Buynow : Form
    {
        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study_material\C#_Project\Brosale\Project_brosale\BrosaleDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }


        public Buynow()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection();

            
            cmd = new SqlCommand("insert into Order_tbl (Fullname , Mobile , Pincode , Address) values ('" + txtfname.Text + "', '" + txtmobile.Text + "' , '" + txtpincode.Text + "' , '" + txtadd.Text + "' )", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("done");
            Thanku l = new Thanku();
            l.Show();
            this.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Userp1 dashboard = new Userp1();
            dashboard.Show();
            this.Hide();
        }
    }
}
