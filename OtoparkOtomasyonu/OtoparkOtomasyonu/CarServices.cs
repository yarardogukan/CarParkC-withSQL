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
using System.Data.SqlClient;
using System.Data.SqlTypes;

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

        public String? katno;
        public int? girisCikis;
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
            if (katno != null)
            {
                switch (katno)
                {

                    case "A1":
                        cBox_KatNu.SelectedIndex = 0;
                        cBox_ParkNu.SelectedIndex = 0;
                        break;
                    case "A2":
                        cBox_KatNu.SelectedIndex = 0;
                        cBox_ParkNu.SelectedIndex = 1;
                        break;
                    case "A3":
                        cBox_KatNu.SelectedIndex = 0;
                        cBox_ParkNu.SelectedIndex = 2;
                        break;
                    case "A4":
                        cBox_KatNu.SelectedIndex = 0;
                        cBox_ParkNu.SelectedIndex = 3;
                        break;
                    case "A5":
                        cBox_KatNu.SelectedIndex = 0;
                        cBox_ParkNu.SelectedIndex = 4;
                        break;
                    case "B1":
                        cBox_KatNu.SelectedIndex = 1;
                        cBox_ParkNu.SelectedIndex = 0;
                        break;
                    case "B2":
                        cBox_KatNu.SelectedIndex = 1;
                        cBox_ParkNu.SelectedIndex = 1;
                        break;
                    case "B3":
                        cBox_KatNu.SelectedIndex = 1;
                        cBox_ParkNu.SelectedIndex = 2;
                        break;
                    case "B4":
                        cBox_KatNu.SelectedIndex = 1;
                        cBox_ParkNu.SelectedIndex = 3;
                        break;
                    case "B5":
                        cBox_KatNu.SelectedIndex = 1;
                        cBox_ParkNu.SelectedIndex = 4;
                        break;
                    case "C1":
                        cBox_KatNu.SelectedIndex = 2;
                        cBox_ParkNu.SelectedIndex = 0;
                        break;
                    case "C2":
                        cBox_KatNu.SelectedIndex = 2;
                        cBox_ParkNu.SelectedIndex = 1;
                        break;
                    case "C3":
                        cBox_KatNu.SelectedIndex = 2;
                        cBox_ParkNu.SelectedIndex = 2;
                        break;
                    case "C4":
                        cBox_KatNu.SelectedIndex = 2;
                        cBox_ParkNu.SelectedIndex = 3;
                        break;
                    case "C5":
                        cBox_KatNu.SelectedIndex = 2;
                        cBox_ParkNu.SelectedIndex = 4;
                        break;
                    case "D1":
                        cBox_KatNu.SelectedIndex = 3;
                        cBox_ParkNu.SelectedIndex = 0;
                        break;
                    case "D2":
                        cBox_KatNu.SelectedIndex = 3;
                        cBox_ParkNu.SelectedIndex = 1;
                        break;
                    case "D3":
                        cBox_KatNu.SelectedIndex = 3;
                        cBox_ParkNu.SelectedIndex = 2;
                        break;
                    case "D4":
                        cBox_KatNu.SelectedIndex = 3;
                        cBox_ParkNu.SelectedIndex = 3;
                        break;
                    case "D5":
                        cBox_KatNu.SelectedIndex = 3;
                        cBox_ParkNu.SelectedIndex = 4;
                        break;
                    case "V1":
                        cBox_KatNu.SelectedIndex = 4;
                        cBox_ParkNu.SelectedIndex = 0;
                        break;
                    case "V2":
                        cBox_KatNu.SelectedIndex = 4;
                        cBox_ParkNu.SelectedIndex = 1;
                        break;
                    case "V3":
                        cBox_KatNu.SelectedIndex = 4;
                        cBox_ParkNu.SelectedIndex = 2;
                        break;
                    case "V4":
                        cBox_KatNu.SelectedIndex = 4;
                        cBox_ParkNu.SelectedIndex = 3;
                        break;
                    case "V5":
                        cBox_KatNu.SelectedIndex = 4;
                        cBox_ParkNu.SelectedIndex = 4;
                        break;
                    default:
                        break;
                }
            }

            if ((girisCikis ?? 0) == 1)
            {
                rB_Giris.Select();
            }
            else
            {
                rB_Cikis.Select();
            }

           


  
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

        private void btn_CikisYap_Click(object sender, EventArgs e)
        {
            SQLProcess process = new SQLProcess();
            List<Object> selectedObject = process.selectQuery("select * from tbl_Kat where kat_ID =" + katIdHesapla(cBox_KatNu.SelectedIndex, cBox_ParkNu.SelectedIndex).ToString()) ?? new List<Object>();
            if (selectedObject.Count == 0)
            {
                MessageBox.Show("Veri tabanından veri Çekilirken bir hata meydana geldi.");
            }else
            {
                List<Object> firstObject = (List<object>)(selectedObject[0] ?? new List<Object>());

                Boolean placeIsEmpty = (Boolean?)firstObject[3] ?? false;
                if (placeIsEmpty)
                {
                    MessageBox.Show("Bu park alanı zaten boş!");
                }
                else
                {
                    process.executeQuery("update tbl_Kat set parkDurumu='True' where kat_ID='" + katIdHesapla(cBox_KatNu.SelectedIndex, cBox_ParkNu.SelectedIndex) + "'");
                    process.executeQuery("update tbl_Fatura set "); // çıkış tarihini ve fiyatı set etmek gerekli.
                }
            }
        }

        private void btn_GirisKayit_Click(object sender, EventArgs e)
        {
            SQLProcess process = new SQLProcess();
            List<Object> selectedObject = process.selectQuery("select * from tbl_Kat where kat_ID =" + katIdHesapla(cBox_KatNu.SelectedIndex, cBox_ParkNu.SelectedIndex).ToString()) ?? new List<Object>();
            if (selectedObject.Count == 0)
            {
                MessageBox.Show("Veri tabanından veri Çekilirken bir hata meydana geldi.");
            }
            else
            {
                List<Object> firstObject = (List<object>) (selectedObject[0] ?? new List<Object>());

                Boolean placeIsEmpty = (Boolean?) firstObject[3] ?? false;
                if (placeIsEmpty)
                {
                    process.executeQuery("insert into tbl_Fatura values ('" + txt_PlakaNo.Text + "', '" + txt_GirisTarihi.Text + "','NULL', '" + katIdHesapla(cBox_KatNu.SelectedIndex, cBox_ParkNu.SelectedIndex) + "', '" + (cBox_AracTur.SelectedIndex + 1) + "', 'NULL')");
                    process.executeQuery("update tbl_Kat set parkDurumu='False' where kat_ID='" + katIdHesapla(cBox_KatNu.SelectedIndex, cBox_ParkNu.SelectedIndex) + "'");
                }
                else
                {
                    MessageBox.Show("Yer Dolu!");
                }
            }
        }              
                       
        private int katIdHesapla(int katNoIndex, int parkNoIndex)
        {
            int katHesapIndex = katNoIndex + 1;
            int parkHesapIndex = parkNoIndex + 1;

            return katHesapIndex * parkHesapIndex;
        }
    }
}
