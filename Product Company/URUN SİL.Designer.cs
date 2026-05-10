namespace PRODUCT_COMPANY
{
    partial class URUN_SİL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(URUN_SİL));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSil = new System.Windows.Forms.Button();
            this.buttonAraTemizle = new System.Windows.Forms.Button();
            this.buttonAra = new System.Windows.Forms.Button();
            this.textAra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(897, 262);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(194, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(558, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "!! Silmek İstediğiniz Ürünün Üstüne Tıklayıp Sil Butonuna Basınız !!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSil.BackgroundImage")));
            this.btnSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(445, 70);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(68, 37);
            this.btnSil.TabIndex = 9;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // buttonAraTemizle
            // 
            this.buttonAraTemizle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAraTemizle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAraTemizle.BackgroundImage")));
            this.buttonAraTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAraTemizle.Location = new System.Drawing.Point(257, 104);
            this.buttonAraTemizle.Name = "buttonAraTemizle";
            this.buttonAraTemizle.Size = new System.Drawing.Size(48, 26);
            this.buttonAraTemizle.TabIndex = 22;
            this.buttonAraTemizle.UseVisualStyleBackColor = false;
            this.buttonAraTemizle.Click += new System.EventHandler(this.buttonAraTemizle_Click);
            // 
            // buttonAra
            // 
            this.buttonAra.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAra.BackgroundImage")));
            this.buttonAra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAra.Location = new System.Drawing.Point(206, 103);
            this.buttonAra.Name = "buttonAra";
            this.buttonAra.Size = new System.Drawing.Size(45, 27);
            this.buttonAra.TabIndex = 21;
            this.buttonAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonAra.UseVisualStyleBackColor = false;
            this.buttonAra.Click += new System.EventHandler(this.buttonAra_Click);
            // 
            // textAra
            // 
            this.textAra.BackColor = System.Drawing.Color.FloralWhite;
            this.textAra.Location = new System.Drawing.Point(34, 104);
            this.textAra.Name = "textAra";
            this.textAra.Size = new System.Drawing.Size(166, 22);
            this.textAra.TabIndex = 20;
            this.textAra.TextChanged += new System.EventHandler(this.textAra_TextChanged);
            // 
            // URUN_SİL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(969, 418);
            this.Controls.Add(this.buttonAraTemizle);
            this.Controls.Add(this.buttonAra);
            this.Controls.Add(this.textAra);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "URUN_SİL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "URUN_SİL";
            this.Load += new System.EventHandler(this.URUN_SİL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button buttonAraTemizle;
        private System.Windows.Forms.Button buttonAra;
        private System.Windows.Forms.TextBox textAra;
    }
}