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
            Random rdm = new Random();

            //storing some variables for UI
            int playerHealth;
            int playerMaxHealth;
            int remainingEnemies = 1;
            bool playerAlive = true;

            //testing map
            string filename = "Dungeon.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Maps\", filename);

            Map map = new Map(path);

            int height = map.GetHeight();
            int width = map.GetWidth();
            
            //setting console window settings
            Console.SetWindowSize(width , height + 10);
            Console.SetBufferSize(width*2 , height*2 );
            Console.CursorVisible = false;

            //setting a player starting position
            int[] pos = { 5, 12 };

            //adding player to map
            map.AddEntity(new Player("player", Size.medium, 14, 14, 14 ,14 ,14, 14, 14), pos);

            playerHealth = map.GetEntity(pos).health.GetHp();
            playerMaxHealth = map.GetEntity(pos).health.GetMaxHp();

            //setting enemy
            
            pos[0] = rdm.Next(1,20);
            pos[1] = rdm.Next(1,20);
            map.AddEntity(new Rat(), pos);

            pos[0] = rdm.Next(1, 20);
            pos[1] = rdm.Next(1, 20);
            map.AddEntity(new Rat(), pos);

            pos[0] = rdm.Next(1, 20);
            pos[1] = rdm.Next(1, 20);
            map.AddEntity(new Rat(), pos);

            pos[0] = rdm.Next(1, 20);
            pos[1] = rdm.Next(1, 20);
            map.AddEntity(new Rat(), pos);

            pos[0] = rdm.Next(1, 20);
            pos[1] = rdm.Next(1, 20);
            map.AddEntity(new Rat(), pos);

            map.PrintMap(0,0);
            printUI(height +1, playerHealth, playerMaxHealth, remainingEnemies, playerAlive);

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

                        if (map.GetEntity(index) != null && !map.GetEntity(index).TookTurn() && map.GetEntity(index).health.GetHp() > 0)
                        {
                            //bool allows player to exit game with escape
                            gameOver = map.GetEntity(index).ChooseAction(map, index);
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
                            playerHealth = entity.health.GetHp();
                        }

                        if (entity.GetName() != "player")
                        {
                            remainingEnemies++;
                        }
                    }
                }

                for (int i = 0; i < map.GetHeight(); i++)
                {
                    for (int j = 0; j < map.GetWidth(); j++)
                    {
                        index[0] = i;
                        index[1] = j;

                        if (map.GetEntity(index) != null && map.GetEntity(index).health.GetHp() <= 0)
                        {
                            map.GetEntity(index).OnDeath(map, index);
                            map.RemoveEntity(index);
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
