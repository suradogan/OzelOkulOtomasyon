using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using System;


namespace OkulOtomasyon
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            //5.SINIF
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from TBL_OGRENCILERR where OGRSINIF ='5.SINIF' ", bgl.baglanti());
            da1.Fill(dt1);
            grdctrl5.DataSource = dt1;
            //6.SINIF
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from TBL_OGRENCILERR where OGRSINIF ='6.SINIF'", bgl.baglanti());
            da2.Fill(dt2);
            grdctrl6.DataSource = dt2;
            //7.SINIF
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from TBL_OGRENCILERR where OGRSINIF ='7.SINIF'", bgl.baglanti());
            da3.Fill(dt3);
            grdctrl7.DataSource = dt3;
            //8.SINIF
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from TBL_OGRENCILERR where OGRSINIF ='8.SINIF'", bgl.baglanti());
            da4.Fill(dt4);
            grdctrl8.DataSource = dt4;
        }
         /*void velilistele()
        {
           DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select VELIID, (VELIANNNE + '  | ' + VELIBABA) AS 'VELIANNNEBABA' from TBL_VELILER", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "VELIID";
            lookUpEdit1.Properties.DisplayMember = "VELIANNNEBABA";
            lookUpEdit1.Properties.DataSource = dt;

        } */
        void sehirekle()
        {
            SqlCommand komut = new SqlCommand("Select * from IllerTablosu", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())//tüm satırı tek tek oku
            {
                cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }
        string resimKlasoru = Path.Combine(Application.StartupPath, "resimler"); // Dinamik resim klasörü
        public string dosyaYolu; // Sınıf düzeyinde tanımlama

        private void btnsil_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {

        }

        private void pcrresim_Click(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void msktc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void labelControl4_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void grdctrl6_Click(object sender, EventArgs e)
        {

        }

        private void grdctrl8_Click(object sender, EventArgs e)
        {

        }

        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            listele();
            sehirekle();
            // Resim klasörünü kontrol et ve yoksa oluştur
            if (!Directory.Exists(resimKlasoru))
            {
                Directory.CreateDirectory(resimKlasoru);
            }
            //velilistele();
        }

        private void gridView1_FocusedRowObjectChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)//boş değilse getir
            {
                txtid.Text = dr["OGRID"].ToString();
                txtad.Text = dr["OGRAD"].ToString();
                txtsoyad.Text = dr["OGRSOYAD"].ToString();
                msktc.Text = dr["OGRTC"].ToString();
                mskno.Text = dr["OGRNO"].ToString();
                cmbil.Text = dr["OGRIL"].ToString();
                cmbsinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    rdioerkek.Checked = true;
                }
                else
                {
                    rdiokdn.Checked = true;
                }
                // cmbil.Text = dr["OGRIL"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                rchadres.Text = dr["OGRADRES"].ToString();
                // Resim yolu
                yeniyol = Path.Combine(resimKlasoru, dr["OGRFOTO"].ToString());
                if (File.Exists(yeniyol))
                {
                    pictureBox1.Image = Image.FromFile(yeniyol);
                }
                else
                {
                    pictureBox1.Image = null; // Resim bulunamazsa boş bırak
                }




            }
        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)//boş değilse getir
            {
                txtid.Text = dr["OGRID"].ToString();
                txtad.Text = dr["OGRAD"].ToString();
                txtsoyad.Text = dr["OGRSOYAD"].ToString();
                msktc.Text = dr["OGRTC"].ToString();
                mskno.Text = dr["OGRNO"].ToString();
                cmbil.Text = dr["OGRIL"].ToString();
                cmbsinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    rdioerkek.Checked = true;
                }
                else
                {
                    rdiokdn.Checked = true;
                }

                //  cmbil.Text = dr["OGRIL"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                rchadres.Text = dr["OGRADRES"].ToString();



            }
            dateEdit1.Text = dr["OGRDOGTAR"].ToString();
            rchadres.Text = dr["OGRADRES"].ToString();

            // Resim yolu
            yeniyol = Path.Combine(resimKlasoru, dr["OGRFOTO"].ToString());
            if (File.Exists(yeniyol))
            {
                pictureBox1.Image = Image.FromFile(yeniyol);
            }
            else
            {
                pictureBox1.Image = null; // Resim bulunamazsa boş bırak
            }
        }


        private void gridView3_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)//boş değilse getir
            {
                txtid.Text = dr["OGRID"].ToString();
                txtad.Text = dr["OGRAD"].ToString();
                txtsoyad.Text = dr["OGRSOYAD"].ToString();
                msktc.Text = dr["OGRTC"].ToString();
                mskno.Text = dr["OGRNO"].ToString();
                cmbil.Text = dr["OGRIL"].ToString();
                cmbsinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    rdioerkek.Checked = true;
                }
                else
                {
                    rdiokdn.Checked = true;
                }
                //cmbil.Text = dr["OGRIL"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                rchadres.Text = dr["OGRADRES"].ToString();
                // Resim yolu
                yeniyol = Path.Combine(resimKlasoru, dr["OGRFOTO"].ToString());
                if (File.Exists(yeniyol))
                {
                    pictureBox1.Image = Image.FromFile(yeniyol);
                }
                else
                {
                    pictureBox1.Image = null; // Resim bulunamazsa boş bırak
                }

            }
        }

        private void gridView4_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            if (dr != null)//boş değilse getir
            {
                txtid.Text = dr["OGRID"].ToString();
                txtad.Text = dr["OGRAD"].ToString();
                txtsoyad.Text = dr["OGRSOYAD"].ToString();
                msktc.Text = dr["OGRTC"].ToString();
                mskno.Text = dr["OGRNO"].ToString();
                cmbil.Text = dr["OGRIL"].ToString();
                cmbsinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    rdioerkek.Checked = true;
                }
                else
                {
                    rdiokdn.Checked = true;
                }
                //cmbil.Text = dr["OGRIL"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                rchadres.Text = dr["OGRADRES"].ToString();

                // Resim yolu
                yeniyol = Path.Combine(resimKlasoru, dr["OGRFOTO"].ToString());
                if (File.Exists(yeniyol))
                {
                    pictureBox1.Image = Image.FromFile(yeniyol);
                }
                else
                {
                   pictureBox1.Image = null; // Resim bulunamazsa boş bırak
                }

            }
        }
        public string cinsiyet;
        private void btnkaydet_Click_1(object sender, EventArgs e)
        {
            if (!File.Exists(yeniyol))
            {
                if (!string.IsNullOrEmpty(dosyaYolu) && File.Exists(dosyaYolu))
                {
                    File.Copy(dosyaYolu, yeniyol, true);
                }
            }

            SqlCommand komut = new SqlCommand("insert into TBL_OGRENCILERR (OGRAD, OGRSOYAD,OGRNO, OGRSINIF, OGRDOGTAR, OGRCINSIYET, OGRTC, OGRIL, OGRADRES, OGRFOTO) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskno.Text);
            komut.Parameters.AddWithValue("@p4", cmbsinif.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.Text);
            if (rdioerkek.Checked == true)
            {
                komut.Parameters.AddWithValue("@p6", cinsiyet = "E");
            }
            else
            {
                komut.Parameters.AddWithValue("@p6", cinsiyet = "K");
            }
            komut.Parameters.AddWithValue("@p7", msktc.Text);
            komut.Parameters.AddWithValue("@p8", cmbil.Text);
            komut.Parameters.AddWithValue("@p9", rchadres.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        public string yeniyol;
        string baseResimYolu = Path.Combine(Application.StartupPath, "resimler");

        private void btnresimsec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası | *.jpg;*png;*nef | Tüm Dosyalar | *.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\Users\\dogan\\OneDrive\\Masaüstü\\c#proje\\OkulOtomasyon\\OkulOtomasyon" + "\\resimler\\" + Guid.NewGuid().ToString() + "jpg";
            File.Copy(dosyayolu, yeniyol);
            pictureBox1.ImageLocation = yeniyol;
        }

        private void btnguncelle_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_OGRENCILERR SET OGRAD=@p1, OGRSOYAD=@p2, OGRNO=@p3, OGRSINIF=@p4, OGRDOGTAR=@p5, OGRCINSIYET=@p6, OGRTC=@p7, OGRIL=@p8, OGRADRES=@p9, OGRFOTO=@p10 WHERE OGRID=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskno.Text);
            komut.Parameters.AddWithValue("@p4", cmbsinif.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.Text);
            komut.Parameters.AddWithValue("@p6", rdioerkek.Checked ? "E" : "K");
            komut.Parameters.AddWithValue("@p7", msktc.Text);
            komut.Parameters.AddWithValue("@p8", cmbil.Text);
            komut.Parameters.AddWithValue("@p9", rchadres.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p11", txtid.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE FROM TBL_OGRENCILERR WHERE OGRID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            // Tüm TextBox'ları temizle
            txtid.Text = string.Empty;
            txtad.Text = string.Empty;
            txtsoyad.Text = string.Empty;
            msktc.Text = string.Empty;
            mskno.Text = string.Empty;

            // ComboBox'ları sıfırla
            cmbil.SelectedIndex = -1;
            cmbsinif.SelectedIndex = -1;

            // RadioButton'ları sıfırla
            rdioerkek.Checked = false;
            rdiokdn.Checked = false;

            // RichTextBox'ı temizle
            rchadres.Text = string.Empty;

            // DateEdit kontrolünü sıfırla
            dateEdit1.Text = string.Empty;

            // Resim alanını temizle
            pictureBox1.Image = null;

            // Bilgilendirme mesajı
            MessageBox.Show("Alanlar temizlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            FrmNfsCzdni frm = new FrmNfsCzdni();
            if (dr != null)
            {
                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();
                frm.tc = dr["OGRTC"].ToString();
                frm.cinsiyet = dr["OGRCINSIYET"].ToString();
                frm.dogtarihi = dr["OGRDOGTAR"].ToString();
                // Resim yolunu aktarma
                string resimDosyasi = Path.Combine(resimKlasoru, dr["OGRFOTO"].ToString());
                frm.resimYolu = resimDosyasi;

                frm.ShowDialog();

            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}