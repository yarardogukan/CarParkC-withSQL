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

        public Home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            
            // �lk a��ld���nda Durum raporu butonun arkas�n� sayfada odu�umuz i�in karart�r.
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
            lbl_HomeSystemTime.Text = DateTime.Now.ToString();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer_SystemTime.Start();
        }
    }
}