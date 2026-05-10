using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PRODUCT_COMPANY
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(
            "Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True"
        );

        public static int GirisYapanKullaniciID;

        public Form1()
        {
            InitializeComponent();
        }

        public class UpdateModel
        {
            public bool update { get; set; }
            public string newVersion { get; set; }
            public string message { get; set; }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            cbGirisKategori.Items.Clear();
            cbGirisKategori.Items.Add("YÖNETİCİ");
            cbGirisKategori.Items.Add("TEDARİK DEPARTMANI");
            cbGirisKategori.Items.Add("PAZARLAMA DEPARTMANI");
            cbGirisKategori.SelectedIndex = 0;

            string path = Path.Combine(Application.StartupPath, "version.txt");

            if (File.Exists(path))
            {
                string version = File.ReadAllText(path).Trim();
                MessageBox.Show("Program sürümü: " + version);
            }
            else
            {
                MessageBox.Show("version.txt bulunamadı!");
            }

          
        }

        private async Task UpdateKontrol()
        {
            try
            {
                string versionPath = Path.Combine(Application.StartupPath, "version.txt");

                if (!File.Exists(versionPath))
                {
                    MessageBox.Show("version.txt bulunamadığı için güncelleme kontrolü yapılamadı.");
                    return;
                }

                string version = File.ReadAllText(versionPath).Trim();

                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback =
                        (message, cert, chain, errors) => true;

                    using (HttpClient client = new HttpClient(handler))
                    {
                        string url = "https://localhost:7079/api/update/check?version=" + version;

                        string json = await client.GetStringAsync(url);

                        UpdateModel data = JsonConvert.DeserializeObject<UpdateModel>(json);

                        if (data != null && data.update)
                        {
                            MessageBox.Show(
                                "Yeni güncelleme mevcut!\n\n" +
                                "Yeni sürüm: " + data.newVersion + "\n" +
                                data.message,
                                "Güncelleme Kontrolü",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show("Program güncel.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Güncelleme kontrolü yapılamadı:\n" +
                    ex.Message,
                    "Güncelleme Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtuname.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adını giriniz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtpas.Text))
            {
                MessageBox.Show("Lütfen şifre giriniz.");
                return;
            }

            if (cbGirisKategori.SelectedItem == null)
            {
                MessageBox.Show("Lütfen giriş kategorisi seçiniz.");
                return;
            }

            string kullaniciAdi = txtuname.Text.Trim();
            string sifre = txtpas.Text.Trim();
            string secilenRol = cbGirisKategori.SelectedItem.ToString();

            string kolonAdi = "";

            switch (secilenRol)
            {
                case "YÖNETİCİ":
                    kolonAdi = "YONETICI";
                    break;

                case "TEDARİK DEPARTMANI":
                    kolonAdi = "TEDARIK_DEPARTMANI";
                    break;

                case "PAZARLAMA DEPARTMANI":
                    kolonAdi = "PAZARLAMA_DEPARTMANI";
                    break;

                default:
                    MessageBox.Show("Geçersiz departman seçimi.");
                    return;
            }

            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM USERS WHERE U_NAME=@kadi AND PASSWORD=@sifre",
                    connection
                );

                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    bool girisYetkili =
                        dr[kolonAdi] != DBNull.Value &&
                        dr[kolonAdi].ToString() == "1";

                    if (girisYetkili)
                    {
                        GirisYapanKullaniciID = Convert.ToInt32(dr["U_ID"]);

                        dr.Close();
                        connection.Close();

                        if (secilenRol == "YÖNETİCİ")
                        {
                            YONETİCİ frm = new YONETİCİ();
                            frm.Show();
                        }
                        else if (secilenRol == "TEDARİK DEPARTMANI")
                        {
                            URUN_GİRİS frm = new URUN_GİRİS();
                            frm.Show();
                        }
                        else if (secilenRol == "PAZARLAMA DEPARTMANI")
                        {
                            URUN_CIKIS frm = new URUN_CIKIS();
                            frm.Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Bu kullanıcı bu departmanda değil!");
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
                }

                if (!dr.IsClosed)
                    dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş sırasında hata oluştu:\n" + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}