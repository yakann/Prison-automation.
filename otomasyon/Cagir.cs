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
using System.IO;

namespace otomasyon
{
    public partial class Cagir : Form
    {
        public Cagir()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source =.; Initial Catalog = hapis; Integrated Security = True");
        private void Cagir_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                    string sorgu = "SELECT * FROM kisi_bilgileri,ceza_bilgisi,adres_tablosu,kan_tablosu,yer_bilgisi WHERE tc_no =  "+ textBox1.Text +"  and kisi_bilgileri.dosya_no = ceza_bilgisi.dosya_no and kisi_bilgileri.yatak_id = yer_bilgisi.yatak_id and kisi_bilgileri.adres_id = adres_tablosu.adres_id and kisi_bilgileri.k_id = kan_tablosu.k_id" ;
                    // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    Image uyeResim = null;
                    //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                    SqlDataReader cikti = komut.ExecuteReader();
                    if (cikti.Read())
                    {
                        // resim getirme : http://www.yazgelistir.com/makale/csharp-veritabanina-resim-kayit-ve-getirme-islemi-1
                        byte[] resim = (byte[])cikti[0];
                        MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                        ms.Write(resim, 0, resim.Length);
                        uyeResim = Image.FromStream(ms,true);
                        pictureBox1.Image = uyeResim;

                        textBox2.Text = cikti["isim"].ToString();
                        textBox3.Text = cikti["soyisim"].ToString();
                        textBox18.Text = cikti["yas"].ToString();
                        textBox11.Text = cikti["kilo"].ToString();
                        textBox12.Text = cikti["boy"].ToString();

                        textBox14.Text = cikti["kan_grubu"].ToString();

                        textBox17.Text = cikti["adresi"].ToString();
                        textBox10.Text = cikti["dogum_yeri"].ToString();

                        textBox15.Text = cikti["blok_adi"].ToString();
                        textBox13.Text = cikti["blok_no"].ToString();
                        textBox16.Text = cikti["yatak_no"].ToString();

                        textBox5.Text = cikti["kisi_bilgisi"].ToString();
                        string deger = cikti["ceza_bitis"].ToString();
                        string[] parcalar = deger.Split(' ');
                        // Doğum tarihi
                        string d_gun = parcalar[0];
                        string[] parcalar2 = d_gun.Split('.');
                        string d_gun2 = parcalar2[2];
                        int b = Convert.ToInt32(d_gun2);
                        DateTime buGun = DateTime.Today;
                        // Yıl farkı
                        int kalan_sure = b - (buGun.Year);
   
                        textBox7.Text = Convert.ToString(kalan_sure) + " Yıl";
                        textBox6.Text = cikti["ceza_bitis"].ToString();

                        
                    }
                    else { MessageBox.Show("Kayıt Bulunamadı..."); }
                    baglanti.Close();

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
    }
}
