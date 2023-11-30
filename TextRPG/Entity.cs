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
        private ConsoleColor color;
        private char symbol;
        private int maxHp;
        private int currentHp;
        private int str;
        private int strMod;
        private int dex;
        private int dexMod;
        private int con;
        private int conMod;
        private int itl;
        private int itlMod;
        private int wis;
        private int wisMod;
        private int cha;
        private int chaMod;
        private int luc;
        private int lucMod;

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
            this.str = str;
            this.dex = dex;
            this.con = con;
            this.itl = itl;
            this.wis = wis;
            this.cha = cha;
            this.luc = luc;

            //setting default color
            color = ConsoleColor.Gray;

            //Getting derived values
            currentHp = maxHp;
            strMod = getMod(str);
            dexMod = getMod(dex);
            conMod = getMod(con);
            itlMod = getMod(itl);
            wisMod = getMod(wis);
            chaMod = getMod(cha);

            maxHp = calcMaxHp();
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
                map.AddEntity(map.GetEntity(startPos), endPos); //puts entity into new location
                map.RemoveEntity(startPos); //removes entity from old location
            }
        }

        /*
         * Method that sends an attack's damageDetails in the form of an int array
         * Output: (int[]) damageDetails: the details of the attack damage stored in an int array
         *      damageDetails[0] = damage value
         *      damageDetails[1] = damage type
         */
        public void Attack(Entity target)
        {
            int damageType = DamageType.bludgeoning.DamageTypeToInt();
            int damage = 1 * size.SizeToInt() + strMod;
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
            currentHp -= damageDetails[0];
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

        /*
         * Mutator method that sets the strength stat of the Entity
         * Input: (int) str: the strength stat of the Entity
         */
        public void SetStr(int str)
        {
            this.str = str;
            strMod = getMod(this.str);
        }

        /*
         * Mutator method that modifies the strength stat of the Entity by a specified amount
         * Input: (int) modStr: the amount by which the strength of the Entity will be modified
         */
        public void ModStr(int modStr)
        {
            str += modStr;
            strMod = getMod(str);
        }

        /*
         * Accessor method that returns the strength stat of the Entity
         * Output: (int) str: the strength stat of the Entity
         */
        public int GetStr()
        {
            return str;
        }

        /*
         * Accessor method that returns the strength modifier of the Entity
         * Output: (int) strMod: the strength modifier of the Entity
         */
        public int GetStrMod()
        {
            return strMod;
        }

        /*
         * Mutator method that sets the dexterity stat of the Entity
         * Input: (int) str: the dexterity stat of the Entity
         */
        public void SetDex(int dex)
        {
            this.dex = dex;
            dexMod = getMod(this.dex);
        }

        /*
         * Mutator method that modifies the dexterity stat of the Entity by a specified amount
         * Input: (int) modDex: the amount by which the dexterity of the Entity will be modified
         */
        public void ModDex(int modDex)
        {
            dex += modDex;
            dexMod = getMod(dex);
        }

        /*
         * Accessor method that returns the dexterity stat of the Entity
         * Output: (int) dex: the dexterity stat of the Entity
         */
        public int GetDex()
        {
            return dex;
        }

        /*
         * Accessor method that returns the dexterity modifier of the Entity
         * Output: (int) dexMod: the dexterity modifier of the Entity
         */
        public int GetDexMod()
        {
            return dexMod;
        }

       /*
        * Mutator method that sets the constituion stat of the Entity
        * Input: (int) con: the constituion stat of the Entity
        */
        public void SetCon(int con)
        {
            this.con = con;
            conMod = getMod(this.con);

            //changing Hp to match
            SetMaxHp(calcMaxHp());
        }

        /*
         * Mutator method that modifies the constituion stat of the Entity by a specified amount
         * Input: (int) modCon: the amount by which the constituion of the Entity will be modified
         */
        public void ModCon(int modCon)
        {
            con += modCon;
            conMod = getMod(con);

            //changing Hp to match
            SetMaxHp(calcMaxHp());
        }

        /*
         * Accessor method that returns the constituion stat of the Entity
         * Output: (int) con: the constituion stat of the Entity
         */
        public int GetCon()
        {
            return con;
        }

        /*
         * Accessor method that returns the constituion modifier of the Entity
         * Output: (int) conMod: the constituion modifier of the Entity
         */
        public int GetConMod()
        {
            return conMod;
        }

       /*
        * Mutator method that sets the intelligence stat of the Entity
        * Input: (int) itl: the intelligence stat of the Entity
        */
        public void SetItl(int itl)
        {
            this.itl = itl;
            itlMod = getMod(this.itl);
        }

        /*
         * Mutator method that modifies the intelligence stat of the Entity by a specified amount
         * Input: (int) modItl: the amount by which the intelligence of the Entity will be modified
         */
        public void ModItl(int modItl)
        {
            itl += modItl;
            itlMod = getMod(itl);
        }

        /*
         * Accessor method that returns the intelligence stat of the Entity
         * Output: (int) itl: the intelligence stat of the Entity
         */
        public int GetItl()
        {
            return itl;
        }

        /*
         * Accessor method that returns the intelligence modifier of the Entity
         * Output: (int) itlMod: the intelligence modifier of the Entity
         */
        public int GetItlMod()
        {
            return itlMod;
        }

       /*
        * Mutator method that sets the wisdom stat of the Entity
        * Input: (int) wis: the wisdom stat of the Entity
        */
        public void SetWis(int wis)
        {
            this.wis = wis;
            wisMod = getMod(this.wis);
        }

        /*
         * Mutator method that modifies the wisdom stat of the Entity by a specified amount
         * Input: (int) modWis: the amount by which the wisdom of the Entity will be modified
         */
        public void ModWis(int modWis)
        {
            wis += modWis;
            wisMod = getMod(wis);
        }

        /*
         * Accessor method that returns the wisdom stat of the Entity
         * Output: (int) wis: the wisdom stat of the Entity
         */
        public int GetWis()
        {
            return wis;
        }

        /*
         * Accessor method that returns the wisdom modifier of the Entity
         * Output: (int) wisMod: the wisdom modifier of the Entity
         */
        public int GetWisMod()
        {
            return wisMod;
        }

       /*
        * Mutator method that sets the charisma stat of the Entity
        * Input: (int) cha: the charisma stat of the Entity
        */
        public void SetCha(int cha)
        {
            this.cha = cha;
            chaMod = getMod(this.cha);
        }

        /*
         * Mutator method that modifies the charisma stat of the Entity by a specified amount
         * Input: (int) modCha: the amount by which the charisma of the Entity will be modified
         */
        public void ModCha(int modCha)
        {
            cha += modCha;
            chaMod = getMod(cha);
        }

        /*
         * Accessor method that returns the charisma stat of the Entity
         * Output: (int) cha: the charisma stat of the Entity
         */
        public int GetCha()
        {
            return cha;
        }

        /*
         * Accessor method that returns the charisma modifier of the Entity
         * Output: (int) chaMod: the charisma modifier of the Entity
         */
        public int GetChaMod()
        {
            return chaMod;
        }

        /*
         * Mutator method that sets the luck stat of the Entity
         * Input: (int) luc: the luck stat of the Entity
         */
        public void SetLuc(int luc)
        {
            this.luc = luc;
            lucMod = getMod(this.luc);
        }

        /*
         * Mutator method that modifies the luck stat of the Entity by a specified amount
         * Input: (int) modLuc: the amount by which the luck of the Entity will be modified
         */
        public void ModLuc(int modLuc)
        {
            luc += modLuc;
            lucMod = getMod(luc);
        }

        /*
         * Accessor method that returns the luck stat of the Entity
         * Output: (int) luc: the luck stat of the Entity
         */
        public int GetLuc()
        {
            return luc;
        }

        /*
         * Accessor method that returns the luck modifier of the Entity
         * Output: (int) lucMod: the luck modifier of the Entity
         */
        public int GetLucMod()
        {
            return lucMod;
        }

        /*
         * Utility method that calculates the modifier for a stat based on the stat
         * Input: (int) stat: that base stat for the modifier
         */
        private int getMod(int stat)
        {
            return (int)((stat-10)/2);
        }

        /*
         * utility method that calculates the max hit points of an Entity
         */
        private int calcMaxHp()
        {
            return 10 + conMod;
        }
    }
}
