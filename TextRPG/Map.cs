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
         * Last Updated: 2023-11-28
         */

        //Map Variables
        private string mapName;
        private Tile[,] background;
        private Entity[,] entities;

        /*
         * Constructor method for a map object
         * Input: (string) path: path to the file containing the map information.
         * Output: (Map) map: an object of type Map
         */
        public Map(string path)
        {
            //declaring some variables (default values added to handle no value error)
            int height, width, startIndex =0, endIndex =0;

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
                    endIndex = i - 1; //sets end of map above clode bracket
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
         * Method that draws the contents of the map on to the console
         * this method will have to be re-written when UI is added
         */
        public void DrawMap()
        {

        }
    }
}
