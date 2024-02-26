using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    //Player class extends the Entity class
    internal class Player : Entity
    {
        /*
         * Class for a Player object in an text based RPG.
         * Author: Matthieu Benedict
         * Last Updated: 2023-11-30
         */

        /*
         * Constructor method for a Player object
         * Input: (string) name: the name of the Entity
         * Input: (Size) size: the size of the Entity
         * Input: (int) str: the strength stat of the Entity
         * Input: (int) dex: the dexterity stat of the Entity
         * Input: (int) con: the constitution stat of the Entity
         * Input: (int) itl: the intelligence stat of the Entity
         * Input: (int) wis: the wisdom stat of the Entity
         * Input: (int) cha: the charisma stat of the Entity
         * Input: (int) luc: the luck stat if the Entity
         * Output: (Entity) entity: an object of type Entity
         */
        public Player(string name, Size size, int str, int dex, int con, int itl, int wis, int cha, int luc) : base(name, '@', size, str, dex, con, itl, wis, cha, luc)
        {
            //sets color of the player to yellow
            base.SetColor(ConsoleColor.Yellow);

            health = new HealthSystem(10, this.con.GetStatMod(), this.str.GetStatMod(), 1);
        }

        /*
         * Method that moves an entity in the map
         * Input: (Map) map: the map that the Entity is on
         * Input: (int[]) startPos: the starting position of the moving Entity on the map
         *      startPos[0]: the Y coordinate of the Entity's starting position
         *      startPos[1]: the X coordinate of the Entity's starting position
         */
        public override bool ChooseAction(Map map, int[] starPos)
        {
            //declaring variables
            int[] endPos = { starPos[0], starPos[1] };

            //getting input from player
            ConsoleKeyInfo input = Console.ReadKey();

            //switch statement to determine which tile to move to
            switch (input.Key)
            {
                //move up
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    endPos[0]--;
                    break;

                //move down
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    endPos[0]++;
                    break;

                //move leftw
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    endPos[1]--;
                    break;

                //move right
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    endPos[1]++;
                    break;

                case ConsoleKey.Escape:
                    return true;
                    break;
            }

            //perform move
            base.Move(map, starPos, endPos);

            return false;

        }

        public override int[] GetDamage()
        {
            int[] damageDetails = new int[2];
            Random rnd = new Random();

            damageDetails[0] = rnd.Next(4) + str.GetStatMod();
            damageDetails[1] = DamageType.bludgeoning.DamageTypeToInt();

            if (damageDetails[0] <= 0)
            {
                damageDetails[0] = 1;
            }

            return damageDetails;
        }

        public override void OnDeath(Map map, int[] pos)
        {
            throw new NotImplementedException();
        }

        public override void specialFunction()
        {
            throw new NotImplementedException();
        }
    }
}
