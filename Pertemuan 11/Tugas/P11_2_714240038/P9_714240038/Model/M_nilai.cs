using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240038.Model
{
    
    public class M_nilai
    {
        // Fields (Private)
        private string matkul;
        private string kategori;
        private string npm;
        private string nilai;

        // Constructor Kosong
        public M_nilai() { }

        // Constructor dengan Parameter
        public M_nilai(string matkul, string kategori, string npm, string nilai)
        {
            this.Matkul = matkul;
            this.Kategori = kategori;
            this.Npm = npm;
            this.Nilai = nilai;
        }

        // Properties (Public)
        public string Matkul
        {
            get => matkul;
            set => matkul = value;
        }

        public string Kategori
        {
            get => kategori;
            set => kategori = value;
        }

        public string Npm
        {
            get => npm;
            set => npm = value;
        }

        public string Nilai
        {
            get => nilai;
            set => nilai = value;
        }
    }
}
