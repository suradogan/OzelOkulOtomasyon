using DevExpress.XtraGrid;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OkulOtomasyon
{
    public partial class FrmNotListele : Form
    {
        public FrmNotListele()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public string OgrenciAdSoyad { get; set; }
        public string OgrenciTC { get; set; }

        private void NotlariListele()
        {
            //try
            //{
            // SQL bağlantısı oluştur ve using bloğunda kullan
            using (SqlConnection baglanti = bgl.baglanti())
            {

                

                // Öğrencinin TC numarasına göre verileri filtrele
                string sorgu = "SELECT NOTSINIF, NOTADSOYAD, NOTTC, NOTBRANS, SINAV1, SINAV2, SOZLU1, SOZLU2, SOZLU3, ORTALAMA " +
                               "FROM TBL_NOTGİRİS WHERE NOTTC = @p1"; // Öğrencinin TC'sine göre notları al

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", OgrenciTC); // TC numarasını parametre olarak ekliyoruz

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt); // Verileri DataTable'a dolduruyoruz

                // Eğer veriler varsa, GridView'e bağla
                if (dt.Rows.Count > 0)
                {
                    gridNotlar.DataSource = dt;  // GridView'e veriyi bağla
                    gridNotlar.Refresh();        // GridView'i güncelle
                }
                else
                {
                    MessageBox.Show("Veri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // using bloğu burada sona erer ve bağlantı otomatik olarak kapanır
            }
        }
           /* catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message + "\n" + ex.StackTrace, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        

        private void FrmNotListele_Load(object sender, EventArgs e)
        {
            lblOgrenci.Text = "Hoşgeldiniz, " + OgrenciAdSoyad;

            // Öğrencinin TC'sine göre bilgileri al
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_OGRENCILERR WHERE OGRTC = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", OgrenciTC);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                // Gerekli diğer bilgileri alıp kullanabilirsin
            }

            // Verileri grid'e yükle
            NotlariListele();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            // Burada yapılacak işlemi belirleyin
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Uygulamayı kapat
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Dosyası|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gridNotlar.ExportToXlsx(saveFile.FileName);
                MessageBox.Show("Excel dosyası başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF Dosyası|*.pdf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                gridNotlar.ExportToPdf(saveFile.FileName);
                MessageBox.Show("PDF dosyası başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
