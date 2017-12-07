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

        private void m_sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    string sorgu = "Delete From kisi_bilgileri Where tc_no=@tc,dosya_no=@dosya_no";
                    string sorgu2 = "Select isim,soyisim From kisi_bilgileri Where isim=@isim,soyisim=@soyisim";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
                    komut.Parameters.AddWithValue("@tc", textBox1.Text);
                    komut.Parameters.AddWithValue("@dosya_no", textBox2.Text);

                    komut2.Parameters.AddWithValue("@isim", label3.Text);
                    komut2.Parameters.AddWithValue("@soyisim", label6.Text);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
    }
}
