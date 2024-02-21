using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal abstract class Entity
    {
        /*
         * Class for a Entity object in an text based RPG.
         * Author: Matthieu Benedict
         * Last Updated: 2024-01-31
         */

        //Entity variables
        private string name;
        private Size size;
        private ConsoleColor color;
        private char symbol;
        public HealthSystem health;
        public Stat str;
        public Stat dex;
        public Stat con;
        public Stat itl;
        public Stat wis;
        public Stat cha;
        public Stat luc;
        private bool tookTurn;

        /*
         * Constructor method for an abstract Entity object
         * Input: (string) name: the name of the Entity
         * Input: (char) symbol: the graphical representation of the Entity
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
        public Entity(string name, char symbol, Size size, int str, int dex, int con, int itl, int wis, int cha, int luc) 
        { 
            //setting entity variables
            this.name = name;
            this.symbol = symbol;
            this.size = size;
            this.str = new Stat(str);
            this.dex = new Stat(dex);
            this.con = new Stat(con);
            this.itl = new Stat(itl);
            this.wis = new Stat(wis);
            this.cha = new Stat(cha);

            //setting default color
            color = ConsoleColor.Gray;

            health = new HealthSystem(con);

            tookTurn = false;
        }

        /*
         * Method that moves an entity in the map
         * Input: (Map) map: the map that the Entity is on
         * Input: (int[]) startPos: the starting position of the moving Entity on the map
         *      startPos[0]: the Y coordinate of the Entity's starting position
         *      startPos[1]: the X coordinate of the Entity's starting position
         * Input: (int[]) endPos: the desired ending position of the moving Entity
         *      endPos[0]: the Y coordinate of the Entity's desired end position
         *      endPos[1]: the X coordinate of the Entity's desired end position
         */
        public void Move(Map map, int[] startPos, int[] endPos)
        {

            //check desired position if within bounds of map
            if (endPos[0] < 0 || endPos[0] >= map.GetHeight() || endPos[1] < 0 || endPos[1] >= map.GetWidth())
            {
                return; //fail to move
            }

            //checks if there is an Entity to attack
            else if (map.GetEntity(endPos) != null)
            {
                Attack(map.GetEntity(endPos)); //attacks entity
            }

            //check if Tile is impassable
            else if (map.GetTile(endPos).GetImpassable())
            {
                return; //fail to move
            }

            //moves
            else
            {
                //deal damage to player standing on dangerous tile
                if (map.GetTile(endPos).GetDangerous())
                {
                    map.GetTile(endPos).DealDamage(this);
                }

                map.AddEntity(map.GetEntity(startPos), endPos); //puts entity into new location
                map.RemoveEntity(startPos); //removes entity from old location
            }

            tookTurn = true;
        }

        /*
         * abstract method for choosing movement, based on child
         */
        public abstract bool ChooseMove(Map map, int[] startPos);

        /*
         * Method that sends an attack's damageDetails in the form of an int array
         * Output: (int[]) damageDetails: the details of the attack damage stored in an int array
         *      damageDetails[0] = damage value
         *      damageDetails[1] = damage type
         */
        public void Attack(Entity target)
        {
            int damageType = DamageType.bludgeoning.DamageTypeToInt();
            int damage = 1 * size.SizeToInt() + str.GetStatMod();
            int[] damageDetails = { damage, damageType };

            target.TakeDamage(damageDetails);
        }

        /*
         * Method that takes damageDetails and does damage to the Entity
         * Input: (int[]) damageDetails: the details of the attack damage stored in an int array
         *      damageDetails[0] = damage value
         *      damageDetails[1] = damage type
         */
        public void TakeDamage(int[] damageDetails)
        {
            health.ModHp(-damageDetails[0]);
        }

        /*
         * Mutator method that sets name of the Entity
         * Input: (string) name: the name of the Entity
         */
        public void SetName(string name)
        {
            this.name = name;
        }

        /*
         * Accessor method that gets the name of an Entity
         * Output: (string) name: the name of the Entity
         */
        public string GetName()
        {
            return name;
        }

        /*
         * Mutator method that sets the graphical representation of the Entity
         * Input: (char) symbol: the graphical representation of the Entity
         */
        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }

        /*
         * Accessor method that returns the graphical representation of the Entity
         * Output: (char) symbol: the graphical representation of the Entity
         */
        public char GetSymbol()
        {
            return symbol;
        }

        /*
         * Mutator method that sets the color of the graphical representation of the Entity
         * Input: (ConsoleColor) color: the color of the graphical representation of the Entity
         */
        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        /*
         * Accessor method that returns the color of the graphical representation of the Entity
         * Output: (ConsoleColor) color: the color of the graphical representation of the Entity
         */
        public ConsoleColor GetColor()
        {
            return color;
        }

        /*
         * Mutator method that sets the size of the Entity
         * Input: (Size) size: the size of the Entity
         */
        public void SetSize(Size size)
        {
            this.size = size;
        }

        /*
         * Accessor method that returns the size of the Entity
         * Output: (Size) size: the size of the Entity
         */
        public Size GetSize()
        {
            return size;
        }
    }
}
