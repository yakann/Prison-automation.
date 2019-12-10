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
    public partial class ana_ekran : Form
    {
        public ana_ekran()
        {
            InitializeComponent();
        }

        private void yeni_uye_Click(object sender, EventArgs e)
        {
            mahkum_kaydet f2 = new mahkum_kaydet();
            f2.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void cikis_Click(object sender, EventArgs e)
        {
            this.Hide();
            login fl = new login();
            fl.Show();
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mahkum_gonder_Click(object sender, EventArgs e)
        {
            this.Hide();
            mahkum_sil fl = new mahkum_sil();
            fl.Show();
        }

        private void m_cagir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cagir fl = new Cagir();
            fl.Show();
        }
    }
}
