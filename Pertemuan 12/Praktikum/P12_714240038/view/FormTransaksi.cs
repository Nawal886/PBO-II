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

namespace P9_714240061.view
{
    public partial class FormTransaksi : Form
    {

        Koneksi koneksi = new Koneksi();
        Transaksi tr = new Transaksi();
        M_transaksi m_tr = new M_transaksi();
        public FormTransaksi()
        {
            InitializeComponent();
        }

        private void cbIdBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                koneksi.OpenConnection();
                string query = "SELECT nama_barang, harga FROM t_barang WHERE id_barang = @id";

                DataTable dt = (DataTable)koneksi.ShowDataParam(query, new MySqlParameter("@id", cbIdBarang.Text));

                if (dt.Rows.Count > 0)
                {
                    txtNamaBarang.Text = dt.Rows[0]["nama_barang"].ToString();
                    txtHarga.Text = dt.Rows[0]["harga"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(txtHarga.Text, out long harga) && int.TryParse(txtQty.Text, out int qty))
            {
                txtTotal.Text = (harga * qty).ToString();
            }
            else
            {
                txtTotal.Text = "0";
            }
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            Tampil();
            GetDataBarang();
        }
        public void GetDataBarang()
        {
            try
            {
                koneksi.OpenConnection(); // Membuka jalur database [cite: 2418]
                                          // Menjalankan query melalui method 'reader' di Koneksi.cs
                MySqlDataReader dr = koneksi.reader("SELECT id_barang FROM t_barang");

                cbIdBarang.Items.Clear(); // Agar data tidak menumpuk saat direfresh
                while (dr.Read())
                {
                    cbIdBarang.Items.Add(dr["id_barang"].ToString());
                }
                dr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                koneksi.CloseConnection(); // Menutup jalur database [cite: 2425]
            }
        }
        public void Tampil()
        {
            // Query JOIN untuk menggabungkan tabel transaksi dan tabel barang
            string query = "SELECT id_transaksi, t_transaksi.id_barang, nama_barang, harga, qty, total " +
                           "FROM t_transaksi JOIN t_barang ON t_barang.id_barang = t_transaksi.id_barang";

            // Mengatur sumber data DataGridView dgvTransaksi
            dgvTransaksi.DataSource = koneksi.ShowData(query);

            // (Opsional) Mengubah nama header kolom agar rapi
            dgvTransaksi.Columns[0].HeaderText = "ID";
            dgvTransaksi.Columns[1].HeaderText = "ID Barang";
            dgvTransaksi.Columns[2].HeaderText = "Nama Barang";
            dgvTransaksi.Columns[3].HeaderText = "Harga";
            dgvTransaksi.Columns[4].HeaderText = "QTY";
            dgvTransaksi.Columns[5].HeaderText = "Total Harga";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cbIdBarang.SelectedIndex == -1 || txtQty.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Cek duplikat di tabel transaksi menggunakan Parameterized Query
                string sqlCek = "SELECT * FROM t_transaksi WHERE id_barang = @id";
                DataTable dt = (DataTable)koneksi.ShowDataParam(sqlCek, new MySql.Data.MySqlClient.MySqlParameter("@id", cbIdBarang.Text));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Barang ini sudah pernah di transaksikan silahkan gunakan tombol (Ubah)", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Isi data ke model transaksi
                    m_tr.Id_barang = cbIdBarang.Text;
                    m_tr.Qty = txtQty.Text;
                    m_tr.Total = txtTotal.Text;

                    tr.Insert(m_tr); // Panggil controller
                    Tampil(); // Refresh tabel
                    btnRefresh.PerformClick(); // Kosongkan form
                }

            }
        }

        private void txtCariBarang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT id_transaksi, t_transaksi.id_barang, nama_barang, harga, qty, total " +
                               "FROM t_transaksi JOIN t_barang ON t_barang.id_barang = t_transaksi.id_barang " +
                               "WHERE t_transaksi.id_barang LIKE @cari OR nama_barang LIKE @cari";

                // PASTIKAN nama di designer adalah txtCariData. Jika masih merah, ganti menjadi txtCariBarang.Text
                dgvTransaksi.DataSource = koneksi.ShowDataParam(query, new MySqlParameter("@cari", "%" + txtCariData.Text + "%"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cbIdBarang.Text = dgvTransaksi.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNamaBarang.Text = dgvTransaksi.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtHarga.Text = dgvTransaksi.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtQty.Text = dgvTransaksi.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtTotal.Text = dgvTransaksi.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (cbIdBarang.SelectedIndex == -1 || txtQty.Text == "")
            {
                MessageBox.Show("Pilih data yang akan diubah melalui tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Mengambil ID Transaksi dari baris yang sedang dipilih di DataGridView (Cells[0])
                string id_transaksi = dgvTransaksi.Rows[dgvTransaksi.CurrentCell.RowIndex].Cells[0].Value.ToString();

                // Mengisi data baru ke dalam model
                m_tr.Id_barang = cbIdBarang.Text;
                m_tr.Qty = txtQty.Text;
                m_tr.Total = txtTotal.Text;

                // Memanggil fungsi Update pada controller transaksi
                if (tr.Update(m_tr, id_transaksi))
                {
                    MessageBox.Show("Data transaksi berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Tampil(); // Refresh tabel transaksi
                    btnRefresh.PerformClick(); // Kosongkan form input
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (cbIdBarang.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih data yang akan dihapus melalui tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Konfirmasi penghapusan
                DialogResult pesan = MessageBox.Show("Apakah anda yakin ingin menghapus transaksi ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (pesan == DialogResult.Yes)
                {
                    // Mengambil ID Transaksi dari baris yang terpilih
                    string id_transaksi = dgvTransaksi.Rows[dgvTransaksi.CurrentCell.RowIndex].Cells[0].Value.ToString();

                    // Memanggil fungsi Delete pada controller transaksi
                    if (tr.Delete(id_transaksi))
                    {
                        MessageBox.Show("Data transaksi berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Tampil(); // Refresh tabel transaksi
                        btnRefresh.PerformClick(); // Kosongkan form input
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbIdBarang.SelectedIndex = -1;

            // 2. Mengosongkan semua TextBox inputan
            txtNamaBarang.Clear();
            txtHarga.Clear();
            txtQty.Clear();

            // 3. Reset Total menjadi 0 (karena ini TextBox Read-Only)
            txtTotal.Text = "0";

            // 4. Mengosongkan TextBox Pencarian
            txtCariData.Clear();

            // 5. Memanggil kembali method Tampil agar DataGridView ter-refresh dari database
            Tampil();

            // 6. Memanggil kembali GetDataBarang jika ada penambahan barang baru di FormBarang
            GetDataBarang();
        }
    }
}
