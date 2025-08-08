using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using DevExpress.Utils.Html;
using DevExpress.XtraEditors;
using static DevExpress.XtraEditors.Mask.MaskSettings;
using System.Data.Entity;



namespace OkulOtomasyon
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
       DbOkulEntities db = new DbOkulEntities();

        //ado.net öğretmen şifre bilgileri
        void listele()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute AyarlarOgretmenler", bgl.baglanti());
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;


        }
        //entity freamwork öğrenci listele
        void ogrlistele()
        {
            // gridControl2.DataSource = db.AyarlarOgrenciler();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute AyarlarOgrenciler", bgl.baglanti());
            da1.Fill(dt1);
            gridControl2.DataSource = dt1;



        }

        void ogretmenlistesi()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select OGRTID, (OGRTAD+' ' +OGRTSOYAD) AS 'OGRTADSOYAD' , OGRTBRANS from TBL_OGRETMENLER", bgl.baglanti());
            da2.Fill(dt2);
            lookUpEdit1.Properties.ValueMember = "OGRTID";
            lookUpEdit1.Properties.DisplayMember = "OGRTADSOYAD";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";
            lookUpEdit1.Properties.DataSource = dt2;

        }
        
        void ogrencilistesi()
        {
           
            var deger = from item in db.TBL_OGRENCILERR
                        select new
                        {
                            OGRID = item.OGRID,
                            OGRADSOYAD = item.OGRAD + " " + item.OGRSOYAD,
                            OGRSINIF = item.OGRSINIF,
                        };
            lookUpEdit2.Properties.ValueMember = "OGRID";
            lookUpEdit2.Properties.DisplayMember = "OGRADSOYAD";
            lookUpEdit2.Properties.NullText = "Öğrenci Seçiniz";
            lookUpEdit2.Properties.DataSource = deger.ToList();
        }
        void temizle()
        {
            txtogrtId.Text = "";
            txtogrId.Text = "";
            txtsinif.Text = "";
            txtbrans.Text = "";
            txtsifre.Text = "";
            txtogrsifre.Text = "";
            mskogrttc.Text = "";
            mskogrtc.Text = "";
            pictureEdit1.Text = "";
            pictureEdit2.Text = "";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";
            lookUpEdit1.Properties.NullText = "Öğrrenci Seçiniz";
        }

        public string yeniyol;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            ogretmenlistesi();
            temizle();
            ogrlistele();
            ogrencilistesi();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtogrtId.Text = dr["AYARLAROGRTID"].ToString();
                lookUpEdit1.Text = dr["OGRTADSOYAD"].ToString();
                txtbrans.Text = dr["OGRTBRANS"].ToString();
                mskogrttc.Text = dr["OGRTTC"].ToString();
                txtsifre.Text = dr["OGRTSIFRE"].ToString();

                // Resim yolunu oluştur
                string fotoDosyasi = dr["OGRTFOTO"].ToString();
                if (!string.IsNullOrEmpty(fotoDosyasi))
                {
                    yeniyol = Path.Combine("C:\\Users\\dogan\\OneDrive\\Masaüstü\\c#proje\\OkulOtomasyon\\OkulOtomasyon" + "\\resimler\\" + fotoDosyasi);
                    if (File.Exists(yeniyol)) // Dosyanın varlığını kontrol et
                    {
                        pictureEdit1.Image = Image.FromFile(yeniyol);
                    }
                    else
                    {
                        MessageBox.Show("Resim dosyası bulunamadı: " + yeniyol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //MessageBox.Show("Resim dosyası adı boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            txtsifre.Text = "";
            SqlCommand komut = new SqlCommand("Select * from TBL_OGRETMENLER where OGRTID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lookUpEdit1.ItemIndex + 1);
            SqlDataReader dr3 = komut.ExecuteReader();


            while (dr3.Read())
            {
                txtogrtId.Text = dr3["OGRTID"].ToString();
                txtbrans.Text = dr3["OGRTBRANS"].ToString();
                mskogrttc.Text = dr3["OGRTTC"].ToString();
                // Resim yolunu oluştur
                string fotoDosyasi = dr3["OGRTFOTO"].ToString();
                if (!string.IsNullOrEmpty(fotoDosyasi))
                {
                    yeniyol = Path.Combine("C:\\Users\\dogan\\OneDrive\\Masaüstü\\c#proje\\OkulOtomasyon\\OkulOtomasyon\\resimler", fotoDosyasi);
                    if (File.Exists(yeniyol)) // Dosyanın varlığını kontrol et
                    {
                        pictureEdit1.Image = Image.FromFile(yeniyol);
                    }
                    else
                    {
                        MessageBox.Show("Resim dosyası bulunamadı: " + yeniyol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //MessageBox.Show("Resim dosyası adı boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }

            bgl.baglanti().Close();
        }

        private void kydtogrt_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBL_OGRTAYARLAR (AYARLAROGRTID,OGRTSIFRE) values (@p1,@p2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtogrtId.Text);
            komut2.Parameters.AddWithValue("@p2", txtsifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gncllogrt_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Update TBL_OGRTAYARLAR set OGRTSIFRE=@p1 where AYARLAROGRTID=@p2", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", txtsifre.Text);
            komut3.Parameters.AddWithValue("@p2", txtogrtId.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void silogrt_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void xtraTabControl2_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtogrId.Text = dr["AYARLARID"].ToString();
                lookUpEdit2.Text = dr["OGRADSOYAD"].ToString();
                txtsinif.Text = dr["OGRSINIF"].ToString();
                mskogrtc.Text = dr["OGRTC"].ToString();
                txtogrsifre.Text = dr["OGRSIFRE"].ToString();

                // Resim yolunu oluştur
                string fotoDosyasi = dr["OGRFOTO"].ToString();
                if (!string.IsNullOrEmpty(fotoDosyasi))
                {
                    yeniyol = Path.Combine("C:\\Users\\dogan\\OneDrive\\Masaüstü\\c#proje\\OkulOtomasyon\\OkulOtomasyon" + "\\resimler\\" + fotoDosyasi);
                    if (File.Exists(yeniyol)) // Dosyanın varlığını kontrol et
                    {
                        pictureEdit1.Image = Image.FromFile(yeniyol);
                    }
                    else
                    {
                        MessageBox.Show("Resim dosyası bulunamadı: " + yeniyol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //MessageBox.Show("Resim dosyası adı boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void lookUpEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            txtogrsifre.Text = "";
            SqlCommand komut = new SqlCommand("Select * from TBL_OGRENCILERR where OGRID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lookUpEdit2.ItemIndex + 1);
            SqlDataReader dr3 = komut.ExecuteReader();


            while (dr3.Read())
            {
                txtogrId.Text = dr3["OGRID"].ToString();
                txtsinif.Text = dr3["OGRSINIF"].ToString();
                mskogrtc.Text = dr3["OGRTC"].ToString();
                // Resim yolunu oluştur
                string fotoDosyasi = dr3["OGRFOTO"].ToString();
                if (!string.IsNullOrEmpty(fotoDosyasi))
                {
                    yeniyol = Path.Combine("C:\\Users\\dogan\\OneDrive\\Masaüstü\\c#proje\\OkulOtomasyon\\OkulOtomasyon" + "\\resimler\\" + fotoDosyasi);
                    if (File.Exists(yeniyol)) // Dosyanın varlığını kontrol et
                    {
                        pictureEdit2.Image = Image.FromFile(yeniyol);
                    }
                    else
                    {
                      //  MessageBox.Show("Resim dosyası bulunamadı: " + yeniyol, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //MessageBox.Show("Resim dosyası adı boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }

        private void kydtogr_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBL_OGRAYARLAR (AYARLARID,OGRSIFRE) values (@p1,@p2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtogrId.Text);
            komut2.Parameters.AddWithValue("@p2", txtogrsifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrlistele();
            temizle();
        }

        private void gncllogr_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Update TBL_OGRAYARLAR set OGRSIFRE=@p1 where AYARLARID=@p2", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", txtogrsifre.Text);
            komut3.Parameters.AddWithValue("@p2", txtogrId.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrlistele();
            temizle();
        }

        private void silogr_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
