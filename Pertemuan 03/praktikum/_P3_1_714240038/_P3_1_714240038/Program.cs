using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pertemuan3_1_714240038
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do

            {
                Console.Clear();
                Console.Write("Menetukan indeks prestasi mahasiswa\n------------------");
                Console.Write("\nMasukan Nama Mahasisiwa: ");

                string nama = Console.ReadLine();

                Console.WriteLine("Masukan Nilai");

                int nilai = Convert.ToInt16(Console.ReadLine());

                string[] grade = { "A", "B", "C", "D", };

                if (nilai >= 85)
                {
                    Console.WriteLine("indeks nilai {0} adalah {1}", nama, grade[0]);
                }
                else if (nilai >= 70 && nilai < 85)
                {
                    Console.WriteLine("indeks nilai {0} adalah {1}", nama, grade[1]);
                }
                else if (nilai >= 60 && nilai < 70)
                {
                    Console.WriteLine("indeks nilai {0} adalah {1}", nama, grade[2]);
                }
                else
                {
                    Console.WriteLine("indeks nilai {0} adalah {1}", nama, grade[3]);

                }
                Console.Write("\nMasukan indeks yang ditampilkan : ");
                char indeks = Convert.ToChar(Console.ReadLine());
                Console.Write("indeks prestasi {0} adalah", nama);

                prestasi(indeks);

                Console.Write("\n\nIngin mengulang lagi? (Y/T) : ");
            }
            while (Console.ReadLine() == "y");
        }
        private static void prestasi(char indeks)
        {
            switch (indeks)
            {
                case 'A':
                    Console.Write("Sangat baik");
                    break;
                case 'B':
                    Console.Write("Baik");
                    break;
                case 'C':
                    Console.Write("Cukup");
                    break;
                case 'D':
                    Console.Write("Buruk");
                    break;
                default:
                    Console.Write("Indeks tidak valid");
                    break;
            }
        }
    }
}

