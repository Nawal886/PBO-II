using MySql.Data.MySqlClient;
using P9_714240061.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240061.controller
{
    internal class Barang
    {
        Koneksi koneksi = new Koneksi();

        public bool Insert(M_barang barang)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO t_barang (nama_barang, harga) VALUES (@nama, @harga)", koneksi.koneksi);
                cmd.Parameters.AddWithValue("@nama", barang.Nama_barang);
                cmd.Parameters.AddWithValue("@harga", barang.Harga);
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }
        // Method Update di dalam class Barang
        public bool Update(M_barang barang, string id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
               // Query SQL Update dengan parameter [cite: 3358, 3360]
                MySqlCommand cmd = new MySqlCommand("UPDATE t_barang SET nama_barang=@nama, harga=@harga WHERE id_barang=@id", koneksi.koneksi);

                cmd.Parameters.AddWithValue("@nama", barang.Nama_barang);
                cmd.Parameters.AddWithValue("@harga", barang.Harga);
                cmd.Parameters.AddWithValue("@id", id); // Menggunakan ID sebagai acuan data yang diubah [cite: 3365]

                cmd.ExecuteNonQuery();
                status = true;
                 MessageBox.Show("Data berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);}
            catch (Exception e)
            {
                 MessageBox.Show(e.Message, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                 koneksi.CloseConnection(); }
            return status;
        }
        // Tambahkan method ini di dalam class Barang (folder controller)
        public bool Delete(string id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                // Parameterized Query untuk menghapus berdasarkan ID
                MySqlCommand cmd = new MySqlCommand("DELETE FROM t_barang WHERE id_barang=@id", koneksi.koneksi);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                status = true;
                MessageBox.Show("Data berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }
    }
}
