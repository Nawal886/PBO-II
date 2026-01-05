using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240061
{
        internal class Koneksi
    {
        string connectionstring = "Server=localhost;Database=pemrog2ulbi;Uid=root;Pwd=;";
        public MySqlConnection koneksi;

        public void OpenConnection()
        {
            koneksi = new MySqlConnection(connectionstring);
            koneksi.Open();
        }

        public void CloseConnection()
        {
            koneksi.Close();
        }

        public object ShowData(string query)
        {
            MySqlDataAdapter data = new MySqlDataAdapter(query, connectionstring);

            DataSet DS = new DataSet();
            data.Fill(DS);
            return DS.Tables[0];
        }
        public void ExecuteQuery(MySqlCommand command)
        {
            command.Connection = koneksi;
            command.ExecuteNonQuery();
        }

        public object ShowDataParam(string query, params MySqlParameter[] parameters)
        {
            // Pastikan variabel koneksi (MySqlConnection) sudah di-instansiasi
            if (koneksi == null) koneksi = new MySqlConnection(connectionstring);

            MySqlCommand cmd = new MySqlCommand(query, koneksi); // Menghubungkan query dengan koneksi

            foreach (MySqlParameter param in parameters)
            {
                cmd.Parameters.Add(param);
            }

            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                data.Fill(ds); // Baris ini tidak akan error lagi jika cmd.Connection sudah terisi
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Database: " + ex.Message);
            }

            return ds.Tables[0];
        }

        public MySqlDataReader reader(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, koneksi);
            return cmd.ExecuteReader();
        }
        public MySqlDataReader reader(string query, MySqlParameter[] parameters)
        {
            MySqlCommand cmd = new MySqlCommand(query, koneksi);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteReader();
        }

    }
}



