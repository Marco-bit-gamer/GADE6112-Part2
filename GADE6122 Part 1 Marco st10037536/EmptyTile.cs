using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class EmptyTile:Tile
    {
        public EmptyTile(int x, int y) : base(x, y)
        {

        }

        public bool Empty()
        {
            if (Obstacle() == false)
            {
                return false;
            }
                return true;
        }

        private bool Obstacle()
        {
            throw new NotImplementedException();
        }
    }
}
