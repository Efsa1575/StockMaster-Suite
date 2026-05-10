namespace PRODUCT_COMPANY
{
    partial class DEPO
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.cbDepoSec = new System.Windows.Forms.ComboBox();
            this.btnDepoyuGörüntüle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonKritikGöster = new System.Windows.Forms.Button();
            this.labelKritik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(729, 355);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(410, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbDepoSec
            // 
            this.cbDepoSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbDepoSec.FormattingEnabled = true;
            this.cbDepoSec.Location = new System.Drawing.Point(144, 30);
            this.cbDepoSec.Name = "cbDepoSec";
            this.cbDepoSec.Size = new System.Drawing.Size(183, 30);
            this.cbDepoSec.TabIndex = 5;
            // 
            // btnDepoyuGörüntüle
            // 
            this.btnDepoyuGörüntüle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDepoyuGörüntüle.Location = new System.Drawing.Point(346, 26);
            this.btnDepoyuGörüntüle.Name = "btnDepoyuGörüntüle";
            this.btnDepoyuGörüntüle.Size = new System.Drawing.Size(184, 36);
            this.btnDepoyuGörüntüle.TabIndex = 6;
            this.btnDepoyuGörüntüle.Text = "Depoyu Görüntüle";
            this.btnDepoyuGörüntüle.UseVisualStyleBackColor = true;
            this.btnDepoyuGörüntüle.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Depo Seç:";
            // 
            // buttonKritikGöster
            // 
            this.buttonKritikGöster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonKritikGöster.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonKritikGöster.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonKritikGöster.Location = new System.Drawing.Point(649, 21);
            this.buttonKritikGöster.Name = "buttonKritikGöster";
            this.buttonKritikGöster.Size = new System.Drawing.Size(103, 45);
            this.buttonKritikGöster.TabIndex = 8;
            this.buttonKritikGöster.Text = "Kritikleri Göster";
            this.buttonKritikGöster.UseVisualStyleBackColor = false;
            this.buttonKritikGöster.Click += new System.EventHandler(this.buttonKritikGöster_Click);
            // 
            // labelKritik
            // 
            this.labelKritik.AutoSize = true;
            this.labelKritik.Location = new System.Drawing.Point(565, 35);
            this.labelKritik.Name = "labelKritik";
            this.labelKritik.Size = new System.Drawing.Size(78, 16);
            this.labelKritik.TabIndex = 10;
            this.labelKritik.Text = "Kritik Stok: 0";
            this.labelKritik.Click += new System.EventHandler(this.labelKritik_Click);
            // 
            // DEPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelKritik);
            this.Controls.Add(this.buttonKritikGöster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDepoyuGörüntüle);
            this.Controls.Add(this.cbDepoSec);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DEPO";
            this.Text = "DEPO";
            this.Load += new System.EventHandler(this.DEPO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbDepoSec;
        private System.Windows.Forms.Button btnDepoyuGörüntüle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonKritikGöster;
        private System.Windows.Forms.Label labelKritik;
    }
}