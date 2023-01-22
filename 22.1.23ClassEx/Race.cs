using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _22._1._23ClassEx
{
    public  class Race
    {
        public static List<Race> topThree = new List<Race>();
        Thread Thread;
        public int KM { get; set; } = 0;
        Random rand = new Random(DateTime.Now.Millisecond);
        public string Name { get; set; }
        public static bool STOP = false;
        public bool stop = false;
        public static int countWinners = 0;
        public static int index = 1;
        Object obj = new object();
        public Race(string name)
        {
            this.Name = name;
            Thread = new Thread(MainLoop);
            Thread.Start();
        }
        public void Drive()
        {
            int km = rand.Next(0, 101);
            
            KM += km;
            if (KM > 10000 && countWinners < 3 && topThree.Count < 3)
            {
                if(topThree.Count<3) topThree.Add(this);

                stop = true;
                countWinners++;
            }
               
            if (countWinners == 3)
            {
                STOP= true;
            }
            
        }

        public void MainLoop()
        {
            while (!STOP || !stop)
            {
                Drive();
            }
            if(KM>=10000 && index<4)
            {

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine((i + 1) + "." + topThree[i].Name + " Reached " + topThree[i].KM);
                }
                Console.Read();

                Console.Read();
            }
            
        }
    }
}
