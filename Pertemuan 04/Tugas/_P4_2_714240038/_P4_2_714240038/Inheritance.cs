using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_2_714240038
{
    // Inheritance: Forward adalah turunan dari Player
    public class Forward : Player
    {
        public Forward(string name, int number) : base(name, number)
        {
        }

        // Override method abstrak
        public override void Play()
        {
            Console.WriteLine($"{Name} (#{Number}) menyerang dan mencetak gol untuk Liverpool!");
        }
    }
}
