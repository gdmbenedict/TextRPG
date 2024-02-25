using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    /*
     * Class for a Equipment Item in a text based RPG
     * Author: Matthieu Benedict
     * Last Updates 2024-02-24
     */

    internal abstract class Equipment : Item
    {
        private EquipmentSlotType slotType; //The slot type of the equipment
        private Size equipmentSize; //The size category of the equipment
        private float dodgeChance; //dodge chance modified by this equipment
        private int[] damageReductions; //the reduction in damage applied by the equipment (indexed by Int damage types)
        private int damage; //damage done by Equipment
        private DamageType damageType; //type of damage done by Equipment
        private bool canAttack; //bool determining if this Equipment can be used in attacks

        /// <summary>
        /// Constructor method for the Equipment class of Item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weight"></param>
        /// <param name="value"></param>
        /// <param name="dodgeChance"></param>
        /// <param name="damageReductions"></param>
        /// <param name="damage"></param>
        /// <param name="damageType"></param>
        /// <param name="canAttack"></param>
        public Equipment(string name, float weight, float value, EquipmentSlotType slotType, Size size, float dodgeChance, int[] damageReductions, int damage, DamageType damageType, bool canAttack) : base(name, weight, value)
        {
            //setting Item type
            base.SetType(ItemType.equipment);

            //Setting slot type and size
            this.slotType = slotType;
            this.equipmentSize = size;

            //setting variables for equipment
            this.dodgeChance = dodgeChance;
            this.damageReductions = damageReductions;
            this.damage = damage;
            this.damageType = damageType;
            this.canAttack = canAttack;
        }

        public override void Use(Entity target)
        {

        }

        /// <summary>
        /// Accessor method for returning the type of EquipmentSlot this Equipment takes up
        /// </summary>
        /// <returns>The slot type of the equipment</returns>
        public EquipmentSlotType GetSlotType() 
        { 
            return slotType; 
        }

        /// <summary>
        /// Mutator method that changes the type of EquipmentSlot this Equipment takes up
        /// </summary>
        /// <param name="slotType">The specified slot type for the equipment</param>
        public void SetSlotType(EquipmentSlotType slotType)
        {
            this.slotType = slotType;
        }

        /// <summary>
        /// Accessor method that returns the size of the Equipment
        /// </summary>
        /// <returns>the size of the Equipment</returns>
        public Size GetEquipmentSize()
        {
            return equipmentSize;
        }

        /// <summary>
        /// Mutator method that sets the size of the Equipment
        /// </summary>
        /// <param name="size">the specified size of the Equipment</param>
        public void SetEquippmentSize(Size size)
        {
            equipmentSize = size;
        }

        /// <summary>
        /// Accessor method that returns the dodge chance modifier of the item
        /// </summary>
        /// <returns>dodge chance modified by this equipment</returns>
        public float GetDodgeChance()
        {
            return dodgeChance;
        }

        /// <summary>
        /// Mutator method that sets the dodge chance modifier of the item
        /// </summary>
        /// <param name="dodgeChance">specified dodge chance modifier of the item</param>
        public void setDodgeChance(float dodgeChance)
        {
            this.dodgeChance= dodgeChance;
        }

        /// <summary>
        /// Accessor method that returns the damage reduction for the specified damage type (in int form)
        /// </summary>
        /// <param name="intDamageType">specified damage type (in int form)</param>
        /// <returns></returns>
        public int GetDamageReduction(int intDamageType)
        {
            return damageReductions[intDamageType];
        }

        /// <summary>
        /// Accessor method that returns the damage reduction for the specified damage type
        /// </summary>
        /// <param name="damageType">specified damage type</param>
        /// <returns></returns>
        public int GetDamageReduction(DamageType damageType)
        {
            return damageReductions[damageType.DamageTypeToInt()];
        }

        /// <summary>
        /// Mutator method that sets the damage reduction for the specified damage type (int int form) to a specified value
        /// </summary>
        /// <param name="intDamageType">specified damage type (int int form)</param>
        /// <param name="damageReduction">specified damage reduction</param>
        public void SetDamageReduction(int intDamageType, int damageReduction)
        {
            damageReductions[intDamageType] = damageReduction;
        }

        /// <summary>
        /// Mutator method that sets the damage reduction for the specified damage type to a specified value
        /// </summary>
        /// <param name="damageType">specified damage type</param>
        /// <param name="damageReduction">specified damage reduction</param>
        public void SetDamageReduction(DamageType damageType, int damageReduction)
        {
            damageReductions[damageType.DamageTypeToInt()] = damageReduction;
        }

        /// <summary>
        /// Accessor method that returns all damage reductions given by an equipment
        /// </summary>
        /// <returns>all damage reductions in an array of ints (indexed by damage type)</returns>
        public int[] GetAllDamageReductions()
        {
            return damageReductions;
        }

        /// <summary>
        /// Mutator method that sets all damage reductions in an array of ints (indexed by damage type)
        /// </summary>
        /// <param name="damageReductions">all damage reductions in an array of ints (indexed by damage type)</param>
        public void SetAllDamageReductions(int[] damageReductions)
        {
            this.damageReductions = damageReductions;
        }

        /// <summary>
        /// Accessor method that returns the amount of damage done by the equipment
        /// </summary>
        /// <returns>amount of damage done by the equipment</returns>
        public int GetDamage()
        {
            return damage;
        }

        /// <summary>
        /// Mutator method that sets the amount of damage done by the equipment
        /// </summary>
        /// <param name="damage">amount of damage done by the equipment</param>
        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        /// <summary>
        /// Accessor method that returns the DamageType of damage done by the equipment
        /// </summary>
        /// <returns>DamageType of damage done by the equipment</returns>
        public DamageType GetDamageType()
        {
            return damageType;
        }

        /// <summary>
        /// Mutator method that sets the DamageType of the damage done by the equiment to a specified DamageType
        /// </summary>
        /// <param name="damageType">specified DamageType of the damage done by the equiment</param>
        public void SetDamageType(DamageType damageType)
        {
            this.damageType = damageType;
        }

        /// <summary>
        /// Accessor method that returns if the equipment can be used in attacking
        /// </summary>
        /// <returns>bool representing if the equipment can be used in attacking</returns>
        public bool CanAttack()
        {
            return canAttack;
        }

        /// <summary>
        /// Mutator method that setsif the equipment can be used in attacking
        /// </summary>
        /// <param name="canAttack">specified value for if the equipment can be used in attacking</param>
        public void SetCanAttack(bool canAttack)
        {
            this.canAttack = canAttack;
        }
    }
}
