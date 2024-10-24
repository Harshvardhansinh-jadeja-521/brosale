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
    public partial class Userp7 : Form
    {
        public Userp7()
        {
            InitializeComponent();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Userp1 l = new Userp1();
            l.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            N1 l = new N1();
            l.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            N2 l = new N2();
            l.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            N3 l = new N3();
            l.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            N4 l = new N4();
            l.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            N5 l = new N5();
            l.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            N6 l = new N6();
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
