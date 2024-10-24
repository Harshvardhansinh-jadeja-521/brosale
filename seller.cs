using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.SqlClient;
namespace Project_brosale
{
    public partial class seller : Form
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

        string i, d;

        void uploadimage()
        {
            openFileDialog1.ShowDialog();
            try
            {
                i = openFileDialog1.FileName.ToString();
                picimg.Load(i);
            }
            catch (Exception e)
            {

            }


        }
        public seller()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection();
            uploadimage();
        }

        private void seller_Load(object sender, EventArgs e)
        {
            connection();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection();
            
            string j = DateTime.Now.ToBinary().ToString();
            d = Application.StartupPath + "\\Image\\" + "j" + "_" + openFileDialog1.SafeFileName.ToString();
            System.IO.File.Copy(i, d);
            cmd = new SqlCommand("insert into Book_tbl (B_Title , B_Author , B_Category , B_Condition , B_Price , B_Quantity , B_Description , B_Image) values ('" + txtbooktitle.Text + "', '" + txtbookauthor.Text + "' , '" + txtbookcat.Text + "' , '" + txtbookcond.Text + "' , '" + txtprice.Text + "' , '" + txtqty.Text + "' , '" + txtbookdes.Text + "','" + d + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("done");
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Userp1 l = new Userp1();
            l.Show();
            this.Hide();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Ask l = new Ask();
            l.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
