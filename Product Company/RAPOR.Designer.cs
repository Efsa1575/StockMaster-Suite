namespace PRODUCT_COMPANY
{
    partial class RAPOR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RAPOR));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checUrunBazli = new System.Windows.Forms.CheckBox();
            this.checkDepoBazli = new System.Windows.Forms.CheckBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnListele = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnRaporlaUrun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRaporlaDepo = new System.Windows.Forms.Button();
            this.FastReport = new FastReport.Report();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(24, 249);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1021, 376);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete_1);
            // 
            // checUrunBazli
            // 
            this.checUrunBazli.AutoSize = true;
            this.checUrunBazli.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checUrunBazli.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checUrunBazli.Location = new System.Drawing.Point(170, 93);
            this.checUrunBazli.Name = "checUrunBazli";
            this.checUrunBazli.Size = new System.Drawing.Size(213, 28);
            this.checUrunBazli.TabIndex = 4;
            this.checUrunBazli.Text = "Ürün Bazlı Raporlama";
            this.checUrunBazli.UseVisualStyleBackColor = false;
            this.checUrunBazli.CheckedChanged += new System.EventHandler(this.checUrunBazli_CheckedChanged);
            // 
            // checkDepoBazli
            // 
            this.checkDepoBazli.AutoSize = true;
            this.checkDepoBazli.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkDepoBazli.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkDepoBazli.Location = new System.Drawing.Point(170, 160);
            this.checkDepoBazli.Name = "checkDepoBazli";
            this.checkDepoBazli.Size = new System.Drawing.Size(218, 28);
            this.checkDepoBazli.TabIndex = 4;
            this.checkDepoBazli.Text = "Depo Bazlı Raporlama";
            this.checkDepoBazli.UseVisualStyleBackColor = false;
            this.checkDepoBazli.CheckedChanged += new System.EventHandler(this.checkDepoBazli_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(438, 30);
            this.monthCalendar1.MaxSelectionCount = 366;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 6;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // btnListele
            // 
            this.btnListele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListele.Location = new System.Drawing.Point(764, 80);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(104, 41);
            this.btnListele.TabIndex = 7;
            this.btnListele.Text = "Lİstele";
            this.btnListele.UseVisualStyleBackColor = false;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(484, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 26);
            this.comboBox1.TabIndex = 8;
            // 
            // btnRaporlaUrun
            // 
            this.btnRaporlaUrun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRaporlaUrun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporlaUrun.Location = new System.Drawing.Point(764, 154);
            this.btnRaporlaUrun.Name = "btnRaporlaUrun";
            this.btnRaporlaUrun.Size = new System.Drawing.Size(104, 41);
            this.btnRaporlaUrun.TabIndex = 9;
            this.btnRaporlaUrun.Text = "Rapor";
            this.btnRaporlaUrun.UseVisualStyleBackColor = false;
            this.btnRaporlaUrun.Click += new System.EventHandler(this.btnRaporlaUrun_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(501, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 68);
            this.label1.TabIndex = 10;
            this.label1.Text = "Lütfen görüntülemek istediğiniz depoyu seçin:";
            // 
            // btnRaporlaDepo
            // 
            this.btnRaporlaDepo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRaporlaDepo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporlaDepo.Location = new System.Drawing.Point(764, 154);
            this.btnRaporlaDepo.Name = "btnRaporlaDepo";
            this.btnRaporlaDepo.Size = new System.Drawing.Size(104, 41);
            this.btnRaporlaDepo.TabIndex = 9;
            this.btnRaporlaDepo.Text = "Rapor";
            this.btnRaporlaDepo.UseVisualStyleBackColor = false;
            this.btnRaporlaDepo.Click += new System.EventHandler(this.btnRaporlaDepo_Click);
            // 
            // FastReport
            // 
            this.FastReport.NeedRefresh = false;
            this.FastReport.ReportResourceString = resources.GetString("FastReport.ReportResourceString");
            this.FastReport.Tag = null;
            // 
            // RAPOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1076, 637);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRaporlaDepo);
            this.Controls.Add(this.btnRaporlaUrun);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.checkDepoBazli);
            this.Controls.Add(this.checUrunBazli);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "RAPOR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAPOR";
            this.Load += new System.EventHandler(this.RAPOR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checUrunBazli;
        private System.Windows.Forms.CheckBox checkDepoBazli;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnRaporlaUrun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRaporlaDepo;
        private FastReport.Report FastReport;
    }
}