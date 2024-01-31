using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Health
    {
        /*
         * Class to handle the health of an gameObject
         * Author: Matthieu Benedict
         * Last Updated: 2024-01-31
         */

        //Health variables
        private int maxHp;
        private int currentHp;

        /*
         * Constructor method for a health object
         * Input: (int) healthMod: the health modifier value of object
         * Output: (Health) health: a health object
         */
        public Health(int healthMod)
        {
            maxHp = healthMod + 10;
            currentHp = maxHp;
        }

        /*
         * Mutator method that sets the maximum hit points of an Entity
         * Input: (int) maxHp: the maximum hit points of an Entity
         */
        public void SetMaxHp(int maxHp)
        {
            int gapHp = this.maxHp - currentHp;
            this.maxHp = maxHp;
            currentHp = this.maxHp - gapHp;

            //sets current hp to 1 if changing maxHp would bring Entity's current Hp to less than 1 
            if (currentHp < 1 && maxHp >= 1)
            {
                currentHp = 1;
            }
        }

        /*
         * Mutator method that modifies the maximum hit points of an Entity by a specified amount
         * Input: (int) maxHpMod: the amount by which the maximum hp is modified
         */
        public void ModMaxHp(int maxHpMod)
        {
            int gapHp = this.maxHp - currentHp;
            maxHp += maxHpMod;
            currentHp = this.maxHp - gapHp;

            //sets current hp to 1 if changing maxHp would bring Entity's current Hp to less than 1 
            if (currentHp < 1 && maxHp >= 1)
            {
                currentHp = 1;
            }
        }

        /*
         * Accessor method that returns the maximum hit points of an Entity
         * Output: (int) maxHp: the maximum hit points of an Entity
         */
        public int GetMaxHp()
        {
            return maxHp;
        }

        /*
         * Mutator method that sets the current hit points of the Entity
         * Input: (int) hp: the current hit points of the Entity
         */
        public void SetHp(int hp)
        {
            currentHp = hp;
        }

        /*
         * Mutator method that modifies the current hit points of the Entity by a spcified amount
         * Input: (int) modHp: the amount by which current hit of the Entity are modified
         */
        public void ModHp(int modHp)
        {
            currentHp += modHp;
        }

        /*
         * Accessor method that returns the current hit points of the Entity
         * Output: (int) currentHp: the current hit points of the Entity
         */
        public int GetHp()
        {
            return currentHp;
        }

    }
}
