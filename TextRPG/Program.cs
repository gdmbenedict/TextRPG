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
            Console.CursorVisible = false;

            //setting a player starting position
            int[] pos = { 5, 12 };

            //adding player to map
            map.AddEntity(new Player("player", Size.medium, 14, 14, 14 ,14 ,14, 14, 14), pos);

            pos[0] = 8; 
            pos[1] = 8;

            map.AddEntity(new Enemy("testEnemy", Size.medium, 8, 8, 8, 8, 8, 8, 8), pos);

            map.PrintMap(0,0);

            bool gameOver = false;
            int[] index = new int[2];

            //test game loop
            while (!gameOver)
            {
                for (int i=0; i<map.GetHeight(); i++)
                {
                    for (int j=0; j<map.GetWidth(); j++)
                    {
                        index[0] = i;
                        index[1] = j;

                        if (map.GetEntity(index) != null && !map.GetEntity(index).TookTurn())
                        {
                            gameOver = map.GetEntity(index).ChooseMove(map, index);
                        }

                    }
                }

                map.PrintMap(0, 0);
                map.clearTurns();
            }

            
        }
    }
}
