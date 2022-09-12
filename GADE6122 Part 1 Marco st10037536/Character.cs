using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    abstract class Character : Tile
    {
        public bool IsDead = false;
        private int hp;
        private int maxHp;
        private int dmg;
        public enum MovementEnum
        {
            Up,
            Down,
            Left,
            Right,
            NoMovement
        }

        string[] TileSight = new string[4];

        public Character(int x, int y, int hp, int maxHp, int dmg) : base(x, y)
        {
            this.hp = hp;
            this.maxHp = maxHp;
            this.dmg = dmg;
        }
        public int Damage
        {
            get { return dmg; }
            set { dmg = value; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public int Max_HP
        {
            get { return maxHp; }
            set { maxHp = value; }
        }


        public bool ChangeTileSight(int Moved, int Move)
        {
            switch (Moved)
            {
                case (int)MovementEnum.NoMovement:
                    return false;
                case (int)MovementEnum.Up:
                    return true;
                case (int)MovementEnum.Down:
                    return true;
                case (int)MovementEnum.Left:
                    return true;
                case (int)MovementEnum.Right:
                    return true;
                default:
                    return false;
            }


        }

        public virtual void Attack(Character target)
        {

        }

        public virtual bool CheckRange(Character target)
        {
            if (DistanceTo(target) > 1)
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(this.X - target.X) + Math.Abs((this.Y - target.Y));
        }

        public void Move(MovementEnum move)
        {
        }

        public abstract MovementEnum ReturnMove(MovementEnum move = 0);
    }
}
