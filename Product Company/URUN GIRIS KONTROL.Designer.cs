namespace PRODUCT_COMPANY
{
    partial class URUN_GIRIS_KONTROL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(URUN_GIRIS_KONTROL));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAraTemizle = new System.Windows.Forms.Button();
            this.buttonAra = new System.Windows.Forms.Button();
            this.textAra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(849, 294);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "GİRİŞ YAPAN ÜRÜNLERİN KONTROLÜ";
            // 
            // buttonAraTemizle
            // 
            this.buttonAraTemizle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAraTemizle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAraTemizle.BackgroundImage")));
            this.buttonAraTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAraTemizle.Location = new System.Drawing.Point(249, 94);
            this.buttonAraTemizle.Name = "buttonAraTemizle";
            this.buttonAraTemizle.Size = new System.Drawing.Size(48, 26);
            this.buttonAraTemizle.TabIndex = 12;
            this.buttonAraTemizle.UseVisualStyleBackColor = false;
            this.buttonAraTemizle.Click += new System.EventHandler(this.buttonAraTemizle_Click);
            // 
            // buttonAra
            // 
            this.buttonAra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAra.BackgroundImage")));
            this.buttonAra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAra.Location = new System.Drawing.Point(198, 93);
            this.buttonAra.Name = "buttonAra";
            this.buttonAra.Size = new System.Drawing.Size(45, 27);
            this.buttonAra.TabIndex = 11;
            this.buttonAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAra.UseVisualStyleBackColor = false;
            this.buttonAra.Click += new System.EventHandler(this.buttonAra_Click);
            // 
            // textAra
            // 
            this.textAra.BackColor = System.Drawing.Color.FloralWhite;
            this.textAra.Location = new System.Drawing.Point(28, 96);
            this.textAra.Name = "textAra";
            this.textAra.Size = new System.Drawing.Size(166, 22);
            this.textAra.TabIndex = 10;
            this.textAra.TextChanged += new System.EventHandler(this.textAra_TextChanged);
            // 
            // URUN_GIRIS_KONTROL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(873, 450);
            this.Controls.Add(this.buttonAraTemizle);
            this.Controls.Add(this.buttonAra);
            this.Controls.Add(this.textAra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "URUN_GIRIS_KONTROL";
            this.Text = "URUN_GIRIS_KONTROL";
            this.Load += new System.EventHandler(this.URUN_GIRIS_KONTROL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAraTemizle;
        private System.Windows.Forms.Button buttonAra;
        private System.Windows.Forms.TextBox textAra;
    }
}