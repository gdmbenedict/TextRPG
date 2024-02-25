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
         * Last Updated: 2024-02-23
         */

        //Entity variables
        private string name; //the name of the Entity
        private Size size; //the size of the Entity
        private ConsoleColor color; //color of the Entity respresentation
        private char symbol; //the graphical representation of the Entity

        //Stats and attributes
        public HealthSystem health;
        public Stat str; //the strength stat of the Entity
        public Stat dex; //the dexterity stat of the Entity
        public Stat con; //the constitution stat of the Entity
        public Stat itl; //the intelligence stat of the Entity
        public Stat wis; //the wisdom stat of the Entity
        public Stat cha; //the charisma stat of the Entity
        public Stat luc; //the luck stat if the Entity
        private bool[] resistances; //damage type resistances of the Entity
        private CreatureType creatureType; //The type that the creature is

        //temporary baseline dodge chance
        private float dodgeChance = 50.0f;

        private bool tookTurn;

        /// <summary>
        /// Constructor for an Entity
        /// </summary>
        /// <param name="name">the name of the Entity</param>
        /// <param name="symbol">the graphical representation of the Entity</param>
        /// <param name="size">the size of the Entity</param>
        /// <param name="str">the strength stat of the Entity</param>
        /// <param name="dex">the dexterity stat of the Entity</param>
        /// <param name="con">the constitution stat of the Entity</param>
        /// <param name="itl">the intelligence stat of the Entity</param>
        /// <param name="wis">the wisdom stat of the Entity</param>
        /// <param name="cha">the charisma stat of the Entity</param>
        /// <param name="luc">the luck stat if the Entity</param>
        /// <param name="resistances">damage type resistances of the Entity</param>
        public Entity(string name, char symbol, Size size, int str, int dex, int con, int itl, int wis, int cha, int luc, bool[] resistances) 
        { 
            //setting entity variables
            this.name = name;
            this.symbol = symbol;
            this.size = size;
            color = ConsoleColor.Gray;

            //Stats and Attributes
            health = null;
            this.str = new Stat(str);
            this.dex = new Stat(dex);
            this.con = new Stat(con);
            this.itl = new Stat(itl);
            this.wis = new Stat(wis);
            this.cha = new Stat(cha);
            this.luc = new Stat(luc);
            this.resistances = resistances;

            //other
            tookTurn = false;
        }

        /// <summary>
        /// Polymorphic constructor for an Entity that doesn't specify resistances
        /// </summary>
        /// <param name="name">the name of the Entity</param>
        /// <param name="symbol">the graphical representation of the Entity</param>
        /// <param name="size">the size of the Entity</param>
        /// <param name="str">the strength stat of the Entity</param>
        /// <param name="dex">the dexterity stat of the Entity</param>
        /// <param name="con">the constitution stat of the Entity</param>
        /// <param name="itl">the intelligence stat of the Entity</param>
        /// <param name="wis">the wisdom stat of the Entity</param>
        /// <param name="cha">the charisma stat of the Entity</param>
        /// <param name="luc">the luck stat if the Entity</param>
        public Entity(string name, char symbol, Size size, int str, int dex, int con, int itl, int wis, int cha, int luc)
        {
            //setting entity variables
            this.name = name;
            this.symbol = symbol;
            this.size = size;
            color = ConsoleColor.Gray;

            //Stats and Attributes
            health = null;
            this.str = new Stat(str);
            this.dex = new Stat(dex);
            this.con = new Stat(con);
            this.itl = new Stat(itl);
            this.wis = new Stat(wis);
            this.cha = new Stat(cha);
            this.luc = new Stat(luc);
            this.resistances = new bool[13];

            //other
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
        public abstract bool ChooseAction(Map map, int[] startPos);

        /*
         * Method that sends an attack's damageDetails in the form of an int array
         * Output: (int[]) damageDetails: the details of the attack damage stored in an int array
         *      damageDetails[0] = damage value
         *      damageDetails[1] = damage type
         */
        public abstract void Attack(Entity target);
        

        /*
         * Method that takes damageDetails and does damage to the Entity
         * Input: (int[]) damageDetails: the details of the attack damage stored in an int array
         *      damageDetails[0] = damage value
         *      damageDetails[1] = damage type
         */
        public void TakeDamage(int[] damageDetails)
        {
            //checks if resistant to damage
            if (resistances[damageDetails[1]])
            {
                damageDetails[0] /= 2; //halves damage
            }

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

        /// <summary>
        /// Accessor method that returns the resistances of an Entity
        /// </summary>
        /// <returns>damage type resistances of the Entity</returns>
        public bool[] getResistances()
        {
            return resistances;
        }

        /// <summary>
        /// Mutator method that sets all resistances of an Entity
        /// </summary>
        /// <param name="resistances">damage type resistances of the Entity</param>
        public void setResistances(bool[] resistances)
        {
            this.resistances = resistances;
        }

        /// <summary>
        /// Mutator method that adds a single resistance to the list of resistances of an Entity
        /// </summary>
        /// <param name="resistanceInt">The DamageType equivilent in int format</param>
        public void addResistance(int resistanceInt)
        {
            resistances[resistanceInt] = true;
        }

        /// <summary>
        /// Mutator method that removes a single resistance to the list of resistances of an Entity
        /// </summary>
        /// <param name="resistanceInt">The DamageType equivilent in int format</param>
        public void removeResistance(int resistanceInt)
        {
            resistances[resistanceInt] = false;
        }

        public float GetDodgeChance()
        {
            return dodgeChance;
        }

        public bool TookTurn()
        {
            return tookTurn;
        }
    }
}
