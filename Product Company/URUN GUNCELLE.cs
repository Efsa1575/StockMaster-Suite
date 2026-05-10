using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class URUN_GUNCELLE : Form
    {
        public URUN_GUNCELLE()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");

        private void ÜRÜN_GÜNCELLE_Load(object sender, EventArgs e)
        {
            ComboboxDoldur();
            UrunleriListele();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void ComboboxDoldur()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand com = new SqlCommand("SELECT C_ID, C_NAME FROM CATEGORY", conn);
                SqlDataAdapter adap = new SqlDataAdapter(com);
                DataTable table = new DataTable();
                adap.Fill(table);

                cbUrunGuncelle.DataSource = table;
                cbUrunGuncelle.DisplayMember = "C_NAME";
                cbUrunGuncelle.ValueMember = "C_ID";
                cbUrunGuncelle.SelectedIndex = -1;

                SqlCommand unitCmd = new SqlCommand("SELECT UNIT_ID, UNIT_NAME FROM UNIT", conn);
                SqlDataAdapter daUnit = new SqlDataAdapter(unitCmd);
                DataTable birimTable = new DataTable();
                daUnit.Fill(birimTable);

                cbKayitBirim.DataSource = birimTable;
                cbKayitBirim.DisplayMember = "UNIT_NAME";
                cbKayitBirim.ValueMember = "UNIT_ID";
                cbKayitBirim.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Combobox verileri yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void UrunleriListele(string aramaMetni = "")
        {
            try
            {
                string query = @"
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
                    ORDER BY P.P_NAME";

                SqlCommand komut = new SqlCommand(query, conn);
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

        private void AlanlariTemizle()
        {
            txtGuncelleID.Clear();
            txtGuncelleName.Clear();
            txtGuncelleMiktar.Clear();
            txtGuncelleAlisFiyat.Clear();
            txtGuncelleSatisFiyati.Clear();
            cbUrunGuncelle.SelectedIndex = -1;
            cbKayitBirim.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
                return;

            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

            if (rowIndex < 0 || rowIndex >= dataGridView1.Rows.Count)
                return;

            txtGuncelleID.Text = dataGridView1.Rows[rowIndex].Cells["P_ID"].Value?.ToString();
            txtGuncelleName.Text = dataGridView1.Rows[rowIndex].Cells["P_NAME"].Value?.ToString();
            string kategoriAdi = dataGridView1.Rows[rowIndex].Cells["C_NAME"].Value?.ToString();
            txtGuncelleMiktar.Text = dataGridView1.Rows[rowIndex].Cells["STOCK_QUANTITY"].Value?.ToString();
            string birim = dataGridView1.Rows[rowIndex].Cells["UNIT_NAME"].Value?.ToString();
            txtGuncelleAlisFiyat.Text = dataGridView1.Rows[rowIndex].Cells["ALIS_FIYATI"].Value?.ToString();
            txtGuncelleSatisFiyati.Text = dataGridView1.Rows[rowIndex].Cells["SATIS_FIYATI"].Value?.ToString();

            if (cbUrunGuncelle.DataSource is DataTable table)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["C_NAME"].ToString() == kategoriAdi)
                    {
                        cbUrunGuncelle.SelectedValue = row["C_ID"];
                        break;
                    }
                }
            }

            if (cbKayitBirim.DataSource is DataTable birimTable)
            {
                foreach (DataRow row in birimTable.Rows)
                {
                    if (row["UNIT_NAME"].ToString() == birim)
                    {
                        cbKayitBirim.SelectedValue = row["UNIT_ID"];
                        break;
                    }
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int kategoriID, birimID, stokMiktari, urunID;
                decimal alisFiyati, satisFiyati;

                if (!int.TryParse(txtGuncelleID.Text, out urunID))
                {
                    MessageBox.Show("Lütfen güncellenecek ürünü listeden seçin.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtGuncelleName.Text))
                {
                    MessageBox.Show("Ürün adı boş bırakılamaz.");
                    return;
                }

                if (!int.TryParse(cbUrunGuncelle.SelectedValue?.ToString(), out kategoriID))
                {
                    MessageBox.Show("Kategori seçiniz.");
                    return;
                }

                if (!int.TryParse(cbKayitBirim.SelectedValue?.ToString(), out birimID))
                {
                    MessageBox.Show("Birim seçiniz.");
                    return;
                }

                if (!int.TryParse(txtGuncelleMiktar.Text, out stokMiktari) || stokMiktari < 0)
                {
                    MessageBox.Show("Geçerli bir stok miktarı giriniz.");
                    return;
                }

                if (!decimal.TryParse(txtGuncelleAlisFiyat.Text, out alisFiyati) || alisFiyati < 0)
                {
                    MessageBox.Show("Geçerli bir alış fiyatı giriniz.");
                    return;
                }

                if (!decimal.TryParse(txtGuncelleSatisFiyati.Text, out satisFiyati) || satisFiyati < 0)
                {
                    MessageBox.Show("Geçerli bir satış fiyatı giriniz.");
                    return;
                }

                string query = @"
                    UPDATE PRODUCT
                    SET 
                        P_NAME = @NAME,
                        C_ID = @CID,
                        UNIT_ID = @UNITID,
                        STOCK_QUANTITY = @STOCK,
                        ALIS_FIYATI = @ALIS,
                        SATIS_FIYATI = @SATIS
                    WHERE P_ID = @ID";

                SqlCommand komut = new SqlCommand(query, conn);
                komut.Parameters.AddWithValue("@NAME", txtGuncelleName.Text.Trim());
                komut.Parameters.AddWithValue("@CID", kategoriID);
                komut.Parameters.AddWithValue("@UNITID", birimID);
                komut.Parameters.AddWithValue("@STOCK", stokMiktari);
                komut.Parameters.AddWithValue("@ALIS", alisFiyati);
                komut.Parameters.AddWithValue("@SATIS", satisFiyati);
                komut.Parameters.AddWithValue("@ID", urunID);

                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Güncelleme başarılı!");
                UrunleriListele(textAra.Text);
                AlanlariTemizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void txtGuncelleAlisFiyat_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtGuncelleAlisFiyat.Text, out decimal alis))
            {
                decimal satis = alis * 1.7m;
                txtGuncelleSatisFiyati.Text = satis.ToString("0.00");
            }
            else
            {
                txtGuncelleSatisFiyati.Text = "";
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

        private void cbUrunGuncelle_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtGuncelleID_TextChanged(object sender, EventArgs e)
        {
        }
    }
}