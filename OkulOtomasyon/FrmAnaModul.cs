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

namespace OkulOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FrmOgretmenler frm1;
        FrmOgrenciler frm2;
        FrmVeliler frm3;
        FrmAyarlar frm4;
        FrmNotGiris frm5;

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new FrmVeliler();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new FrmOgrenciler();
                frm2.MdiParent = this;
                frm2.Show();
            }
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new FrmNotGiris();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new FrmAyarlar();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
     
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frm1 == null ||  frm1.IsDisposed) { 
            frm1 = new FrmOgretmenler();
            frm1.MdiParent = this;
            frm1.Show();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
            ribbonPage1.Visible = true;
            ribbonPageGroup1.Visible = true;
            barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnogretmenler.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barButtonItem11.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            barButtonItem14.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void ribbonControl1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
