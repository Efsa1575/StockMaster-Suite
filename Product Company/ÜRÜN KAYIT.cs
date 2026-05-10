using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class URUN_KAYIT : Form
    {
        public URUN_KAYIT()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
           

            SqlCommand komut = new SqlCommand(@"
            INSERT INTO PRODUCT 
            (P_NAME, C_ID, STOCK_QUANTITY, ALIS_FIYATI, SATIS_FIYATI, UNIT_ID)
            VALUES 
            (@P_NAME, @C_ID, @STOCK_QUANTITY, @ALIS_FIYATI, @SATIS_FIYATI, @UNIT_ID)", conn);

            komut.Parameters.AddWithValue("@P_NAME", txtUrunKayıt.Text);
            komut.Parameters.AddWithValue("@C_ID", Convert.ToInt32(cbUrunKayıt.SelectedValue));
            komut.Parameters.AddWithValue("@STOCK_QUANTITY", Convert.ToInt32(txtUrunMiktari.Text));
            komut.Parameters.AddWithValue("@ALIS_FIYATI", Convert.ToDecimal(txtAlisFiyati.Text));
            komut.Parameters.AddWithValue("@SATIS_FIYATI", Convert.ToDecimal(txtSatisFiyati.Text));
            komut.Parameters.AddWithValue("@UNIT_ID", Convert.ToInt32(cbKayitBirim.SelectedValue));

                komut.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Kaydedildi!!");

                URUNLER frm = new URUNLER();
                frm.ShowDialog();
                this.Close();
            }



        

        private void ÜRÜN_KAYIT_Load(object sender, EventArgs e)
        {

            conn.Open();

            SqlCommand komut = new SqlCommand(@"SELECT C_ID, C_NAME FROM CATEGORY", conn);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

           
            cbUrunKayıt.DisplayMember = "C_NAME"; 
            cbUrunKayıt.ValueMember = "C_ID";    
            cbUrunKayıt.DataSource = dt;
            SqlCommand cmdBirim = new SqlCommand("SELECT UNIT_ID, UNIT_NAME FROM UNIT", conn);
            SqlDataAdapter daBirim = new SqlDataAdapter(cmdBirim);
            DataTable dtBirim = new DataTable();
            daBirim.Fill(dtBirim);
            cbKayitBirim.DisplayMember = "UNIT_NAME";
            cbKayitBirim.ValueMember = "UNIT_ID";
            cbKayitBirim.DataSource = dtBirim;

            conn.Close();
        }

        private void cbUrunKayıt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAlisFiyati_TextChanged(object sender, EventArgs e)
        {
           
               
                if (decimal.TryParse(txtAlisFiyati.Text, out decimal alis))
                {
                   
                    decimal satis = alis * 1.7m;

                    
                    txtSatisFiyati.Text = satis.ToString();
                }
               
            }

        }
    }
    


