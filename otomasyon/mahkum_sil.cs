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
namespace otomasyon
{
    public partial class mahkum_sil : Form
    {
        public mahkum_sil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source =.; Initial Catalog = hapis; Integrated Security = True");
        SqlConnection baglanti2 = new SqlConnection(@"Data Source =.; Initial Catalog = hapis; Integrated Security = True");
        private void m_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("İsim:" + label3.Text + "\nSoyisim:" + label6.Text+ "\n\nBu Kişiyi Tahliye Etmek İstediğinize Emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        string sorgu = "Delete From kisi_bilgileri Where tc_no=@tc,dosya_no=@dosya_no";
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);

                        komut.Parameters.AddWithValue("@tc", textBox1.Text);


                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Mahkum Silme İşlemi Gerçekleşti.");
                    }
                else
                {
                    MessageBox.Show("Silme işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                    string sorgu2 = "SELECT isim,soyisim FROM kisi_bilgileri WHERE tc_no =  " + textBox1.Text + "";
                    // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                    SqlCommand komut2 = new SqlCommand(sorgu2, baglanti2);
                    //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                    SqlDataReader cikti = komut2.ExecuteReader();
                    if (cikti.Read())
                    {                       
                        label3.Text = cikti["isim"].ToString();
                        label6.Text = cikti["soyisim"].ToString();
                    }
                    else { MessageBox.Show("Kayıt Bulunamadı..."); }
                    baglanti2.Close();

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
    }
}
