using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _22._1._23ClassEx
{
    public class WriteRandomNumbers
    {
        public static string Path = "C:\\Users\\User\\source\\Projects\\Semester3\\Haim\\filesCreation\\exsits";
        private WriteToFileWithThreads[] fileWriters;
        private string[] fileNames = { $"{Path}\\file1.txt", $"{Path}\\file2.txt", $"{Path}\\file3.txt", $"{Path}\\file4.txt" };
        private int numberOfThreads = 4;

        public WriteRandomNumbers()
        {
            fileWriters = new WriteToFileWithThreads[numberOfThreads];

            for (int i = 0; i < numberOfThreads; i++)
            {
                fileWriters[i] = new WriteToFileWithThreads(fileNames[i]);
            }
        }

        public void callTheThreads()
        {
            Thread[] threads = new Thread[numberOfThreads];
            

            for (int i = 0; i < numberOfThreads; i++)
            {
                int threadIndex = i;
                threads[i] = new Thread(WriteRandomNumbersToFile);
                threads[i].Start(threadIndex);
            }

           
        }

        private void WriteRandomNumbersToFile(object fileIndex)
        {
            int index = (int)fileIndex;
            Random random = new Random();

            for (int j = 0; j < 10000; j++)
            {
                int randomNumber = random.Next();
                fileWriters[index].WriteToFile(randomNumber.ToString());
            }
        }
    }

}
