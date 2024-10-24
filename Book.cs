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
        int id;
        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study_material\C#_Project\Brosale\Project_brosale\BrosaleDB.mdf;Integrated Security=True;Connect Timeout=30";
        string i, d;
        

        void connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }
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
        /*void fillg()
        {
            connection();
            da = new SqlDataAdapter("select * from  Book_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }*/

        void fillg()
        {
            connection();
            da = new SqlDataAdapter("select B_Id , B_Title , B_Author , B_Category , B_Condition , B_Price , B_Quantity , B_Description , B_Image from Book_tbl", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("B_Image1", Type.GetType("System.Byte[]"));

            foreach (DataRow drow in dt.Rows)
            {
                drow["B_Image1"] = File.ReadAllBytes(drow["B_Image"].ToString());
            }
            dataGridView1.DataSource = dt;
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
            string book = txtbooktitle.Text;
            if(btnsave.Text=="Save")
            {
                connection();
                string j = DateTime.Now.ToBinary().ToString();
                d = Application.StartupPath + "\\Image\\" + "j" + "_" + openFileDialog1.SafeFileName.ToString();
                System.IO.File.Copy(i, d);
                cmd = new SqlCommand("insert into Book_tbl (B_Title , B_Author , B_Category , B_Condition , B_Price , B_Quantity , B_Description , B_Image) values ('" + txtbooktitle.Text + "', '" + txtbookauthor.Text + "' , '" + txtbookcat.Text + "' , '" + txtbookcond.Text + "' , '" + txtprice.Text + "' , '" + txtqty.Text + "' , '" + txtbookdes.Text + "','" + d + "')", con);
                cmd.ExecuteNonQuery();
               /* userp2 p = new userp2(book);
                p.ShowDialog();*/
              
                fillg();
            }

            else
            {
                connection();
                cmd = new SqlCommand("update Book_tbl set B_Title='" + txtbooktitle.Text + "',B_Author='" + txtbookauthor.Text + "',B_Category='" + txtbookcat.Text + "' , B_Condition='"+txtbookcond.Text+"',B_Price='"+txtprice.Text+"',B_Quantity='"+txtqty.Text+"',B_Description='"+txtbookdes.Text+"'         where B_Id='" + id + "'     ", con);
                cmd.ExecuteNonQuery();
            }
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            fillg();
            connection();
            da = new SqlDataAdapter("select  B_Title from Book_tbl", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add("B_Image1", Type.GetType("System.Byte[]"));
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

            /*Ask a = new Ask();
            a.Show();
            this.Hide();*/
        }

        private void combobooklist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection();
            uploadimage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Update")
            {
                button4.Text = "Update";
                connection();

                id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["B_Id"].Value);

                string title, author, cat, con, price, qty, des;
                title = dataGridView1.Rows[e.RowIndex].Cells["B_Title"].Value.ToString();
                author = dataGridView1.Rows[e.RowIndex].Cells["B_Author"].Value.ToString();
                cat = dataGridView1.Rows[e.RowIndex].Cells["B_Category"].Value.ToString();
                con = dataGridView1.Rows[e.RowIndex].Cells["B_Condition"].Value.ToString();
                price = dataGridView1.Rows[e.RowIndex].Cells["B_Price"].Value.ToString();
                qty = dataGridView1.Rows[e.RowIndex].Cells["B_Quantity"].Value.ToString();
                des = dataGridView1.Rows[e.RowIndex].Cells["B_Description"].Value.ToString();


                txtbooktitle.Text = title;
                txtbookauthor.Text = author;
                txtbookcat.Text = cat;
                txtbookcond.Text = con;
                txtprice.Text = price;
                txtqty.Text = qty;
                txtbookdes.Text = des;
            }
            else
            {
                connection();
                id = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells["B_Id"].Value);

                cmd = new SqlCommand("delete from Book_tbl where B_Id='" + id + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Record");
                fillg();

            }
        }

        private void txtbooktitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            User l = new User();
            l.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DashBoard l = new DashBoard();
            l.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            log l = new log();
            l.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Book l = new Book();
            l.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
