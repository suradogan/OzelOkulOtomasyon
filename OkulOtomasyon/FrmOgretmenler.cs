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
using DevExpress.Data;
using System.IO;

namespace OkulOtomasyon
{
    public partial class FrmOgretmenler : Form
    {
        public FrmOgretmenler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRETMENLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }
        public string yeniyol; 
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası | *.jpg;*png;*nef | Tüm Dosyalar | *.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\Users\\dogan\\OneDrive\\Masaüstü\\c#proje\\OkulOtomasyon\\OkulOtomasyon" + "\\resimler\\" + Guid.NewGuid().ToString() + "jpg";
            File.Copy(dosyayolu, yeniyol);
            pcrresim.ImageLocation = yeniyol;
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }
         void ilekle()
        {
            SqlCommand komut = new SqlCommand("Select * from IllerTablosu", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        void bransgetir()
        {
            SqlCommand komut = new SqlCommand("Select * from TBL_BRANSLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbbrans.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            msktc.Text = "";
            msktel.Text = "";
            txtmail.Text = "";
            cmbil.Text = "";
            cmbbrans.Text = "";
            rchadres.Text = "";
            pcrresim.ImageLocation = null; // Resim kutusunu sıfırla
            yeniyol = null; // Resim yolu değişkenini sıfırla
        }

        private void FrmOgretmenler_Load(object sender, EventArgs e)
        {
            listele();
            ilekle();
            bransgetir();
        }

        private void msktc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtid.Text)) // ID alanı boşsa kullanıcıyı uyar
          //  {
           //     MessageBox.Show("Lütfen bir ID giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             //   return; // İşlemi durdur
           // }

            SqlCommand komut = new SqlCommand(
                "INSERT INTO TBL_OGRETMENLER ( OGRTAD, OGRTSOYAD, OGRTTC, OGRTTEL, OGRTMAIL, OGTRIL, OGRTADRES, OGRTBRANS, OGRTFOTO) " +
                "VALUES ( @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9,@p10)",
                bgl.baglanti());

            // Parametreleri doldur
          //  komut.Parameters.AddWithValue("@p1", txtid.Text); // Elle girilen ID değeri
            komut.Parameters.AddWithValue("@p2", txtad.Text);
            komut.Parameters.AddWithValue("@p3", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p4", msktc.Text);
            komut.Parameters.AddWithValue("@p5", msktel.Text);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.Parameters.AddWithValue("@p7", cmbil.Text);
            komut.Parameters.AddWithValue("@p8", rchadres.Text);
            komut.Parameters.AddWithValue("@p9", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol) ?? ""); // Resim yolu boş olabilir

            try
            {
                komut.ExecuteNonQuery(); // Sorguyu çalıştır
                MessageBox.Show("Personel başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                bgl.baglanti().Close(); // Bağlantıyı kapat
            }

            // Listeyi güncelle
            listele();

            // Alanları temizle
            temizle();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["OGRTID"].ToString();
                txtad.Text = dr["OGRTAD"].ToString();
                txtsoyad.Text = dr["OGRTSOYAD"].ToString();
                msktc.Text = dr["OGRTTC"].ToString();
                msktel.Text = dr["OGRTTEL"].ToString();
                cmbil.Text = dr["OGTRIL"].ToString();
                cmbbrans.Text = dr["OGRTBRANS"].ToString();
                txtmail.Text = dr["OGRTMAIL"].ToString();
                rchadres.Text = dr["OGRTADRES"].ToString();
                yeniyol = "C:\\Users\\dogan\\OneDrive\\Masaüstü\\c#proje\\OkulOtomasyon\\OkulOtomasyon" + "\\resimler\\" + dr["OGRTFOTO"].ToString();
                pcrresim.ImageLocation = yeniyol;


            }
        }

        private void pcrresim_Click(object sender, EventArgs e)
        {

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtid.Text)) // ID alanı boşsa yeni kayıt eklenir
            {
                // Yeni bir ID oluştur
                SqlCommand maxIdKomut = new SqlCommand("SELECT ISNULL(MAX(OGRTID), 0) + 1 FROM TBL_OGRETMENLER", bgl.baglanti());
                int yeniId = Convert.ToInt32(maxIdKomut.ExecuteScalar());
                bgl.baglanti().Close();

                // Yeni kayıt ekle
                SqlCommand komutEkle = new SqlCommand(
                    "INSERT INTO TBL_OGRETMENLER (OGRTID, OGRTAD, OGRTSOYAD, OGRTTC, OGRTTEL, OGRTMAIL, OGTRIL, OGRTADRES, OGRTBRANS, OGRTFOTO) " +
                    "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)",
                    bgl.baglanti());
                komutEkle.Parameters.AddWithValue("@p1", yeniId); // Yeni ID
                komutEkle.Parameters.AddWithValue("@p2", txtad.Text);
                komutEkle.Parameters.AddWithValue("@p3", txtsoyad.Text);
                komutEkle.Parameters.AddWithValue("@p4", msktc.Text);
                komutEkle.Parameters.AddWithValue("@p5", msktel.Text);
                komutEkle.Parameters.AddWithValue("@p6", txtmail.Text);
                komutEkle.Parameters.AddWithValue("@p7", cmbil.Text);
                komutEkle.Parameters.AddWithValue("@p8", rchadres.Text);
                komutEkle.Parameters.AddWithValue("@p9", cmbbrans.Text);
                komutEkle.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));

                komutEkle.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Yeni personel eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Var olan kaydı güncelle
                SqlCommand komutGuncelle = new SqlCommand(
                    "UPDATE TBL_OGRETMENLER SET OGRTAD=@p1, OGRTSOYAD=@p2, OGRTTC=@p3, OGRTTEL=@p4, OGRTMAIL=@p5, OGTRIL=@p6, OGRTADRES=@p7, OGRTBRANS=@p8, OGRTFOTO=@p9 WHERE OGRTID=@p10",
                    bgl.baglanti());
                komutGuncelle.Parameters.AddWithValue("@p1", txtad.Text);
                komutGuncelle.Parameters.AddWithValue("@p2", txtsoyad.Text);
                komutGuncelle.Parameters.AddWithValue("@p3", msktc.Text);
                komutGuncelle.Parameters.AddWithValue("@p4", msktel.Text);
                komutGuncelle.Parameters.AddWithValue("@p5", txtmail.Text);
                komutGuncelle.Parameters.AddWithValue("@p6", cmbil.Text);
                komutGuncelle.Parameters.AddWithValue("@p7", rchadres.Text);
                komutGuncelle.Parameters.AddWithValue("@p8", cmbbrans.Text);
                komutGuncelle.Parameters.AddWithValue("@p9", Path.GetFileName(yeniyol));
                komutGuncelle.Parameters.AddWithValue("@p10", txtid.Text);

                komutGuncelle.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Personel bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Listeyi güncelle
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text)) // ID boş değilse silme işlemi yapılır
            {
                DialogResult onay = MessageBox.Show("Bu öğretmeni silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (onay == DialogResult.Yes)
                {
                    SqlCommand komutSil = new SqlCommand("DELETE FROM TBL_OGRETMENLER WHERE OGRTID=@p1", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@p1", txtid.Text);
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Öğretmen başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeyi güncelle
                    listele();

                    // Alanları temizle
                    temizle();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz öğretmeni seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

    }
}
