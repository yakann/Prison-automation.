namespace otomasyon
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.yeni_uye = new System.Windows.Forms.Button();
            this.mahkum_gonder = new System.Windows.Forms.Button();
            this.guncelle = new System.Windows.Forms.Button();
            this.cikis = new System.Windows.Forms.Button();
            this.m_cagir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // yeni_uye
            // 
            this.yeni_uye.BackColor = System.Drawing.Color.Transparent;
            this.yeni_uye.Location = new System.Drawing.Point(99, 129);
            this.yeni_uye.Name = "yeni_uye";
            this.yeni_uye.Size = new System.Drawing.Size(120, 33);
            this.yeni_uye.TabIndex = 0;
            this.yeni_uye.Text = "Yeni Üye Ekle";
            this.yeni_uye.UseVisualStyleBackColor = false;
            this.yeni_uye.Click += new System.EventHandler(this.yeni_uye_Click);
            // 
            // mahkum_gonder
            // 
            this.mahkum_gonder.BackColor = System.Drawing.Color.Transparent;
            this.mahkum_gonder.Location = new System.Drawing.Point(99, 168);
            this.mahkum_gonder.Name = "mahkum_gonder";
            this.mahkum_gonder.Size = new System.Drawing.Size(120, 33);
            this.mahkum_gonder.TabIndex = 0;
            this.mahkum_gonder.Text = "Mahkumu Gönder";
            this.mahkum_gonder.UseVisualStyleBackColor = false;
            this.mahkum_gonder.Click += new System.EventHandler(this.mahkum_gonder_Click);
            // 
            // guncelle
            // 
            this.guncelle.BackColor = System.Drawing.Color.Transparent;
            this.guncelle.Location = new System.Drawing.Point(99, 207);
            this.guncelle.Name = "guncelle";
            this.guncelle.Size = new System.Drawing.Size(120, 33);
            this.guncelle.TabIndex = 0;
            this.guncelle.Text = "Güncelle";
            this.guncelle.UseVisualStyleBackColor = false;
            // 
            // cikis
            // 
            this.cikis.BackColor = System.Drawing.Color.Transparent;
            this.cikis.Location = new System.Drawing.Point(99, 285);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(120, 33);
            this.cikis.TabIndex = 0;
            this.cikis.Text = "Oturumu Kapat";
            this.cikis.UseVisualStyleBackColor = false;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // m_cagir
            // 
            this.m_cagir.BackColor = System.Drawing.Color.Transparent;
            this.m_cagir.Location = new System.Drawing.Point(99, 246);
            this.m_cagir.Name = "m_cagir";
            this.m_cagir.Size = new System.Drawing.Size(120, 33);
            this.m_cagir.TabIndex = 0;
            this.m_cagir.Text = "Mahkum Çağır";
            this.m_cagir.UseVisualStyleBackColor = false;
            this.m_cagir.Click += new System.EventHandler(this.m_cagir_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(715, 491);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.m_cagir);
            this.Controls.Add(this.guncelle);
            this.Controls.Add(this.mahkum_gonder);
            this.Controls.Add(this.yeni_uye);
            this.Name = "Form3";
            this.Text = "Ana Ekran";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button yeni_uye;
        private System.Windows.Forms.Button mahkum_gonder;
        private System.Windows.Forms.Button guncelle;
        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.Button m_cagir;
    }
}