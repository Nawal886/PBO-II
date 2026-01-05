using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240061.model
{
    internal class M_nilai
    {
        // deklarasi variabel
        string matkul;
        string kategori;
        string npm;
        string nilai;

        // property Matkul
        public string Matkul
        {
            get { return matkul; }
            set { matkul = value; }
        }

        // property Kategori
        public string Kategori
        {
            get { return kategori; }
            set { kategori = value; }
        }

        // property NPM
        public string Npm
        {
            get { return npm; }
            set { npm = value; }
        }

        // property Nilai
        public string Nilai
        {
            get { return nilai; }
            set { nilai = value; }
        }
    }
}