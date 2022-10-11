using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    abstract class Item
    {
        private string M = "money";

        public Item(int x, int y) 
        {
            Tile.Equals(x, y);
        }

        public override string ToString()
        {
            return M;
        }
    }
}
