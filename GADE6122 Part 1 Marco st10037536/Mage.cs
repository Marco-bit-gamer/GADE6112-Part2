using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class Mage : Enemy
    {
        public Mage(int x, int y, int hp = 5) : base(x, y, hp, 5, 5)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            return MovementEnum.NoMovement;
        }

        public override bool CheckRange(Character target)
        {
            return (Math.Abs(target.X - this.X) <= 1 && Math.Abs(target.Y - this.Y) <= 1);
        }
    }
}
