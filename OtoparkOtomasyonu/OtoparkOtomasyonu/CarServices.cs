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
                    default:
                        break;
                }
            }

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

        private void btn_CikisYap_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_GirisKayit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NLRIGP6;Initial Catalog=otoparkVeritabani;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Kat where kat_ID =" + katIdHesapla(cBox_KatNu.SelectedIndex, cBox_ParkNu.SelectedIndex), con);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {   
                if (reader.GetBoolean(3))
                {
                    try
                    {
                        sqlProcess();
                        MessageBox.Show("data saved");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Yer Dolu");
                }
            }

            con.Close();
        }              
                       
        private int katIdHesapla(int katNoIndex, int parkNoIndex)
        {
            int katHesapIndex = katNoIndex + 1;
            int parkHesapIndex = parkNoIndex + 1;

            return katHesapIndex * parkHesapIndex;
        }

        private void sqlProcess()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-NLRIGP6;Initial Catalog=otoparkVeritabani;Integrated Security=True");
            SqlCommand cmd2 = new SqlCommand("insert into tbl_Fatura values ('" + txt_PlakaNo.Text + "', '" + txt_GirisTarihi.Text + "','NULL', '" + katIdHesapla(cBox_KatNu.SelectedIndex, cBox_ParkNu.SelectedIndex) + "', '" + (cBox_AracTur.SelectedIndex + 1) + "', 'NULL')");
            cmd2.Connection = con;
            con.Open();
            con.Close();
            SqlCommand cmd3 = new SqlCommand("update tbl_Kat set parkDurumu='False' where kat_ID='" + katIdHesapla(cBox_KatNu.SelectedIndex, cBox_ParkNu.SelectedIndex) + "'");
            cmd3.Connection = con;
            con.Open();
            con.Close();
            
        }
    }
}
