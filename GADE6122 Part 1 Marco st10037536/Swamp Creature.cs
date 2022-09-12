using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class Swamp_Creature : Enemy
    {
        public Swamp_Creature(int x, int y) : base(x, y, 10, 10, 1)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            switch (move)
            {
                case MovementEnum.Up:
                    return move;
                    break;
                case MovementEnum.Down:
                    return move;
                    break;
                case MovementEnum.Left:
                    return move;
                    break;
                case MovementEnum.Right:
                    return move;
                    break;
                default:
                    return MovementEnum.NoMovement;
            }
        }
    }
}
