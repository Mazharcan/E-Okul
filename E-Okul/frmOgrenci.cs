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
    public partial class frmOgrenci : Form
    {
        public frmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TN04UGV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void frmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kulupler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);    //komuttan gelen değeri buraya bağla
            DataTable dt = new DataTable();                   //bir tane veri tablosu oluştur
            da.Fill(dt);                                      //bunun içine doldur
            cmbOgrKulup.DisplayMember = "KulupAd";            //comboboxta gözükücek olan isim kulupAd olsun
            cmbOgrKulup.ValueMember = "KulupID";              //sistemde arkaplandaki değeri kulupID olsun,
            cmbOgrKulup.DataSource = dt;                      //veri kaynağını dt(veri tablosuyla) doldur
            baglanti.Close();
        }
        string c = "";         //cinsiyet değişkeni                       //else kısmı olmadığından ds kodunda ki c hata verir o yüzden c ye başta boş değer ata

private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.OgrenciEkle(txtOgrAd.Text, txtOgrSoyad.Text, byte.Parse(cmbOgrKulup.SelectedValue.ToString()), c);   //combobox.text değil cmbOgrKulup.SelectedValue.ToString() olucak seçilen değer siliicek 
            MessageBox.Show("Öğrenci Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

        }
        private void cmbOgrKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtOgrID.Text = cmbOgrKulup.SelectedValue.ToString();         //combobaxta seçlen değeri string olarak txtID ya yazdır 
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtOgrID.Text));
            MessageBox.Show("Öğrenci Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //eğer cinsiyet erkek ise raidbtnerkek değilse kız seçili olsun
          //RADİOBUTTON-CİNSİYET VE COMBOBOX-KULÜP YAPMAYI UNUTMA



        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelleme(txtOgrAd.Text, txtOgrSoyad.Text,byte.Parse(cmbOgrKulup.SelectedValue.ToString()),c,int.Parse(txtOgrID.Text));
            MessageBox.Show("Öğrenci Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rdbtnKız_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnKız.Checked == true)
            {
                c = "Kız";
            }
        }

        private void rdbtnErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnErkek.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
             dataGridView1.DataSource= ds.OgrenciGetir(txtAra.Text);
        }
    }
}
