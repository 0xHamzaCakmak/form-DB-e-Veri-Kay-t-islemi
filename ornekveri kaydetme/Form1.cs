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

namespace ornekveri_kaydetme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kayıtlar;Integrated Security=True");
        private void verilerigoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Gelenler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Adsoyad"].ToString();
                ekle.SubItems.Add(oku["Firma"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Gelenler (Adsoyad,Firma, Telefon) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
