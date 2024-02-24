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

        public Equipment(string name, float weight, float value) : base(name, weight, value)
        {
            //setting Item type
            base.setType(ItemType.equipment);
        }

        public override void Use(Entity target)
        {

        }
    }
}
