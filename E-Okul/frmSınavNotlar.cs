using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace E_Okul
{
    public partial class frmSınavNotlar : Form
    {
        public frmSınavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.tbl_NotlarTableAdapter();

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtOgrID.Text));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmOgretmen fro = new frmOgretmen();
            this.Hide();
            fro.Show();

        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TN04UGV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void frmSınavNotlar_Load(object sender, EventArgs e)
        {
            //comboboxa veri aktarımı               //SqlClient,SqlCommand,SqlDataAdapter hepsini ekle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);    //komuttan gelen değeri buraya bağla
            DataTable dt = new DataTable();                   //bir tane veri tablosu oluştur
            da.Fill(dt);                                      //bunun içine doldur
            cmbDers.DisplayMember = "Dersad";            //comboboxta gözükücek olan isim kulupAd olsun
            cmbDers.ValueMember = "DersID";              //sistemde arkaplandaki değeri kulupID olsun,
            cmbDers.DataSource = dt;                      //veri kaynağını dt(veri tablosuyla) doldur
            baglanti.Close();
        }
        int notID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notID =int.Parse( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());  //seçilen 0. sütun
            txtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        int s1, s2, s3, proje;
        double ortalama;
        public void temizle()
        {
            txtDurum.Text = "";
            txtOgrID.Text = "";
            txtOrtalama.Text = "";
            txtProje.Text = "";
            txtSınav1.Text = "";
            txtSınav2.Text = "";
            txtSınav3.Text = "";
            txtOgrID.Focus();

        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        string durum;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            s1 = Convert.ToInt16(txtSınav1.Text);
            s2 = Convert.ToInt16(txtSınav2.Text);
            s3 = Convert.ToInt16(txtSınav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (s1 + s2 + s3 + proje) / 4;
            txtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                durum = "Geçti";
            }
            else
            {
                durum = "Kaldı";
            }
            txtDurum.Text = durum;

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //HATA
            ds.NotGuncelle(byte.Parse(txtSınav1.Text), byte.Parse(txtSınav2.Text), byte.Parse(txtSınav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text), notID); //sınav notlarını tiinyiny olarak tanımladığımız için hata veriyor onları byte a çevir diyor
        }
    }
}
