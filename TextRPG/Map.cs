using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextRPG
{
    internal class Map
    {
        /*
         * Class for a Map object in an text based RPG.
         * Author: Matthieu Benedict
         * Last Updated: 2023-11-29
         */

        //Map Variables
        private string mapName;
        private Tile[,] background;
        private Entity[,] entities;
        private int height;
        private int width;

        /*
         * Constructor method for a map object
         * Input: (string) path: path to the file containing the map information.
         * Output: (Map) map: an object of type Map
         */
        public Map(string path)
        {
            //declaring some variables (default values added to handle no value error)
            int startIndex =0, endIndex =0;

            //check if file exists
            if (!File.Exists(@path))
            {
                //throw an error
            }

            //getting input from file
            string[] input = File.ReadAllLines(@path);

            //parsing through file for basic information
            //this section needs to be changed to fit JSON file format later
            mapName = input[0];

            for (int i=0; i<input.Length; i++)
            {
                if (input[i] == "{")
                {
                    startIndex = i + 1; //sets start of map below open bracket
                }

                if (input[i] == "}")
                {
                    endIndex = i -1; //sets end of map above closed bracket
                }
            }

            if (!(endIndex >= startIndex))
            {
                //throw error
            }

            height = endIndex - startIndex + 1; //gets height of map
            width = input[startIndex].Length; //gets width of map

            //initializing Tile map & Entity map
            background = new Tile[height, width];
            entities = new Entity[height, width];

            //cycle through every char of the input map
            for (int y=0; y<height; y++)
            {
                for (int x=0; x<width; x++)
                {
                    //sets each individual tile to their correct value
                    background[y, x] = new Tile(input[y + startIndex][x]);
                }
            }
  
        }

        /*
         * Method that prints the visuals of the map to screen
         * Input: (int) startPosCol: column (x-axis) starting position to print
         * Input: (int) startPosRow: row (y-axis) starting position to print
         */
        public void PrintMap(int startPosCol, int startPosRow)
        {
            for (int y=0; y<height; y++)
            {
                for (int x=0; x<width; x++)
                {
                    //setting cursor position
                    Console.SetCursorPosition(startPosCol + x, startPosRow + y);

                    if (entities[y,x] == null)
                    {
                        //print Tile to screen
                        Console.ForegroundColor = background[y,x].GetColor();
                        Console.Write(background[y,x].GetSymbol());
                    }

                    //include item check here

                    else
                    {
                        //print entity to screen
                        Console.ForegroundColor = entities[y,x].GetColor();
                        Console.Write(entities[y,x].GetSymbol());
                    }
                }
            }
        }

        /*
         * Accessor method for Height of the Map
         * Output: (int) height: the length of a column of the map array
         */
        public int GetHeight()
        {
            return height;
        }

        /*
         * Accessor method for the width of Map
         * Output: (int) width: the width of a row of the map array
         */
        public int GetWidth()
        {
            return width;
        }

        /*
         * Accessor method for specified Tile in map background
         * Input: (int[]) pos: position of the Tile on the map background
         *      pos[0]: the Y coordinate of the Tile
         *      pos[1]: the X coordinate of the Tile
         */
        public Tile GetTile(int[] pos)
        {
            return background[pos[0], pos[1]];
        }

        /*
         * Accessor method for specified Entity in map entities
         * Input: (int[]) pos: position of the Entity on the map entities
         *      pos[0]: the Y coordinate of the Entity
         *      pos[1]: the X coordinate of the Entity
         */
        public Entity GetEntity(int[] pos)
        {
            return entities[pos[0], pos[1]];
        }

        /*
         * Mutator method that sets an Entity's position on the Map entities
         * Input: (Entity) entity: the desired entity to be placed in Map entities
         * Input: (int[]) pos: position of the Entity on the map entities
         *      pos[0]: the Y coordinate of the Entity
         *      pos[1]: the X coordinate of the Entity
         */
        public void AddEntity(Entity entity, int[] pos)
        {
            entities[pos[0], pos[1]] = entity;
        }

        /*
         * Mutator method that removes an Entity from the Map entities
         * Input: (int[]) pos: position of the Entity on the map entities
         *      pos[0]: the Y coordinate of the Entity
         *      pos[1]: the X coordinate of the Entity
         */
        public void RemoveEntity(int[] pos)
        {
            entities[pos[0], pos[1]] = null;
        }

        public Entity[,] GetEntities()
        {
            return entities;
        }

        public void clearTurns()
        {
            foreach (Entity entity in entities)
            {
                if (entity != null)
                {
                    entity.clearTurn();
                }
                
            }
        }
    }
}
