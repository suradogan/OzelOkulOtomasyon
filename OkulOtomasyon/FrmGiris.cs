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

namespace OkulOtomasyon
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void BtnYonetici_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği TC ve şifreyi al
            string yoneticiTC = MskTC.Text;
            string yoneticiSifre = TxtSifre.Text;

            // SQL sorgusunu yaz
            string sorgu = "SELECT * FROM TBL_YONETICI WHERE YONETICI_TC = @tc AND YONETICI_SIFRE = @sifre";

            try
            {
                SqlConnection baglanti = bgl.baglanti(); // Veritabanı bağlantısı
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@tc", yoneticiTC); // Kullanıcının TC'sini parametre olarak ekle
                komut.Parameters.AddWithValue("@sifre", yoneticiSifre); // Kullanıcının şifresini parametre olarak ekle

                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    // Giriş başarılı, yeni forma geçiş yap
                    Form1 yoneticiForm = new Form1();
                    yoneticiForm.Show();
                    this.Hide();
                }
                else
                {
                    // TC veya şifre yanlış
                    MessageBox.Show("TC veya Şifre hatalı! Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                baglanti.Close(); // Bağlantıyı kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Veritabanı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /* Giriş yapıldıktan sonra
        FrmNotListele frm = new FrmNotListele();
        frm.OgrenciAdSoyad = "Ali Veli"; // Çekilen Ad Soyad
frm.OgrenciTC = "12345678910"; // Öğrencinin TC'si
frm.Show();
this.Hide();*/


        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            // Veritabanı bağlantısı
            sqlbaglantisi bgl = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("SELECT OGRAD, OGRSOYAD FROM TBL_OGRENCILERR WHERE OGRTC = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                string adSoyad = dr["OGRAD"].ToString() + " " + dr["OGRSOYAD"].ToString();

                // Yeni form açılıyor ve bilgi aktarılıyor
                FrmNotListele frm = new FrmNotListele();
                frm.OgrenciAdSoyad = adSoyad; // Ad Soyad aktarılıyor
                frm.OgrenciTC = MskTC.Text;   // TC bilgisi de aktarılıyor
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçersiz TC Kimlik Numarası veya Şifre !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bgl.baglanti().Close();
        }

        private void BtnOgretmen_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select OGRTTC,OGRTSIFRE from TBL_OGRTAYARLAR inner join TBL_OGRETMENLER on TBL_OGRTAYARLAR.AYARLAROGRTID=TBL_OGRETMENLER.OGRTID where OGRTTC =@p1 and OGRTSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmNotGiris frm1 = new FrmNotGiris();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifreniz Hatalı");
                MskTC.Text = "";
                TxtSifre.Text = "";
            }
            bgl.baglanti().Close();
        }
    } 
    }

    

