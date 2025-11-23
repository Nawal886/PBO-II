using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P6_4_714240038
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Mengatur Upper/Lower case langsung dari properties
            // Agar Textbox otomatis mengubah input user
            txtUsername.CharacterCasing = CharacterCasing.Lower;
            txtKodePromo.CharacterCasing = CharacterCasing.Upper;
        }
        private void btnDaftar_Click(object sender, EventArgs e)
        {
            // Logika: Cek Validasi dulu -> Jika Benar -> Tampilkan MessageBox
            if (ValidasiForm())
            {
                // Menyusun string agar tampilannya rapi seperti di Screenshot P5_4
                string infoPendaftaran =
                    "Nama : " + txtNama.Text + "\n" +
                    "Username : " + txtUsername.Text + "\n" +
                    "No HP : " + txtNoHP.Text + "\n" +
                    "Email : " + txtEmail.Text + "\n" +
                    "Kode Promo : " + txtKodePromo.Text + "\n" +
                    "Status : Validasi Berhasil";

                // Menampilkan MessageBox dengan Ikon Informasi (biru)
                MessageBox.Show(
                    infoPendaftaran,             // Isi pesan
                    "Informasi Pendaftaran",     // Judul (Header)
                    MessageBoxButtons.OK,        // Tombol
                    MessageBoxIcon.Information   // Ikon 'i' biru
                );
            }
            else
            {
                // Jika ada validasi yang gagal, munculkan peringatan error
                MessageBox.Show(
                    "Masih ada data yang belum sesuai. Silakan cek tanda seru merah!",
                    "Validasi Gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void txtNoHP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                epError.SetError(txtNoHP, "Hanya boleh angka!");
            }
            else
            {
                epError.SetError(txtNoHP, "");
            }
        }

       

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!string.IsNullOrEmpty(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                epError.SetError(txtEmail, "Format email salah!");
            }
        }

        private void txtNama_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                epError.SetError(txtNama, "Hanya boleh huruf!");
            }
            else
            {
                epError.SetError(txtNama, "");
            }
        }

        // Fungsi Pengecekan Menyeluruh
        private bool ValidasiForm()
        {
            bool isValid = true;
            epError.Clear(); // Bersihkan error lama

            // 1. Cek Nama (Required) 
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                epError.SetError(txtNama, "Nama wajib diisi!");
                isValid = false;
            }

            // 2. Cek No HP (Required)
            if (string.IsNullOrWhiteSpace(txtNoHP.Text))
            {
                epError.SetError(txtNoHP, "Nomor HP wajib diisi!");
                isValid = false;
            }

            // 3. Cek Email (Regex Validator) 
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                epError.SetError(txtEmail, "Email wajib diisi!");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                epError.SetError(txtEmail, "Format email salah! (Harus ada @ dan .)");
                isValid = false;
            }

            // 4. Cek Username (Required + Lowercase otomatis)
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                epError.SetError(txtUsername, "Username wajib diisi!");
                isValid = false;
            }

            // 5. Cek Password (Length Validator) 
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                epError.SetError(txtPassword, "Password wajib diisi!");
                isValid = false;
            }
            else if (txtPassword.Text.Length < 8)
            {
                epError.SetError(txtPassword, "Password minimal 8 karakter!");
                isValid = false;
            }

            // 6. Cek Konfirmasi Password (Comparison) 
            if (txtKonfirmasi.Text != txtPassword.Text)
            {
                epError.SetError(txtKonfirmasi, "Password tidak sama!");
                isValid = false;
            }

            return isValid; // Kembalikan status (True jika semua aman, False jika ada error)
        }
    }
    }
    
    
    

