using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class URUN_GIRIS_KONTROL : Form
    {
        public URUN_GIRIS_KONTROL()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");

        private void URUN_GIRIS_KONTROL_Load(object sender, EventArgs e)
        {
            GirisleriListele();
        }

        private void GirisleriListele(string aramaMetni = "")
        {
            try
            {
                string query = @"
                    SELECT
                        PL.P_ID AS [ID],
                        PL.PRODUCT_NAME AS [Ürün Adı],
                        PL.CATEGORY_NAME AS [Kategori],
                        PL.QUANTITY AS [Giriş Miktarı],
                        PL.ALIS_FIYATI AS [Alış Fiyatı (TL)],
                        PL.TOPLAM_MALIYET AS [Toplam Maliyet (TL)],
                        U.NAME + ' ' + U.SURNAME AS [Kullanıcı Adı],
                        PL.GIRIS_TARIHI AS [Giriş Tarihi]
                    FROM PRODUCT_LOGIN PL
                    LEFT JOIN USERS U ON U.U_ID = PL.USER_ID
                    WHERE
                        @arama = ''
                        OR PL.PRODUCT_NAME LIKE '%' + @arama + '%'
                        OR PL.CATEGORY_NAME LIKE '%' + @arama + '%'
                        OR U.NAME LIKE '%' + @arama + '%'
                        OR U.SURNAME LIKE '%' + @arama + '%'
                        OR (U.NAME + ' ' + U.SURNAME) LIKE '%' + @arama + '%'
                        OR CAST(PL.QUANTITY AS NVARCHAR) LIKE '%' + @arama + '%'
                        OR CAST(PL.ALIS_FIYATI AS NVARCHAR) LIKE '%' + @arama + '%'
                        OR CAST(PL.TOPLAM_MALIYET AS NVARCHAR) LIKE '%' + @arama + '%'
                        OR CONVERT(NVARCHAR, PL.GIRIS_TARIHI, 104) LIKE '%' + @arama + '%'
                    ORDER BY PL.GIRIS_TARIHI DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@arama", aramaMetni.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Ürün Adı"].HeaderText = "Ürün Adı";
                    dataGridView1.Columns["Kategori"].HeaderText = "Kategori";
                    dataGridView1.Columns["Giriş Miktarı"].HeaderText = "Giriş Miktarı";
                    dataGridView1.Columns["Alış Fiyatı (TL)"].HeaderText = "Alış Fiyatı (TL)";
                    dataGridView1.Columns["Toplam Maliyet (TL)"].HeaderText = "Toplam Maliyet (TL)";
                    dataGridView1.Columns["Kullanıcı Adı"].HeaderText = "Kullanıcı Adı";
                    dataGridView1.Columns["Giriş Tarihi"].HeaderText = "Giriş Tarihi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme / arama sırasında hata oluştu: " + ex.Message);
            }
        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            GirisleriListele(textAra.Text);
        }

        private void buttonAraTemizle_Click(object sender, EventArgs e)
        {
            textAra.Clear();
            GirisleriListele();
        }

        private void textAra_TextChanged(object sender, EventArgs e)
        {
            GirisleriListele(textAra.Text);
        }
    }
}