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
            Weapon
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

        public string Symbol(int symbol)
        {
            switch (symbol)
            {
                case (int)TileType.Hero:
                    return "H";
                case (int)TileType.Enemy:
                    return "SC";
                case (int)TileType.Gold:
                    return "G";
                case (int)TileType.Weapon:
                    return "W";
                default:
                    return "";
            }
        }
    }
}
