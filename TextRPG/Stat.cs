using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Stat
    {
        /*
         * Class to handle a stat game object
         * Author: Matthieu Benedict
         * Last Updated: 2024-02-21
         */

        private int trueStat; //actual stat value of a game object
        private int currentStat; //current stat value, used for calculations
        private int maxStat; //max stat value that can be naturally achieve
        private int minStat =1; //always set to 1
        private int statMod; //the modifier value of the stat used for calculations
        private bool unsynched; //bool that tracks if the stat value is synched (true == current)
        private bool uncapped; //bool tracking if the stat is beholdent to its max value

        /// <summary>
        /// Consturctor method for a stat.
        /// </summary>
        /// <param name="statValue">the value of the stat</param>
        /// <param name="maxStatValue">the maximum value of the stat</param>
        /// <param name="minValue">the minimum value of the stat</param>
        public Stat(int statValue, int maxStatValue, int minValue)
        {
            minStat = minValue;

            if (statValue < minStat)
            {
                statValue = minStat;
            }

            trueStat = statValue;
            maxStat = maxStatValue;

            currentStat = trueStat;
            statMod = CalcStatMod(currentStat);

            unsynched = false;
            uncapped = false;
        }

        /// <summary>
        /// Consturctor method for a stat.
        /// </summary>
        /// <param name="statValue">the value of the stat</param>
        /// <param name="maxStatValue">the maximum value of the stat</param>
        public Stat(int statValue, int maxStatValue)
        {

            if (statValue < minStat)
            {
                statValue = minStat;
            }

            trueStat = statValue;
            maxStat = maxStatValue;

            currentStat = trueStat;
            statMod = CalcStatMod(currentStat);

            unsynched = false;
            uncapped = false;
        }

        /// <summary>
        /// Polymorphic constructor for a stat, requiring only the stat value.
        /// </summary>
        /// <param name="statValue">the value of the sta</param>
        public Stat(int statValue)
        {
            if (statValue < minStat)
            {
                statValue = minStat;
            }

            trueStat = statValue;
            maxStat = 20;

            currentStat = trueStat;
            statMod = CalcStatMod(currentStat);

            unsynched = false;
            uncapped = false;
        }

        /// <summary>
        /// Polymorphic contructor for a stat requiring no inputs
        /// </summary>
        public Stat()
        {
            trueStat = 10;
            maxStat = 20;

            currentStat = trueStat;
            statMod = CalcStatMod(currentStat);

            unsynched = false;
            uncapped = false;
        }

        /// <summary>
        /// Utility function that returns the stat mod for a stat
        /// </summary>
        /// <param name="statValue">current stat value, used for calculations</param>
        /// <returns>the modifier value of the stat used for calculations</returns>
        private int CalcStatMod(int statValue)
        {
            return statValue - 10 / 2;
        }

        /// <summary>
        /// Accessor method for the true value of a stat
        /// </summary>
        /// <returns>actual stat value of a game object</returns>
        public int GetTrueStat()
        {
            return trueStat;
        }

        /// <summary>
        /// Mutator method for the true value of a stat
        /// </summary>
        /// <param name="statValue">intended value for the true stat</param>
        public void SetTrueStat(int statValue)
        {
            trueStat = statValue;

            if (trueStat < minStat)
            {
                trueStat = minStat;
            }

            if (!unsynched)
            {
                SetCurrentStat(trueStat);
            }
        }

        /// <summary>
        /// Mutator method for the true value of a stat
        /// </summary>
        /// <param name="statModification">integer value by which the true stat of a game object will be modified</param>
        public void ModTrueStat(int statModification)
        {
            trueStat += statModification;

            if (trueStat < minStat)
            {
                trueStat = minStat;
            }

            if (!unsynched)
            {
                SetCurrentStat(trueStat);
            }
        }

        /// <summary>
        /// Accessor method for the current value of a stat
        /// </summary>
        /// <returns>the current value (used for calculations) of a stat</returns>
        public int GetCurrentStat()
        {
            return currentStat;
        }

        /// <summary>
        /// Mutator method for the current value of a stat
        /// </summary>
        /// <param name="statValue">the intended value for the current value (used for calculations) of a stat</param>
        public void SetCurrentStat(int statValue)
        {
            currentStat = statValue;

            if (currentStat < minStat)
            {
                currentStat = minStat;
            }

            if(currentStat > maxStat && !uncapped)
            {
                currentStat = maxStat;
            }

            statMod = CalcStatMod(currentStat);
        }

        /// <summary>
        /// Mutator method for the current value of a stat
        /// </summary>
        /// <param name="statModification">integer vlaue by which the current value of the stat will be modified</param>
        public void ModCurrentStat(int statModification)
        {
            currentStat += statModification;

            if (currentStat < minStat)
            {
                currentStat = minStat;
            }

            if (currentStat > maxStat && !uncapped)
            {
                currentStat = maxStat;
            }

            statMod = CalcStatMod(currentStat);
        }

        /// <summary>
        /// Accessor method for the maximum value of a stat
        /// </summary>
        /// <returns>max stat value that can be naturally achieve</returns>
        public int GetMaxStat()
        {
            return maxStat;
        }

        /// <summary>
        /// Mutator method for the maximum value of a stat
        /// </summary>
        /// <param name="maxStatValue">the intended maximum value of the stat</param>
        public void SetMaxStat(int maxStatValue)
        {
            maxStat = maxStatValue;

            if(maxStat < minStat)
            {
                maxStat = minStat;
            }

            if (!unsynched)
            {
                SetCurrentStat(trueStat);
            }

            if (currentStat > maxStat && !uncapped)
            {
                SetCurrentStat(maxStat);
            }
        }

        /// <summary>
        /// Mutator method for the maximum value of a stat
        /// </summary>
        /// <param name="maxStatModification">integer value by which the maximum value for the stat will be modified</param>
        public void ModMaxStat(int maxStatModification)
        {
            maxStat += maxStatModification;

            if (maxStat < minStat)
            {
                maxStat = minStat;
            }

            if (!unsynched)
            {
                SetCurrentStat(trueStat);
            }

            if (currentStat > maxStat && !uncapped)
            {
                SetCurrentStat(maxStat);
            }
        }

        /// <summary>
        /// Mutator method the unsychs the true stat and the current class
        /// </summary>
        public void UnsynchStat()
        {
            unsynched = true;
        }

        /// <summary>
        /// Mutator method that synchs the true stat and the current stat
        /// </summary>
        public void SychStat()
        {
            unsynched = false;

            SetCurrentStat(trueStat);
        }

        /// <summary>
        /// Mutator method that disables the maximum value for the stat.
        /// </summary>
        public void UncapStat()
        {
            uncapped = true;

            if (trueStat > maxStat)
            {
                currentStat = trueStat;
            }
        }

        /// <summary>
        /// Mutator method that enables the maximum value for the stat.
        /// </summary>
        public void CapStat()
        {
            uncapped = false;

            if (currentStat > maxStat)
            {
                SetCurrentStat(maxStat);
            }
        }
    }
}
