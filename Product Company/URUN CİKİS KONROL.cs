using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class URUN_CİKİS_KONROL : Form
    {
        public URUN_CİKİS_KONROL()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");

        private void URUN_CİKİS_KONROL_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            CikislariListele();
        }

        private void CikislariListele(string aramaMetni = "")
        {
            try
            {
                string query = @"
                    SELECT
                        po.OUT_ID AS [ID],
                        po.PRODUCT_NAME AS [Ürün Adı],
                        po.CATEGORY_NAME AS [Kategori],
                        po.QUANTITY AS [Çıkış Miktarı],
                        po.SATIS_FIYATI AS [Çıkış Fiyatı (TL)],
                        ISNULL(po.TOPLAM_MALIYET, po.QUANTITY * po.SATIS_FIYATI) AS [Toplam Maliyet (TL)],
                        u.NAME + ' ' + u.SURNAME AS [Kullanıcı],
                        po.CIKIS_TARIHI AS [Çıkış Tarihi]
                    FROM PRODUCT_OUT po
                    LEFT JOIN USERS u ON u.U_ID = po.USER_ID
                    WHERE
                        @arama = ''
                        OR po.PRODUCT_NAME LIKE '%' + @arama + '%'
                        OR po.CATEGORY_NAME LIKE '%' + @arama + '%'
                        OR u.NAME LIKE '%' + @arama + '%'
                        OR u.SURNAME LIKE '%' + @arama + '%'
                        OR (u.NAME + ' ' + u.SURNAME) LIKE '%' + @arama + '%'
                        OR CAST(po.QUANTITY AS NVARCHAR) LIKE '%' + @arama + '%'
                        OR CAST(po.SATIS_FIYATI AS NVARCHAR) LIKE '%' + @arama + '%'
                        OR CAST(ISNULL(po.TOPLAM_MALIYET, po.QUANTITY * po.SATIS_FIYATI) AS NVARCHAR) LIKE '%' + @arama + '%'
                        OR CONVERT(NVARCHAR, po.CIKIS_TARIHI, 104) LIKE '%' + @arama + '%'
                    ORDER BY po.CIKIS_TARIHI DESC";

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
                    dataGridView1.Columns["Çıkış Miktarı"].HeaderText = "Çıkış Miktarı";
                    dataGridView1.Columns["Çıkış Fiyatı (TL)"].HeaderText = "Çıkış Fiyatı (TL)";
                    dataGridView1.Columns["Toplam Maliyet (TL)"].HeaderText = "Toplam Maliyet (TL)";
                    dataGridView1.Columns["Kullanıcı"].HeaderText = "Kullanıcı";
                    dataGridView1.Columns["Çıkış Tarihi"].HeaderText = "Çıkış Tarihi";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme / arama sırasında hata oluştu: " + ex.Message);
            }
        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            CikislariListele(textAra.Text);
        }

        private void buttonAraTemizle_Click(object sender, EventArgs e)
        {
            textAra.Clear();
            CikislariListele();
        }

        private void textAra_TextChanged(object sender, EventArgs e)
        {
            CikislariListele(textAra.Text);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}