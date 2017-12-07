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
        public yerleske(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }
        public string a;
        public string b;
        public string c;
        public string d;
        public Form1 f1;
        public string dondur;
        public string renk_sonucu;
        SqlConnection baglanti = new SqlConnection(@"Data Source =.; Initial Catalog = hapis; Integrated Security = True");
        
        private void yerleske_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    
                    string sorgu = "SELECT * FROM buton_islemi WHERE buton_biti = 1";
                    
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    DataTable table = new DataTable();
                    SqlDataAdapter da=new SqlDataAdapter(komut);
                    da.Fill(table);
                    SqlDataReader cikti = komut.ExecuteReader();
                    if (cikti.Read())
                    {

                        string degisken2;
                       
                        Button[] dizim2 = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30, btn31, btn32, btn33, btn34, btn35, btn36, btn37, btn38, btn39, btn40, btn41, btn42, btn43, btn44, btn45, btn46, btn47, btn48, btn49, btn50, btn51, btn52, btn53, btn54, btn55, btn56, btn57, btn58, btn59, btn60, btn61, btn62, btn63, btn64, btn65, btn66, btn67, btn68, btn69, btn70, btn71, btn72, btn73, btn74, btn75, btn76, btn77, btn78, btn79, btn80, btn81, btn82, btn83, btn84, btn85, btn86, btn87, btn88, btn89, btn90, btn91, btn92, btn93, btn94, btn95, btn96, btn97, btn98, btn99, btn100, btn101, btn102, btn103, btn104, btn105, btn106, btn107, btn108, btn109, btn110, btn111, btn112 };


                        for (int i = 0; i < dizim2.Length; i++)
                        {
                            
                                degisken2 = table.Rows[i]["buton_ismi"].ToString();
                                if (degisken2 == dizim2[i].Name)
                                {
                                    dizim2[i].BackColor = Color.DarkRed;

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

        public void goster()
        {
            if (MessageBox.Show("Blok Adı : " + c + "\nBlok Numarası :" + a + "\nYatak Numarası :" + b+"\nKaydı onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.f1.labeleYerlestir(a, b, c);
                renk_sonucu = "kirmizi";

            }
            else
            {
                MessageBox.Show("Kayıt işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                renk_sonucu = "yesil";
            }

        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            c = label1.Text;
            a = groupBox2.Text;
            b = btn1.Text;   
            d = c + a + b;
            if (btn1.BackColor == Color.Lime)
            {
                btn1.BackColor = Color.DarkRed;
                goster();
                if (renk_sonucu=="yesil")
                {
                    btn1.BackColor = Color.Lime;
                }        
            }
            else
            {
               btn1.BackColor = Color.Lime;
            }

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            c = label1.Text;
            a = groupBox2.Text;
            b = btn2.Text;
            d = c + a + b;
            if (btn2.BackColor == Color.Lime)
            {
                btn2.BackColor = Color.DarkRed;
                goster();
                if (renk_sonucu == "yesil")
                {
                    btn2.BackColor = Color.Lime;
                }
            }
            else
            {
                btn2.BackColor = Color.Lime;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    string sorgu = "insert into buton_islemi(buton_ismi,buton_biti) values (@buton_ismi,@buton_biti)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);

                    if (btn1.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn1.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");                      
                    }
                    else if (btn2.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn2.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn3.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn3.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn4.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn4.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn5.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn5.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn6.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn6.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn7.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn7.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn8.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn8.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn9.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn9.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn10.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn10.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn11.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn11.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn12.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn12.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn13.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn13.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn14.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn14.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn15.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn15.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn16.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn16.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn17.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn17.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn18.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn18.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn19.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn19.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn20.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn20.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn21.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn21.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn22.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn22.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn23.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn23.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn24.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn24.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn25.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn25.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn26.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn26.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn27.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn27.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn28.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn28.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn29.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn29.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn30.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn30.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn31.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn31.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn32.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn32.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn33.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn33.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn34.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn34.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn35.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn35.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn36.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn36.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn37.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn37.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn38.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn38.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn39.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn39.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn40.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn40.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn41.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn41.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn42.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn42.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn43.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn43.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn44.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn44.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn45.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn45.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn46.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn46.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn47.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn47.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn48.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn48.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn49.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn49.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn50.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn50.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn51.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn51.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn52.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn52.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn53.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn53.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn54.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn54.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn55.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn55.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn56.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn56.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn57.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn57.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn58.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn58.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn59.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn59.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn60.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn60.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn61.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn61.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn62.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn62.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn63.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn63.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn64.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn64.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn65.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn65.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn66.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn66.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn67.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn67.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn68.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn68.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn69.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn69.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn70.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn70.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn71.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn71.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn72.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn72.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn73.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn73.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn74.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn74.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn75.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn75.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn76.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn76.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn77.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn77.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn78.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn78.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn79.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn79.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn80.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn80.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn81.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn81.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn82.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn82.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn83.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn83.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn84.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn84.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn85.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn85.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn86.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn86.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn87.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn87.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn88.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn88.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn89.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn89.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn90.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn90.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn91.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn91.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn92.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn92.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn93.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn93.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn94.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn94.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn95.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn95.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn96.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn96.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn97.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn97.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn98.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn98.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn99.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn99.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn100.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn100.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn101.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn101.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn102.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn102.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn103.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn103.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn104.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn104.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn105.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn105.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn106.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn106.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn107.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn107.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn108.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn108.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn109.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn109.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn110.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn110.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn111.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn111.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
                    }
                    else if (btn112.BackColor == Color.DarkRed)
                    {
                        komut.Parameters.AddWithValue("@buton_ismi", btn112.Name);
                        komut.Parameters.AddWithValue("@buton_biti", "True");
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
            c = label1.Text;
            a = groupBox2.Text;
            b = btn3.Text;
            d = c + a + b;
            if (btn3.BackColor == Color.Lime)
            {
                btn3.BackColor = Color.DarkRed;
                goster();
                if (renk_sonucu == "yesil")
                {
                    btn1.BackColor = Color.Lime;
                }
            }
            else
            {
                btn3.BackColor = Color.Lime;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            c = label1.Text;
            a = groupBox2.Text;
            b = btn4.Text;
            d = c + a + b;
            if (btn4.BackColor == Color.Lime){btn4.BackColor = Color.DarkRed;goster();if (renk_sonucu == "yesil"){btn4.BackColor = Color.Lime;}
            }
            else{btn4.BackColor = Color.Lime;}
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            c = label1.Text;
            a = groupBox2.Text;
            b = btn5.Text;
            d = c + a + b;
            if (btn5.BackColor == Color.Lime)
            {
                btn5.BackColor = Color.DarkRed; goster(); if (renk_sonucu == "yesil") { btn5.BackColor = Color.Lime; }
            }
            else { btn5.BackColor = Color.Lime; }
        }
    }

}
