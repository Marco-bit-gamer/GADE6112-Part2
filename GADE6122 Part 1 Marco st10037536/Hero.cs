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
            if (move == MovementEnum.NoMovement) return MovementEnum.NoMovement;
            return (TileSight[(int)move].Type is TileType.EmptyTile or TileType.Gold) ? move : MovementEnum.NoMovement;
        }

        public override string ToString()
        {
            return $"Player Stats: \n HP: {HP}/{Max_HP} \n Damage: {Damage} \n [{X}, {Y}]\n Gold Amount: {GoldCount}";
        }
    }
}
