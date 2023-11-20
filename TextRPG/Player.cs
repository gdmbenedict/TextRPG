using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    //Struct to store player position
    struct position
    {
        public int x; //x position of the player
        public int y; //y position of the player
    }

    /*
     * Class for a player object
     * Author: Matthieu Benedict
     */
    public class Player
    {
        //stored variables for the player
        private string name;
        private int maxHealth;
        private int health;
        private int atk;
        private position playerPos;

        /*
         * Constructer class for a player object
         * Input: (string) name: this is the name of the player character stored in a string variable
         * Input: (int) maxHealth: the total hit points of the player. If they reach zero the player character dies
         * Input: (int) atk: the attack value for the player, this being the damage they deal with an attack
         * Input: (int) posX: this is the X value of the player's position on the play space
         * Input: (int) posY: this is the Y value of the player's position on the play space
         */
        public Player(string name, int maxHealth, int atk, int posX, int posY)
        {
            //assigning player variables
            this.name = name;
            this.maxHealth = maxHealth;
            health = maxHealth;
            this.atk = atk;
            playerPos.x = posX;
            playerPos.y = posY;
        }

        /*
         * Mutator method to handle the player object taking damage and returns a damage message
         * Input: (int) damage: the damage value applied to the player character
         * Output: (string) message: a message giving details of the damage
         */
        public string TakeDamage(int damage)
        {
            string message;

            health -= damage; //applying damage to player health
            message = name + " took " + damage + " damage!";

            return message;
        }

        /*
         * Mutator method to modify the player position
         * Input: (int) xIn: the movement value of the player on the x axis.
         * Input: (int) yIn: the movement value of the player on the y axis.
         */
        public void Move(int xIn, int yIn)
        {
            playerPos.x += xIn;
            playerPos.y += yIn;
        }

        /*
         * Accessor method for the player's attack value. (this will be modified later to have a more complex attack method)
         * Output: (int) atk: raw damage dealt by player
         */
        public int Attack()
        {
            return atk;
        }

        /*
         * Accessor method for the player's health value
         * Output: (int) health: the remaining hitpoints of the player
         */
        public int GetHealth()
        {
            return health;
        }

        /*
         * Accessor method for the player character's name
         * Output: (string) name: the name of the player character
         */
        public string GetName()
        {
            return name;
        }

        /*
         * Accessor method for the player's X position
         * Output: (int) posX: this is the X value of the player's position on the play space
         */
        public int GetPosX()
        {
            return playerPos.x;
        }

        /*
         * Accessor method for the player's Y position
         * Output: (int) posY: this is the Y value of the player's position on the play space
         */
        public int GetPosY()
        {
            return playerPos.y;
        }
    }
}
