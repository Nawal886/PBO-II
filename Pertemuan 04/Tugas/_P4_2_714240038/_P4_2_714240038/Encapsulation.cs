using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_2_714240038
{
    // Encapsulation: field private, diakses lewat property
    public class Club
    {
        private string clubName;
        private string coach;
        private int foundedYear;

        public string ClubName
        {
            get { return clubName; }
            set { clubName = value; }
        }

        public string Coach
        {
            get { return coach; }
            set { coach = value; }
        }

        public int FoundedYear
        {
            get { return foundedYear; }
            set
            {
                if (value < 1800)
                    foundedYear = 1892;
                else
                    foundedYear = value;
            }
        }

        public void ShowClubInfo()
        {
            Console.WriteLine($"Klub: {ClubName}\nPelatih: {Coach}\nDidirikan Tahun: {FoundedYear}");
        }
    }
}