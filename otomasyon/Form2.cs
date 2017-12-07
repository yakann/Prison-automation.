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
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FSI8QQL;Initial Catalog=hapis;Integrated Security=True");


        public Form2()
        {
            InitializeComponent();
        }

        private void giris_Click(object sender, EventArgs e)
        {
            if (kullanici_adi.Text == "" || sifre.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                //Create SqlConnection
                SqlCommand cmd = new SqlCommand("Select * from login where kullaniciadi=@username and sifrem=@password", baglanti);
                cmd.Parameters.AddWithValue("@username", kullanici_adi.Text);
                cmd.Parameters.AddWithValue("@password", sifre.Text);
                baglanti.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                baglanti.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    Form3 fm = new Form3();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void giris_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fl = new Form3();
            fl.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
