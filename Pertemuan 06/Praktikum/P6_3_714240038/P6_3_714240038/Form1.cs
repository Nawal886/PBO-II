using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace P6_3_714240038
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void SetErrorMessages(TextBox textBox, string warningMessage, string wrongMessage, string correctMessage)
        {
            epWarning.SetError(textBox, warningMessage);
            epWrong.SetError(textBox, wrongMessage);
            epCorrect.SetError(textBox, correctMessage);
        }

        private void txtHuruf_Leave(object sender, EventArgs e)
        {
            if (txtHuruf.Text == "")
            {
                SetErrorMessages(txtHuruf, "Textbox Huruf tidak boleh kosong!", "", "");
            }
            else if (txtHuruf.Text.All(Char.IsLetter))
            {
                SetErrorMessages(txtHuruf, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtHuruf, "", "Inputan hanya boleh huruf!", "");
            }
        }

        private void txtAngka_TextChanged(object sender, EventArgs e)
        {
            // Cek apakah TextBox kosong
            if (txtAngka.Text == "")
            {
                // Tampilkan pesan kesalahan: "TextBox Angka tidak boleh kosong!"
                SetErrorMessages(txtAngka, "Textbox Angka tidak boleh kosong!", "", "");
            }
            // Cek apakah semua karakter adalah angka
            else if (txtAngka.Text.All(Char.IsNumber))
            {
                // Tampilkan pesan sukses: "Betul!"
                // Perhatikan bahwa parameter ketiga (untuk pesan sukses) diisi "Betul!"
                SetErrorMessages(txtAngka, "", "", "Betul!");
            }
            // Jika ada karakter yang bukan angka
            else
            {
                // Tampilkan pesan kesalahan: "Inputan hanya boleh angka!"
                SetErrorMessages(txtAngka, "", "Inputan hanya boleh angka!", "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            // Cek apakah TextBox kosong
            if (txtEmail.Text == "")
            {
                // Tampilkan pesan kesalahan: "Textbox Email tidak boleh kosong!"
                SetErrorMessages(txtEmail, "Textbox Email tidak boleh kosong!", "", "");
            }
            // Cek apakah format email valid menggunakan Regular Expression
            else if (Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                // Jika format valid, tampilkan pesan sukses: "Betul!"
                SetErrorMessages(txtEmail, "", "", "Betul!");
            }
            // Jika format email tidak valid
            else
            {
                // Tampilkan pesan kesalahan: "Format email salah!\nContoh: a@b.c"
                SetErrorMessages(txtEmail, "", "Format email salah!\nContoh: a@b.c", "");
            }

        }

        private void txtAngka1_Leave(object sender, EventArgs e)
        {
            // Wajib diisi
            if (txtAngka1.Text == "")
            {
                SetErrorMessages(txtAngka1, "Wajib diisi!", null, null);
                return;
            }

            // Validasi angka
            if (!int.TryParse(txtAngka1.Text, out _))
            {
                SetErrorMessages(txtAngka1, null, "Hanya boleh angka!", null);
                txtAngka1.Clear();
                return;
            }

            // Benar
            SetErrorMessages(txtAngka1, null, null, "Benar!");

            // Cek apakah Angka2 sudah terisi
            if (txtAngka2.Text != "")
            {
                txtAngka2_Leave(sender, e); // Panggil validasi Angka2
            }
        }


        private void txtAngka2_Leave(object sender, EventArgs e)
        {
            // Wajib diisi
            if (txtAngka2.Text == "")
            {
                SetErrorMessages(txtAngka2, "Wajib diisi!", null, null);
                return;
            }

            // Validasi angka
            if (!int.TryParse(txtAngka2.Text, out int angka2))
            {
                SetErrorMessages(txtAngka2, null, "Hanya boleh angka!", null);
                txtAngka2.Clear();
                return;
            }

            // Apakah Angka1 sudah terisi?
            if (txtAngka1.Text == "")
            {
                SetErrorMessages(txtAngka2, "Angka 1 belum diisi!", null, null);
                return;
            }

            // Ambil nilai Angka1
            int angka1 = int.Parse(txtAngka1.Text);

            // Bandingkan Angka1 dan Angka2
            if (angka1 > angka2)
            {
                SetErrorMessages(txtAngka2, null, null, "Benar (Angka1 > Angka2)");
            }
            else
            {
                SetErrorMessages(txtAngka2, null, "Angka 1 harus lebih besar!", null);
            }
        }
    }
}


