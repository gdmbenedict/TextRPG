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
            //storing some variables for UI
            int playerHealth;
            int playerMaxHealth;
            int remainingEnemies = 1;
            bool playerAlive = true;

            //testing map
            string filename = "TestMap.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Maps\", filename);

            Map map = new Map(path);

            int height = map.GetHeight();
            int width = map.GetWidth();

            //setting console window settings
            Console.SetWindowSize(width * 2, height * 2);
            Console.SetBufferSize(width * 2, height * 2);
            Console.CursorVisible = false;

            //setting a player starting position
            int[] pos = { 5, 12 };

            //adding player to map
            map.AddEntity(new Player("player", Size.medium, 14, 14, 14 ,14 ,14, 14, 14), pos);

            playerHealth = map.GetEntity(pos).GetHp();
            playerMaxHealth = map.GetEntity(pos).GetMaxHp();

            //settinh enemy
            pos[0] = 8; 
            pos[1] = 8;

            map.AddEntity(new Enemy("testEnemy", Size.medium, 8, 8, 8, 8, 8, 8, 8), pos);

            map.PrintMap(0,0);
            printUI(height + 1, playerHealth, playerMaxHealth, remainingEnemies, playerAlive);

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

                        if (map.GetEntity(index) != null && !map.GetEntity(index).TookTurn() && map.GetEntity(index).GetHp() > 0)
                        {
                            //bool allows player to exit game with escape
                            gameOver = map.GetEntity(index).ChooseMove(map, index);
                        }

                        if (map.GetEntity(index) != null && map.GetEntity(index).GetHp() <= 0)
                        {
                            map.RemoveEntity(index);
                        }

                    }
                }

                playerAlive = false;
                remainingEnemies = 0;
                playerHealth = 0;

                //update UI loop
                foreach (Entity entity in map.GetEntities())
                {

                    if (entity != null)
                    {
                        if (entity.GetName() == "player")
                        {
                            playerAlive = true;
                            playerHealth = entity.GetHp();
                        }

                        if (entity.GetName() == "testEnemy")
                        {
                            remainingEnemies++;
                        }
                    }
                }

                map.PrintMap(0, 0);
                map.clearTurns();

                //ends game after showing win message.
                gameOver = printUI(height+1, playerHealth, playerMaxHealth, remainingEnemies, playerAlive);

            }

            
        }

        //method that prints the UI to the screen
        private static bool printUI(int startPosY, int health, int maxHealth, int enemies, bool playerAlive)
        {
            //clearing previous UI
            Console.SetCursorPosition(0, startPosY);
            Console.Write(new String(' ', Console.BufferWidth));
            Console.Write(new String(' ', Console.BufferWidth));
            Console.Write(new String(' ', Console.BufferWidth));
            Console.Write(new String(' ', Console.BufferWidth));
            Console.Write(new String(' ', Console.BufferWidth));
            Console.Write(new String(' ', Console.BufferWidth));

            //setting color
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, startPosY);

            Console.WriteLine("============================");

            //writting text to inform which Icon you are
            Console.Write("You are the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" icon.");

            //writting health text
            Console.WriteLine("You have " + health + "/" + maxHealth + " hp.");

            //regular game UI
            if (enemies > 0 && playerAlive)
            {
                //writting remaining Enemies
                Console.WriteLine("There are " + enemies + " enemies remaining.");
            }
            //player lose
            else if (!playerAlive)
            {
                Console.WriteLine("You Lose...");
            }
            //player win
            else if (enemies <= 0)
            {
                Console.WriteLine("You Win!");
            }


            Console.WriteLine("============================");

            if (enemies <=0 || !playerAlive)
            {
                Console.ReadKey();
                return true;
            }

            return false;
        }
    }
}
