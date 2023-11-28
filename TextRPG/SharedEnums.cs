using System.Runtime.CompilerServices;

namespace TextRPG
{
    /*
     * Code to handle shared enums and thier related functions.
     * Author: Matthieu Benedict
     * Last Updated: 2023-11-28
     */

    //damage type enum
    public enum DamageType
    {
        acid,           //0
        bludgeoning,    //1
        cold,           //2
        fire,           //3
        force,          //4
        lightning,      //5
        necrotic,       //6
        piercing,       //7
        poison,         //8
        psychic,        //9
        radiant,        //10
        slashing,       //11
        sound           //12        
    }

    /*
     * Class to handle extension methods for the DamageType Enum
     */
    static class DamageMethods
    {
        /*
         * Extension method that converts the DamageType Enum into an int
         * Input: (DamageType) damageType: the type of damage
         * Output: (int) convertedDamage: the type of damage converted into an integer.
         */
        public static int DamageTypeToInt(this DamageType damageType)
        {
            return (int)damageType;
        }

        /*
         * Extension method that converts the DamageType Enum into an int
         * Input: (int) intDamageType: the type of damage converted into an integer.
         * Output: (DamageType) damageType: the type of damage
         */
        public static DamageType IntToDamageType(int intDamageType)
        {
            return (DamageType)intDamageType;
        }
    }

    //enum defining size of an entity
    public enum Size
    {
        tiny,       // 1/4x1/4
        small,      // 1/2x1/2
        medium,     // 1x1
        large,      // 2x2
        huge,       // 3x3
        Gigantic,   // 4x4
        Collosal    // 5x5
    }

    /*
     * Class to handle extension methods for the DamageType Enum
     */
    static class SizeMethods
    {
        /*
         * Extension method to convert size to int
         * Input: (Size) size: the size of the entity or item
         * Output: (int) intSize: the size of the entity or item expressed as an int
         */
        public static int SizeToInt(this Size size)
        {
            return (int)size;
        }

        /*
         * Extension method to convert from int value of enum to size
         * Input: (int) intSize: the size of the entity or item expressed as an int
         * Output: (Size) size: the size of the entity or item
         */
        public static Size IntToSize(int intsize)
        {
            return (Size)intsize;
        }
    }
}