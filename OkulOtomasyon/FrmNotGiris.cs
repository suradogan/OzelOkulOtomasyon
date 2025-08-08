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
using System.IO;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using System;
using DevExpress.XtraEditors;

namespace OkulOtomasyon
{
    public partial class FrmNotGiris : Form
    {
        public FrmNotGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            //5.SINIF
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from TBL_NOTGİRİS where NOTSINIF ='5.SINIF' ", bgl.baglanti());
            da1.Fill(dt1);
            grdctrl5.DataSource = dt1;
            //6.SINIF
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from TBL_NOTGİRİS where NOTSINIF ='6.SINIF'", bgl.baglanti());
            da2.Fill(dt2);
            grdctrl6.DataSource = dt2;
            //7.SINIF
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select * from TBL_NOTGİRİS where NOTSINIF ='7.SINIF'", bgl.baglanti());
            da3.Fill(dt3);
            grdctrl7.DataSource = dt3;
            //8.SINIF
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select * from TBL_NOTGİRİS where NOTSINIF ='8.SINIF'", bgl.baglanti());
            da4.Fill(dt4);
            grdctrl8.DataSource = dt4;
        }
        void ogrlist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select OGRID, (OGRAD + ' '  + OGRSOYAD) AS 'OGRADSOYAD' from TBL_OGRENCILERR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "OGRID";
            lookUpEdit1.Properties.DisplayMember = "OGRADSOYAD";
            lookUpEdit1.Properties.DataSource = dt;
        }
        private void gridView1_FocusedRowObjectChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void gridView3_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void btntemizle_Click_1(object sender, EventArgs e)
        {

        }

        private void btnsil_Click_1(object sender, EventArgs e)
        {

        }

        private void btnresimsec_Click(object sender, EventArgs e)
        {

        }

        private void btnguncelle_Click_1(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void FrmNotGiris_Load(object sender, EventArgs e)
        {
            listele();
            ogrlist();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["NOTID"].ToString();
                lookUpEdit1.Text = dr["NOTADSOYAD"].ToString();

                msktc.Text = dr["NOTTC"].ToString();
                txtort.Text = dr["ORTALAMA"].ToString();
                cmbsinif.Text = dr["NOTSINIF"].ToString();
                cmbbrans.Text = dr["NOTBRANS"].ToString();
                sinav1.Text = dr["SINAV1"].ToString();
                sinav2.Text = dr["SINAV2"].ToString();
                sozlu1.Text = dr["SOZLU1"].ToString();
                sozlu2.Text = dr["SOZLU2"].ToString();
                sozlu3.Text = dr["SOZLU3"].ToString();





            }
        }

        private void grdctrl7_Click(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            sinav1.Text = "";
            sinav2.Text = "";
            sozlu2.Text = "";
            sozlu1.Text = "";
            sozlu3.Text = "";
            cmbbrans.Text = "";
            SqlCommand komut = new SqlCommand("Select * from TBL_OGRENCILERR where OGRID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lookUpEdit1.ItemIndex + 1);
            SqlDataReader dr3 = komut.ExecuteReader();


            while (dr3.Read())
            {
                txtid.Text = dr3["OGRID"].ToString();
                cmbsinif.Text = dr3["OGRSINIF"].ToString();
                msktc.Text = dr3["OGRTC"].ToString();


            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
          SqlCommand komut = new SqlCommand("INSERT INTO TBL_NOTGİRİS (NOTSINIF, NOTADSOYAD, NOTTC, NOTBRANS, SINAV1, SINAV2, SOZLU1, SOZLU2, SOZLU3, ORTALAMA) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbsinif.Text);
            komut.Parameters.AddWithValue("@p2", lookUpEdit1.Text);
            komut.Parameters.AddWithValue("@p3", msktc.Text);
            komut.Parameters.AddWithValue("@p4", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p5", sinav1.Text);
            komut.Parameters.AddWithValue("@p6", sinav2.Text);
            komut.Parameters.AddWithValue("@p7", sozlu1.Text);
            komut.Parameters.AddWithValue("@p8", sozlu2.Text);
            komut.Parameters.AddWithValue("@p9", sozlu3.Text);
            komut.Parameters.AddWithValue("@p10", txtort.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Notlar başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE TBL_NOTGİRİS SET NOTSINIF=@p1, NOTADSOYAD=@p2, NOTTC=@p3, NOTBRANS=@p4, SINAV1=@p5, SINAV2=@p6, SOZLU1=@p7, SOZLU2=@p8, SOZLU3=@p9, ORTALAMA=@p10 WHERE NOTID=@p11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbsinif.Text);
            komut.Parameters.AddWithValue("@p2", lookUpEdit1.Text);
            komut.Parameters.AddWithValue("@p3", msktc.Text);
            komut.Parameters.AddWithValue("@p4", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p5", sinav1.Text);
            komut.Parameters.AddWithValue("@p6", sinav2.Text);
            komut.Parameters.AddWithValue("@p7", sozlu1.Text);
            komut.Parameters.AddWithValue("@p8", sozlu2.Text);
            komut.Parameters.AddWithValue("@p9", sozlu3.Text);
            komut.Parameters.AddWithValue("@p10", txtort.Text);
            komut.Parameters.AddWithValue("@p11", txtid.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Notlar başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnhesapla_Click(object sender, EventArgs e)
        {
            try
            {
                double s1, s2, soz1, soz2, soz3, ort;
                s1 = Convert.ToDouble(sinav1.Text);
                s2 = Convert.ToDouble(sinav2.Text);
                soz1 = Convert.ToDouble(sozlu1.Text);
                soz2 = Convert.ToDouble(sozlu2.Text);
                soz3 = Convert.ToDouble(sozlu3.Text);

                ort = (s1 + s2 + soz1 + soz2 + soz3) / 5;
                txtort.Text = ort.ToString("0.00"); // Ondalıklı olarak göstermek için

                MessageBox.Show("Ortalama hesaplandı: " + ort.ToString("0.00"), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen tüm notları eksiksiz girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView2_FocusedRowObjectChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gridView2.RowCount == 0 || gridView2.FocusedRowHandle < 0) return; // Boş veri kontrolü

            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["NOTID"].ToString();
                lookUpEdit1.EditValue = dr["NOTADSOYAD"].ToString(); // Doğru değer atama
                msktc.Text = dr["NOTTC"].ToString();
                txtort.Text = dr["ORTALAMA"].ToString();
                cmbsinif.Text = dr["NOTSINIF"].ToString();
                cmbbrans.Text = dr["NOTBRANS"].ToString();
                sinav1.Text = dr["SINAV1"].ToString();
                sinav2.Text = dr["SINAV2"].ToString();
                sozlu1.Text = dr["SOZLU1"].ToString();
                sozlu2.Text = dr["SOZLU2"].ToString();
                sozlu3.Text = dr["SOZLU3"].ToString();
            }
        }

        private void gridView3_FocusedRowObjectChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gridView3.RowCount == 0 || gridView3.FocusedRowHandle < 0) return; // Boş veri kontrolü

            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["NOTID"].ToString();
                lookUpEdit1.EditValue = dr["NOTADSOYAD"].ToString(); // Doğru değer atama
                msktc.Text = dr["NOTTC"].ToString();
                txtort.Text = dr["ORTALAMA"].ToString();
                cmbsinif.Text = dr["NOTSINIF"].ToString();
                cmbbrans.Text = dr["NOTBRANS"].ToString();
                sinav1.Text = dr["SINAV1"].ToString();
                sinav2.Text = dr["SINAV2"].ToString();
                sozlu1.Text = dr["SOZLU1"].ToString();
                sozlu2.Text = dr["SOZLU2"].ToString();
                sozlu3.Text = dr["SOZLU3"].ToString();
            }
        }

        private void gridView4_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            if (gridView4.RowCount == 0 || gridView4.FocusedRowHandle < 0) return; // Boş veri kontrolü

            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["NOTID"].ToString();
                lookUpEdit1.EditValue = dr["NOTADSOYAD"].ToString(); // Doğru değer atama
                msktc.Text = dr["NOTTC"].ToString();
                txtort.Text = dr["ORTALAMA"].ToString();
                cmbsinif.Text = dr["NOTSINIF"].ToString();
                cmbbrans.Text = dr["NOTBRANS"].ToString();
                sinav1.Text = dr["SINAV1"].ToString();
                sinav2.Text = dr["SINAV2"].ToString();
                sozlu1.Text = dr["SOZLU1"].ToString();
                sozlu2.Text = dr["SOZLU2"].ToString();
                sozlu3.Text = dr["SOZLU3"].ToString();
            }
        }
    }
}



