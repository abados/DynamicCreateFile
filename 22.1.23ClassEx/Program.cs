using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._1._23ClassEx
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StringClass newClass = new StringClass("word");

            newClass.printIt();


            FileClass1 fileHandler = new FileClass1("C:\\Users\\User\\source\\Projects\\Semester3\\Haim\\filesCreation\\file.txt");
            fileHandler.CreateFile();
            fileHandler.WriteToFile("This is a new line of text being added to the file.");

        }
    }
}
