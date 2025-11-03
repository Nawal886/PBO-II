using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_1_714240038
{
    public class DVD_714240038 : Product_714240038
    {
        protected string duration;

        public DVD_714240038(string title, string duration)
        {
            MyType = "DVD";
            MyTitle = title;
            this.duration = duration;
            Console.WriteLine("ini dari claas DVD");
        }

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        //Implementasi metode abstrak dari kelas induk
        public override void DisplayInfo()
        {
            Console.WriteLine("Product is a {0} called \"{1}\" and has {2} minutes durations.", MyType, MyTitle, duration);
        }

    }
}
