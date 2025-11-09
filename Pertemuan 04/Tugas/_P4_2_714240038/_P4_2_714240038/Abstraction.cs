using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_2_714240038
{
    // Abstraction: class abstrak Player mewakili konsep umum pemain bola
    public abstract class Player
    {
        public string Name { get; set; }
        public int Number { get; set; }

        // Constructor
        public Player(string name, int number)
        {
            Name = name;
            Number = number;
        }

        // Method abstrak (harus di-override)
        public abstract void Play();
    }
}

