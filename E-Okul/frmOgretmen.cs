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
    public partial class frmOgretmen : Form
    {
        public frmOgretmen()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmKulupIslemleri frk = new frmKulupIslemleri();
            frk.Show();
        }

        private void btnDERS_Click(object sender, EventArgs e)
        {
            frmDersler frd = new frmDersler();
            frd.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOGRENCI_Click(object sender, EventArgs e)
        {
            frmOgrenci fro = new frmOgrenci();
            fro.Show();
        }

        private void btnNOT_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSınavNotlar frn = new frmSınavNotlar();
            frn.Show();
        }

        private void btnOGRETMEN_Click(object sender, EventArgs e)
        {
            this.Hide();
            OgretmenOzellik froo = new OgretmenOzellik();
            froo.Show();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmGiris frg = new frmGiris();  
            frg.Show();
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
