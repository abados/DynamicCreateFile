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
    

        public void Run()
        {
            Count c1 = new Count("A", 3000);
            Count c2 = new Count("B", 500);
            
        }


        

        class Count
        {
            private static bool stopThreads = false;
            Thread thread;
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
                int i = 0;
                while (!stopThreads)
                {
                    Console.WriteLine(i + " " + Label);
                    i++;
                    if (i % 10 == 0)
                    {
                        Console.WriteLine("Enter a number:");
                        int userInput = int.Parse(Console.ReadLine());
                        if (userInput == 0)
                        {
                            //Environment.Exit(0);
                            stopThreads = true;
                        }
                    }
                    Thread.Sleep(SleepTime);
                }
            }
        }


           
        }

    }

