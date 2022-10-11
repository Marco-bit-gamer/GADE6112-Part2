using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class Gold : Item
    {
        private int AmountGold;
        private Random rnd = new Random();

        public Gold(int x, int y) : base(x, y)
        {
            EmptyTile.ReferenceEquals(x, y);
            AmountGold = rnd.Next(1, 6);
        }

    }
}
