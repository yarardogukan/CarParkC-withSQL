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
            buttons.Add(btn_A1);
            buttons.Add(btn_A2);
            buttons.Add(btn_A3);
            buttons.Add(btn_A4);
            buttons.Add(btn_A5);
            buttons.Add(btn_B1);
            buttons.Add(btn_B2);
            buttons.Add(btn_B3);
            buttons.Add(btn_B4);
            buttons.Add(btn_B5);
            buttons.Add(btn_C1);
            buttons.Add(btn_C2);
            buttons.Add(btn_C3);
            buttons.Add(btn_C4);
            buttons.Add(btn_C5);
            buttons.Add(btn_D1);
            buttons.Add(btn_D2);
            buttons.Add(btn_D3);
            buttons.Add(btn_D4);
            buttons.Add(btn_D5);
            buttons.Add(btn_V1);
            buttons.Add(btn_V2);
            buttons.Add(btn_V3);
            buttons.Add(btn_V4);
            buttons.Add(btn_V5);

            SQLProcess process = new SQLProcess();
            List<Object> selectedObject = process.selectQuery("select * from tbl_Kat") ?? new List<Object>();
            if (selectedObject.Count == 0)
            {
                MessageBox.Show("Veri tabanından veri Çekilirken bir hata meydana geldi.");
            }
            else
            {
                 for (int i = 0; i < buttons.Count; i++)
                {
                    Button button = buttons[i];
                    
                    List<Object> floor = (List<object>)(selectedObject[i] ?? new List<Object>());
                    Boolean placeIsEmpty = (Boolean?)floor[3] ?? false;
                    if (placeIsEmpty)
                    {
                        button.Text = "Boş";
                        button.BackColor = Color.Green;
                        button.ForeColor = Color.White;
                    }
                    else
                    {
                        String placePlaka = (String?)floor[2] ?? ""; //plaka hangi indeksteyse değişecek
                        button.Text = placePlaka;
                        button.BackColor = Color.Red;
                        button.ForeColor = Color.White;
                    }
                    
                }
            }
        }

        private void parkClick(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            MessageBox.Show(clickedButton.Name);
            String buttonSqlName = clickedButton.Name.Replace("btn_", "");
            int placeIsEmpty = clickedButton.BackColor == Color.Red ? 0 : 1;
            if (clickedButton != null)
            {
                CarServices carServices = new CarServices();
                carServices.katno = buttonSqlName;
                carServices.girisCikis = placeIsEmpty;
                this.Hide();
                carServices.Show();
            }
        }

    }
}
