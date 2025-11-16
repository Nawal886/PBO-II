using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5__4_714240038
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            // VALIDASI NAMA
            if (txtNama.Text == "")
            {
                MessageBox.Show("Nama belum diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // VALIDASI JENIS KELAMIN (ComboBox)
            if (comboJK.SelectedIndex == -1)
            {
                MessageBox.Show("Jenis kelamin belum dipilih!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // VALIDASI TANGGAL LAHIR
            DateTime tanggal = dateTimePicker1.Value;

            // VALIDASI PILIHAN KELAS (CHECKBOX)
            List<string> kelas = new List<string>();

            if (cbSepak.Checked) kelas.Add("Sepak Bola");
            if (cbRenang.Checked) kelas.Add("Renang");
            if (cbTenis.Checked) kelas.Add("Tenis");
            if (cbYoga.Checked) kelas.Add("Yoga");
            if (cbBasket.Checked) kelas.Add("Basket");
            if (cbBulu.Checked) kelas.Add("Bulu Tangkis");
            if (cbVoli.Checked) kelas.Add("Voli");
            if (cbPanahan.Checked) kelas.Add("Panahan");

            if (kelas.Count == 0)
            {
                MessageBox.Show("Pilihan kelas belum diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // VALIDASI PILIHAN JADWAL (RADIOBUTTON)
            string jadwal = "";

            if (rbSenin.Checked) jadwal = "Senin s/d Rabu, 14.00 - 16.00";
            else if (rbSelasa.Checked) jadwal = "Selasa s/d Kamis, 14.00 - 16.00";
            else if (rbSabtu.Checked) jadwal = "Sabtu s/d Minggu, 09.00 - 11.00";
            else if (rbMinggu.Checked) jadwal = "Minggu, 13.00 - 20.00";

            if (jadwal == "")
            {
                MessageBox.Show("Pilihan jadwal belum diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // MEMBENTUK TEKS UNTUK MESSAGEBOX
            string info =
                "Nama : " + txtNama.Text + "\n" +
                "Jenis Kelamin : " + comboJK.Text + "\n" +
                "Tanggal Lahir : " + tanggal.ToString("dd MMMM yyyy") + "\n" +
                "Pilihan Kelas : " + string.Join(", ", kelas) + "\n" +
                "Pilihan Jadwal : " + jadwal;

            // MENAMPILKAN MESSAGEBOX KAYA GAMBAR KANAN
            MessageBox.Show(info, "Informasi Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

