using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace _22._1._23ClassEx
{
    public class StringClass
    {
        Thread thread1;
        Thread thread2;
        string letter1 = "A";
        string letter2 = "B";

        public StringClass()
        {
            
            thread1 = new Thread(printIt);
            thread1.Start(letter1);
            thread2 = new Thread(printIt);
            thread2.Start(letter2);
        }

        string Word { get; set; }

        public void printIt(object letter)
        {
            string letterString = (string)letter;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " " + letterString);
                Thread.Sleep(1000);
            }
        }
    }
}
