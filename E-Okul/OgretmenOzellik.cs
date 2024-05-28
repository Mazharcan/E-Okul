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
    public partial class OgretmenOzellik : Form
    {
        public OgretmenOzellik()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_OgretmenlerTableAdapter ds = new DataSet1TableAdapters.tbl_OgretmenlerTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TN04UGV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");


        private void OgretmenOzellik_Load(object sender, EventArgs e)
        {
            //comboboxa veri aktarımı               //SqlClient,SqlCommand,SqlDataAdapter hepsini ekle
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);    //komuttan gelen değeri buraya bağla
            DataTable dt = new DataTable();                   //bir tane veri tablosu oluştur
            da.Fill(dt);                                      //bunun içine doldur
            cmbBrans.DisplayMember = "DersAd";            //comboboxta gözükücek olan isim kulupAd olsun
            cmbBrans.ValueMember = "DersID";              //sistemde arkaplandaki değeri kulupID olsun,
            cmbBrans.DataSource = dt;                      //veri kaynağını dt(veri tablosuyla) doldur
            baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgretmenListe();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmOgretmen fro = new frmOgretmen();
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.OgretmenEkle(txtOgrAdSoyad.Text,byte.Parse(cmbBrans.SelectedValue.ToString())); 
            MessageBox.Show("Öğretmen Eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgretmenGetir(txtAra.Text);    //öğrencide ad ve soıyad ayrı olduğu i,çin sadece adı yazınca geldi
                                                                        //ama öğretmenler tablosunda adsoyad şeklinde olduğu için ad ve soyadı yazman gerekir aratabilmek için
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            ds.OgretmenGuncelle(txtOgrAdSoyad.Text, byte.Parse(cmbBrans.SelectedValue.ToString()), byte.Parse(txtOgrID.Text));
            MessageBox.Show("Öğretmen Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrAdSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgretmenSil(byte.Parse(txtOgrID.Text));
            MessageBox.Show("Öğretmen Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
