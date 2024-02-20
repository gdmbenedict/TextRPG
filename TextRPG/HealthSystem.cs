using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class HealthSystem
    {
        /*
         * Class to handle the health of an gameObject
         * Author: Matthieu Benedict
         * Last Updated: 2024-01-31
         */

        //Health variables
        private int maxHp;
        private int currentHp;
        private int trueHP;

       
        public HealthSystem(int baseHP, int majorHealthMod, int minorHealthMod, int level)
        {
         
        }

        private int CalcHP(int baseHP, int majorHealthMod, int minorHealthMod, int level)
        {
            int calculatedHP;

            calculatedHP = baseHP + minorHealthMod + (2 * majorHealthMod);
            for (int i=0; i<level; i++)
            {
                calculatedHP += ((minorHealthMod + 2 * majorHealthMod) / 3) + 5; //5 insures that no health will be lost per level
            }

            return calculatedHP;
        }
        
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

        
        public int GetMaxHp()
        {
            return maxHp;
        }

        
        public void SetHp(int hp)
        {
            currentHp = hp;
        }

        
        public void ModHp(int modHp)
        {
            currentHp += modHp;
        }

        
        public int GetHp()
        {
            return currentHp;
        }

        public int getTrueHP()
        {
            return trueHP;
        }

    }
}
