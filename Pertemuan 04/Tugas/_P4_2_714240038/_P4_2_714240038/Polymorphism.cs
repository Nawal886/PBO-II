using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_2_714240038
{
    // Polymorphism: Goalkeeper juga turunan Player tapi aksi berbeda
    public class Goalkeeper : Player
    {
        public Goalkeeper(string name, int number) : base(name, number)
        {
        }

        public override void Play()
        {
            Console.WriteLine($"{Name} (#{Number}) melakukan penyelamatan gemilang di gawang Liverpool!");
        }
    }
}