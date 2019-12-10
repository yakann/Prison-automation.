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
using System.Data.SqlClient;

namespace otomasyon
{
    public partial class yerleske : Form
    {
        public yerleske(mahkum_kaydet f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }
        public string buton_adi;
        public string a;
        public string b;
        public string c;
        public string d;
        public mahkum_kaydet f1;
        public string dondur;
        public string son_deger;
        public string renk_sonucu;
        SqlConnection baglanti = new SqlConnection(@"Data Source =.; Initial Catalog = hapis; Integrated Security = True");
        SqlConnection baglanti2 = new SqlConnection(@"Data Source =.; Initial Catalog = hapis; Integrated Security = True");

        private void yerleske_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();

                    string sorgu2 = "SELECT * FROM buton_islemi WHERE buton_biti = 1";

                    SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
                    DataTable table = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(komut2);
                    da.Fill(table);
                    SqlDataReader cikti = komut2.ExecuteReader();
                    if (cikti.Read())
                    {
                        string degisken2;
                        
                        Button[] dizim2 = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40, btn41, btn42, btn43, btn44, btn45, btn46, btn47, btn48, btn49, btn50, btn51, btn52, btn53, btn54, btn55, btn56, btn57, btn58, btn59, btn60, btn61, btn62, btn63, btn64, btn65, btn66, btn67, btn68, btn69, btn70, btn71, btn72, btn73, btn74, btn75, btn76, btn77, btn78, btn79, btn80, btn81, btn82, btn83, btn84, btn85, btn86, btn87, btn88, btn89, btn90, btn91, btn92, btn93, btn94, btn95, btn96, btn97, btn98, btn99, btn100, btn101, btn102, btn103, btn104, btn105, btn106, btn107, btn108, btn109, btn110, btn111, btn112 };
                        for (int j = 0; j<20; j++) { 
                        for (int i = 0; i < dizim2.Length; i++)
                        {
                            degisken2 = table.Rows[j]["buton_ismi"].ToString();

                            if (degisken2 == dizim2[i].Name)
                            {
                                dizim2[i].BackColor = Color.DarkRed;
                                break;
                            }
                            else { continue; }
                        }
                        }
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
        public void goster(string deger)
        {
            if (MessageBox.Show("Blok Adı : " + c + "\nBlok Numarası :" + a + "\nYatak Numarası :" + b+"\nKaydı onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.f1.labeleYerlestir(a, b, c);
                renk_sonucu = "kirmizi";
                son_deger = deger;
            }
            else
            {
                MessageBox.Show("Kayıt işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                renk_sonucu = "yesil";
            }

        }
        private void btn1_Click_1(object sender, EventArgs e)
        {
            buton_adi = btn1.Name;
            renk_dongum();

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            buton_adi = btn2.Name;
            renk_dongum();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti2.State == ConnectionState.Closed)
                {
                    baglanti2.Open();
                    string sorgu = "insert into buton_islemi(buton_ismi,buton_biti) values (@buton_ismi,@buton_biti)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti2);
                    Button[] dizim3 = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40, btn41, btn42, btn43, btn44, btn45, btn46, btn47, btn48, btn49, btn50, btn51, btn52, btn53, btn54, btn55, btn56, btn57, btn58, btn59, btn60, btn61, btn62, btn63, btn64, btn65, btn66, btn67, btn68, btn69, btn70, btn71, btn72, btn73, btn74, btn75, btn76, btn77, btn78, btn79, btn80, btn81, btn82, btn83, btn84, btn85, btn86, btn87, btn88, btn89, btn90, btn91, btn92, btn93, btn94, btn95, btn96, btn97, btn98, btn99, btn100, btn101, btn102, btn103, btn104, btn105, btn106, btn107, btn108, btn109, btn110, btn111, btn112 };

                    for (int i=0; i<111; i++)
                    {
                        if(dizim3[i].BackColor == Color.DarkRed && this.son_deger == Convert.ToString(dizim3[i].Name.Trim()))
                        {
                            MessageBox.Show(Convert.ToString(dizim3[i].Name.Length));
                            MessageBox.Show(Convert.ToString(dizim3[i].Name));
                            komut.Parameters.AddWithValue("@buton_ismi", dizim3[i].Name);
                            komut.Parameters.AddWithValue("@buton_biti", "True");
                            break;
                        }
                    }
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            buton_adi = btn3.Name;
            renk_dongum();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            buton_adi = btn4.Name;
            renk_dongum();
        }

        public void renk_dongum()
        {
            Button[] dizim3 = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40, btn41, btn42, btn43, btn44, btn45, btn46, btn47, btn48, btn49, btn50, btn51, btn52, btn53, btn54, btn55, btn56, btn57, btn58, btn59, btn60, btn61, btn62, btn63, btn64, btn65, btn66, btn67, btn68, btn69, btn70, btn71, btn72, btn73, btn74, btn75, btn76, btn77, btn78, btn79, btn80, btn81, btn82, btn83, btn84, btn85, btn86, btn87, btn88, btn89, btn90, btn91, btn92, btn93, btn94, btn95, btn96, btn97, btn98, btn99, btn100, btn101, btn102, btn103, btn104, btn105, btn106, btn107, btn108, btn109, btn110, btn111, btn112 };
            string silinen_deger = buton_adi.Remove(0, 3);
            int yeni_deger = Convert.ToInt32(silinen_deger);
            if (yeni_deger <= 14) { a = groupBox2.Text; c = label1.Text; } else if(yeni_deger <= 28) { a = groupBox1.Text; c = label1.Text; } else if (yeni_deger <= 42) { a = groupBox4.Text; c = label1.Text; } else if (yeni_deger <= 56) { a = groupBox3.Text; c = label1.Text; } else if (yeni_deger <= 70) { a = groupBox7.Text; c = label2.Text; } else if (yeni_deger <= 84) { a = groupBox5.Text; c = label2.Text; } else if (yeni_deger <= 98) { a = groupBox8.Text; c = label2.Text; } else if (yeni_deger <= 112) { a = groupBox6.Text; c = label2.Text; }

            for (int i = 0; i < 111; i++)
            {
                if (buton_adi == dizim3[i].Name)
                {
                    b = dizim3[i].Text;
                    d = c + a + b;

                    if (dizim3[i].BackColor == Color.Lime)
                    {
                        dizim3[i].BackColor = Color.DarkRed; goster(dizim3[i].Name); if (renk_sonucu == "yesil") { dizim3[i].BackColor = Color.Lime; }
                    }
                    else { dizim3[i].BackColor = Color.Lime; }
                }
            }

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            buton_adi = btn5.Name;            renk_dongum();

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            buton_adi = btn6.Name;            renk_dongum();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            buton_adi = btn7.Name;            renk_dongum();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            buton_adi = btn8.Name;            renk_dongum();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            buton_adi = btn9.Name;            renk_dongum();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            buton_adi = btn10.Name;            renk_dongum();
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            buton_adi = btn11.Name;            renk_dongum();
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            buton_adi = btn12.Name;            renk_dongum();
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            buton_adi = btn13.Name;            renk_dongum();
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            buton_adi = btn14.Name;            renk_dongum();
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            buton_adi = btn15.Name;            renk_dongum();
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            buton_adi = btn16.Name;
            renk_dongum();
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            buton_adi = btn17.Name;            renk_dongum();
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            buton_adi = btn18.Name;            renk_dongum();
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            buton_adi = btn19.Name;            renk_dongum();
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            buton_adi = btn20.Name;            renk_dongum();
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            buton_adi = btn21.Name;            renk_dongum();
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            buton_adi = btn22.Name; renk_dongum();
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            buton_adi = btn23.Name; renk_dongum();
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            buton_adi = btn24.Name; renk_dongum();
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            buton_adi = btn25.Name; renk_dongum();
        }

        private void btn26_Click(object sender, EventArgs e)
        {
            buton_adi = btn26.Name; renk_dongum();
        }

        private void btn27_Click(object sender, EventArgs e)
        {
            buton_adi = btn27.Name; renk_dongum();
        }

        private void btn28_Click(object sender, EventArgs e)
        {
            buton_adi = btn28.Name; renk_dongum();
        }

        private void btn29_Click(object sender, EventArgs e)
        {
            buton_adi = btn29.Name; renk_dongum();
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            buton_adi = btn30.Name; renk_dongum();
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            buton_adi = btn31.Name; renk_dongum();
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            buton_adi = btn32.Name; renk_dongum();
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            buton_adi = btn33.Name; renk_dongum();
        }

        private void btn34_Click(object sender, EventArgs e)
        {
            buton_adi = btn34.Name; renk_dongum();
        }

        private void btn35_Click(object sender, EventArgs e)
        {
            buton_adi = btn35.Name; renk_dongum();
        }

        private void btn36_Click(object sender, EventArgs e)
        {
            buton_adi = btn36.Name; renk_dongum();
        }

        private void btn37_Click(object sender, EventArgs e)
        {
            buton_adi = btn37.Name; renk_dongum();
        }

        private void btn38_Click(object sender, EventArgs e)
        {
            buton_adi = btn38.Name; renk_dongum();
        }

        private void btn39_Click(object sender, EventArgs e)
        {
            buton_adi = btn39.Name; renk_dongum();
        }

        private void btn40_Click(object sender, EventArgs e)
        {
            buton_adi = btn40.Name; renk_dongum();
        }

        private void btn41_Click(object sender, EventArgs e)
        {
            buton_adi = btn41.Name; renk_dongum();
        }

        private void btn42_Click(object sender, EventArgs e)
        {
            buton_adi = btn42.Name; renk_dongum();
        }

        private void btn43_Click(object sender, EventArgs e)
        {
            buton_adi = btn43.Name; renk_dongum();
        }

        private void btn44_Click(object sender, EventArgs e)
        {
            buton_adi = btn44.Name; renk_dongum();
        }

        private void btn45_Click(object sender, EventArgs e)
        {
            buton_adi = btn45.Name; renk_dongum();
        }

        private void btn46_Click(object sender, EventArgs e)
        {
            buton_adi = btn46.Name; renk_dongum();
        }

        private void btn47_Click(object sender, EventArgs e)
        {
            buton_adi = btn47.Name; renk_dongum();
        }

        private void btn48_Click(object sender, EventArgs e)
        {
            buton_adi = btn48.Name; renk_dongum();
        }

        private void btn49_Click(object sender, EventArgs e)
        {
            buton_adi = btn49.Name; renk_dongum();
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            buton_adi = btn50.Name; renk_dongum();
        }

        private void btn51_Click(object sender, EventArgs e)
        {
            buton_adi = btn51.Name; renk_dongum();
        }

        private void btn52_Click(object sender, EventArgs e)
        {
            buton_adi = btn52.Name; renk_dongum();
        }

        private void btn53_Click(object sender, EventArgs e)
        {
            buton_adi = btn53.Name; renk_dongum();
        }

        private void btn54_Click(object sender, EventArgs e)
        {
            buton_adi = btn54.Name; renk_dongum();
        }

        private void btn55_Click(object sender, EventArgs e)
        {
            buton_adi = btn55.Name; renk_dongum();
        }

        private void btn56_Click(object sender, EventArgs e)
        {
            buton_adi = btn56.Name; renk_dongum();
        }

        private void btn57_Click(object sender, EventArgs e)
        {
            buton_adi = btn57.Name; renk_dongum();
        }

        private void btn58_Click(object sender, EventArgs e)
        {
            buton_adi = btn58.Name; renk_dongum();
        }

        private void btn59_Click(object sender, EventArgs e)
        {
            buton_adi = btn59.Name; renk_dongum();
        }

        private void btn60_Click(object sender, EventArgs e)
        {
            buton_adi = btn60.Name; renk_dongum();
        }

        private void btn61_Click(object sender, EventArgs e)
        {
            buton_adi = btn61.Name; renk_dongum();
        }

        private void btn62_Click(object sender, EventArgs e)
        {
            buton_adi = btn62.Name; renk_dongum();
        }

        private void btn63_Click(object sender, EventArgs e)
        {
            buton_adi = btn63.Name; renk_dongum();
        }

        private void btn64_Click(object sender, EventArgs e)
        {
            buton_adi = btn64.Name; renk_dongum();
        }

        private void btn65_Click(object sender, EventArgs e)
        {
            buton_adi = btn65.Name; renk_dongum();
        }

        private void btn66_Click(object sender, EventArgs e)
        {
            buton_adi = btn66.Name; renk_dongum();
        }

        private void btn67_Click(object sender, EventArgs e)
        {
            buton_adi = btn67.Name; renk_dongum();
        }

        private void btn68_Click(object sender, EventArgs e)
        {
            buton_adi = btn68.Name; renk_dongum();
        }

        private void btn69_Click(object sender, EventArgs e)
        {
            buton_adi = btn69.Name; renk_dongum();
        }

        private void btn70_Click(object sender, EventArgs e)
        {
            buton_adi = btn70.Name; renk_dongum();
        }

        private void btn71_Click(object sender, EventArgs e)
        {
            buton_adi = btn71.Name; renk_dongum();
        }

        private void btn72_Click(object sender, EventArgs e)
        {
            buton_adi = btn72.Name; renk_dongum();
        }

        private void btn73_Click(object sender, EventArgs e)
        {
            buton_adi = btn73.Name; renk_dongum();
        }

        private void btn74_Click(object sender, EventArgs e)
        {
            buton_adi = btn74.Name; renk_dongum();
        }

        private void btn75_Click(object sender, EventArgs e)
        {
            buton_adi = btn75.Name; renk_dongum();
        }

        private void btn76_Click(object sender, EventArgs e)
        {
            buton_adi = btn76.Name; renk_dongum();
        }

        private void btn77_Click(object sender, EventArgs e)
        {
            buton_adi = btn77.Name; renk_dongum();
        }

        private void btn78_Click(object sender, EventArgs e)
        {
            buton_adi = btn78.Name; renk_dongum();
        }

        private void btn79_Click(object sender, EventArgs e)
        {
            buton_adi = btn79.Name; renk_dongum();
        }

        private void btn80_Click(object sender, EventArgs e)
        {
            buton_adi = btn80.Name; renk_dongum();
        }

        private void btn81_Click(object sender, EventArgs e)
        {
            buton_adi = btn81.Name; renk_dongum();
        }

        private void btn82_Click(object sender, EventArgs e)
        {
            buton_adi = btn82.Name; renk_dongum();
        }

        private void btn83_Click(object sender, EventArgs e)
        {
            buton_adi = btn83.Name; renk_dongum();
        }

        private void btn84_Click(object sender, EventArgs e)
        {
            buton_adi = btn84.Name; renk_dongum();
        }

        private void btn85_Click(object sender, EventArgs e)
        {
            buton_adi = btn85.Name; renk_dongum();
        }

        private void btn86_Click(object sender, EventArgs e)
        {
            buton_adi = btn86.Name; renk_dongum();
        }

        private void btn87_Click(object sender, EventArgs e)
        {
            buton_adi = btn87.Name; renk_dongum();
        }

        private void btn88_Click(object sender, EventArgs e)
        {
            buton_adi = btn88.Name; renk_dongum();
        }

        private void btn89_Click(object sender, EventArgs e)
        {
            buton_adi = btn89.Name; renk_dongum();
        }

        private void btn90_Click(object sender, EventArgs e)
        {
            buton_adi = btn90.Name; renk_dongum();
        }

        private void btn91_Click(object sender, EventArgs e)
        {
            buton_adi = btn91.Name; renk_dongum();
        }

        private void btn92_Click(object sender, EventArgs e)
        {
            buton_adi = btn92.Name; renk_dongum();
        }

        private void btn93_Click(object sender, EventArgs e)
        {
            buton_adi = btn93.Name; renk_dongum();
        }

        private void btn94_Click(object sender, EventArgs e)
        {
            buton_adi = btn94.Name; renk_dongum();
        }

        private void btn95_Click(object sender, EventArgs e)
        {
            buton_adi = btn95.Name; renk_dongum();
        }

        private void btn96_Click(object sender, EventArgs e)
        {
            buton_adi = btn96.Name; renk_dongum();
        }

        private void btn97_Click(object sender, EventArgs e)
        {
            buton_adi = btn97.Name; renk_dongum();
        }

        private void btn98_Click(object sender, EventArgs e)
        {
            buton_adi = btn98.Name; renk_dongum();
        }

        private void btn99_Click(object sender, EventArgs e)
        {
            buton_adi = btn99.Name; renk_dongum();
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            buton_adi = btn100.Name; renk_dongum();
        }

        private void btn101_Click(object sender, EventArgs e)
        {
            buton_adi = btn101.Name; renk_dongum();
        }

        private void btn102_Click(object sender, EventArgs e)
        {
            buton_adi = btn102.Name; renk_dongum();
        }

        private void btn103_Click(object sender, EventArgs e)
        {
            buton_adi = btn103.Name; renk_dongum();
        }

        private void btn104_Click(object sender, EventArgs e)
        {
            buton_adi = btn104.Name; renk_dongum();
        }

        private void btn105_Click(object sender, EventArgs e)
        {
            buton_adi = btn105.Name; renk_dongum();
        }

        private void btn106_Click(object sender, EventArgs e)
        {
            buton_adi = btn106.Name; renk_dongum();
        }

        private void btn107_Click(object sender, EventArgs e)
        {
            buton_adi = btn107.Name; renk_dongum();
        }

        private void btn108_Click(object sender, EventArgs e)
        {
            buton_adi = btn108.Name; renk_dongum();
        }

        private void btn109_Click(object sender, EventArgs e)
        {
            buton_adi = btn109.Name; renk_dongum();
        }

        private void btn110_Click(object sender, EventArgs e)
        {
            buton_adi = btn110.Name; renk_dongum();
        }

        private void btn111_Click(object sender, EventArgs e)
        {
            buton_adi = btn111.Name; renk_dongum();
        }

        private void btn112_Click(object sender, EventArgs e)
        {
            buton_adi = btn112.Name; renk_dongum();
        }
    }

}
