using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._1._23ClassEx
{
    public class FileClass1
    {
        private string fileName;
        private string path;
        private string baseName;
        private string newFileName;
        private int fileNumber = 1;

        public FileClass1(string fileName)
        {
            this.fileName = fileName;
            this.path = Path.GetDirectoryName(fileName);
            this.baseName = Path.GetFileNameWithoutExtension(fileName);
        }

        public void CreateFile()
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

        public void WriteToFile(string text)
        {
            FileInfo file = new FileInfo(fileName);

            if (file.Length >= 1000)
            {
                newFileName = path + "\\" + baseName + fileNumber + ".txt";
                fileNumber++;
                if (!File.Exists(newFileName))
                {
                    using (FileStream fs = File.Create(newFileName))
                    {
                        Console.WriteLine("New file created successfully.");
                    }
                }
                else
                {
                    while (File.Exists(newFileName))
                    {
                        fileNumber++;
                        newFileName = path + "\\" + baseName + fileNumber + ".txt";
                    }
                    using (FileStream fs = File.Create(newFileName))
                    {
                        Console.WriteLine("New file created successfully.");
                    }
                }
                fileName = newFileName;
            }

            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(text);
            }
        }
    }
}
