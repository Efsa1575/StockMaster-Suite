namespace PRODUCT_COMPANY
{
    partial class CALISAN_KONTROL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CALISAN_KONTROL));
            this.buttonYeniKayit = new System.Windows.Forms.Button();
            this.buttonMevcutCalisan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbKayıtKategori = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtkayıtpass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtkayıtphone = new System.Windows.Forms.TextBox();
            this.txtkayıtuname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtkayıtsoyisim = new System.Windows.Forms.TextBox();
            this.txtkayıtisim = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonAraTemizle = new System.Windows.Forms.Button();
            this.buttonAra = new System.Windows.Forms.Button();
            this.textAra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonYeniKayit
            // 
            this.buttonYeniKayit.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonYeniKayit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonYeniKayit.BackgroundImage")));
            this.buttonYeniKayit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonYeniKayit.Location = new System.Drawing.Point(36, 198);
            this.buttonYeniKayit.Name = "buttonYeniKayit";
            this.buttonYeniKayit.Size = new System.Drawing.Size(79, 62);
            this.buttonYeniKayit.TabIndex = 0;
            this.buttonYeniKayit.UseVisualStyleBackColor = false;
            this.buttonYeniKayit.Click += new System.EventHandler(this.buttonYeniKayit_Click);
            // 
            // buttonMevcutCalisan
            // 
            this.buttonMevcutCalisan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMevcutCalisan.BackgroundImage")));
            this.buttonMevcutCalisan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMevcutCalisan.Location = new System.Drawing.Point(36, 316);
            this.buttonMevcutCalisan.Name = "buttonMevcutCalisan";
            this.buttonMevcutCalisan.Size = new System.Drawing.Size(79, 62);
            this.buttonMevcutCalisan.TabIndex = 1;
            this.buttonMevcutCalisan.UseVisualStyleBackColor = true;
            this.buttonMevcutCalisan.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Ivory;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(165, 163);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(585, 275);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cbKayıtKategori
            // 
            this.cbKayıtKategori.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbKayıtKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbKayıtKategori.FormattingEnabled = true;
            this.cbKayıtKategori.Location = new System.Drawing.Point(607, 80);
            this.cbKayıtKategori.Name = "cbKayıtKategori";
            this.cbKayıtKategori.Size = new System.Drawing.Size(143, 30);
            this.cbKayıtKategori.TabIndex = 22;
            this.cbKayıtKategori.SelectedIndexChanged += new System.EventHandler(this.cbKayıtKategori_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Info;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(523, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 21;
            this.label7.Text = "Pozisyon:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(559, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Şifre:";
            // 
            // txtkayıtpass
            // 
            this.txtkayıtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkayıtpass.Location = new System.Drawing.Point(607, 50);
            this.txtkayıtpass.Name = "txtkayıtpass";
            this.txtkayıtpass.Size = new System.Drawing.Size(143, 26);
            this.txtkayıtpass.TabIndex = 19;
            this.txtkayıtpass.TextChanged += new System.EventHandler(this.txtkayıtpass_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(540, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Telefon:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(258, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Kullanıcı Adı:";
            // 
            // txtkayıtphone
            // 
            this.txtkayıtphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkayıtphone.Location = new System.Drawing.Point(607, 14);
            this.txtkayıtphone.Name = "txtkayıtphone";
            this.txtkayıtphone.Size = new System.Drawing.Size(143, 26);
            this.txtkayıtphone.TabIndex = 15;
            this.txtkayıtphone.TextChanged += new System.EventHandler(this.txtkayıtphone_TextChanged);
            // 
            // txtkayıtuname
            // 
            this.txtkayıtuname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkayıtuname.Location = new System.Drawing.Point(354, 80);
            this.txtkayıtuname.Name = "txtkayıtuname";
            this.txtkayıtuname.Size = new System.Drawing.Size(127, 26);
            this.txtkayıtuname.TabIndex = 16;
            this.txtkayıtuname.TextChanged += new System.EventHandler(this.txtkayıtuname_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(289, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Soyisim:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(309, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "İsim:";
            // 
            // txtkayıtsoyisim
            // 
            this.txtkayıtsoyisim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkayıtsoyisim.Location = new System.Drawing.Point(354, 48);
            this.txtkayıtsoyisim.Name = "txtkayıtsoyisim";
            this.txtkayıtsoyisim.Size = new System.Drawing.Size(127, 26);
            this.txtkayıtsoyisim.TabIndex = 11;
            this.txtkayıtsoyisim.TextChanged += new System.EventHandler(this.txtkayıtsoyisim_TextChanged);
            // 
            // txtkayıtisim
            // 
            this.txtkayıtisim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkayıtisim.Location = new System.Drawing.Point(354, 16);
            this.txtkayıtisim.Name = "txtkayıtisim";
            this.txtkayıtisim.Size = new System.Drawing.Size(127, 26);
            this.txtkayıtisim.TabIndex = 12;
            this.txtkayıtisim.TextChanged += new System.EventHandler(this.txtkayıtisim_TextChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(471, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 35);
            this.button1.TabIndex = 23;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(548, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 35);
            this.button3.TabIndex = 24;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonAraTemizle
            // 
            this.buttonAraTemizle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAraTemizle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAraTemizle.BackgroundImage")));
            this.buttonAraTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAraTemizle.Location = new System.Drawing.Point(354, 129);
            this.buttonAraTemizle.Name = "buttonAraTemizle";
            this.buttonAraTemizle.Size = new System.Drawing.Size(42, 26);
            this.buttonAraTemizle.TabIndex = 27;
            this.buttonAraTemizle.UseVisualStyleBackColor = false;
            this.buttonAraTemizle.Click += new System.EventHandler(this.buttonAraTemizle_Click);
            // 
            // buttonAra
            // 
            this.buttonAra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAra.BackgroundImage")));
            this.buttonAra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAra.Location = new System.Drawing.Point(308, 128);
            this.buttonAra.Name = "buttonAra";
            this.buttonAra.Size = new System.Drawing.Size(39, 27);
            this.buttonAra.TabIndex = 26;
            this.buttonAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAra.UseVisualStyleBackColor = false;
            this.buttonAra.Click += new System.EventHandler(this.buttonAra_Click);
            // 
            // textAra
            // 
            this.textAra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textAra.Location = new System.Drawing.Point(165, 132);
            this.textAra.Name = "textAra";
            this.textAra.Size = new System.Drawing.Size(137, 22);
            this.textAra.TabIndex = 25;
            this.textAra.TextChanged += new System.EventHandler(this.textAra_TextChanged);
            // 
            // CALISAN_KONTROL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.buttonAraTemizle);
            this.Controls.Add(this.buttonAra);
            this.Controls.Add(this.textAra);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbKayıtKategori);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtkayıtpass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtkayıtphone);
            this.Controls.Add(this.txtkayıtuname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtkayıtsoyisim);
            this.Controls.Add(this.txtkayıtisim);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonMevcutCalisan);
            this.Controls.Add(this.buttonYeniKayit);
            this.Name = "CALISAN_KONTROL";
            this.Text = "CALISAN_KONTROL";
            this.Load += new System.EventHandler(this.CALISAN_KONTROL_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonYeniKayit;
        private System.Windows.Forms.Button buttonMevcutCalisan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbKayıtKategori;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtkayıtpass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtkayıtphone;
        private System.Windows.Forms.TextBox txtkayıtuname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtkayıtsoyisim;
        private System.Windows.Forms.TextBox txtkayıtisim;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAraTemizle;
        private System.Windows.Forms.Button buttonAra;
        private System.Windows.Forms.TextBox textAra;
    }
}