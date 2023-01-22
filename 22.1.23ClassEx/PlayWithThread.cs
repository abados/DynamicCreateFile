using _22._1._23ClassEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _22._1._23ClassEx
{
    public class PlayWithThread
    {
        public void Run()
        {
            Count c1 = new Count("A", 1000);
            Count c2 = new Count("B", 500);
            Count c3 = new Count("C", 250);
        }
    }

    class Count
    {
        public Count(string label, int sleep)
        {
            Label = label;
            SleepTime = sleep;
            thread = new Thread(Run);
            thread.Start();
        }

        public string Label { get; set; }
        public int SleepTime { get; set; }

        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($" This is num {i} {Label}  ");
                System.Threading.Thread.Sleep(SleepTime);
            }
        }

        Thread thread;
    }

}


