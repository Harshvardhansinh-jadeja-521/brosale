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
    public partial class Book : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study_material\C#_Project\Brosale\Project_brosale\BrosaleDB.mdf;Integrated Security=True;Connect Timeout=30";


        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        void fillg()
        {
            connection();
            da = new SqlDataAdapter("select * from  BookTbl", con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        public Book()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtbooktitle.Text=="" || txtbookauthor.Text == "" || txtqty.Text == "" || txtprice.Text == "" || combocat.SelectedIndex == -1)
            {
                MessageBox.Show("Messing Information");
            }

            else
            {
                connection();
                try
                {
                    cmd = new SqlCommand("insert into BookTbl (BTitle , BAuthor , BCat , BQty , BPrice ) values ('" + txtbooktitle.Text + "' , '" + txtbookauthor.Text + "', '"+ combocat.SelectedIndex.ToString() + "' ,'" + txtqty.Text + "' , '" + txtprice.Text + "' )", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book save successfully");
 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                fillg();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            fillg();
            connection();
        }
    }
}
