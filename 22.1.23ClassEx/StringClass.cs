using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._1._23ClassEx
{
    public class StringClass
    {

        public StringClass(string word) {
            
            Word= word;
        }

        string Word { get; set; }

         public void printIt()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " " + Word);
            }
        }
    }
}
