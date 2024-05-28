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
    public partial class frmOgrenciNotlar : Form
    {
        public frmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TN04UGV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
       
        private void frmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DersAd,Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum from tbl_Notlar inner join tbl_Dersler on tbl_Notlar.DersID=tbl_Dersler.DersID where OgrId =@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();              //numara değişkenini from açıldığında formun sol üstüne yaz
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

  



        }
    }
}
