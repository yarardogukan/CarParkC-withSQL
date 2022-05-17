using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoparkOtomasyonu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_LoginUserName.Text=="admin" && txt_LoginPassword.Text=="123")
            {
                new Home().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Kullanıcı Adı / Şifre Hatalıdır. Tekrardan deneyiniz.");
                txt_LoginUserName.Clear();
                txt_LoginPassword.Clear();
                txt_LoginUserName.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txt_LoginUserName.Clear();
            txt_LoginPassword.Clear();
            txt_LoginUserName.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btn_Login.PerformClick();
            }
        }
    }
}
