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
         * Last Updated: 2023-11-28
         */

        //Entity variables
        private string name;
        private Size size;
        private char symbol;
        private int maxHp;
        private int currentHp;
        private int str;
        private int dex;
        private int con;
        private int itl;
        private int wis;
        private int cha;
        private int luc;

        /*
         * Constructor method for an abstract Entity object.
         * Input: (string) name: the name of the entity.
         * Input: (char) symbol: the graphical representation of the entity.
         * Input: (int) maxHp: the max number of hit points of the entity.
         * Input: (int) str: the strength stat of the entity.
         * Input: (int) dex: the dexterity stat of the entity.
         * Input: (int) con: the constitution stat of the entity.
         * Input: (int) itl: the intelligence stat of the entity.
         * Input: (int) wis: the wisdom stat of the entity.
         * Input: (int) cha: the charisma stat of the entity.
         * Input: (int) luc: the luck stat if the entity.
         * Output: (Entity) entity: an object of type Entity.
         */
        public Entity(string name, char symbol, Size size, int maxHp, int str, int dex, int con, int itl, int wis, int cha, int luc) 
        { 
            this.name = name;
            this.symbol = symbol;
            this.size = size;
            this.maxHp = maxHp;
            this.str = str;
            this.dex = dex;
            this.con = con;
            this.itl = itl;
            this.wis = wis;
            this.cha = cha;
            this.luc = luc;

        }

        public int[] Attack(Entity target)
        {
            int damage = 1 + GetStrMod();
            
        }

        /*
         * Mutator method that sets name of the Entity
         * Input: (string) name: the name of the Entity
         */
        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {

        }
    }
}
