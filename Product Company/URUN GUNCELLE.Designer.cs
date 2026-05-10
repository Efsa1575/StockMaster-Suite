namespace PRODUCT_COMPANY
{
    partial class URUN_GUNCELLE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(URUN_GUNCELLE));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtGuncelleAlisFiyat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGuncelleMiktar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUrunGuncelle = new System.Windows.Forms.ComboBox();
            this.txtGuncelleName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGuncelleSatisFiyati = new System.Windows.Forms.TextBox();
            this.cbKayitBirim = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonAraTemizle = new System.Windows.Forms.Button();
            this.buttonAra = new System.Windows.Forms.Button();
            this.textAra = new System.Windows.Forms.TextBox();
            this.txtGuncelleID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 256);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(892, 203);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtGuncelleAlisFiyat
            // 
            this.txtGuncelleAlisFiyat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGuncelleAlisFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleAlisFiyat.Location = new System.Drawing.Point(638, 112);
            this.txtGuncelleAlisFiyat.Name = "txtGuncelleAlisFiyat";
            this.txtGuncelleAlisFiyat.Size = new System.Drawing.Size(202, 28);
            this.txtGuncelleAlisFiyat.TabIndex = 1;
            this.txtGuncelleAlisFiyat.TextChanged += new System.EventHandler(this.txtGuncelleAlisFiyat_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(529, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alış Fiyatı:";
            // 
            // txtGuncelleMiktar
            // 
            this.txtGuncelleMiktar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGuncelleMiktar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleMiktar.Location = new System.Drawing.Point(638, 54);
            this.txtGuncelleMiktar.Name = "txtGuncelleMiktar";
            this.txtGuncelleMiktar.Size = new System.Drawing.Size(202, 28);
            this.txtGuncelleMiktar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(513, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stok Miktarı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(144, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kategori:";
            // 
            // cbUrunGuncelle
            // 
            this.cbUrunGuncelle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbUrunGuncelle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUrunGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbUrunGuncelle.FormattingEnabled = true;
            this.cbUrunGuncelle.Location = new System.Drawing.Point(234, 113);
            this.cbUrunGuncelle.Name = "cbUrunGuncelle";
            this.cbUrunGuncelle.Size = new System.Drawing.Size(202, 30);
            this.cbUrunGuncelle.TabIndex = 3;
            this.cbUrunGuncelle.SelectedIndexChanged += new System.EventHandler(this.cbUrunGuncelle_SelectedIndexChanged);
            // 
            // txtGuncelleName
            // 
            this.txtGuncelleName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGuncelleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleName.Location = new System.Drawing.Point(234, 58);
            this.txtGuncelleName.Name = "txtGuncelleName";
            this.txtGuncelleName.Size = new System.Drawing.Size(202, 28);
            this.txtGuncelleName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(139, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ürün Adı:";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnGuncelle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.BackgroundImage")));
            this.btnGuncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(446, 199);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(64, 38);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(520, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Satış Fiyatı:";
            // 
            // txtGuncelleSatisFiyati
            // 
            this.txtGuncelleSatisFiyati.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGuncelleSatisFiyati.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleSatisFiyati.Location = new System.Drawing.Point(638, 156);
            this.txtGuncelleSatisFiyati.Name = "txtGuncelleSatisFiyati";
            this.txtGuncelleSatisFiyati.ReadOnly = true;
            this.txtGuncelleSatisFiyati.Size = new System.Drawing.Size(202, 28);
            this.txtGuncelleSatisFiyati.TabIndex = 6;
            // 
            // cbKayitBirim
            // 
            this.cbKayitBirim.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbKayitBirim.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbKayitBirim.FormattingEnabled = true;
            this.cbKayitBirim.Location = new System.Drawing.Point(234, 159);
            this.cbKayitBirim.Name = "cbKayitBirim";
            this.cbKayitBirim.Size = new System.Drawing.Size(202, 30);
            this.cbKayitBirim.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(99, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ürünün Birimi:";
            // 
            // buttonAraTemizle
            // 
            this.buttonAraTemizle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAraTemizle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAraTemizle.BackgroundImage")));
            this.buttonAraTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAraTemizle.Location = new System.Drawing.Point(258, 215);
            this.buttonAraTemizle.Name = "buttonAraTemizle";
            this.buttonAraTemizle.Size = new System.Drawing.Size(48, 26);
            this.buttonAraTemizle.TabIndex = 19;
            this.buttonAraTemizle.UseVisualStyleBackColor = false;
            this.buttonAraTemizle.Click += new System.EventHandler(this.buttonAraTemizle_Click);
            // 
            // buttonAra
            // 
            this.buttonAra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAra.BackgroundImage")));
            this.buttonAra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAra.Location = new System.Drawing.Point(207, 214);
            this.buttonAra.Name = "buttonAra";
            this.buttonAra.Size = new System.Drawing.Size(45, 27);
            this.buttonAra.TabIndex = 18;
            this.buttonAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAra.UseVisualStyleBackColor = false;
            this.buttonAra.Click += new System.EventHandler(this.buttonAra_Click);
            // 
            // textAra
            // 
            this.textAra.BackColor = System.Drawing.Color.FloralWhite;
            this.textAra.Location = new System.Drawing.Point(35, 215);
            this.textAra.Name = "textAra";
            this.textAra.Size = new System.Drawing.Size(166, 22);
            this.textAra.TabIndex = 17;
            this.textAra.TextChanged += new System.EventHandler(this.textAra_TextChanged);
            // 
            // txtGuncelleID
            // 
            this.txtGuncelleID.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGuncelleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGuncelleID.Location = new System.Drawing.Point(368, 12);
            this.txtGuncelleID.Name = "txtGuncelleID";
            this.txtGuncelleID.Size = new System.Drawing.Size(202, 28);
            this.txtGuncelleID.TabIndex = 20;
            // 
            // URUN_GUNCELLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(941, 471);
            this.Controls.Add(this.txtGuncelleID);
            this.Controls.Add(this.buttonAraTemizle);
            this.Controls.Add(this.buttonAra);
            this.Controls.Add(this.textAra);
            this.Controls.Add(this.cbKayitBirim);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGuncelleSatisFiyati);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.cbUrunGuncelle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGuncelleMiktar);
            this.Controls.Add(this.txtGuncelleName);
            this.Controls.Add(this.txtGuncelleAlisFiyat);
            this.Controls.Add(this.dataGridView1);
            this.Name = "URUN_GUNCELLE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÜRÜN_GÜNCELLE";
            this.Load += new System.EventHandler(this.ÜRÜN_GÜNCELLE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtGuncelleAlisFiyat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGuncelleMiktar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbUrunGuncelle;
        private System.Windows.Forms.TextBox txtGuncelleName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGuncelleSatisFiyati;
        private System.Windows.Forms.ComboBox cbKayitBirim;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonAraTemizle;
        private System.Windows.Forms.Button buttonAra;
        private System.Windows.Forms.TextBox textAra;
        private System.Windows.Forms.TextBox txtGuncelleID;
    }
}