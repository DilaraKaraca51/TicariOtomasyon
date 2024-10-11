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
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi baglan = new sqlbaglantisi();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_ADMIN WHERE KullaniciAd=@p1 AND Sifre=@p2", baglan.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullanıcıAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                FrmAnaSayfa2 anasayfa = new FrmAnaSayfa2();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO TBL_ADMIN(KullaniciAd,Sifre)values (@KullaniciAd,@Sifre)";
            SqlCommand komut = new SqlCommand(sorgu,baglan.baglanti());
            komut.Parameters.AddWithValue("@KullaniciAd", txtkullanici.Text);
            komut.Parameters.AddWithValue("@Sifre", txtsifre2.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Oluşturuldu");
            baglan.baglanti().Close();
        }

     
    }
}
