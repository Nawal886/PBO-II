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

namespace P9_714240061.view
{
    public partial class FormBarang : Form
    {
        // Deklarasi objek di dalam class
        Koneksi koneksi = new Koneksi();
        Barang brg = new Barang();
        M_barang m_brg = new M_barang();

        public FormBarang()
        {
            InitializeComponent();
        }

        private void FormBarang_Load(object sender, EventArgs e)
        {
            // Panggil Tampil agar data muncul saat form dibuka
            Tampil();
        }

        public void Tampil()
        {
            // Pastikan (Name) DataGridView di designer adalah dgvBarang
            dgvBarang.DataSource = koneksi.ShowData("SELECT * FROM t_barang");
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtNamaBarang.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Masukkan data ke Model [cite: 400]
                m_brg.Nama_barang = txtNamaBarang.Text;
                m_brg.Harga = txtHarga.Text;

                // Panggil method Insert dari Controller Barang [cite: 401]
                if (brg.Insert(m_brg))
                {
                    // Jika berhasil, kosongkan form dan refresh tabel [cite: 408]
                    btnRefresh.PerformClick();
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtNamaBarang.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Pilih data yang akan diubah terlebih dahulu!", "Peringatan");
            }
            else
            {
                m_brg.Nama_barang = txtNamaBarang.Text;
                m_brg.Harga = txtHarga.Text;

                // Ambil ID dari sel pertama DataGridView yang sedang diklik
                string id = dgvBarang.Rows[dgvBarang.CurrentCell.RowIndex].Cells[0].Value.ToString();

                if (brg.Update(m_brg, id)) // Pastikan method Update sudah ada di Barang.cs [cite: 616]
                {
                    btnRefresh.PerformClick();
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Apakah yakin akan menghapus data ini?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if (pesan == DialogResult.Yes) 
    {
                string id = dgvBarang.Rows[dgvBarang.CurrentCell.RowIndex].Cells[0].Value.ToString();
                 if (brg.Delete(id)) // Pastikan method Delete sudah ada di Barang.cs [cite: 979]
                {
                    btnRefresh.PerformClick();
                }
            }
        }

        private void txtCariBarang_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM t_barang WHERE id_barang LIKE @cari OR nama_barang LIKE @cari";

            // Memanggil ShowDataParam dari Koneksi.cs dengan parameter pencarian
            dgvBarang.DataSource = koneksi.ShowDataParam(query, new MySql.Data.MySqlClient.MySqlParameter("@cari", "%" + txtCariData.Text + "%"));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtNamaBarang.Clear();
            txtHarga.Clear();
            txtCariData.Clear(); 
            Tampil();
        }

        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil baris yang sedang diklik
                DataGridViewRow row = dgvBarang.Rows[e.RowIndex];

                // Pindahkan data ke TextBox (sesuaikan indeks kolom tabelmu)
                // Biasanya: Index 0 = ID, Index 1 = Nama, Index 2 = Harga
                txtNamaBarang.Text = row.Cells[1].Value.ToString();
                txtHarga.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
