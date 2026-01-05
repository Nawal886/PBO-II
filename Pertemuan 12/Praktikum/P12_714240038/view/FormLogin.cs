using P9_714240061.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240061.view
{
    public partial class FormLogin : Form
    {
        CekLogin login = new CekLogin();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Mengecek apakah TextBox Username atau Password masih kosong
            if (string.IsNullOrWhiteSpace(tbUsername.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show(
                    "Username dan Password tidak boleh kosong!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string username = tbUsername.Text;
            string password = tbPassword.Text;

            bool status = login.cek_login(username, password);

            // Mengecek hasil login
            if (status)
            {
                MessageBox.Show(
                    "Login Berhasil",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ParentForm pform = new ParentForm(); // Membuat objek ParentForm
                Hide(); // Menyembunyikan Form Login
                pform.Show(); // Menampilkan ParentForm
            }
            else
            {
                MessageBox.Show(
                    "Username atau Password salah",
                    "Gagal Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
