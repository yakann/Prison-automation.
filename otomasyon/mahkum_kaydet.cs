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
    public partial class mahkum_kaydet : Form
    {
        public string degisken;
        public int deger;
        public int kan_id;
        public string blok;
        public string kogus;
        public string yatak;

        public void cevir(string a)
        {
            string[] parcalar = a.Split(' ');
            // Doğum tarihi
            blok = parcalar[0];
            kogus = parcalar[2];
            yatak = parcalar[5];
            
        }
        public mahkum_kaydet()
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
        SqlConnection baglanti2 = new SqlConnection(@"Data Source =.; Initial Catalog = hapis; Integrated Security = True");

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
            if (Convert.ToString(tc_no.Text.Length) != "0" || Convert.ToString(adi.Text.Length) != "0" || Convert.ToString(soyadi.Text.Length) != "0" ||
                Convert.ToString(kilo.Text.Length) != "0" || Convert.ToString(boy.Text.Length) != "0" || Convert.ToString(tel_no.Text.Length) != "0" ||
                Convert.ToString(kisibilgi.Text.Length) != "0" || Convert.ToString(tc_no.Text.Length) != "0" || Convert.ToString(dsyno.Text.Length) != "0" ||
                Convert.ToString(cezasure.Text.Length) != "0")
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
                        //Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
                        string kayit = "insert into kisi_bilgileri(tc_no,dosya_no,isim,soyisim,yas,kilo,boy,k_id,tel_no,kisi_bilgisi) values (@tc_no,@dosy_no,@isim,@soyisim,@yas,@kilo,@boy,@k_id,@tel_no,@kisi_bilgisi)";
                        string kayit2 = "insert into ceza_bilgisi(dosya_no,ceza_suresi,ceza_baslangic,ceza_bitis,profil_resmi) values (@dosya_no,@ceza_suresi,@ceza_baslangic,@ceza_bitis,@profil_resmi)";
                        string kayit3 = "insert into adres_tablosu(adresi,dogum_yeri) values (@adresi,@dogum_yeri)";
                        string kayit5 = "insert into yer_bilgisi(blok_adi,blok_no,yatak_no) values (@blok_adi,@blok_no,@yatak_no)";
                        // müşteriler tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        SqlCommand komut2 = new SqlCommand(kayit2, baglanti);
                        SqlCommand komut3 = new SqlCommand(kayit3, baglanti);
                        SqlCommand komut5 = new SqlCommand(kayit5, baglanti);
                        //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                         
                        komut.Parameters.AddWithValue("@tc_no", tc_no.Text);
                        komut.Parameters.AddWithValue("@isim", adi.Text);
                        komut.Parameters.AddWithValue("@soyisim", soyadi.Text);
                        komut.Parameters.AddWithValue("@yas", label16.Text);
                        komut.Parameters.AddWithValue("@kilo", Convert.ToInt32(kilo.Text));
                        komut.Parameters.AddWithValue("@boy", Convert.ToDecimal(boy.Text));
                        komut.Parameters.AddWithValue("@k_id", kan_id);
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

                        cevir(label15.Text);
                        komut5.Parameters.AddWithValue("@blok_adi", Convert.ToChar(blok.Trim()));
                        komut5.Parameters.AddWithValue("@blok_no", Convert.ToString(kogus.Trim()));
                        komut5.Parameters.AddWithValue("@yatak_no", yatak.Trim());


                        //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        komut3.ExecuteNonQuery();
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
            else
            {
                MessageBox.Show("Boş Geçilemez!");
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
        public int i = 0;
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
            label15.Text = c + " " + a + " Numaralı Koğuş " + b + " Numaralı Yatak.";
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void kangrubu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (kangrubu.Text.Trim() == kangrubu.Items[0].ToString())
            {
                this.kan_id = 1;
            }
            else if (kangrubu.Text == kangrubu.Items[1].ToString())
            {
                this.kan_id = 2;
            }
            else if (kangrubu.Text == kangrubu.Items[2].ToString())
            {
                this.kan_id = 3; MessageBox.Show("gddasdasds");
            }
            else if (kangrubu.Text == kangrubu.Items[3].ToString())
            {
                this.kan_id = 4;
            }
            else if (kangrubu.Text == kangrubu.Items[4].ToString())
            {
                this.kan_id = 5;
            }
            else if (kangrubu.Text == kangrubu.Items[5].ToString())
            {
                this.kan_id = 6;
            }
            else if (kangrubu.Text == kangrubu.Items[6].ToString())
            {
                this.kan_id = 7;
            }
            else if (kangrubu.Text == kangrubu.Items[7].ToString())
            {
                MessageBox.Show("birşey yok");
                this.kan_id = 8;
            }
        }
    }
}


////degisken = deger2.Substring(0, deger2.Length - 1);
////MessageBox.Show(degisken);
//MessageBox.Show(kangrubu.Text + "230");
//try
//{
//    if (baglanti2.State == ConnectionState.Closed)
//    {
//        baglanti2.Open();
//        // Bağlantımızı kontrol ediyoruz, eğer kapalıysa açıyoruz.
//        string sorgu = "SELECT k_id FROM kan_tablosu WHERE kan_grubu =  " + kangrubu.SelectedItem.ToString() + "";
//        MessageBox.Show(kangrubu.Text + "238");
//        SqlCommand komutson = new SqlCommand(sorgu, baglanti2);
//        MessageBox.Show(komutson.ToString() + "240");
//        SqlDataReader cikti = komutson.ExecuteReader();
//        MessageBox.Show(kangrubu.Text + "242");
//        if (cikti.Read())
//        {

//            deger = Convert.ToInt32(cikti["k_id"]);
//            MessageBox.Show(deger.ToString());
//        }
//        else { MessageBox.Show("Kayıt Bulunamadı..."); }
//        baglanti2.Close();

//    }
//}
//catch (Exception hata)
//{
//    MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
//}