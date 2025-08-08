using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Layout.Frames;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulOtomasyon
{
    public partial class FrmVeliler : Form
    {
        public FrmVeliler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_VELILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void temizle()
        {
            txtid.Text = "";
            txtannead.Text = "";
            txtbabaad.Text = "";
            msktel1.Text = "";
            msktel2.Text = "";
            txtmail.Text = "";
           
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {

        }

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
        
        private void FrmVeliler_Load(object sender, EventArgs e)
        {
            listele();
            gridView1.FocusedRowObjectChanged += gridView1_FocusedRowObjectChanged;
        

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
private void btnkaydet_Click_1(object sender, EventArgs e)
        {
            // VELIID sütununu INSERT sorgusundan kaldırdık
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_VELILER (VELIANNNE, VELIBABA, VELITEL1, VELITEL2, VELIMAIL) " +
                                              "VALUES (@p1, @p2, @p3, @p4, @p5)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtannead.Text);
            komut.Parameters.AddWithValue("@p2", txtbabaad.Text);
            komut.Parameters.AddWithValue("@p3", msktel1.Text);
            komut.Parameters.AddWithValue("@p4", msktel2.Text);
            komut.Parameters.AddWithValue("@p5", txtmail.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Veli Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        
        private void btnsil_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text)) // ID boş değilse silme işlemi yapılır
            {
                DialogResult onay = MessageBox.Show("Bu veliyi silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (onay == DialogResult.Yes)
                {
                    // Silme işlemi TBL_VELILER tablosunda yapılacak
                    SqlCommand komutSil = new SqlCommand("DELETE FROM TBL_VELILER WHERE VELIID=@p1", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@p1", txtid.Text);
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Veli başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeyi güncelle
                    listele();

                    // Alanları temizle
                    temizle();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz veliye ait ID'yi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnguncelle_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtid.Text)) // ID alanı boşsa yeni kayıt eklenir
            {
                // Yeni bir ID oluştur
                SqlCommand maxIdKomut = new SqlCommand("SELECT ISNULL(MAX(VELIID), 0) + 1 FROM TBL_VELILER", bgl.baglanti());
                int yeniId = Convert.ToInt32(maxIdKomut.ExecuteScalar());
                bgl.baglanti().Close();

                // Yeni kayıt ekle
                SqlCommand komutEkle = new SqlCommand(
                    "INSERT INTO TBL_VELILER (VELIID, VELIANNNE, VELIBABA, VELITEL1, VELITEL2, VELIMAIL) " +
                    "VALUES (@p1, @p2, @p3, @p4, @p5, @p6)",
                    bgl.baglanti());
                komutEkle.Parameters.AddWithValue("@p1", yeniId); // Yeni ID
                komutEkle.Parameters.AddWithValue("@p2", txtannead.Text);
                komutEkle.Parameters.AddWithValue("@p3", txtbabaad.Text);
                komutEkle.Parameters.AddWithValue("@p4", msktel1.Text);
                komutEkle.Parameters.AddWithValue("@p5", msktel2.Text);
                komutEkle.Parameters.AddWithValue("@p6", txtmail.Text);
                komutEkle.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Yeni veli eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Var olan kaydı güncelle
                SqlCommand komutGuncelle = new SqlCommand(
                    "UPDATE TBL_VELILER SET VELIANNNE=@p1, VELIBABA=@p2, VELITEL1=@p3, VELITEL2=@p4, VELIMAIL=@p5 " +
                    "WHERE VELIID=@p6", // VELIID'i güncellemiyoruz
                    bgl.baglanti());
                komutGuncelle.Parameters.AddWithValue("@p1", txtannead.Text);
                komutGuncelle.Parameters.AddWithValue("@p2", txtbabaad.Text);
                komutGuncelle.Parameters.AddWithValue("@p3", msktel1.Text);
                komutGuncelle.Parameters.AddWithValue("@p4", msktel2.Text);
                komutGuncelle.Parameters.AddWithValue("@p5", txtmail.Text);
                komutGuncelle.Parameters.AddWithValue("@p6", txtid.Text); // ID'yi kullanıyoruz

                komutGuncelle.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Veli bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Listeyi güncelle
            listele();
        }


        private void gridView1_FocusedRowObjectChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            // Eğer grid'deki bir satır seçildiyse
            if (gridView1.FocusedRowHandle >= 0)
            {
                // Seçilen satırdaki veriyi alıyoruz
                DataRow selectedRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                // Seçilen satırdaki verileri ilgili alanlara atıyoruz
                txtid.Text = selectedRow["VELIID"].ToString();
                txtannead.Text = selectedRow["VELIANNNE"].ToString();
                txtbabaad.Text = selectedRow["VELIBABA"].ToString();
                msktel1.Text = selectedRow["VELITEL1"].ToString();
                msktel2.Text = selectedRow["VELITEL2"].ToString();
                txtmail.Text = selectedRow["VELIMAIL"].ToString();
            }
        }

        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            // TextBox ve MaskedTextBox'ları temizleyin
            txtid.Text = "";
            txtannead.Text = "";
            txtbabaad.Text = "";
            msktel1.Text = "";
            msktel2.Text = "";
            txtmail.Text = "";

            // Eğer varsa, resim veya diğer öğeleri de temizlemek isterseniz buraya ekleyebilirsiniz
            // Örneğin: pcrresim.Image = null; (Resim alanını temizlemek için)
        }
    }
}
