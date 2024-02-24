using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    /*
     * Class for an Equipment Slot that is part of a loadout.
     * Author: Matthieu Benedict
     * Last Updated: 2024-02-23
     */

    internal class EquipmentSlot
    {
        private EquipmentSlotType slotType; //the type of slot
        private Size size;
        private Equipment slot; //the equipped equipment

        /// <summary>
        /// Constructor method for a slot for equipment
        /// </summary>
        /// <param name="slotType">the type of slot this slot is</param>
        public EquipmentSlot(EquipmentSlotType slotType)
        {
            this.slotType = slotType;
            slot = null; //nothing equipped on contruction
        }

        /// <summary>
        /// Accessor method to retreive the type the slot is
        /// </summary>
        /// <returns>the type of slot this slot is</returns>
        public EquipmentSlotType GetSlotType()
        {
            return slotType;
        }

        /// <summary>
        /// Mutator method that sets the type of the slot to a desired type
        /// </summary>
        /// <param name="slotType">the desired type of slot this slot is</param>
        public void SetSlotType(EquipmentSlotType slotType)
        {
            this.slotType = slotType;
        }

        /// <summary>
        /// Accessor method that returns the size of the equipment slot (based on the creature size)
        /// </summary>
        /// <returns>size of the equipment slot (based on the creature size)</returns>
        public Size GetSize()
        {
            return size;
        }

        /// <summary>
        /// Mutator method that sets the size of the equipment slot (based on the creature size
        /// </summary>
        /// <param name="size">specified size of the equipment slot (based on the creature size</param>
        public void SetSize(Size size)
        {
            this.size = size;
        }

        /// <summary>
        /// Accessor method that returns equipment in the slot
        /// </summary>
        /// <returns>the equipment in the slot</returns>
        public Equipment GetSlot()
        {
            return slot;
        }

        /// <summary>
        /// Mutator method that sets the equipment in the slot to a specified equipment
        /// </summary>
        /// <param name="slot">the equipment specified to be put in the slot</param>
        public void SetSlot(Equipment slot)
        {
            this.slot = slot;
        }
    }
}
