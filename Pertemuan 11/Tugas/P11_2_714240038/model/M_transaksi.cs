using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240061.model
{
    internal class M_transaksi
    {
        
            public string Id_barang { get; set; }
            public string Qty { get; set; }
            public string Total { get; set; }

            public M_transaksi() { }
            // Constructor untuk mempermudah passing data
            public M_transaksi(string id_barang, string qty, string total)
            {
                this.Id_barang = id_barang;
                this.Qty = qty;
                this.Total = total;
            }
        

    }
}
