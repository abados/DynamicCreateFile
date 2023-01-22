using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._1._23ClassEx
{
    public class WriteToFileWithThreads
    {
        // private variables to store file name, path, base name and serial number
        private string fileName;
        private string path;
        private string baseName;
        

        public WriteToFileWithThreads(string fileName) // constructor to accept file name as parameter
        {
            this.fileName = fileName;
            this.path = Path.GetDirectoryName(fileName);// get the directory path of the file
            this.baseName = Path.GetFileNameWithoutExtension(fileName); //get the base name of the file (without extension)
            CreateFile();
        }

        public void CreateFile() // function to create the file if it doesn't exist
        {
            if (!File.Exists(fileName))
            {
                using (FileStream fs = File.Create(fileName))
                {
                    Console.WriteLine("File created successfully.");
                }
            }
            else
            {
                Console.WriteLine("File already exists.");
            }
        }

        public void WriteToFile(string text)  // function to write text to the file
        {
            FileInfo file = new FileInfo(fileName);   // create a FileInfo object to check the size of the file

            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(text);
            }
        }
    }
}
