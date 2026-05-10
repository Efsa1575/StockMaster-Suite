using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRODUCT_COMPANY
{
    public partial class YONETİCİ : Form
    {
        public YONETİCİ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DEPO frm=new DEPO();
            frm.ShowDialog();
            frm.Hide();
            frm.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            URUNLER frm=new URUNLER();  
            frm.ShowDialog();   
            frm.Hide();
            frm.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            URUN_CİKİS_KONROL frm=new URUN_CİKİS_KONROL();
            frm.ShowDialog();

        frm.Hide(); 
            frm.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            URUN_GIRIS_KONTROL frm=new URUN_GIRIS_KONTROL();
            frm.ShowDialog();

            frm.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RAPOR frm=new RAPOR();
            frm.ShowDialog();
            frm.Hide();
        }

        private void YONETİCİ_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CALISAN_KONTROL frm = new CALISAN_KONTROL();
            frm.ShowDialog();
        }
    }
}
