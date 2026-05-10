using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class URUN_CIKIS : Form
    {
        public URUN_CIKIS()
        {
            InitializeComponent();
        }

        SqlConnection bağla = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");
        bool tutarHesaplandiMi = false;

        private void URUN_CIKIS_Load(object sender, EventArgs e)
        {
            DepolariGetir();
            BirimleriGetir();

            cbCikisKategori.Enabled = false;
            cbCikisBirim.Enabled = false;

            cbCikisDepo.SelectedIndexChanged += cbCikisDepo_SelectedIndexChanged;
            cbCikisIsim.SelectedIndexChanged += cbCikisIsim_SelectedIndexChanged;
            txtCikisMiktar.TextChanged += txtCikisMiktar_TextChanged;
            txtCikisFiyat.TextChanged += txtCikisFiyat_TextChanged;
        }

        private void DepolariGetir()
        {
            try
            {
                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlDataAdapter daDepo = new SqlDataAdapter("SELECT DEPO_ID, DEPO_ADI FROM DEPO", bağla);
                DataTable dtDepo = new DataTable();
                daDepo.Fill(dtDepo);

                cbCikisDepo.DataSource = dtDepo;
                cbCikisDepo.DisplayMember = "DEPO_ADI";
                cbCikisDepo.ValueMember = "DEPO_ID";
                cbCikisDepo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Depolar yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağla.State != ConnectionState.Closed)
                    bağla.Close();
            }
        }

        private void BirimleriGetir()
        {
            try
            {
                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlDataAdapter daBirim = new SqlDataAdapter("SELECT UNIT_ID, UNIT_NAME FROM UNIT", bağla);
                DataTable dtBirim = new DataTable();
                daBirim.Fill(dtBirim);

                cbCikisBirim.DataSource = dtBirim;
                cbCikisBirim.DisplayMember = "UNIT_NAME";
                cbCikisBirim.ValueMember = "UNIT_ID";
                cbCikisBirim.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Birimler yüklenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağla.State != ConnectionState.Closed)
                    bağla.Close();
            }
        }

        private void KategorileriGetirDepoyaGore()
        {
            try
            {
                if (cbCikisDepo.SelectedValue == null || cbCikisDepo.SelectedValue is DataRowView)
                    return;

                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT C.C_ID, C.C_NAME
                    FROM CATEGORY C
                    INNER JOIN DEPO_KATEGORI DK ON C.C_ID = DK.C_ID
                    WHERE DK.DEPO_ID = @DEPO_ID", bağla);

                cmd.Parameters.AddWithValue("@DEPO_ID", Convert.ToInt32(cbCikisDepo.SelectedValue));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbCikisKategori.DataSource = dt;
                cbCikisKategori.DisplayMember = "C_NAME";
                cbCikisKategori.ValueMember = "C_ID";
                cbCikisKategori.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler getirilirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağla.State != ConnectionState.Closed)
                    bağla.Close();
            }
        }

        private void UrunleriGetirDepoyaGore()
        {
            try
            {
                if (cbCikisDepo.SelectedValue == null || cbCikisDepo.SelectedValue is DataRowView)
                    return;

                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT DISTINCT P.P_ID, P.P_NAME
                    FROM PRODUCT P
                    INNER JOIN DEPO_KATEGORI DK ON P.C_ID = DK.C_ID
                    WHERE DK.DEPO_ID = @DEPO_ID", bağla);

                cmd.Parameters.AddWithValue("@DEPO_ID", Convert.ToInt32(cbCikisDepo.SelectedValue));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbCikisIsim.DataSource = dt;
                cbCikisIsim.DisplayMember = "P_NAME";
                cbCikisIsim.ValueMember = "P_ID";
                cbCikisIsim.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler getirilirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağla.State != ConnectionState.Closed)
                    bağla.Close();
            }
        }

        private void cbCikisDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCikisDepo.SelectedValue == null || cbCikisDepo.SelectedValue is DataRowView)
                return;

            KategorileriGetirDepoyaGore();
            UrunleriGetirDepoyaGore();

            cbCikisKategori.SelectedIndex = -1;
            cbCikisBirim.SelectedIndex = -1;
            cbCikisIsim.SelectedIndex = -1;
            txtCikisFiyat.Clear();
            txtCikisMiktar.Clear();
            tbTutar.Clear();
            tutarHesaplandiMi = false;
        }

        private void cbCikisIsim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCikisIsim.SelectedValue == null || cbCikisIsim.SelectedValue is DataRowView)
                return;

            int urunId;

            try
            {
                urunId = Convert.ToInt32(cbCikisIsim.SelectedValue);
            }
            catch
            {
                return;
            }

            try
            {
                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT SATIS_FIYATI, UNIT_ID, C_ID
                    FROM PRODUCT
                    WHERE P_ID = @id", bağla);

                cmd.Parameters.AddWithValue("@id", urunId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    decimal satisFiyat = Convert.ToDecimal(reader["SATIS_FIYATI"]);
                    int unitId = Convert.ToInt32(reader["UNIT_ID"]);
                    int kategoriId = Convert.ToInt32(reader["C_ID"]);

                    txtCikisFiyat.Text = satisFiyat.ToString("0.00");
                    cbCikisBirim.SelectedValue = unitId;
                    cbCikisKategori.SelectedValue = kategoriId;
                }

                reader.Close();

                tbTutar.Clear();
                tutarHesaplandiMi = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün bilgileri getirilirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağla.State != ConnectionState.Closed)
                    bağla.Close();
            }
        }

        private void txtCikisMiktar_TextChanged(object sender, EventArgs e)
        {
            tbTutar.Clear();
            tutarHesaplandiMi = false;
        }

        private void txtCikisFiyat_TextChanged(object sender, EventArgs e)
        {
            tbTutar.Clear();
            tutarHesaplandiMi = false;
        }

        private bool UrunKategoriDogruMu()
        {
            try
            {
                if (cbCikisIsim.SelectedValue == null || cbCikisKategori.SelectedValue == null)
                    return false;

                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand("SELECT C_ID FROM PRODUCT WHERE P_ID = @P_ID", bağla);
                cmd.Parameters.AddWithValue("@P_ID", Convert.ToInt32(cbCikisIsim.SelectedValue));

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int gercekKategoriID = Convert.ToInt32(result);
                    int secilenKategoriID = Convert.ToInt32(cbCikisKategori.SelectedValue);

                    return gercekKategoriID == secilenKategoriID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori kontrolünde hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağla.State != ConnectionState.Closed)
                    bağla.Close();
            }

            return false;
        }

        private bool UrunBuDepoyaUygunMu()
        {
            try
            {
                if (cbCikisIsim.SelectedValue == null || cbCikisDepo.SelectedValue == null)
                    return false;

                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM PRODUCT P
                    INNER JOIN DEPO_KATEGORI DK ON P.C_ID = DK.C_ID
                    WHERE P.P_ID = @P_ID AND DK.DEPO_ID = @DEPO_ID", bağla);

                cmd.Parameters.AddWithValue("@P_ID", Convert.ToInt32(cbCikisIsim.SelectedValue));
                cmd.Parameters.AddWithValue("@DEPO_ID", Convert.ToInt32(cbCikisDepo.SelectedValue));

                int sonuc = Convert.ToInt32(cmd.ExecuteScalar());
                return sonuc > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Depo uygunluk kontrolünde hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağla.State != ConnectionState.Closed)
                    bağla.Close();
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbCikisDepo.SelectedValue == null ||
                cbCikisIsim.SelectedValue == null ||
                cbCikisKategori.SelectedValue == null ||
                cbCikisBirim.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtCikisMiktar.Text) ||
                string.IsNullOrWhiteSpace(txtCikisFiyat.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (!tutarHesaplandiMi || string.IsNullOrWhiteSpace(tbTutar.Text))
            {
                MessageBox.Show("Lütfen önce hesap makinesi butonuna basarak tutarı hesaplayınız.");
                return;
            }

            if (Form1.GirisYapanKullaniciID == 0)
            {
                MessageBox.Show("Kullanıcı bilgisi alınamadı. Lütfen tekrar giriş yapın.");
                return;
            }

            int girilenMiktar;
            decimal satisFiyati;
            decimal toplamTutar;

            if (!int.TryParse(txtCikisMiktar.Text, out girilenMiktar) || girilenMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!");
                return;
            }

            if (!decimal.TryParse(txtCikisFiyat.Text, out satisFiyati) || satisFiyati < 0)
            {
                MessageBox.Show("Geçerli bir fiyat giriniz!");
                return;
            }

            if (!decimal.TryParse(tbTutar.Text, out toplamTutar) || toplamTutar <= 0)
            {
                MessageBox.Show("Tutar hesaplanamadı. Lütfen hesap makinesi butonuna basınız.");
                return;
            }

            if (!UrunKategoriDogruMu())
            {
                MessageBox.Show("Kategori yanlış! Seçilen ürün ile kategori uyuşmuyor.");
                return;
            }

            if (!UrunBuDepoyaUygunMu())
            {
                MessageBox.Show("Bu ürün seçilen depoya uygun değil.");
                return;
            }

            try
            {
                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                int secilenUrunID = Convert.ToInt32(cbCikisIsim.SelectedValue);

                SqlCommand stokSorgu = new SqlCommand("SELECT STOCK_QUANTITY FROM PRODUCT WHERE P_ID = @P_ID", bağla);
                stokSorgu.Parameters.AddWithValue("@P_ID", secilenUrunID);

                object stokSonuc = stokSorgu.ExecuteScalar();
                int mevcutStok = stokSonuc != null && stokSonuc != DBNull.Value ? Convert.ToInt32(stokSonuc) : 0;

                if (girilenMiktar > mevcutStok)
                {
                    MessageBox.Show("Stokta yeterli miktar yok!");
                    return;
                }

                int yeniMiktar = mevcutStok - girilenMiktar;

                SqlCommand stokGuncelle = new SqlCommand(@"
                    UPDATE PRODUCT
                    SET STOCK_QUANTITY = @STOCK_QUANTITY
                    WHERE P_ID = @P_ID", bağla);

                stokGuncelle.Parameters.AddWithValue("@STOCK_QUANTITY", yeniMiktar);
                stokGuncelle.Parameters.AddWithValue("@P_ID", secilenUrunID);
                stokGuncelle.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO PRODUCT_OUT
                    (PRODUCT_NAME, CATEGORY_ID, CATEGORY_NAME, QUANTITY, TOPLAM_MALIYET, USER_ID, DEPO_ID, P_ID, SATIS_FIYATI)
                    VALUES
                    (@PRODUCT_NAME, @CATEGORY_ID, @CATEGORY_NAME, @QUANTITY, @TOPLAM_MALIYET, @USER_ID, @DEPO_ID, @P_ID, @SATIS_FIYATI)", bağla);

                cmd.Parameters.AddWithValue("@PRODUCT_NAME", cbCikisIsim.Text);
                cmd.Parameters.AddWithValue("@CATEGORY_ID", Convert.ToInt32(cbCikisKategori.SelectedValue));
                cmd.Parameters.AddWithValue("@CATEGORY_NAME", cbCikisKategori.Text);
                cmd.Parameters.AddWithValue("@QUANTITY", girilenMiktar);
                cmd.Parameters.AddWithValue("@TOPLAM_MALIYET", toplamTutar);
                cmd.Parameters.AddWithValue("@USER_ID", Form1.GirisYapanKullaniciID);
                cmd.Parameters.AddWithValue("@DEPO_ID", Convert.ToInt32(cbCikisDepo.SelectedValue));
                cmd.Parameters.AddWithValue("@P_ID", secilenUrunID);
                cmd.Parameters.AddWithValue("@SATIS_FIYATI", satisFiyati);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Ürün çıkışı başarıyla kaydedildi!");

                cbCikisIsim.SelectedIndex = -1;
                cbCikisKategori.SelectedIndex = -1;
                cbCikisBirim.SelectedIndex = -1;
                txtCikisMiktar.Clear();
                txtCikisFiyat.Clear();
                tbTutar.Clear();
                tutarHesaplandiMi = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message);
            }
            finally
            {
                if (bağla.State != ConnectionState.Closed)
                    bağla.Close();
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            decimal nMiktar, nFiyat;

            if (!decimal.TryParse(txtCikisMiktar.Text, out nMiktar) || nMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
                return;
            }

            if (!decimal.TryParse(txtCikisFiyat.Text, out nFiyat) || nFiyat < 0)
            {
                MessageBox.Show("Geçerli bir fiyat giriniz.");
                return;
            }

            decimal nTutar = nMiktar * nFiyat;
            tbTutar.Text = nTutar.ToString("0.00");
            tutarHesaplandiMi = true;
        }
    }
}