using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class Gold : Item
    {
        private int amountGold;
        private Random rnd = new();

        public Gold(int x, int y) : base(x, y)
        {
            amountGold = rnd.Next(1, 6);
        }

        public int AmountGold { get => amountGold; set => amountGold = value; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
