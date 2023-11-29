using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //testing map
            string filename = "TestMap.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Maps\", filename);

            Map map = new Map(path);

            int height = map.GetHeight();
            int width = map.GetWidth();

            //setting console window settings
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width * 2, height * 2);

            map.PrintMap(0,0);

            Console.ReadKey();
        }
    }
}
