using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_2_714240038
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char ulang;

            do
            {
                Console.Clear();

                Console.WriteLine("=== MENU PERSEGI PANJANG ===");
                Console.WriteLine("1. Hitung Luas");
                Console.WriteLine("2. Hitung Keliling");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu (1-3): ");

                string pilihan = Console.ReadLine();

                int panjang = 0;
                int lebar = 0;

                if (pilihan == "1" || pilihan == "2")
                {
                    Console.Write("Masukkan panjang: ");
                    panjang = int.Parse(Console.ReadLine());
                    Console.Write("Masukkan lebar: ");
                    lebar = int.Parse(Console.ReadLine());
                }

                switch (pilihan)
                {
                    case "1":
                        int luas = panjang * lebar;
                        Console.WriteLine($"Luas Persegi Panjang: {luas}");
                        break;
                    case "2":
                        int keliling = 2 * (panjang + lebar);
                        Console.WriteLine($"Keliling Persegi Panjang: {keliling}");
                        break;
                    case "3":
                        Console.WriteLine("Program selesai.");
                        Console.WriteLine("Terima kasih!");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Menu tidak tersedia. Silakan pilih menu yang valid.");
                        break;
                }

                Console.Write("Ingin mengulang kembali (Y/T)? ");
                ulang = char.Parse(Console.ReadLine().ToUpper());

            } while (ulang == 'Y');

            Console.WriteLine("Terima kasih!");
            Console.ReadKey();
        }
    }
}
