using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OtoparkOtomasyonu
{
    public partial class Home : Form
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

        int toplamAracSayisi = 100;
        int mevcutAracSayisi = 20;
        

        public Home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            
            // Ýlk açýldýðýnda Durum raporu butonun arkasýný sayfada oduðumuz için karartýr.
            pnl_HomeNav.Height = btn_HomeDurumRaporu.Height;
            pnl_HomeNav.Top = btn_HomeDurumRaporu.Top;
            pnl_HomeNav.Left = btn_HomeDurumRaporu.Left;
            btn_HomeDurumRaporu.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btn_HomeDurumRaporu_Click(object sender, EventArgs e)
        {
            btn_HomeAracDurumu.BackColor = Color.FromArgb(24, 30, 54);
            btn_HomeAracIslemler.BackColor = Color.FromArgb(24, 30, 54);

            pnl_HomeNav.Height= btn_HomeDurumRaporu.Height;
            pnl_HomeNav.Top= btn_HomeDurumRaporu.Top;
            pnl_HomeNav.Left= btn_HomeDurumRaporu.Left;
            btn_HomeDurumRaporu.BackColor=Color.FromArgb(46,51,73);
        }

        private void btn_HomeAracDurumu_Click(object sender, EventArgs e)
        {
            CarState cs = new CarState();
            cs.Show();
            this.Hide();
        }

        private void btn_HomeAracIslemler_Click(object sender, EventArgs e)
        {
            CarServices cser = new CarServices();
            cser.Show();
            this.Hide();
            
        }

        private void btn_HomeCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_SystemTime_Tick(object sender, EventArgs e)
        {
            lbl_HomeSystemTime.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }

        private void Home_Load(object sender, EventArgs e)
        {
            SQLProcess process = new SQLProcess();
            List<Object> currentState = process.selectQuery("select * from tbl_Kat where parkDurumu='False'") ?? new List<object>(); // tabloda ki true false neyse o koyulacak
            // BURADA + OLARAK Veri tabanında ki kayıtlara göre gün bazlı hesaplama yapıplıp
            // araç ve tutar hesaplanacak
            
            mevcutAracSayisi = currentState.Count;
            float dolulukOrani = mevcutAracSayisi * 100 / 25;
            timer_SystemTime.Start();
            dolulukLabel.Text = "%" + dolulukOrani.ToString();
            aracCountLabel.Text = toplamAracSayisi.ToString() + " Adet";
            currentCarLabel.Text = mevcutAracSayisi.ToString() + " Adet";
            gelirLabel.Text = "0₺";
            gelirDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            dolulukGraphs.Value = (int)dolulukOrani;
            dolulukGraphs.ProgressColor = setProgressColor(dolulukOrani);
        }

        private Color setProgressColor(float oran)
        {

            if (oran > 70 && oran <= 100)
            {
                return Color.DarkRed;
            }
          
            else if (oran > 30 && oran <= 70)
            {
                return Color.DarkOrange;
            }
            else
            {
                return Color.DarkGreen;
            }
        }

    }
}