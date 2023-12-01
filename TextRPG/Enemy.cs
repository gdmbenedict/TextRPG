using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Enemy : Entity
    {

        public Enemy(string name, Size size, int str, int dex, int con, int itl, int wis, int cha, int luc) : base(name, 'E', size, str, dex, con, itl, wis, cha, luc)
        {
            base.SetColor(ConsoleColor.Red);
        }

        public override bool ChooseMove(Map map, int[] startPos)
        {
            int[] endPos = new int[2];
            
            int[] posNorth = { startPos[0] -1, startPos[1] };
            int[] posSouth = { startPos[0] +1, startPos[1] };
            int[] posEast = { startPos[0], startPos[1] -1};
            int[] posWest = { startPos[0], startPos[1] +1};

            Random random = new Random();
            int choice = random.Next(0,4);

            switch (choice)
            {
                case 0:
                    endPos = posNorth;
                    break;

                case 1:
                    endPos = posSouth;
                    break;

                case 2:
                    endPos = posEast;
                    break;

                case 3:
                    endPos = posWest;
                    break;
            }

            if (map.GetEntity(posNorth) != null)
            {
                if (map.GetEntity(posNorth).GetName() == "player")
                {
                    endPos = posNorth;
                }
            }

            if (map.GetEntity(posSouth) != null)
            {
                if (map.GetEntity(posSouth).GetName() == "player")
                {
                    endPos = posSouth;
                }
            }

            if (map.GetEntity(posEast) != null)
            {
                if (map.GetEntity(posEast).GetName() == "player")
                {
                    endPos = posEast;
                }
            }

            if (map.GetEntity(posWest) != null)
            {
                if (map.GetEntity(posWest).GetName() == "player")
                {
                    endPos = posWest;
                }
            }

            base.Move(map, startPos, endPos);

            return false;
        }
    }
}
