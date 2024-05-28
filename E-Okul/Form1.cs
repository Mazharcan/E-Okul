using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Okul
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmOgrenciNotlar fr = new frmOgrenciNotlar();
            fr.numara = textBox1.Text;  //fr dekii numara değişkenne textbox a gireceğindeğeri ata 
            fr.Show();
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmOgretmen fr = new frmOgretmen();
            fr.Show();
            this.Hide();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }
    }
}
