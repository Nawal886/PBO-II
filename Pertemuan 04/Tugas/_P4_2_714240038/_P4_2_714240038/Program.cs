using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_2_714240038
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== LIVERPOOL FC ===\n");

            // Abstraction + Inheritance + Polymorphism
            Player salah = new Forward("Mohamed Salah", 11);
            Player alisson = new Goalkeeper("Alisson Becker", 1);

            salah.Play();
            alisson.Play();

            Console.WriteLine("\n=== ENCAPSULATION ===");
            Club liverpool = new Club();
            liverpool.ClubName = "Liverpool FC";
            liverpool.Coach = "Arne Slot";
            liverpool.FoundedYear = 1892;
            liverpool.ShowClubInfo();

            Console.WriteLine("\n=== CONSTRUCTOR ===");
            Team mainTeam = new Team("Liverpool", 11);
            mainTeam.ShowTeamData();

            Console.WriteLine("\n=== THIS IS LIVERPOOL ===");
        }
    }
}

