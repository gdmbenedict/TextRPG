using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Stat
    {
        private int trueStat; //actual stat value of a creature
        private int currentStat; //current stat value, used for calculations
        private int maxStat; //max stat value that can be naturally achieve
        private int statMod; //the modifier value of the stat used for calculations
        private bool unsynched; //bool that tracks if the stat value is synched (true == current)

        public Stat(int statValue, int maxStatValue)
        {
            trueStat = statValue;
            maxStat = maxStatValue;

            currentStat = trueStat;
            statMod = CalcStatMod(currentStat);

            unsynched = false;
        }

        public Stat()
        {
            trueStat = 10;
            maxStat = 20;

            currentStat = trueStat;
            statMod = CalcStatMod(currentStat);
        }
    

        private int CalcStatMod(int statValue)
        {
            return statValue - 10 / 2;
        }

        public int getTrueStat()
        {
            return trueStat;
        }

        public void setTrueStat(int statValue)
        {
            trueStat = statValue;

            if (!unsynched)
            {
                setCurrentStat(trueStat);
            }
        }

        public void modTrueStat(int statModification)
        {
            trueStat += statModification;

            if (!unsynched)
            {
                setCurrentStat(trueStat);
            }
        }

        public int getCurrentStat()
        {
            return currentStat;
        }

        public void setCurrentStat(int statValue)
        {
            currentStat = statValue;

            statMod = CalcStatMod(currentStat);
        }

        public void modCurrentStat(int statModification)
        {
            currentStat += statModification;

            statMod = CalcStatMod(currentStat);
        }

        public int getMaxStat()
        {
            return maxStat;
        }

        public void setMaxStat(int maxStatValue)
        {
            maxStat = maxStatValue;
        }

        public void modMaxStat(int maxStatModification)
        {
            maxStat += maxStatModification;
        }

        public void unsynchStat()
        {
            unsynched = true;
        }

        public void sychStat()
        {
            unsynched = false;

            currentStat = trueStat;
        }

    }
}
