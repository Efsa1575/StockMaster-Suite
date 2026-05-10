using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class URUN_GİRİS : Form
    {
        public URUN_GİRİS()
        {
            InitializeComponent();
        }

        SqlConnection bağla = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");
        bool tutarHesaplandiMi = false;

        private void URUN_GİRİS_Load(object sender, EventArgs e)
        {
            DepolariGetir();
            BirimleriGetir();

            cbGirisKategori.Enabled = false;
            cbGirisBirim.Enabled = false;

            cbGirisDepo.SelectedIndexChanged += cbGirisDepo_SelectedIndexChanged;
            cbGirisUrunAdi.SelectedIndexChanged += cbGirisUrunAdi_SelectedIndexChanged;
            txtGirisMiktar.TextChanged += txtGirisMiktar_TextChanged;
            txtGirisFiyat.TextChanged += txtGirisFiyat_TextChanged;
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

                cbGirisDepo.DataSource = dtDepo;
                cbGirisDepo.DisplayMember = "DEPO_ADI";
                cbGirisDepo.ValueMember = "DEPO_ID";
                cbGirisDepo.SelectedIndex = -1;
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

                cbGirisBirim.DataSource = dtBirim;
                cbGirisBirim.DisplayMember = "UNIT_NAME";
                cbGirisBirim.ValueMember = "UNIT_ID";
                cbGirisBirim.SelectedIndex = -1;
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
                if (cbGirisDepo.SelectedValue == null || cbGirisDepo.SelectedValue is DataRowView)
                    return;

                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT C.C_ID, C.C_NAME
                    FROM CATEGORY C
                    INNER JOIN DEPO_KATEGORI DK ON C.C_ID = DK.C_ID
                    WHERE DK.DEPO_ID = @DEPO_ID", bağla);

                cmd.Parameters.AddWithValue("@DEPO_ID", Convert.ToInt32(cbGirisDepo.SelectedValue));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbGirisKategori.DataSource = dt;
                cbGirisKategori.DisplayMember = "C_NAME";
                cbGirisKategori.ValueMember = "C_ID";
                cbGirisKategori.SelectedIndex = -1;
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
                if (cbGirisDepo.SelectedValue == null || cbGirisDepo.SelectedValue is DataRowView)
                    return;

                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT DISTINCT P.P_ID, P.P_NAME
                    FROM PRODUCT P
                    INNER JOIN DEPO_KATEGORI DK ON P.C_ID = DK.C_ID
                    WHERE DK.DEPO_ID = @DEPO_ID", bağla);

                cmd.Parameters.AddWithValue("@DEPO_ID", Convert.ToInt32(cbGirisDepo.SelectedValue));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbGirisUrunAdi.DataSource = dt;
                cbGirisUrunAdi.DisplayMember = "P_NAME";
                cbGirisUrunAdi.ValueMember = "P_ID";
                cbGirisUrunAdi.SelectedIndex = -1;
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

        private void cbGirisDepo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGirisDepo.SelectedValue == null || cbGirisDepo.SelectedValue is DataRowView)
                return;

            KategorileriGetirDepoyaGore();
            UrunleriGetirDepoyaGore();

            cbGirisKategori.SelectedIndex = -1;
            cbGirisBirim.SelectedIndex = -1;
            cbGirisUrunAdi.SelectedIndex = -1;
            txtGirisFiyat.Clear();
            txtGirisMiktar.Clear();
            tbTutar.Clear();
            tutarHesaplandiMi = false;
        }

        private void cbGirisUrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGirisUrunAdi.SelectedValue == null || cbGirisUrunAdi.SelectedValue is DataRowView)
                return;

            int urunId;

            try
            {
                urunId = Convert.ToInt32(cbGirisUrunAdi.SelectedValue);
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
                    SELECT ALIS_FIYATI, UNIT_ID, C_ID
                    FROM PRODUCT
                    WHERE P_ID = @id", bağla);

                cmd.Parameters.AddWithValue("@id", urunId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    decimal alisFiyat = Convert.ToDecimal(reader["ALIS_FIYATI"]);
                    int unitId = Convert.ToInt32(reader["UNIT_ID"]);
                    int kategoriId = Convert.ToInt32(reader["C_ID"]);

                    txtGirisFiyat.Text = alisFiyat.ToString("0.00");
                    cbGirisBirim.SelectedValue = unitId;
                    cbGirisKategori.SelectedValue = kategoriId;
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

        private void txtGirisMiktar_TextChanged(object sender, EventArgs e)
        {
            tbTutar.Clear();
            tutarHesaplandiMi = false;
        }

        private void txtGirisFiyat_TextChanged(object sender, EventArgs e)
        {
            tbTutar.Clear();
            tutarHesaplandiMi = false;
        }

        private bool UrunKategoriDogruMu()
        {
            try
            {
                if (cbGirisUrunAdi.SelectedValue == null || cbGirisKategori.SelectedValue == null)
                    return false;

                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand("SELECT C_ID FROM PRODUCT WHERE P_ID = @P_ID", bağla);
                cmd.Parameters.AddWithValue("@P_ID", Convert.ToInt32(cbGirisUrunAdi.SelectedValue));

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    int gercekKategoriID = Convert.ToInt32(result);
                    int secilenKategoriID = Convert.ToInt32(cbGirisKategori.SelectedValue);

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
                if (cbGirisUrunAdi.SelectedValue == null || cbGirisDepo.SelectedValue == null)
                    return false;

                if (bağla.State != ConnectionState.Open)
                    bağla.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*)
                    FROM PRODUCT P
                    INNER JOIN DEPO_KATEGORI DK ON P.C_ID = DK.C_ID
                    WHERE P.P_ID = @P_ID AND DK.DEPO_ID = @DEPO_ID", bağla);

                cmd.Parameters.AddWithValue("@P_ID", Convert.ToInt32(cbGirisUrunAdi.SelectedValue));
                cmd.Parameters.AddWithValue("@DEPO_ID", Convert.ToInt32(cbGirisDepo.SelectedValue));

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
            if (cbGirisDepo.SelectedValue == null ||
                cbGirisUrunAdi.SelectedValue == null ||
                cbGirisKategori.SelectedValue == null ||
                cbGirisBirim.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtGirisMiktar.Text) ||
                string.IsNullOrWhiteSpace(txtGirisFiyat.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (!tutarHesaplandiMi || string.IsNullOrWhiteSpace(tbTutar.Text))
            {
                MessageBox.Show("Lütfen önce hesap makinesi butonuna basarak tutarı hesaplayınız.");
                return;
            }

            int girilenMiktar;
            decimal alisFiyati;
            decimal toplamTutar;

            if (!int.TryParse(txtGirisMiktar.Text, out girilenMiktar) || girilenMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
                return;
            }

            if (!decimal.TryParse(txtGirisFiyat.Text, out alisFiyati) || alisFiyati < 0)
            {
                MessageBox.Show("Geçerli bir fiyat giriniz.");
                return;
            }

            if (!decimal.TryParse(tbTutar.Text, out toplamTutar) || toplamTutar <= 0)
            {
                MessageBox.Show("Tutar hesaplanamadı. Lütfen hesap makinesi butonuna basınız.");
                return;
            }

            if (Form1.GirisYapanKullaniciID == 0)
            {
                MessageBox.Show("Kullanıcı bilgisi alınamadı. Lütfen tekrar giriş yapın.");
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

                int secilenUrunID = Convert.ToInt32(cbGirisUrunAdi.SelectedValue);

                SqlCommand stokSorgu = new SqlCommand("SELECT STOCK_QUANTITY FROM PRODUCT WHERE P_ID = @P_ID", bağla);
                stokSorgu.Parameters.AddWithValue("@P_ID", secilenUrunID);

                object stokSonuc = stokSorgu.ExecuteScalar();
                int mevcutStok = stokSonuc != null && stokSonuc != DBNull.Value ? Convert.ToInt32(stokSonuc) : 0;
                int yeniMiktar = mevcutStok + girilenMiktar;

                SqlCommand stokGuncelle = new SqlCommand(@"
                    UPDATE PRODUCT
                    SET STOCK_QUANTITY = @STOCK_QUANTITY
                    WHERE P_ID = @P_ID", bağla);

                stokGuncelle.Parameters.AddWithValue("@STOCK_QUANTITY", yeniMiktar);
                stokGuncelle.Parameters.AddWithValue("@P_ID", secilenUrunID);
                stokGuncelle.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO PRODUCT_LOGIN
                    (PRODUCT_NAME, CATEGORY_NAME, QUANTITY, ALIS_FIYATI, TOPLAM_MALIYET, USER_ID, DEPO_ID, GIRIS_TARIHI)
                    VALUES
                    (@PRODUCT_NAME, @CATEGORY_NAME, @QUANTITY, @ALIS_FIYATI, @TOPLAM_MALIYET, @USER_ID, @DEPO_ID, GETDATE())", bağla);

                cmd.Parameters.AddWithValue("@PRODUCT_NAME", cbGirisUrunAdi.Text);
                cmd.Parameters.AddWithValue("@CATEGORY_NAME", cbGirisKategori.Text);
                cmd.Parameters.AddWithValue("@QUANTITY", girilenMiktar);
                cmd.Parameters.AddWithValue("@ALIS_FIYATI", alisFiyati);
                cmd.Parameters.AddWithValue("@TOPLAM_MALIYET", toplamTutar);
                cmd.Parameters.AddWithValue("@USER_ID", Form1.GirisYapanKullaniciID);
                cmd.Parameters.AddWithValue("@DEPO_ID", Convert.ToInt32(cbGirisDepo.SelectedValue));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Ürün girişi başarıyla kaydedildi!");

                cbGirisUrunAdi.SelectedIndex = -1;
                cbGirisKategori.SelectedIndex = -1;
                cbGirisBirim.SelectedIndex = -1;
                txtGirisMiktar.Clear();
                txtGirisFiyat.Clear();
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

            if (!decimal.TryParse(txtGirisMiktar.Text, out nMiktar) || nMiktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
                return;
            }

            if (!decimal.TryParse(txtGirisFiyat.Text, out nFiyat) || nFiyat < 0)
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