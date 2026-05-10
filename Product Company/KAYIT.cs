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

namespace PRODUCT_COMPANY
{
    public partial class KAYIT : Form
    {
        public KAYIT()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");
        int kayıt;
        private void kayıtekle()
        {
           
{
                
                
                    if (cbKayıtKategori.SelectedItem == null)
                    {
                        MessageBox.Show("Lütfen bir rol seçiniz.");
                        return;
                    }

                    string telefon = txtkayıtphone.Text;
                    string soyisim = txtkayıtsoyisim.Text;
                    string isim = txtkayıtisim.Text;
                    string kullaniciAdi = txtkayıtuname.Text;
                    string sifre = txtkayıtpass.Text;
                    string secilenRol = cbKayıtKategori.SelectedItem.ToString();

                    int yonetici = 0, tedarik = 0, pazarlama = 0;

                    switch (secilenRol)
                    {
                        case "YÖNETİCİ":
                            yonetici = 1;
                            break;
                        case "TEDARİK DEPARTMANI":
                            tedarik = 1;
                            break;
                        case "PAZARLAMA DEPARTMANI":
                            pazarlama = 1;
                            break;
                       
                            
                    }

                    conn.Open();

                    SqlCommand komut = new SqlCommand(@"
                    INSERT INTO USERS 
                    (NAME, SURNAME, PHONE, U_NAME, PASSWORD, YONETICI, PAZARLAMA_DEPARTMANI, TEDARIK_DEPARTMANI) 
                    VALUES 
                    (@NAME, @SNAME, @PHONE, @UNAME, @PASS, @YONETICI, @PAZARLAMA, @TEDARIK)", conn);

                    komut.Parameters.AddWithValue("@NAME", isim);
                    komut.Parameters.AddWithValue("@SNAME", soyisim);
                    komut.Parameters.AddWithValue("@PHONE", telefon);
                    komut.Parameters.AddWithValue("@UNAME", kullaniciAdi);
                    komut.Parameters.AddWithValue("@PASS", sifre);
                    komut.Parameters.AddWithValue("@YONETICI", yonetici);
                    komut.Parameters.AddWithValue("@PAZARLAMA", pazarlama);
                    komut.Parameters.AddWithValue("@TEDARIK", tedarik);

                    kayıt = komut.ExecuteNonQuery();

                    if (kayıt > 0)
                    {
                        MessageBox.Show("Kullanıcı başarıyla eklendi!");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarısız!");
                    }

                    conn.Close();
                }

            }

            private void button1_Click(object sender, EventArgs e)
        {

            kayıtekle();
            if (kayıt > 0)
            {
                Form1 frm = new Form1();
                frm.ShowDialog();
                this.Close();
               
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız!!");
            }

        }

        private void KAYIT_Load(object sender, EventArgs e)
        {

            cbKayıtKategori.Items.Clear();
            cbKayıtKategori.Items.Add("YÖNETİCİ");
            cbKayıtKategori.Items.Add("TEDARİK DEPARTMANI");
            cbKayıtKategori.Items.Add("PAZARLAMA DEPARTMANI");
            cbKayıtKategori.SelectedIndex = 0;
        }
    }
}
