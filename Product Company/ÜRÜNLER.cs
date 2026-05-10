using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class URUNLER : Form
    {
        public URUNLER()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");

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

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme sırasında hata oluştu: " + ex.Message);
            }
        }

        private void ÜRÜNLER_Load(object sender, EventArgs e)
        {
            UrunleriListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            URUN_KAYIT frm = new URUN_KAYIT();
            frm.ShowDialog();
            UrunleriListele(textAra.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            URUN_GUNCELLE frm = new URUN_GUNCELLE();
            frm.ShowDialog();
            UrunleriListele(textAra.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            URUN_SİL frm = new URUN_SİL();
            frm.ShowDialog();
            UrunleriListele(textAra.Text);
        }

        private void textAra_TextChanged(object sender, EventArgs e)
        {
            UrunleriListele(textAra.Text);
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}