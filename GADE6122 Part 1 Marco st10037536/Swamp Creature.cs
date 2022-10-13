using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class Swamp_Creature : Enemy
    {
        public Swamp_Creature(int x, int y, int hp = 10) : base(x, y, hp, 10, 1)
        {

        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            bool availableTile = false;

            for (int i = 0; i < TileSight.Length; i++)
            {
                if (TileSight[i] is EmptyTile)
                {
                    availableTile = true;
                    break;
                }
            }

            if (!availableTile) return MovementEnum.NoMovement;

            bool loop;
            int dir;
            do
            {
                dir = random.Next(4);

                loop = (TileSight[dir] is not EmptyTile or Gold);

            } while (loop);

            //new C# syntax for return switch cases
            return dir switch
            {
                0 => MovementEnum.Up,
                1 => MovementEnum.Down,
                2 => MovementEnum.Left,
                3 => MovementEnum.Right,
                _ => MovementEnum.NoMovement,
            };
        }
    }
}
