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

namespace E_Okul
{
    public partial class frmKulupIslemleri : Form
    {
        public frmKulupIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TN04UGV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
          void liste()    //METOT
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulupler", baglanti);           //koşul olmadığından command kullanmana gerek yok
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void frmKulupIslemleri_Load(object sender, EventArgs e)
        {
            liste();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //sen kulüp ksımına uzun bir metin yazarsan kod patlar hata verir sen bir sütuna Sqlde ki alandan daha çok değer verdin (varchar() kısıtlaması yüzünden)
            //bunun için hata kontrollerini kullanıcaksın  try catch bloğu!

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_kulupler (kulupad) values (@p1)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulupAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;              //mousehower çift tıkla yani mouse üstüne gelince nolsun
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("delete from tbl_kulupler where kulupID = @p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtKulupID.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update tbl_kulupler set kulupad = @b1 where kulupıd = @b2", baglanti);
            komut3.Parameters.AddWithValue("@b1", txtKulupAd.Text);
            komut3.Parameters.AddWithValue("@b2", txtKulupID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }
    }
}
