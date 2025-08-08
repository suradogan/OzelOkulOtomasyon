namespace OkulOtomasyon
{
    partial class FrmNotListele
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotListele));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblOgrenci = new DevExpress.XtraEditors.LabelControl();
            this.gridNotlar = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtOgrenciTC = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridNotlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOgrenciTC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(1150, 470);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(197, 61);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "ÇIKIŞ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lblOgrenci
            // 
            this.lblOgrenci.Appearance.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOgrenci.Appearance.Options.UseFont = true;
            this.lblOgrenci.Location = new System.Drawing.Point(388, 12);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new System.Drawing.Size(470, 59);
            this.lblOgrenci.TabIndex = 0;
            this.lblOgrenci.Text = "HOŞGELDİN[Ad Soyad]";
            this.lblOgrenci.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // gridNotlar
            // 
            this.gridNotlar.Location = new System.Drawing.Point(12, 76);
            this.gridNotlar.MainView = this.gridView1;
            this.gridNotlar.Name = "gridNotlar";
            this.gridNotlar.Size = new System.Drawing.Size(1132, 468);
            this.gridNotlar.TabIndex = 1;
            this.gridNotlar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridNotlar;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            // 
            // txtOgrenciTC
            // 
            this.txtOgrenciTC.EditValue = "Giriş Ekranına Gelen TC bilgisi burada saklanacak";
            this.txtOgrenciTC.Location = new System.Drawing.Point(12, 7);
            this.txtOgrenciTC.Name = "txtOgrenciTC";
            this.txtOgrenciTC.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOgrenciTC.Properties.Appearance.Options.UseFont = true;
            this.txtOgrenciTC.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtOgrenciTC.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtOgrenciTC.Properties.MaskSettings.Set("mask", "00000000000");
            this.txtOgrenciTC.Size = new System.Drawing.Size(10, 36);
            this.txtOgrenciTC.TabIndex = 1;
            this.txtOgrenciTC.Visible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(1150, 308);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(197, 61);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Excel\'e Aktar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(1150, 392);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(197, 61);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "PDF\'e Aktar";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // FrmNotListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 553);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.txtOgrenciTC);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lblOgrenci);
            this.Controls.Add(this.gridNotlar);
            this.Name = "FrmNotListele";
            this.Text = "FrmNotListele";
            this.Load += new System.EventHandler(this.FrmNotListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridNotlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOgrenciTC.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblOgrenci;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridNotlar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtOgrenciTC;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}