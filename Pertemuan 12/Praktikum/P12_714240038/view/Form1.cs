using MySql.Data.MySqlClient;
using P9_714240061.controller;
using P9_714240061.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240061
{

    public partial class Form1 : Form
    {
        Koneksi koneksi = new Koneksi();

        public Form1()
        {
            InitializeComponent();
        }
        public void ResetForm()
        {
            textboxNpm.Clear();
            textboxNama.Clear();
            textboxAlamat.Clear();
            textboxEmail.Clear();
            textboxNohp.Clear();
            textboxCariData.Text = "";
            comboBoxAngkatan.SelectedIndex = -1;
        }

        public void Tampil()
        {
            // Query SELECT untuk mengambil semua data mahasiswa
            string query = "SELECT * FROM t_mahasiswa";

            // Memanggil method ShowData() dari class Koneksi
            DataMahasiswa.DataSource = koneksi.ShowData(query);

            // Mengubah nama header kolom (opsional, tetapi dianjurkan)
            DataMahasiswa.Columns[0].HeaderText = "NPM";
            DataMahasiswa.Columns[1].HeaderText = "Nama";
            DataMahasiswa.Columns[2].HeaderText = "Angkatan";
            DataMahasiswa.Columns[3].HeaderText = "Alamat";
            DataMahasiswa.Columns[4].HeaderText = "Email";
            DataMahasiswa.Columns[5].HeaderText = "No HP";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            Tampil();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (textboxNpm.Text == "" || textboxNama.Text == "" ||
    comboBoxAngkatan.SelectedIndex == -1 ||
    textboxAlamat.Text == "" || textboxEmail.Text == "" ||
    textboxNohp.Text == "")
            {
                  MessageBox.Show(
                  "Data tidak boleh kosong",
                  "Peringatan",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
);
            }
            else
            {
                Mahasiswa mhs = new Mahasiswa();
                M_mahasiswa m_mhs = new M_mahasiswa();

                m_mhs.Npm = textboxNpm.Text;
                m_mhs.Nama = textboxNama.Text;
                m_mhs.Angkatan = comboBoxAngkatan.Text;
                m_mhs.Alamat = textboxAlamat.Text;
                m_mhs.Email = textboxEmail.Text;
                m_mhs.Nohp = textboxNohp.Text;

                mhs.Insert(m_mhs);
                ResetForm();
                Tampil();
            }
        }

        private void DataMahasiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textboxNpm.Text = DataMahasiswa.Rows[e.RowIndex].Cells[0].Value.ToString();
                textboxNama.Text = DataMahasiswa.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBoxAngkatan.Text = DataMahasiswa.Rows[e.RowIndex].Cells[2].Value.ToString();
                textboxAlamat.Text = DataMahasiswa.Rows[e.RowIndex].Cells[3].Value.ToString();
                textboxEmail.Text = DataMahasiswa.Rows[e.RowIndex].Cells[4].Value.ToString();
                textboxNohp.Text = DataMahasiswa.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (textboxNpm.Text == "" || textboxNama.Text == "" ||
            comboBoxAngkatan.SelectedIndex == -1 ||
            textboxAlamat.Text == "" || textboxEmail.Text == "" ||
            textboxNohp.Text == "")
            {
                MessageBox.Show(
                "Data tidak boleh kosong",
                "Peringatan",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning
);
            }
            else
            {
                Mahasiswa mhs = new Mahasiswa();
                M_mahasiswa m_mhs = new M_mahasiswa();

                m_mhs.Nama = textboxNama.Text;
                m_mhs.Angkatan = comboBoxAngkatan.Text;
                m_mhs.Alamat = textboxAlamat.Text;
                m_mhs.Email = textboxEmail.Text;
                m_mhs.Nohp = textboxNohp.Text;

                mhs.Update(m_mhs, textboxNpm.Text);
                ResetForm();
                Tampil();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
            Tampil();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
        "Yakin ingin menghapus data ini?",
        "Konfirmasi",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Mahasiswa mhs = new Mahasiswa();
                mhs.Delete(textboxNpm.Text);
                ResetForm();
                Tampil();
            }
        }

        private void textboxCariData_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM t_mahasiswa " +
                 "WHERE npm LIKE @param OR nama LIKE @param";

            DataMahasiswa.DataSource = koneksi.ShowDataParam(
                sql,
                new MySqlParameter("@param", "%" + textboxCariData.Text + "%")
            );
        }
    }
}

