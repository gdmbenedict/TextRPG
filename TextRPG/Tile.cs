using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Tile
    {
        /*
         * Class for a tile object in an text based RPG map.
         * Author: Matthieu Benedict
         * Last Updated: 2023-11-27
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

        //Variables
        private char symbol;
        private string name;
        private ConsoleColor color;
        private bool impassable;
        private bool dangerous;
        private int damage;
        private DamageType damageType;


        /*
         * Constructor method for a tile object.
         * Input: (char) tileType: character which determines what type of tile is used
         * Output: (Tile) tile: an object of type tile.
         */
        public Tile(char tileType)
        {
            /*
             * Legend for tile types:
             * air      ' '
             * door     '/'
             * floor    '.'
             * lava     'l'
             * wall     '-' or '|' or '+'
             * water    'w'
             */

            switch (tileType)
            {
                //open air
                case ' ':
                    symbol = tileType;
                    name = "air";
                    color = ConsoleColor.White;
                    impassable = true;
                    dangerous = false;
                    damage = 0;
                    damageType = DamageType.force;
                    break;

                case '/':
                    symbol = tileType;
                    name = "door";
                    color = ConsoleColor.Gray;
                    impassable = false;
                    dangerous = false;
                    damage = 0;
                    damageType = DamageType.force;
                    break;

                case '.':
                    symbol = tileType;
                    name = "floor";
                    color = ConsoleColor.DarkGray;
                    impassable = false;
                    dangerous = false;
                    damage = 0;
                    damageType = DamageType.force;
                    break;

                case 'l':
                    symbol = '~';
                    name = "lava";
                    color = ConsoleColor.DarkRed;
                    impassable = false;
                    dangerous = true;
                    damage = 10;
                    damageType = DamageType.fire;
                    break;

                case '-':
                case '|':
                case '+':
                    symbol = tileType;
                    name = "wall";
                    color = ConsoleColor.Gray;
                    impassable = true;
                    dangerous = false;
                    damage = 0;
                    damageType = DamageType.force;
                    break;

                case 'w':
                    symbol = '~';
                    name = "water";
                    color = ConsoleColor.Blue;
                    impassable = false;
                    dangerous = true;
                    damage = 10;
                    damageType = DamageType.fire;
                    break;

                default:
                    break;
            }
        }

        /*
         * Mutator method that sets name
         * Input: (string) name: the name of the tile
         */
        public void SetName(string name)
        {
            this.name = name;
        }

        /*
         * Accessor method that gets name of tile
         * Output: (string) name: the name of the tile
         */
        public string GetName()
        {
            return name;
        }

        /*
         * Mutator method that sets symbol of tile
         * Input: (char) symbol: the symbol you want to set the tile as
         */
        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }

        /*
         * Accessor method for symbol of tile
         * Output: (char) symbol: the symbol of the tile
         */
        public char GetSymbol()
        {
            return symbol;
        }

        /*
         * Mutator method that sets color of the tile
         * Input: (enum ConsoleColor) color: the color of the tile
         */
        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        /*
         * Accessor method for the color of the tile
         * Output: (enum ConsoleColor) color: the color of the tile
         */
        public ConsoleColor GetColor()
        {
            return color;
        }

        /*
         * Mutator method for the passability (letting player walk over / through tile) of the tile
         * Input: (bool) impassable: bool handling if the player can walk through tile
         */
        public void SetImpassable(bool impassable)
        {
            this.impassable = impassable;
        }

        /*
         * Accessor method for the passability (letting player walk over / through tile) of the tile
         * Output: (bool) impassable: bool handling if the player can walk through tile
         */
        public bool GetImpassable()
        {
            return impassable;
        }

        /*
         * Mutator method for if the tile deals damage when walked over
         * Input: (bool) dangerous: bool handling if the tile deals damage
         */
        public void SetDangerous(bool dangerous)
        {
            this.dangerous = dangerous;
        }

        /*
         * Accessor method for if the tile deals damage when walked over
         * Output: (bool) dangerous: bool handling if the tile deals damage
         */
        public bool GetDangerous()
        {
            return dangerous;
        }

        /*
         * Mutator method for the damage the tile deals when walked on
         * Input: (int) damage: the damage value the tile outputs when walked on
         */
        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        /*
         * Mutator method the sets the type of damage done by the tile
         * Input: (DamageType) damageType: the type of damage done by the tile
         */
        public void SetDamageType(DamageType damageType)
        {
            this.damageType = damageType;
        }

        /*
         * Method that sends the damage details in the form of an int array
         * Output: (int[ ]) damageDetails: the details of damage stored in an int array
         *      damageDetails[0] = damage value
         *      damageDetails[1] = damage type
         */
        public int[] DealDamage()
        {
            //int variable to store damage type according to type to int conversion
            int damageType;

            //converting damage type into int
            switch (this.damageType)
            {
                case DamageType.acid:
                    damageType = 0;
                    break;

                case DamageType.bludgeoning:
                    damageType = 1;
                    break;

                case DamageType.cold:
                    damageType = 2;
                    break;

                case DamageType.fire:
                    damageType = 3;
                    break;

                case DamageType.force:
                    damageType = 4;
                    break;

                case DamageType.lightning:
                    damageType = 5;
                    break;

                case DamageType.necrotic:
                    damageType = 6;
                    break;

                case DamageType.piercing:
                    damageType = 7;
                    break;

                case DamageType.poison:
                    damageType = 8;
                    break;

                case DamageType.psychic:
                    damageType = 9;
                    break;

                case DamageType.radiant:
                    damageType = 10;
                    break;

                case DamageType.slashing:
                    damageType = 11;
                    break;

                case DamageType.sound:
                    damageType = 12;
                    break;

                default:
                    damageType = 4;
                    break;
            }

            int[] damageDetails = {damage, damageType};
            return damageDetails;
        }
    }
}
