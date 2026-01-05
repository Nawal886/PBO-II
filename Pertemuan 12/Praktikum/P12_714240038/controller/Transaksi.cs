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

    internal class Transaksi
    {
        Koneksi koneksi = new Koneksi();

        public bool Insert(M_transaksi transaksi)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                // Baris ke-21 di gambar kamu sebelumnya
                MySqlCommand cmd = new MySqlCommand("INSERT INTO t_transaksi (id_barang, qty, total) VALUES (@id, @qty, @total)", koneksi.koneksi);
                cmd.Parameters.AddWithValue("@id", transaksi.Id_barang);
                cmd.Parameters.AddWithValue("@qty", transaksi.Qty);
                cmd.Parameters.AddWithValue("@total", transaksi.Total);

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
        public bool Update(M_transaksi transaksi, string id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE t_transaksi SET id_barang=@id_barang, qty=@qty, total=@total WHERE id_transaksi=@id", koneksi.koneksi);
                cmd.Parameters.AddWithValue("@id_barang", transaksi.Id_barang);
                cmd.Parameters.AddWithValue("@qty", transaksi.Qty);
                cmd.Parameters.AddWithValue("@total", transaksi.Total);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                status = true;
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
        public bool Delete(string id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM t_transaksi WHERE id_transaksi=@id", koneksi.koneksi);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                status = true;
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