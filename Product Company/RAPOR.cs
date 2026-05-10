using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FastReport;

namespace PRODUCT_COMPANY
{
    public partial class RAPOR : Form
    {
        public RAPOR()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-F8K0SN2F\\SQLEXPRESS01;Initial Catalog=COMPANY;Integrated Security=True");
        private DateTime? _rangeStart = null;

        private void DepolariDoldur()
        {
            using (var da = new SqlDataAdapter("SELECT DEPO_ID, DEPO_ADI FROM DEPO ORDER BY DEPO_ADI", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "DEPO_ADI";
                comboBox1.ValueMember = "DEPO_ID";
                comboBox1.DataSource = dt;
                comboBox1.SelectedIndex = -1;
            }
        }

        private void RAPOR_Load(object sender, EventArgs e)
        {
            checUrunBazli.Checked = false;
            checkDepoBazli.Checked = false;

            monthCalendar1.Visible = false;
            comboBox1.Visible = false;
            comboBox1.Enabled = false;

            monthCalendar1.MaxSelectionCount = 366;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            label1.Visible = false;

            btnRaporlaUrun.Visible = false;
            btnRaporlaDepo.Visible = false;
        }

        private void checUrunBazli_CheckedChanged(object sender, EventArgs e)
        {
            if (checUrunBazli.Checked)
            {
                checkDepoBazli.Checked = false;

                monthCalendar1.Visible = true;
                comboBox1.Visible = false;
                comboBox1.Enabled = false;
                label1.Visible = false;

                btnRaporlaUrun.Visible = true;
                btnRaporlaDepo.Visible = false;
            }
            else
            {
                monthCalendar1.Visible = false;
                btnRaporlaUrun.Visible = false;
            }
        }

        private void checkDepoBazli_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDepoBazli.Checked)
            {
                checUrunBazli.Checked = false;

                monthCalendar1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Enabled = true;
                label1.Visible = true;

                btnRaporlaUrun.Visible = false;
                btnRaporlaDepo.Visible = true;

                DepolariDoldur();
            }
            else
            {
                comboBox1.Visible = false;
                comboBox1.Enabled = false;
                comboBox1.DataSource = null;
                btnRaporlaDepo.Visible = false;
            }
        }

        private void FormatGridForDetail()
        {
            string[] numCols = { "Alış Fiyatı", "Satış Fiyatı", "Alış Miktarı", "Satış Miktarı", "Toplam Maliyet", "Stok Miktarı" };

            foreach (var c in numCols)
            {
                if (dataGridView1.Columns.Contains(c))
                {
                    dataGridView1.Columns[c].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns[c].DefaultCellStyle.Format = "N2";
                }
            }

            if (dataGridView1.Columns.Contains("Giriş Tarihi"))
            {
                dataGridView1.Columns["Giriş Tarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dataGridView1.Columns["Giriş Tarihi"].DefaultCellStyle.NullValue = "-";
            }

            if (dataGridView1.Columns.Contains("Çıkış Tarihi"))
            {
                dataGridView1.Columns["Çıkış Tarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                dataGridView1.Columns["Çıkış Tarihi"].DefaultCellStyle.NullValue = "-";
            }
        }

        private void TrySetDisplayIndex(string colName, int index)
        {
            if (dataGridView1.Columns.Contains(colName))
                dataGridView1.Columns[colName].DisplayIndex = index;
        }

        private void Listele_UrunBazli()
        {
            DateTime start = monthCalendar1.SelectionStart.Date;
            DateTime end = monthCalendar1.SelectionEnd.Date.AddDays(1).AddTicks(-1);

            string sql = @"
;WITH Hareket AS (
    SELECT 
        la.GIRIS_TARIHI AS [Giriş Tarihi],
        CAST(NULL AS datetime) AS [Çıkış Tarihi],
        COALESCE(p.P_NAME, la.PRODUCT_NAME) AS [Ürün Adı],
        d.DEPO_ADI AS [Depo],
        la.ALIS_FIYATI AS [Alış Fiyatı],
        CAST(NULL AS decimal(18,2)) AS [Satış Fiyatı],
        CAST(ISNULL(la.QUANTITY,0) AS decimal(18,2)) AS [Alış Miktarı],
        CAST(NULL AS decimal(18,2)) AS [Satış Miktarı],
        CAST(ISNULL(la.QUANTITY,0) * ISNULL(la.ALIS_FIYATI,0) AS decimal(18,2)) AS [Toplam Maliyet],
        CAST(1 AS bit) AS [Alış],
        CAST(0 AS bit) AS [Satış]
    FROM dbo.PRODUCT_LOGIN la
    LEFT JOIN dbo.PRODUCT p ON p.P_ID = la.P_ID
    LEFT JOIN dbo.DEPO d ON d.DEPO_ID = la.DEPO_ID
    WHERE la.GIRIS_TARIHI BETWEEN @start AND @end

    UNION ALL

    SELECT 
        CAST(NULL AS datetime) AS [Giriş Tarihi],
        po.CIKIS_TARIHI AS [Çıkış Tarihi],
        COALESCE(p.P_NAME, po.PRODUCT_NAME) AS [Ürün Adı],
        d.DEPO_ADI AS [Depo],
        CAST(NULL AS decimal(18,2)) AS [Alış Fiyatı],
        po.SATIS_FIYATI AS [Satış Fiyatı],
        CAST(NULL AS decimal(18,2)) AS [Alış Miktarı],
        CAST(ISNULL(po.QUANTITY,0) AS decimal(18,2)) AS [Satış Miktarı],
        CAST(ISNULL(po.QUANTITY,0) * ISNULL(po.SATIS_FIYATI,0) AS decimal(18,2)) AS [Toplam Maliyet],
        CAST(0 AS bit) AS [Alış],
        CAST(1 AS bit) AS [Satış]
    FROM dbo.PRODUCT_OUT po
    LEFT JOIN dbo.PRODUCT p ON p.P_ID = po.P_ID
    LEFT JOIN dbo.DEPO d ON d.DEPO_ID = po.DEPO_ID
    WHERE po.CIKIS_TARIHI BETWEEN @start AND @end
)
SELECT *
FROM Hareket
ORDER BY COALESCE([Giriş Tarihi],[Çıkış Tarihi]) DESC, [Ürün Adı]";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = start;
                cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = end;

                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                dataGridView1.DataSource = dt;
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            FormatGridForDetail();
        }

        private void Listele_DepoBazli()
        {
            const string sql = @"
SELECT 
    p.P_NAME AS [Ürün Adı],
    CAST(ISNULL(p.STOCK_QUANTITY,0) AS decimal(18,2)) AS [Stok Miktarı]
FROM dbo.PRODUCT p
WHERE p.DEPO_ID = @depo
ORDER BY p.P_NAME;";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@depo", SqlDbType.Int).Value = Convert.ToInt32(comboBox1.SelectedValue);

                var dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dt;
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridView1.Columns.Contains("Stok Miktarı"))
            {
                var col = dataGridView1.Columns["Stok Miktarı"];
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.DefaultCellStyle.Format = "N2";
            }

            foreach (var name in new[] {
                "Alış","Satış","Giriş Tarihi","Çıkış Tarihi",
                "Alış Fiyatı","Satış Fiyatı","Alış Miktarı","Satış Miktarı",
                "Toplam Maliyet","Kategori","ID","Depoya Giriş Tarihi",
                "Giriş Miktarı","Çıkış Miktarı","Mevcut Stok"
            })
            {
                if (dataGridView1.Columns.Contains(name))
                    dataGridView1.Columns[name].Visible = false;
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            if (checUrunBazli.Checked)
            {
                Listele_UrunBazli();
                return;
            }

            if (checkDepoBazli.Checked)
            {
                if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("Lütfen bir depo seçin.");
                    return;
                }

                Listele_DepoBazli();
                return;
            }

            MessageBox.Show("Lütfen Ürün Bazlı veya Depo Bazlı seçim yapın.");
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 400;

            if (_rangeStart == null)
            {
                _rangeStart = e.Start.Date;
                monthCalendar1.SelectionRange = new SelectionRange(_rangeStart.Value, _rangeStart.Value);
            }
            else
            {
                DateTime start = _rangeStart.Value <= e.Start ? _rangeStart.Value : e.Start.Date;
                DateTime end = _rangeStart.Value <= e.Start ? e.End.Date : _rangeStart.Value;

                int days = (end - start).Days + 1;
                if (days > monthCalendar1.MaxSelectionCount)
                    end = start.AddDays(monthCalendar1.MaxSelectionCount - 1);

                monthCalendar1.SelectionRange = new SelectionRange(start, end);
                _rangeStart = null;
            }
        }

        private bool ToBool(object v)
        {
            if (v == null || v == DBNull.Value) return false;
            if (v is bool b) return b;
            if (v is int i) return i != 0;
            if (v is byte by) return by != 0;
            return v.ToString() == "1" || v.ToString().Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        private void dataGridView1_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.Columns.Contains("Depoya Giriş Tarihi")) return;

            var colAlis = dataGridView1.Columns["Alış"];
            var colSatis = dataGridView1.Columns["Satış"];
            int idxAlis = colAlis != null ? colAlis.Index : -1;
            int idxSatis = colSatis != null ? colSatis.Index : -1;
            if (idxAlis == -1 && idxSatis == -1) return;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool alis = idxAlis >= 0 && ToBool(row.Cells[idxAlis].Value);
                bool satis = idxSatis >= 0 && ToBool(row.Cells[idxSatis].Value);

                if (alis && idxAlis >= 0)
                {
                    var cell = row.Cells[idxAlis];
                    cell.Style.BackColor = Color.LightGreen;
                    cell.Style.SelectionBackColor = Color.LightGreen;
                    cell.Style.ForeColor = Color.Black;
                }

                if (satis && idxSatis >= 0)
                {
                    var cell = row.Cells[idxSatis];
                    cell.Style.BackColor = Color.LightGreen;
                    cell.Style.SelectionBackColor = Color.LightGreen;
                    cell.Style.ForeColor = Color.Black;
                }
            }
        }

        private void UrunBazliFastReport()
        {
            var src = dataGridView1.DataSource as DataTable;
            if (src == null || src.Rows.Count == 0)
                return;

            var dt = src.Copy();

            void R(string oldName, string newName)
            {
                if (dt.Columns.Contains(oldName))
                    dt.Columns[oldName].ColumnName = newName;
            }

            R("Giriş Tarihi", "GirisTarihi");
            R("Çıkış Tarihi", "CikisTarihi");
            R("Ürün Adı", "UrunAdi");
            R("Depo", "Depo");
            R("Alış Fiyatı", "AlisFiyati");
            R("Satış Fiyatı", "SatisFiyati");
            R("Alış Miktarı", "AlisMiktari");
            R("Satış Miktarı", "SatisMiktari");
            R("Toplam Maliyet", "ToplamMaliyet");
            R("Alış", "Alis");
            R("Satış", "Satis");

            string frxPath = Path.Combine(Application.StartupPath, "Reports", "UrunBazli.frx");
            if (!File.Exists(frxPath))
            {
                MessageBox.Show("FRX bulunamadı:\n" + frxPath);
                return;
            }

            using (var report = new Report())
            {
                report.Load(frxPath);
                dt.TableName = "RAPOR";
                report.RegisterData(dt, "RAPOR");
                report.GetDataSource("RAPOR").Enabled = true;
                report.Design();
            }
        }

        private void DepoBazliFastReport()
        {
            var src = dataGridView1.DataSource as DataTable;
            if (src == null || src.Rows.Count == 0)
                return;

            var dt = src.Copy();

            void R(string oldName, string newName)
            {
                if (dt.Columns.Contains(oldName))
                    dt.Columns[oldName].ColumnName = newName;
            }

            R("Ürün Adı", "UrunAdi");
            R("Stok Miktarı", "StokMiktari");

            string frxPath = Path.Combine(Application.StartupPath, "Reports", "DepoBazli.frx");
            if (!File.Exists(frxPath))
            {
                MessageBox.Show("FRX bulunamadı:\n" + frxPath);
                return;
            }

            using (var report = new Report())
            {
                report.Load(frxPath);
                dt.TableName = "RAPOR";
                report.RegisterData(dt, "RAPOR");
                report.GetDataSource("RAPOR").Enabled = true;
                report.Design();
            }
        }

        private void btnRaporlaDepo_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen bir depo seçin.");
                return;
            }

            Listele_DepoBazli();
            DepoBazliFastReport();
        }

        private void btnRaporlaUrun_Click(object sender, EventArgs e)
        {
            Listele_UrunBazli();
            UrunBazliFastReport();
        }
    }
}