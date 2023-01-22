using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._1._23ClassEx
{
    public class FileClass1
    { // private variables to store file name, path, base name and serial number
        private string fileName;
        private string path;
        private string baseName;
        private string newFileName;
        private int fileNumber = 1;

        public FileClass1(string fileName) // constructor to accept file name as parameter
        {
            this.fileName = fileName;   
            this.path = Path.GetDirectoryName(fileName);// get the directory path of the file
            this.baseName = Path.GetFileNameWithoutExtension(fileName); //get the base name of the file (without extension)
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

            CheckSize(file);

            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(text);
            }
        }

        public void CheckSize(FileInfo file)  // function to write text to the file
        {

            if (file.Length >= 1000)   // check if the file size is greater than or equal to 1000kb
            {
                newFileName = path + "\\" + baseName + fileNumber + ".txt"; // create new file name
                fileNumber++;
                if (!File.Exists(newFileName)) // check if the new file name already exists
                {
                    using (FileStream fs = File.Create(newFileName)) // create new file
                    {
                        Console.WriteLine("New file created successfully.");
                    }
                }
                else // if the new file name already exists, increment the serial number and check again
                {
                    while (File.Exists(newFileName))
                    {
                        fileNumber++;
                        newFileName = path + "\\" + baseName + fileNumber + ".txt";
                    }
                    using (FileStream fs = File.Create(newFileName))    // create new file
                    {
                        Console.WriteLine("New file created successfully.");
                    }
                }
                fileName = newFileName; // update the file name to use the new file name

            }

        }
    }
}
