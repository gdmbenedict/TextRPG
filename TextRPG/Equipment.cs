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
        private float dodgeChance;
        private int[] damageReduction;
        private int damage;
        private DamageType damageType;
        private bool canAttack;

        public Equipment(string name, float weight, float value, float dodgeChance, int[] damageReduction, int damage, DamageType damageType, bool canAttack) : base(name, weight, value)
        {
            //setting Item type
            base.SetType(ItemType.equipment);

            //setting variables for equipment
            this.dodgeChance = dodgeChance;
            this.damageReduction = damageReduction;
            this.damage = damage;
            this.damageType = damageType;
            this.canAttack = canAttack;
        }

        public override void Use(Entity target)
        {

        }

        public 
    }
}
