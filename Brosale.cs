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
    public partial class Brosale : Form
    {
        public Brosale()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int startpro = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpro += 1;
            Myprogress.Value = startpro;
            Pr.Text = startpro + "%";
            if(Myprogress.Value == 100)
            {
                Myprogress.Value = 0;
                timer1.Stop();

                Login l = new Login();
                l.Show();
                this.Hide();
            }
        }

        private void Brosale_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
