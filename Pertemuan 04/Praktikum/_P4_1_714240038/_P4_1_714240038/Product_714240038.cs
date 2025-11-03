using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P4_1_714240038
{
    public abstract class Product_714240038
    {

        private string myType;
        private string myTitle;

        public Product_714240038()
        {

        }

        //contructor 
        public Product_714240038(string type, string title)
        {
            myType = type;
            myTitle = title;
        }

        //property for myType
        public string MyType
        {
            get { return myType; }
            set { myType = value; }
        }

        //property for myTitle
        public string MyTitle
        {
            get { return myTitle; }
            set { myTitle = value; }
        }

        //metode abstrack untuk menampilkan detail produk
        public abstract void DisplayInfo();


    }

}
    
