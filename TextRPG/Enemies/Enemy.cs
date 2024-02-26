using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal abstract class Enemy : Entity
    {
        private BehviourState behviourState;

        public Enemy(string name, Size size, int str, int dex, int con, int itl, int wis, int cha, int luc) : base(name, 'E', size, str, dex, con, itl, wis, cha, luc)
        {
            base.SetColor(ConsoleColor.Red);

        }

        public Enemy() : base()
        {

        }



        public void SetBehaviourState(BehviourState behviourState)
        {
            this.behviourState = behviourState;
        }

        public BehviourState GetBehviourState()
        {
            return behviourState;
        }
    }
}
