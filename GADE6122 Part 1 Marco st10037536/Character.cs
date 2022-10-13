using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    abstract class Character : Tile
    {
        private int hp;
        private int maxHp;
        private int dmg;
        private int goldCount;

        public enum MovementEnum
        {
            Up,
            Down,
            Left,
            Right,
            NoMovement
        }

        public Tile[] TileSight;

        public Character(int x, int y, int hp, int maxHp, int dmg) : base(x, y)
        {
            this.hp = hp;
            this.maxHp = maxHp;
            this.dmg = dmg;
            TileSight = new Tile[4];
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

        public int GoldCount
        {
            get { return goldCount; }
            set { goldCount = value; }
        }

        public virtual void Attack(Character target)
        {
            if (!CheckRange(target)) return;
            target.hp -= this.dmg;
        }

        public bool IsDead()
        {
            return this.hp <= 0;
        }

        public virtual bool CheckRange(Character target)
        {
            return (DistanceTo(target) <= 1);
        }

        private int DistanceTo(Character target)
        {
            return Math.Abs(this.X - target.X) + Math.Abs((this.Y - target.Y));
        }
        
        public void Move(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.Up:
                    this.Y -= 1;
                    break;
                case MovementEnum.Down:
                    this.Y += 1;
                    break;
                case MovementEnum.Left:
                    this.X -= 1;
                    break;
                case MovementEnum.Right:
                    this.X += 1;
                    break;
                case MovementEnum.NoMovement:
                    break;
                default:
                    break;
            }
        }

        public void PickUp(Item i)
        {
            if (i is null) return;
            switch (i)
            {
                case Gold:
                    Gold tmp = (Gold)i;
                    goldCount += tmp.AmountGold;
                    break;
                default:
                    break;
            }
        }

        public abstract MovementEnum ReturnMove(MovementEnum move = 0);
    }
}
