using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class Hero : Character
    {
        public Hero(int x, int y, int hp, int maxHp) : base(x, y, hp, maxHp, 2)
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

        public override string ToString()
        {
            string output = "Player Stats: \n HP: HP/Max HP \n Damage: 2 \n [X, Y]";
            return output;
        }
    }
}
