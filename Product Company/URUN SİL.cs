using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class URUN_SİL : Form
    {
        public URUN_SİL()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");
        int urunID = -1;

        private void URUN_SİL_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            UrunleriListele();
        }

        private void UrunleriListele(string aramaMetni = "")
        {
            try
            {
                SqlCommand komut = new SqlCommand(@"
                    SELECT 
                        P.P_ID,
                        P.P_NAME,
                        C.C_NAME,
                        P.STOCK_QUANTITY,
                        U.UNIT_NAME,
                        P.ALIS_FIYATI,
                        P.SATIS_FIYATI
                    FROM PRODUCT P
                    INNER JOIN CATEGORY C ON P.C_ID = C.C_ID
                    INNER JOIN UNIT U ON P.UNIT_ID = U.UNIT_ID
                    WHERE
                        @arama = ''
                        OR P.P_NAME LIKE '%' + @arama + '%'
                        OR C.C_NAME LIKE '%' + @arama + '%'
                        OR U.UNIT_NAME LIKE '%' + @arama + '%'
                        OR CAST(P.STOCK_QUANTITY AS NVARCHAR) LIKE '%' + @arama + '%'
                        OR CAST(P.ALIS_FIYATI AS NVARCHAR) LIKE '%' + @arama + '%'
                        OR CAST(P.SATIS_FIYATI AS NVARCHAR) LIKE '%' + @arama + '%'
                    ORDER BY P.P_NAME", conn);

                komut.Parameters.AddWithValue("@arama", aramaMetni.Trim());

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["P_ID"].HeaderText = "ID";
                    dataGridView1.Columns["P_NAME"].HeaderText = "Ürün Adı";
                    dataGridView1.Columns["C_NAME"].HeaderText = "Kategori";
                    dataGridView1.Columns["STOCK_QUANTITY"].HeaderText = "Stok Miktarı";
                    dataGridView1.Columns["UNIT_NAME"].HeaderText = "Birim";
                    dataGridView1.Columns["ALIS_FIYATI"].HeaderText = "Alış Fiyatı";
                    dataGridView1.Columns["SATIS_FIYATI"].HeaderText = "Satış Fiyatı";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler listelenirken hata oluştu: " + ex.Message);
            }
        }

        private void Temizle()
        {
            urunID = -1;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (urunID == -1)
                {
                    MessageBox.Show("Lütfen silinecek ürünü seçin.");
                    return;
                }

                DialogResult cevap = MessageBox.Show(
                    "Seçilen ürünü silmek istediğinize emin misiniz?",
                    "Silme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (cevap != DialogResult.Yes)
                    return;

                SqlCommand komut = new SqlCommand("DELETE FROM PRODUCT WHERE P_ID = @ID", conn);
                komut.Parameters.AddWithValue("@ID", urunID);

                conn.Open();
                int silinen = komut.ExecuteNonQuery();
                conn.Close();

                if (silinen > 0)
                {
                    MessageBox.Show("Ürün başarıyla silindi!");
                    Temizle();
                    UrunleriListele(textAra.Text);
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarısız. Ürün bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                urunID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["P_ID"].Value);
            }
        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            UrunleriListele(textAra.Text);
        }

        private void buttonAraTemizle_Click(object sender, EventArgs e)
        {
            textAra.Clear();
            UrunleriListele();
        }

        private void textAra_TextChanged(object sender, EventArgs e)
        {
            UrunleriListele(textAra.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}