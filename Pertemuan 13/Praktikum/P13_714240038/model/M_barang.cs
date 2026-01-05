using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240061.model
{
    internal class M_barang
    {
        public string Nama_barang { get; set; }
        public string Harga { get; set; }

        public M_barang() { }
        public M_barang(string nama_barang, string harga)
        {
            this.Nama_barang = nama_barang;
            this.Harga = harga;
        }
    }
}
