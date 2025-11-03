using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_1_714240038
{
    public class Book_714240038 : Product_714240038
    {
        protected string pageCount;

        public Book_714240038(string type, string title, string pageCount) : base(type, title)
        {
            this.pageCount = pageCount;
        }

        public string PageCount
        {
            get { return pageCount; }
            set { pageCount = value; }
        }

        //Implementasi metode abstrak dari kelas induk
        public override void DisplayInfo()
        {
            Console.WriteLine("Product is a {0} called \"{1}\" and has {2} pages.", MyType, MyTitle, pageCount);
        }
    }
    
    }

