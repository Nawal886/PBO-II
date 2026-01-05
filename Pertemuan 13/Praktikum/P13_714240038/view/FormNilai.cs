using MySql.Data.MySqlClient;
using P9_714240061.controller;
using P9_714240061.lib;
using P9_714240061.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240061.view
{
    public partial class FormNilai : Form
    {
        Koneksi koneksi = new Koneksi();

        // memanggil class model nilai
        M_nilai m_nilai = new M_nilai();

        // deklarasi variabel id_nilai
        string id_nilai;

        public void Tampil()
        {
            DataNilai.DataSource = koneksi.ShowData(
                "SELECT id_nilai, matkul, kategori, t_nilai.npm, nama, nilai " +
                "FROM t_nilai JOIN t_mahasiswa ON t_mahasiswa.npm = t_nilai.npm"
            );

            DataNilai.Columns[0].HeaderText = "ID";
            DataNilai.Columns[1].HeaderText = "Mata Kuliah";
            DataNilai.Columns[2].HeaderText = "Kategori";
            DataNilai.Columns[3].HeaderText = "NPM";
            DataNilai.Columns[4].HeaderText = "Nama Mahasiswa";
            DataNilai.Columns[5].HeaderText = "Nilai";
        }

        public void GetDataMhs()
        {
            // mengosongkan isi ComboBox terlebih dahulu
            checkBoxNpm.Items.Clear();

            // membuka koneksi database
            koneksi.OpenConnection();

            // menjalankan query untuk mengambil npm dari tabel mahasiswa
            MySqlDataReader reader = koneksi.reader("SELECT npm FROM t_mahasiswa");

            // membaca data satu per satu
            while (reader.Read())
            {
                // memasukkan npm ke ComboBox
                checkBoxNpm.Items.Add(reader["npm"].ToString());
            }

            // menutup reader
            reader.Close();

            // menutup koneksi database
            koneksi.CloseConnection();
        }
        public void GetNamaMhs()
        {
            // cek apakah combobox npm sudah dipilih
            if (string.IsNullOrEmpty(checkBoxNpm.Text))
            {
                return;
            }

            // query untuk mengambil nama mahasiswa berdasarkan npm
            string sql = "SELECT nama FROM t_mahasiswa WHERE npm = @npm";

            // jalankan query menggunakan parameter
            DataTable dt = (DataTable)koneksi.ShowDataParam(
                sql,
                new MySql.Data.MySqlClient.MySqlParameter("@npm", checkBoxNpm.Text)
            );

            // tampilkan nama mahasiswa ke textbox
            textBoxNama.Text = dt.Rows[0]["nama"].ToString();
        }



        public FormNilai()
        {
            InitializeComponent();
        }

        private void FormNilai_Load(object sender, EventArgs e)
        {
            Tampil();
            GetDataMhs();
        }

        private void DataNilai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // pastikan baris yang diklik valid
            if (e.RowIndex < 0)
            {
                return;
            }

            // ambil id_nilai dari kolom pertama
            id_nilai = DataNilai.Rows[e.RowIndex].Cells[0].Value.ToString();

            // ambil data lain dan tampilkan ke form
            checkBoxMatkul.Text = DataNilai.Rows[e.RowIndex].Cells[1].Value.ToString();
            checkBoxKategori.Text = DataNilai.Rows[e.RowIndex].Cells[2].Value.ToString();
            checkBoxNpm.Text = DataNilai.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxNilai.Text = DataNilai.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void textBoxCariData_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT id_nilai, matkul, kategori, t_nilai.npm, nama, nilai " +
                 "FROM t_nilai JOIN t_mahasiswa ON t_mahasiswa.npm = t_nilai.npm " +
                 "WHERE t_nilai.npm LIKE @param OR nama LIKE @param";

            DataNilai.DataSource = koneksi.ShowDataParam(
                sql,
                new MySql.Data.MySqlClient.MySqlParameter(
                    "@param", "%" + textBoxCariData.Text + "%"
                )
            );
        }

        public void ResetForm()
        {
            // mengosongkan ComboBox
            checkBoxMatkul.SelectedIndex = -1;
            checkBoxKategori.SelectedIndex = -1;
            checkBoxNpm.SelectedIndex = -1;

            // mengosongkan TextBox
            textBoxNilai.Clear();
            textBoxNama.Clear();
            textBoxCariData.Clear();

            // reset id_nilai
            id_nilai = null;
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            // cek apakah data sudah dipilih
            if (id_nilai == null)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            // konfirmasi hapus
            DialogResult dialog = MessageBox.Show(
                "Yakin ingin menghapus data ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // jika user memilih Yes
            if (dialog == DialogResult.Yes)
            {
                Nilai n = new Nilai();
                n.Delete(id_nilai);

                // refresh tampilan
                ResetForm();
                Tampil();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBoxNpm_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNamaMhs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
            Tampil();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // validasi input
            if (checkBoxMatkul.Text == "" ||
                checkBoxKategori.Text == "" ||
                checkBoxNpm.Text == "" ||
                textBoxNilai.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong");
                return;
            }

            // isi model nilai
            m_nilai.Matkul = checkBoxMatkul.Text;
            m_nilai.Kategori = checkBoxKategori.Text;
            m_nilai.Npm = checkBoxNpm.Text;
            m_nilai.Nilai = textBoxNilai.Text;

            // simpan data
            Nilai n = new Nilai();
            n.Insert(m_nilai);

            // refresh tampilan
            ResetForm();
            Tampil();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            // cek apakah data sudah dipilih
            if (id_nilai == null)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            // validasi input
            if (checkBoxMatkul.Text == "" ||
                checkBoxKategori.Text == "" ||
                checkBoxNpm.Text == "" ||
                textBoxNilai.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong");
                return;
            }

            // isi model nilai
            m_nilai.Matkul = checkBoxMatkul.Text;
            m_nilai.Kategori = checkBoxKategori.Text;
            m_nilai.Npm = checkBoxNpm.Text;
            m_nilai.Nilai = textBoxNilai.Text;

            // update data
            Nilai n = new Nilai();
            n.Update(m_nilai, id_nilai);

            // refresh tampilan
            ResetForm();
            Tampil();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            save.FileName = "Report Nilai.xlsx";
            save.OverwritePrompt = false;

            if (save.ShowDialog() == DialogResult.OK)
            {
                string filePath = save.FileName;

                if (File.Exists(filePath))
                    File.Delete(filePath);

                Excel excel_lib = new Excel();
                excel_lib.ExportToExcel(DataNilai, filePath);

                MessageBox.Show(
                    "Data berhasil diekspor ke file Excel.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
