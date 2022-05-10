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
    public partial class CarState : Form
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

        public CarState()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // İlk açıldığında Durum raporu butonun arkasını sayfada oduğumuz için karartır.
            pnl_HomeNav.Height = btn_HomeAracDurumu.Height;
            pnl_HomeNav.Top = btn_HomeAracDurumu.Top;
            pnl_HomeNav.Left = btn_HomeAracDurumu.Left;
            btn_HomeAracDurumu.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btn_HomeDurumRaporu_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void btn_HomeAracDurumu_Click(object sender, EventArgs e)
        {
            btn_HomeAracDurumu.BackColor = Color.FromArgb(24, 30, 54);
            btn_HomeAracIslemler.BackColor = Color.FromArgb(24, 30, 54);

            pnl_HomeNav.Height = btn_HomeDurumRaporu.Height;
            pnl_HomeNav.Top = btn_HomeDurumRaporu.Top;
            pnl_HomeNav.Left = btn_HomeDurumRaporu.Left;
            btn_HomeDurumRaporu.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btn_HomeAracIslemler_Click(object sender, EventArgs e)
        {
            CarServices carServices = new CarServices();
            carServices.Show();
            this.Hide();
        }

        private void btn_HomeCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void CarState_Load(object sender, EventArgs e)
        {
            
        }
    }
}
