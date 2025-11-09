using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_2_714240038
{
    // Constructor: inisialisasi objek Team
    public class Team
    {
        public string TeamName { get; set; }
        public int PlayerCount { get; set; }

        // Constructor dipanggil otomatis saat membuat objek
        public Team(string teamName, int playerCount)
        {
            TeamName = teamName;
            PlayerCount = playerCount;
        }

        public void ShowTeamData()
        {
            Console.WriteLine($"Tim {TeamName} berisi {PlayerCount} pemain siap bertanding!");
        }
    }
}