using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OtoparkOtomasyonu
{
    public partial class CarServices : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );

        public CarServices()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // İlk açıldığında Araç İşlemleri butonunun arkasını sayfada oduğumuz için karartır.
            pnl_HomeNav.Height = btn_HomeAracIslemler.Height;
            pnl_HomeNav.Top = btn_HomeAracIslemler.Top;
            pnl_HomeNav.Left = btn_HomeAracIslemler.Left;
            btn_HomeAracIslemler.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btn_HomeAracIslemler_Click(object sender, EventArgs e)
        {
            btn_HomeAracDurumu.BackColor = Color.FromArgb(24, 30, 54);
            btn_HomeDurumRaporu.BackColor = Color.FromArgb(24, 30, 54);

            pnl_HomeNav.Height = btn_HomeAracIslemler.Height;
            pnl_HomeNav.Top = btn_HomeAracIslemler.Top;
            pnl_HomeNav.Left = btn_HomeAracIslemler.Left;
            btn_HomeAracIslemler.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void rB_Giris_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            txt_GirisTarihi.Text = DateTime.Now.ToString();
        }

        private void rB_Cikis_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible=false;
            groupBox3.Visible=true;
            txt_CikisTarihi.Text = DateTime.Now.ToString();
        }


        private void CarServices_Load(object sender, EventArgs e)
        {
            rB_Giris.Select();
  
        }

        private void groupBox2_Enter(object sender, EventArgs e){/*yanlış basıldı*/}
        private void label6_Click(object sender, EventArgs e){/* yanlış basıldı*/}
        private void textBox1_TextChanged(object sender, EventArgs e){/* yanlış basıldı!*/}
        private void textBox3_TextChanged(object sender, EventArgs e){/* yanlış basıldı!*/}

        private void btn_HomeAracDurumu_Click(object sender, EventArgs e)
        {
            CarState carState = new CarState();
            carState.Show();
            this.Hide();
        }

        private void btn_HomeDurumRaporu_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void btn_HomeCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cBox_KatNu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBox_ParkNu.Items.Clear();
            for (int i = 1; i < 6; i++)
            {
                cBox_ParkNu.Items.Add("K" + (cBox_KatNu.SelectedIndex + 1).ToString() + "P" + i.ToString());
            }
        }

        private void cBox_CikisKatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBox_CikisParkNu.Items.Clear();
            for (int i = 1; i < 6; i++)
            {
                cBox_CikisParkNu.Items.Add("K" + (cBox_KatNu.SelectedIndex + 1).ToString() + "P" + i.ToString());
            }
        }
    }
}
