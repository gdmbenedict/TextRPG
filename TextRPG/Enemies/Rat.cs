using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Rat : Enemy
    {
        public Rat() : base()
        {
            SetName("Rat");
            SetSymbol('r');
            SetSize(Size.tiny);
            SetColor(ConsoleColor.Red);

            health = new HealthSystem(4);
            str = new Stat(2);  
            dex = new Stat(11);
            con = new Stat(9);
            itl = new Stat(2);
            wis = new Stat(10);
            cha = new Stat(4);
            luc = new Stat(6);

            setResistances(new bool[13]); //sets all resistances to false
            SetCreatureType(CreatureType.beast);

            Random rdm = new Random();

            if ((int)(rdm.NextDouble() * 100) < 20)
            {
                SetBehaviourState(BehviourState.aggressive);
            }
            else
            {
                SetBehaviourState(BehviourState.passive);
            }
        }

        public override bool ChooseAction(Map map, int[] startPos)
        {
            int[] endPos = new int[2];

            int[] posNorth = { startPos[0] - 1, startPos[1] };
            int[] posSouth = { startPos[0] + 1, startPos[1] };
            int[] posEast = { startPos[0], startPos[1] - 1 };
            int[] posWest = { startPos[0], startPos[1] + 1 };

            Random random = new Random();
            int choice = random.Next(0, 4);

            bool hasTarget = false;

            if (GetBehviourState() == BehviourState.aggressive)
            {
                //make list of targets within range
                List<int[]> targets = new List<int[]>();

                for (int y = -5; y <= 5; y++){

                    //height boudry check
                    if (startPos[0] + y > 0 && startPos[0] + y < map.GetHeight())
                    {
                        for(int x = -5; x <= 5; x++)
                        {
                            //width boundry check
                            if (startPos[1] + x > 0 && startPos[1] + x < map.GetWidth())
                            {
                                //set index for entity search
                                int[] index = new int[] { startPos[0] + y, startPos[1] + x };    
                                if (map.GetEntity(index) != null && map.GetEntity(index).GetName() != base.GetName())
                                {
                                    targets.Add(index);
                                    hasTarget = true;
                                }
                            }
                        }
                    }
                }

                //check if there are valid targets
                if (targets.Count > 0)
                {
                    //sets baseline position
                    int[] TargetLocation = startPos;

                    //determine closest target
                    foreach (int[] target in targets)
                    {
                        //compares current target to closest target
                        if ((Math.Abs(target[0] - startPos[0]) + Math.Abs(target[0] - startPos[0])) > (Math.Abs(TargetLocation[0] - startPos[0]) + Math.Abs(TargetLocation[0] - startPos[0])))
                        {
                            TargetLocation = target;
                        }
                    }

                    //head towards position

                    //y axis
                    if (Math.Abs(TargetLocation[0] - startPos[0]) > Math.Abs(TargetLocation[1] - startPos[1]))
                    {
                        if (TargetLocation[0] > startPos[0])
                        {
                            endPos = posSouth;
                        }
                        else
                        {
                            endPos = posNorth;
                        }
                    }
                    //x axis
                    else
                    {
                        if (TargetLocation[1] > startPos[1])
                        {
                            endPos = posWest;
                        }
                        else
                        {
                            endPos = posEast;
                        }
                    }
                }

                
                    
            }

            if(GetBehviourState() != BehviourState.aggressive || !hasTarget)
            {
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

                if (map.GetEntity(endPos) != null)
                {
                    return false;
                }
            }          

            base.Move(map, startPos, endPos);

            return false;
        }

        public override int[] GetDamage()
        {
            int[] damageDetails = new int[2];
            Random rnd = new Random();

            damageDetails[0] = 1;
            damageDetails[1] = DamageType.piercing.DamageTypeToInt();

            return damageDetails;
        }

        new public void TakeDamage(int[] damageDetails)
        {
            SetBehaviourState(BehviourState.aggressive);
            base.TakeDamage(damageDetails);
        }

        public override void OnDeath(Map map, int[] pos)
        {
            for (int y = -5; y <= 5; y++)
            {

                //height boudry check
                if (pos[0] + y > 0 && pos[0] + y < map.GetHeight())
                {
                    for (int x = -5; x <= 5; x++)
                    {
                        //width boundry check
                        if (pos[1] + x > 0 && pos[1] + x < map.GetWidth())
                        {
                            //set index for entity search
                            int[] index = new int[] { pos[0] + y, pos[1] + x };
                            if (map.GetEntity(index) != null && map.GetEntity(index).GetName() == base.GetName())
                            {
                                map.GetEntity(index).specialFunction();
                            }
                        }
                    }
                }
            }
        }

        public override void specialFunction()
        {
            SetBehaviourState(BehviourState.aggressive);
        }
    }   
}
