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

namespace OkulOtomasyon
{
    public partial class FrmNfsCzdni : Form
    {
        public string ad;
        public string soyad;
        public string tc;
        public string cinsiyet;
        public string dogtarihi;
        public string resimYolu; // Resim yolu için public değişken

        public FrmNfsCzdni()
        {
            InitializeComponent();
        }
        
        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmNfsCzdni_Load(object sender, EventArgs e)
        {
            // Gelen verileri doldur
            lblAd.Text = ad; // Formdaki label veya diğer kontrollerinize göre ayarlayın
            lblSoyad.Text = soyad;
            lblTc.Text = tc;
            lblCinsiyet.Text = cinsiyet;
            lblDogumTarihi.Text = dogtarihi;

            // Resmi yükle


            if (!string.IsNullOrEmpty(resimYolu) && File.Exists(resimYolu))
            {
                pictureEdit1.Image = Image.FromFile(resimYolu); // pictureEdit1 yerine PictureBox kullanıyorsanız ayarlayın
            }
            else
            {
                pictureEdit1.Image = null; // Resim bulunamazsa boş bırak
            }
        }

        private void lblsoyad_Click(object sender, EventArgs e)
        {

        }
    }
}
