using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_brosale
{
    public partial class Userp2 : Form
    {
      

      

        public Userp2()
        {
            InitializeComponent();
           /* vScrollBar1.Value = flowLayoutPanel1.VerticalScroll.Value;
            vScrollBar1.Minimum = flowLayoutPanel1.VerticalScroll.Minimum;
            vScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;*/


           // flowLayoutPanel1.ControlAdded += flowLayoutPanel1_ControlAdded;
        }

        private void userp2_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
          //  label1.Text = "BOOK:" + _book;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
           // flowLayoutPanel1.VerticalScroll.Value = vScrollBar1.Value;
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Userp1 l = new Userp1();
            l.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            H1 l = new H1();
            l.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            H2 l = new H2();
            l.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            H3 l = new H3();
            l.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            H4 l = new H4();
            l.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            H5 l = new H5();
            l.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            H6 l = new H6();
            l.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            H7 l = new H7();
            l.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

            H8 l = new H8();
            l.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

            H9 l = new H9();
            l.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            H11 l = new H11();
            l.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            H10 l = new H10();
            l.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            H12 l = new H12();
            l.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            seller l = new seller();
            l.Show();
            this.Hide();
        }
    }
}
