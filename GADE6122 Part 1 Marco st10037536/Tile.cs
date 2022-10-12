using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    abstract class Tile
    {
        protected int x;
        protected int y;
        public enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon,
            Obstacle,
            EmptyTile
        }

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }

        public TileType Type
        {
            get;
            set;
        }
    }
}
