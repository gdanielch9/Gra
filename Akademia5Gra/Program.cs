using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Akademia5Gra.Creatures;

namespace Akademia5Gra
{
    class Program
    {

        private static void FileWrite()
        {
            FileStream fileStream = new FileStream("WymiaryOkna.txt",FileMode.Create,FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.WriteLine("20");
            streamWriter.WriteLine("40");
            streamWriter.Close();
            fileStream.Close();
        }

        private static void FileRead()
        {
            FileStream fileStream = new FileStream("WymiaryOkna.txt",FileMode.Open,FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            int height = int.Parse(streamReader.ReadLine());            // rzutowanie na int nie potrzebne jeżeli chcemy tylko wyświetlić w konsoli
            int width = int.Parse(streamReader.ReadLine());

            Console.WriteLine(height);
            Console.WriteLine(width);
            streamReader.Close();
            fileStream.Close();
            }

        static void Main(string[] args)
        {
            //FileWrite();
            //FileRead();
            World word = new World();

            word.RunWorld();
            Console.ReadKey();
        }
    }
}
