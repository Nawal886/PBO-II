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
    internal class Nilai
    {
        // membuat objek koneksi
        Koneksi koneksi = new Koneksi();

        // ===============================
        // METHOD INSERT DATA NILAI
        // ===============================
        public bool Insert(M_nilai nilai)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO t_nilai (matkul, kategori, npm, nilai) " +
                    "VALUES (@matkul, @kategori, @npm, @nilai)"
                );

                cmd.Parameters.AddWithValue("@matkul", nilai.Matkul);
                cmd.Parameters.AddWithValue("@kategori", nilai.Kategori);
                cmd.Parameters.AddWithValue("@npm", nilai.Npm);
                cmd.Parameters.AddWithValue("@nilai", nilai.Nilai);

                koneksi.ExecuteQuery(cmd);
                status = true;

                MessageBox.Show("Data nilai berhasil ditambahkan");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        // ===============================
        // METHOD UPDATE DATA NILAI
        // ===============================
        public bool Update(M_nilai nilai, string id_nilai)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(
                    "UPDATE t_nilai SET matkul=@matkul, kategori=@kategori, " +
                    "npm=@npm, nilai=@nilai WHERE id_nilai=@id"
                );

                cmd.Parameters.AddWithValue("@matkul", nilai.Matkul);
                cmd.Parameters.AddWithValue("@kategori", nilai.Kategori);
                cmd.Parameters.AddWithValue("@npm", nilai.Npm);
                cmd.Parameters.AddWithValue("@nilai", nilai.Nilai);
                cmd.Parameters.AddWithValue("@id", id_nilai);

                koneksi.ExecuteQuery(cmd);
                status = true;

                MessageBox.Show("Data nilai berhasil diubah");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        // ===============================
        // METHOD DELETE DATA NILAI
        // ===============================
        public bool Delete(string id_nilai)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();

                MySqlCommand cmd = new MySqlCommand(
                    "DELETE FROM t_nilai WHERE id_nilai=@id"
                );

                cmd.Parameters.AddWithValue("@id", id_nilai);
                koneksi.ExecuteQuery(cmd);
                status = true;

                MessageBox.Show("Data nilai berhasil dihapus");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }
    }
}
