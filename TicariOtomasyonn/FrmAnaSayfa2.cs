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

namespace TicariOtomasyonn
{
    public partial class FrmAnaSayfa2 : Form
    {
        public FrmAnaSayfa2()
        {
            InitializeComponent();
        }

        sqlbaglantisi baglan = new sqlbaglantisi();

        //ÜRÜNLER SAYFASI
        void listele()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TBL_URUNLER", baglan.baglanti());
            adapter.Fill(table);
            dataGridView1.DataSource=table;
        }

        void temizle()
        {
            adtxt.Text="";
            TxtAlis.Text="";
            txtID.Text="";
            TxtMarka.Text="";
            TxtModel.Text="";
            TxtSatis.Text="";
            maskedYil.Text="";
            numericAdet.Value=0;
            richTextBoxDetay.Text="";
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglan.baglanti());
            komut.Parameters.AddWithValue("p1", adtxt.Text);
            komut.Parameters.AddWithValue("p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("p3", TxtModel.Text);
            komut.Parameters.AddWithValue("p4", maskedYil.Text);
            komut.Parameters.AddWithValue("p5", int.Parse((numericAdet.Value).ToString()));
            komut.Parameters.AddWithValue("p6", decimal.Parse(TxtAlis.Text).ToString());
            komut.Parameters.AddWithValue("p7", decimal.Parse(TxtSatis.Text).ToString());
            komut.Parameters.AddWithValue("p8", richTextBoxDetay.Text);
            komut.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Ürün Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("DELETE FROM TBL_URUNLER WHERE ID=@p1", baglan.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtID.Text);
            komutsil.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_URUNLER SET URUNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 WHERE ID=@p9", baglan.baglanti());
            komut.Parameters.AddWithValue("p1", adtxt.Text);
            komut.Parameters.AddWithValue("p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("p3", TxtModel.Text);
            komut.Parameters.AddWithValue("p4", maskedYil.Text);
            komut.Parameters.AddWithValue("p5", int.Parse((numericAdet.Value).ToString()));
            komut.Parameters.AddWithValue("p6", decimal.Parse(TxtAlis.Text));
            komut.Parameters.AddWithValue("p7", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("p8", richTextBoxDetay.Text);
            komut.Parameters.AddWithValue("p9", txtID.Text);
            komut.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        //PERSONEL SAYFASI

        void personelliste()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TBL_PERSONEL", baglan.baglanti());
            adapter.Fill(table);
            dataGridView3.DataSource=table;
            
        }

        void sehirliStesi()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_ILLER", baglan.baglanti());
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                cmbIL.Items.Add(reader[0]);
            }
            baglan.baglanti().Close();
        }

      /*  private void FrmPersonel_Load(object sender, EventArgs e)
        {
            personelliste();
            sehirliStesi();
            
        }*/
        void temizle2()
        {
            IDTEXT.Text="";
            ADTXTBOX.Text="";
            SOYADTXTBOX.Text="";
            MskTC.Text="";
            MskTel.Text="";
            TxtMail.Text="";
            cmbIL.Text="";
            CMBILCE.Text="";
            RCHADRES.Text="";
            TXTGOREV.Text="";
        }

        private void KAYDETbtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_PERSONEL (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)", baglan.baglanti());
            komut.Parameters.AddWithValue("@P1", ADTXTBOX.Text);
            komut.Parameters.AddWithValue("@P2", SOYADTXTBOX.Text);
            komut.Parameters.AddWithValue("@P3", MskTel.Text);
            komut.Parameters.AddWithValue("@P4", MskTC.Text);
            komut.Parameters.AddWithValue("@P5", TxtMail.Text);
            komut.Parameters.AddWithValue("@P6", cmbIL.Text);
            komut.Parameters.AddWithValue("@P7", CMBILCE.Text);
            komut.Parameters.AddWithValue("@P8", RCHADRES.Text);
            komut.Parameters.AddWithValue("@P9", TXTGOREV.Text);
            komut.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelliste();
        }

        private void SILbtn_Click(object sender, EventArgs e)
        {

            SqlCommand komutsil = new SqlCommand("DELETE FROM TBL_PERSONEL WHERE ID=@P1", baglan.baglanti());
            komutsil.Parameters.AddWithValue("@P1", IDTEXT.Text);
            komutsil.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Personel Listeden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
            personelliste();
            temizle();
        }

        private void GUNCELLEbtn_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_PERSONEL SET AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9 WHERE ID=@P10", baglan.baglanti());
            komut.Parameters.AddWithValue("@P1", ADTXTBOX.Text);
            komut.Parameters.AddWithValue("@P2", SOYADTXTBOX.Text);
            komut.Parameters.AddWithValue("@P3", MskTel.Text);
            komut.Parameters.AddWithValue("@P4", MskTC.Text);
            komut.Parameters.AddWithValue("@P5", TxtMail.Text);
            komut.Parameters.AddWithValue("@P6", cmbIL.Text);
            komut.Parameters.AddWithValue("@P7", CMBILCE.Text);
            komut.Parameters.AddWithValue("@P8", RCHADRES.Text);
            komut.Parameters.AddWithValue("@P9", TXTGOREV.Text);
            komut.Parameters.AddWithValue("@P10", IDTEXT.Text);
            komut.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personelliste();
        }

        private void TEMIZLEbtn_Click(object sender, EventArgs e)
        {
            temizle2();
        }

        private void cmbIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIL.Items.Clear();
            SqlCommand komut = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE Sehır=@p1", baglan.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbIL.SelectedIndex + 1);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                CMBILCE.Items.Add(reader[0]);
            }
            baglan.baglanti().Close();
        }

        private void FrmAnaSayfa2_Load(object sender, EventArgs e)
        {
            personelliste();
            sehirliStesi();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
           // baglan.baglanti().Open();
            SqlDataAdapter veri = new SqlDataAdapter("SELECT * FROM TBL_URUNLER",baglan.baglanti());
            DataTable table = new DataTable();
            veri.Fill(table);
            dataGridView1.DataSource = table;
            baglan.baglanti().Close();
        }

        // STOKLAR SAYFASI
        private void Btn_VerileriGoster_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select UrunAd,Sum(Adet) As 'Miktar' from Tbl_URUNLER group by UrunAd", baglan.baglanti());
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView4.DataSource = table;
            baglan.baglanti().Close();

        }
    }
}
