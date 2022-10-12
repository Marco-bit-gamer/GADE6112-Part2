using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class Obstacle:Tile
    {
        public Obstacle(int x, int y) : base(x, y)
        {

        }
        public bool _Obstacle(string Symbol)
        {
            switch (Symbol)
            {
                case "X":
                    return true;
                case "SC":
                    return true;
                default:
                    return false;
            }
        }
    }
}
