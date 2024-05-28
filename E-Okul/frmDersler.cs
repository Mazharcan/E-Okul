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
    public partial class frmDersler : Form
    {
        public frmDersler()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.tbl_DerslerTableAdapter();

        private void frmDersler_Load(object sender, EventArgs e)
        {
            //HİÇ SORGU YAZMADAN SİHİRBAZ ÜZERİNDE HALLETTİK ,DATASET 
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAd.Text);
            MessageBox.Show("Ders Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersID.Text)); 
            MessageBox.Show("Ders Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            ds.DersGüncelle(txtDersAd.Text, byte.Parse(txtDersID.Text));
            MessageBox.Show("Ders Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();


        }
    }
}
