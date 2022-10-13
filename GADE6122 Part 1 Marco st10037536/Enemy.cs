using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    abstract class Enemy : Character
    {
        public Random random = new Random();

        protected Enemy(int x, int y, int hp, int maxHp, int dmg) : base(x, y, hp, maxHp, dmg)
        {

        }


        public override string ToString()
        {
            return $"Enemy at [{X}, {Y}] ({Damage}) HP: {HP}";
        }
    }
}
