using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class CALISAN_KONTROL : Form
    {
        public CALISAN_KONTROL()
        {
            InitializeComponent();

            // Eventleri burada bağla
            this.Load += CALISAN_KONTROL_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
            textAra.TextChanged += textAra_TextChanged;
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");
        int seciliKullaniciID = -1;

        private void CALISAN_KONTROL_Load(object sender, EventArgs e)
        {
            cbKayıtKategori.Items.Clear();
            cbKayıtKategori.Items.Add("YÖNETİCİ");
            cbKayıtKategori.Items.Add("TEDARİK DEPARTMANI");
            cbKayıtKategori.Items.Add("PAZARLAMA DEPARTMANI");
            cbKayıtKategori.SelectedIndex = -1;

            dataGridView1.Visible = false;
        }

        private void MevcutCalisanlariListele(string aramaKelimesi = "")
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        U_ID,
                        NAME,
                        SURNAME,
                        PHONE,
                        U_NAME,
                        PASSWORD,
                        YONETICI,
                        TEDARIK_DEPARTMANI,
                        PAZARLAMA_DEPARTMANI
                    FROM USERS
                    WHERE
                        NAME LIKE @arama OR
                        SURNAME LIKE @arama OR
                        PHONE LIKE @arama OR
                        U_NAME LIKE @arama OR
                        (
                            CASE 
                                WHEN YONETICI = 1 THEN 'YÖNETİCİ'
                                WHEN TEDARIK_DEPARTMANI = 1 THEN 'TEDARİK DEPARTMANI'
                                WHEN PAZARLAMA_DEPARTMANI = 1 THEN 'PAZARLAMA DEPARTMANI'
                                ELSE ''
                            END
                        ) LIKE @arama", conn);

                cmd.Parameters.AddWithValue("@arama", "%" + aramaKelimesi + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (!dt.Columns.Contains("POZISYON"))
                    dt.Columns.Add("POZISYON");

                foreach (DataRow row in dt.Rows)
                {
                    if (row["YONETICI"].ToString() == "1")
                        row["POZISYON"] = "YÖNETİCİ";
                    else if (row["TEDARIK_DEPARTMANI"].ToString() == "1")
                        row["POZISYON"] = "TEDARİK DEPARTMANI";
                    else if (row["PAZARLAMA_DEPARTMANI"].ToString() == "1")
                        row["POZISYON"] = "PAZARLAMA DEPARTMANI";
                    else
                        row["POZISYON"] = "";
                }

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                dataGridView1.Visible = true;

                dataGridView1.Columns["U_ID"].HeaderText = "ID";
                dataGridView1.Columns["NAME"].HeaderText = "İsim";
                dataGridView1.Columns["SURNAME"].HeaderText = "Soyisim";
                dataGridView1.Columns["PHONE"].HeaderText = "Telefon";
                dataGridView1.Columns["U_NAME"].HeaderText = "Kullanıcı Adı";
                dataGridView1.Columns["PASSWORD"].HeaderText = "Şifre";
                dataGridView1.Columns["POZISYON"].HeaderText = "Pozisyon";

                dataGridView1.Columns["YONETICI"].Visible = false;
                dataGridView1.Columns["TEDARIK_DEPARTMANI"].Visible = false;
                dataGridView1.Columns["PAZARLAMA_DEPARTMANI"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çalışanlar listelenirken hata oluştu: " + ex.Message);
            }
        }

        private void AlanlariTemizle()
        {
            txtkayıtisim.Clear();
            txtkayıtsoyisim.Clear();
            txtkayıtphone.Clear();
            txtkayıtuname.Clear();
            txtkayıtpass.Clear();
            cbKayıtKategori.SelectedIndex = -1;
            seciliKullaniciID = -1;
        }

        private void buttonYeniKayit_Click(object sender, EventArgs e)
        {
            KAYIT frm = new KAYIT();
            frm.ShowDialog();
            MevcutCalisanlariListele(textAra.Text.Trim());
        }

        // MEVCUT ÇALIŞAN
        private void button2_Click(object sender, EventArgs e)
        {
            MevcutCalisanlariListele(textAra.Text.Trim());
        }

        // YENİLE
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliKullaniciID == -1)
                {
                    MessageBox.Show("Lütfen güncellenecek çalışanı seçin.");
                    return;
                }

                if (txtkayıtisim.Text == "" || txtkayıtsoyisim.Text == "" || txtkayıtphone.Text == "" ||
                    txtkayıtuname.Text == "" || txtkayıtpass.Text == "" || cbKayıtKategori.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }

                int yonetici = 0, tedarik = 0, pazarlama = 0;

                switch (cbKayıtKategori.SelectedItem.ToString())
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

                SqlCommand cmd = new SqlCommand(@"
                    UPDATE USERS
                    SET 
                        NAME = @NAME,
                        SURNAME = @SURNAME,
                        PHONE = @PHONE,
                        U_NAME = @UNAME,
                        PASSWORD = @PASSWORD,
                        YONETICI = @YONETICI,
                        TEDARIK_DEPARTMANI = @TEDARIK,
                        PAZARLAMA_DEPARTMANI = @PAZARLAMA
                    WHERE U_ID = @ID", conn);

                cmd.Parameters.AddWithValue("@ID", seciliKullaniciID);
                cmd.Parameters.AddWithValue("@NAME", txtkayıtisim.Text);
                cmd.Parameters.AddWithValue("@SURNAME", txtkayıtsoyisim.Text);
                cmd.Parameters.AddWithValue("@PHONE", txtkayıtphone.Text);
                cmd.Parameters.AddWithValue("@UNAME", txtkayıtuname.Text);
                cmd.Parameters.AddWithValue("@PASSWORD", txtkayıtpass.Text);
                cmd.Parameters.AddWithValue("@YONETICI", yonetici);
                cmd.Parameters.AddWithValue("@TEDARIK", tedarik);
                cmd.Parameters.AddWithValue("@PAZARLAMA", pazarlama);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Çalışan bilgileri güncellendi.");
                MevcutCalisanlariListele(textAra.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // SİL
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (seciliKullaniciID == -1)
                {
                    MessageBox.Show("Lütfen silinecek çalışanı seçin.");
                    return;
                }

                DialogResult sonuc = MessageBox.Show("Bu kullanıcı silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM USERS WHERE U_ID = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", seciliKullaniciID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Kullanıcı silindi.");
                    AlanlariTemizle();
                    MevcutCalisanlariListele(textAra.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // SATIRA TIKLAYINCA TEXTLERE DOLDUR
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            DataGridViewRow row = dataGridView1.CurrentRow;

            if (row.Cells["U_ID"] == null || row.Cells["U_ID"].Value == null) return;

            seciliKullaniciID = Convert.ToInt32(row.Cells["U_ID"].Value);

            txtkayıtisim.Text = row.Cells["NAME"]?.Value?.ToString() ?? "";
            txtkayıtsoyisim.Text = row.Cells["SURNAME"]?.Value?.ToString() ?? "";
            txtkayıtphone.Text = row.Cells["PHONE"]?.Value?.ToString() ?? "";
            txtkayıtuname.Text = row.Cells["U_NAME"]?.Value?.ToString() ?? "";
            txtkayıtpass.Text = row.Cells["PASSWORD"]?.Value?.ToString() ?? "";

            string pozisyon = row.Cells["POZISYON"]?.Value?.ToString() ?? "";
            cbKayıtKategori.SelectedItem = pozisyon;
        }

        private void txtkayıtisim_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtkayıtphone_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtkayıtsoyisim_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtkayıtpass_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtkayıtuname_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbKayıtKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        // TEXTBOXA YAZDIKÇA ARAMA
        private void textAra_TextChanged(object sender, EventArgs e)
        {
            MevcutCalisanlariListele(textAra.Text.Trim());
        }

        // ARA BUTONU
        private void buttonAra_Click(object sender, EventArgs e)
        {
            MevcutCalisanlariListele(textAra.Text.Trim());
        }

        // ARAMA TEMİZLE BUTONU
        private void buttonAraTemizle_Click(object sender, EventArgs e)
        {
            textAra.Clear();
            MevcutCalisanlariListele();
        }

        private void CALISAN_KONTROL_Load_1(object sender, EventArgs e)
        {

        }
    }
}