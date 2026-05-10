using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class DEPO : Form
    {
        public DEPO()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");

        private void DEPO_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                SqlCommand depoCmd = new SqlCommand("SELECT DEPO_ID, DEPO_ADI FROM DEPO", conn);
                SqlDataAdapter daDepo = new SqlDataAdapter(depoCmd);
                DataTable depoTable = new DataTable();
                daDepo.Fill(depoTable);

                cbDepoSec.DataSource = depoTable;
                cbDepoSec.DisplayMember = "DEPO_ADI";
                cbDepoSec.ValueMember = "DEPO_ID";

                conn.Close();

                labelKritik.Text = "Kritik Stok: -";
                labelKritik.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Depolar yüklenirken hata oluştu: " + ex.Message);

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void GridBasliklariAyarla()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["P_ID"].HeaderText = "ID";
                dataGridView1.Columns["P_NAME"].HeaderText = "Ürün Adı";
                dataGridView1.Columns["C_NAME"].HeaderText = "Kategori";
                dataGridView1.Columns["STOCK_QUANTITY"].HeaderText = "Stok Miktarı";
            }
        }

        private int KritikBoyaVeSay()
        {
            int kritikSayi = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["STOCK_QUANTITY"].Value != null &&
                    row.Cells["STOCK_QUANTITY"].Value != DBNull.Value)
                {
                    int stok = Convert.ToInt32(row.Cells["STOCK_QUANTITY"].Value);

                    if (stok <= 300)
                    {
                        kritikSayi++;
                        row.Cells["STOCK_QUANTITY"].Style.BackColor = Color.Red;
                        row.Cells["STOCK_QUANTITY"].Style.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.Cells["STOCK_QUANTITY"].Style.BackColor = Color.White;
                        row.Cells["STOCK_QUANTITY"].Style.ForeColor = Color.Black;
                    }
                }
            }

            labelKritik.Text = "Kritik Stok: " + kritikSayi;
            labelKritik.ForeColor = kritikSayi > 0 ? Color.Red : Color.Green;

            return kritikSayi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenDepoID = Convert.ToInt32(cbDepoSec.SelectedValue);

                SqlCommand komut = new SqlCommand(@"
                    SELECT 
                        P.P_ID,
                        P.P_NAME,
                        C.C_NAME,
                        P.STOCK_QUANTITY
                    FROM PRODUCT P
                    INNER JOIN CATEGORY C ON P.C_ID = C.C_ID
                    WHERE P.DEPO_ID = @DEPO_ID", conn);

                komut.Parameters.AddWithValue("@DEPO_ID", secilenDepoID);

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                GridBasliklariAyarla();

                labelKritik.Text = "Kritik Stok: -";
                labelKritik.ForeColor = Color.Black;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["STOCK_QUANTITY"].Value != null &&
                        row.Cells["STOCK_QUANTITY"].Value != DBNull.Value)
                    {
                        row.Cells["STOCK_QUANTITY"].Style.BackColor = Color.White;
                        row.Cells["STOCK_QUANTITY"].Style.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Depo görüntülenirken hata oluştu: " + ex.Message);
            }
        }

        private void buttonKritikGöster_Click(object sender, EventArgs e)
        {
            try
            {
                int secilenDepoID = Convert.ToInt32(cbDepoSec.SelectedValue);

                SqlCommand komut = new SqlCommand(@"
                    SELECT 
                        P.P_ID,
                        P.P_NAME,
                        C.C_NAME,
                        P.STOCK_QUANTITY
                    FROM PRODUCT P
                    INNER JOIN CATEGORY C ON P.C_ID = C.C_ID
                    WHERE P.DEPO_ID = @DEPO_ID
                      AND P.STOCK_QUANTITY <= 300", conn);

                komut.Parameters.AddWithValue("@DEPO_ID", secilenDepoID);

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                GridBasliklariAyarla();
                KritikBoyaVeSay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kritik ürünler gösterilirken hata oluştu: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelKritik_Click(object sender, EventArgs e)
        {

        }
    }
}