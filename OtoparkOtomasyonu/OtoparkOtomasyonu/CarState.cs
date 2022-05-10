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
            List<Button> buttons = new List<Button>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);  
            buttons.Add(button17);
            buttons.Add(button18);
            buttons.Add(button19);
            buttons.Add(button20);
            buttons.Add(button21);
            buttons.Add(button22);
            buttons.Add(button23);
            buttons.Add(button24);
            buttons.Add(button25);

            foreach (Button button in buttons) { 
                button.Text = "Boş";
                button.BackColor = Color.Green;
                button.ForeColor = Color.White;

                if (button == button10)
                {
                    button.Text = "34 AAA 34";
                    button.BackColor = Color.Red;
                    button.ForeColor = Color.White;
                }
            }
        }

        private void parkClick(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Text = "34 AAA 34";
                clickedButton.BackColor = Color.Red;
            }
        }
    }
}
