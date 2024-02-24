using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    /*
     * Abstract item object
     * Author: Matthieu Benedict
     * Last Updated: 2024-02-23
     */

    internal abstract class Item
    {
        private string name; //name of the item
        private float weight; //the weight of the item
        private float value; //the value of the item
        private ItemType type; //the type of the item


        /// <summary>
        /// Constructor method for an abstract item object
        /// </summary>
        /// <param name="name">name of the item</param>
        /// <param name="weight">the weight of the item</param>
        /// <param name="value">the value of the item</param>
        public Item(string name, float weight, float value)
        {
            this.name = name;
            this.weight = weight;
            this.value = value;
        }

        /// <summary>
        /// Accessor method for the name of the Item
        /// </summary>
        /// <returns>the name of the Item</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Mutator method that sets the name of an Item
        /// </summary>
        /// <param name="name">the name of the Item</param>
        public void SetName(string name)
        {
            this.name=name;
        }

        /// <summary>
        /// Accessor method that returns the weight of an Item
        /// </summary>
        /// <returns>the weight of the item</returns>
        public float GetWeight()
        {
            return weight;
        }

        /// <summary>
        /// Mutator method that sets the weight of an Item
        /// </summary>
        /// <param name="weight">the weight of the item</param>
        public void SetWeight(float weight)
        {
            this.weight=weight;
        }

        /// <summary>
        /// Accessor method that returns the value of an item
        /// </summary>
        /// <returns>the value of an Item</returns>
        public float GetValue()
        {
            return value;
        }

        /// <summary>
        /// Mutator method that sets the value of an item
        /// </summary>
        /// <param name="value">the value of an Item</param>
        public void SetValue(float value)
        {
            this.value =value;
        }

        /// <summary>
        /// Accessor method that returns the type of the item
        /// </summary>
        /// <returns>the type of the item</returns>
        public ItemType GetType()
        {
            return type;
        }

        /// <summary>
        /// Mutator method that sets the type of the item
        /// </summary>
        /// <param name="type">the type of the item</param>
        public void SetType(ItemType type)
        {
            this.type = type;
        }

        /// <summary>
        /// Abstract method that triggers the effect of the Item for a given Entity
        /// </summary>
        /// <param name="target">the target Entity of the Item effect</param>
        public abstract void Use(Entity target);
    }
}
