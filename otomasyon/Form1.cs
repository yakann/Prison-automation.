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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        yerleske f2;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.f2 = new yerleske(this);
            f2.Show();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source =.; Initial Catalog = hapis; Integrated Security = True");
       
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        
       
        private int yas_hesapla(string a)
        {

            string[] parcalar = a.Split(' ');
            // Doğum tarihi
            string d_gun = parcalar[2];
            int b = Convert.ToInt32(d_gun);
            // Bu günün tarihi
            DateTime buGun = DateTime.Today;
            // Yıl farkı
            int yas = buGun.Year - b;
            return yas;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(resimPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] resim = br.ReadBytes((int)fs.Length);//www.gorselprogramlama.com

            br.Close();
            fs.Close();
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                    string kayit = "insert into kisi_bilgileri(tc_no,isim,soyisim,yas,kilo,boy,tel_no,kisi_bilgisi) values (@tc_no,@isim,@soyisim,@yas,@kilo,@boy,@tel_no,@kisi_bilgisi)";
                    string kayit2 = "insert into ceza_bilgisi(dosya_no,ceza_suresi,ceza_baslangic,ceza_bitis,profil_resmi) values (@dosya_no,@ceza_suresi,@ceza_baslangic,@ceza_bitis,@profil_resmi)";
                    string kayit3 = "insert into adres_tablosu(adresi,dogum_yeri) values (@adresi,@dogum_yeri)";
                    string kayit4 = "insert into kan_tablosu(kan_grubu) values (@kan_grubu)";
                    string kayit5 = "insert into yer_bilgisi(blok_adi,blok_no,yatak_no) values (@blok_adi,@blok_no,@yatak_no)";
                    // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    SqlCommand komut2 = new SqlCommand(kayit2, baglanti);
                    SqlCommand komut3 = new SqlCommand(kayit3, baglanti);
                    SqlCommand komut4 = new SqlCommand(kayit4, baglanti);
                    SqlCommand komut5 = new SqlCommand(kayit5, baglanti);
                    //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.

                    komut.Parameters.AddWithValue("@tc_no", tc_no.Text);
                    komut.Parameters.AddWithValue("@isim", adi.Text);
                    komut.Parameters.AddWithValue("@soyisim", soyadi.Text);
                    komut.Parameters.AddWithValue("@yas", label16.Text);
                    komut.Parameters.AddWithValue("@kilo", Convert.ToInt32(kilo.Text));
                    komut.Parameters.AddWithValue("@boy", Convert.ToDecimal(boy.Text));
                    komut.Parameters.AddWithValue("@tel_no", tel_no.Text);
                    komut.Parameters.AddWithValue("@kisi_bilgisi", kisibilgi.Text);
                    MessageBox.Show("Aşama1");
                    komut2.Parameters.AddWithValue("@dosya_no", dsyno.Text);
                    komut2.Parameters.AddWithValue("@ceza_suresi", cezasure.Text);
                    komut2.Parameters.AddWithValue("@ceza_baslangic", dateTimePicker1.Value);
                    komut2.Parameters.AddWithValue("@ceza_bitis", dateTimePicker2.Value);
                    //komut2.Parameters.AddWithValue("@profil_resmi", pictureBox1.Text);
                    komut2.Parameters.Add("@profil_resmi", SqlDbType.Image, resim.Length).Value = resim;//www.gorselprogramlama.com
                    MessageBox.Show("Aşama2");
                    komut3.Parameters.AddWithValue("@adresi", adres.Text);
                    komut3.Parameters.AddWithValue("@dogum_yeri", dogum_yeri.Text);
                    MessageBox.Show("Aşama3");
                    komut4.Parameters.AddWithValue("@kan_grubu", kangrubu.Text);
                    MessageBox.Show("Aşama4");
                    komut5.Parameters.AddWithValue("@blok_adi", label16.Text);
                    komut5.Parameters.AddWithValue("@blok_no", kilo.Text);
                    komut5.Parameters.AddWithValue("@yatak_no", boy.Text);
                    MessageBox.Show("Aşama5");

                    //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                    komut.ExecuteNonQuery();
                    komut2.ExecuteNonQuery();
                    komut3.ExecuteNonQuery();
                    komut4.ExecuteNonQuery();
                    komut5.ExecuteNonQuery();
                    //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                    baglanti.Close();
                    MessageBox.Show("Mahkum Kayıt İşlemi Gerçekleşti.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        public void dateTimePicker3_MouseCaptureChanged(object sender, EventArgs e)
        {
            string dogum_tarihi = dateTimePicker3.Text;
            //string dogum_tarihi = dateTimePicker3.Value.ToString();
            //MessageBox.Show("Müşteri Kayıt İşlemi Gerçekleşti."+ dogum_tarihi);
            int a = yas_hesapla(dogum_tarihi);
            label16.Text = Convert.ToString(a);


        }
        string resimPath;
        public int i =0;
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = !button3.Enabled;
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Resim Seç";
            fd.Filter = "(*.jpg)|*.jpg|(*.png)|*.png";

            do
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    this.pictureBox1.Image = Image.FromFile(fd.FileName);
                    resimPath = fd.FileName.ToString();

                    //new Bitmap(fd.OpenFile());
                    button3.Visible = false;
                    MessageBox.Show("Resim Başarıyla Eklendi.");
                    break;
                }
                else
                {
                    MessageBox.Show("Resim Eklenemedi.");
                }
                i++;
            } while (i == 1);
            
        }

        private void dsyno_TextChanged(object sender, EventArgs e)
        {
            dsyno.MaxLength = 10;
        }

        private void tc_no_TextChanged(object sender, EventArgs e)
        {
            tc_no.MaxLength = 11;
        }

        private void tel_no_TextChanged(object sender, EventArgs e)
        {
            tel_no.MaxLength = 11;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            this.f2 = new yerleske(this);
        }
        public void labeleYerlestir(String a, String b, String c)
        {
            label15.Text = c+ " "+a +" Numaralı Koğuş " + b + " Numaralı Yatak.";
        }

    }
}
