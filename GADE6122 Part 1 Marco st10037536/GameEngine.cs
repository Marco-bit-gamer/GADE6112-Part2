using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GADE6122_Part_1_Marco_st10037536.Character;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class GameEngine
    {
        private Map mapClass;
        public Map MapClass { get { return mapClass; } }
        public GameEngine()
        {
            mapClass = new Map(7, 12, 7, 12, 8);
        }
        public bool MovePlayer(MovementEnum direction)
        {
            if (mapClass.HeroProp.ReturnMove(direction) == direction)
            {
                mapClass.HeroProp.Move(direction);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
