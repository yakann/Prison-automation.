using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otomasyon
{
    public partial class login : Form
    {


        public login()
        {
            InitializeComponent();
        }

        public User user;
        public UserProvider islem;

        private void giris_Click_1(object sender, EventArgs e)
        {
            islem = new UserProvider();
            user = islem.getUser(kullanici_adi.Text, sifre.Text);
            if (user != null)
            {
                ana_ekran fl = new ana_ekran();
                fl.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ya da şifre Yanlış!");
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saat.Text = "Saat: "+DateTime.Now.ToLongTimeString();
            tarih.Text = "Tarih: "+DateTime.Now.ToShortDateString();
        }
    }
}
