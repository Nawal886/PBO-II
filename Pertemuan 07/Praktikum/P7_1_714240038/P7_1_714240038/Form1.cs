using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P7_1_714240038
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCek_Click(object sender, EventArgs e)
        {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrWhiteSpace(textBoxNama.Text))
            {
                errorMessage.AppendLine("Nama harus diisi!");
            }

            if (comboBoxAngkatan.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Angkatan harus diisi!");
            }

            if (string.IsNullOrWhiteSpace(textBoxKelas.Text))
            {
                errorMessage.AppendLine("Kelas harus diisi!");
            }

            string errorString = errorMessage.ToString();
            if (string.IsNullOrEmpty(errorString))
            {
                // Mengubah ukuran FORM
                this.Size = new Size(333, 526);

                MessageBox.Show(
                    "Lengkap",
                    "Informasi Data Submit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    errorString.Trim(),
                    "Informasi Data Submit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }


            if (string.IsNullOrEmpty(errorString))
            {
                MessageBox.Show(
                    "Lengkap",
                    "Informasi Data Submit",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    errorString.Trim(),
                    "Informasi Data Submit",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void adioButtonWeekday_CheckedChanged(object sender, EventArgs e)
        {
            if (adioButtonWeekday.Checked)
            {
                checkBoxKuliah.Enabled = true;
                checkBoxKuliah.Checked = false;

                checkBoxTidur.Enabled = true;
                checkBoxTidur.Checked = false;

                checkBoxLiburan.Enabled = false;
                checkBoxLiburan.Checked = false;
            }
        }

        private void radioButtonWeekend_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeekend.Checked)
            {
                checkBoxKuliah.Enabled = false;
                checkBoxKuliah.Checked = false;

                checkBoxTidur.Enabled = true;
                checkBoxTidur.Checked = false;

                checkBoxLiburan.Enabled = true;
                checkBoxLiburan.Checked = false;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string hari = null;
            string kegiatan = null;

            foreach (Control control in Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    hari = radioButton.Text;
                    break;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    if (!string.IsNullOrEmpty(kegiatan))
                    {
                        kegiatan += ", ";
                    }
                    kegiatan += checkBox.Text;
                }
            }

            MessageBox.Show(
                "Nama: " + textBoxNama.Text + "\n" +
                "Angkatan: " + comboBoxAngkatan.Text + "\n" +
                "Kelas: " + textBoxKelas.Text + "\n" +
                "====================\n" +
                "Hari: " + hari + "\n" +
                "Kegiatan: " + kegiatan,
                "Informasi Data Submit",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            //// Menggunakan LINQ
            //string hari = Controls.OfType<RadioButton>()
            //    .FirstOrDefault(rb => rb.Checked)?.Text; // FirstOrDefault akan mengembalikan null jika tidak ada yang terpilih

            //string kegiatan = string.Join(", ",
            //    Controls.OfType<CheckBox>()
            //    .Where(cb => cb.Checked) // Where memastikan hanya CheckBox yang tidak null dan Checked yang diambil.
            //    .Select(cb => cb.Text));

            //// Menampilkan pesan informasi
            //MessageBox.Show(
            //    "Nama: " + textBoxNama.Text + "\n" +
            //    "Angkatan: " + comboBoxAngkatan.Text + "\n" +
            //    "Kelas: " + textBoxKelas.Text + "\n" +
            //    "=================================\n" +
            //    "Hari: " + hari + "\n" +
            //    "Kegiatan: " + kegiatan,
            //    "Informasi Data Submit",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }

            MessageBox.Show(
                "Form Berhasil Direset!!",
                "Informasi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            Size = new Size(295, 216);
        }
    }
    }
    

