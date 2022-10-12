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
                        MapClass.MapProp[MapClass.HeroProp.Y, MapClass.HeroProp.X] = new Hero(MapClass.HeroProp.Y, MapClass.HeroProp.X, 99, 99) { Type = Tile.TileType.Hero };
                switch (direction)
                {
                    case MovementEnum.Up:
                        MapClass.MapProp[MapClass.HeroProp.Y + 1, MapClass.HeroProp.X] = new EmptyTile(MapClass.HeroProp.Y + 1, MapClass.HeroProp.X) { Type = Tile.TileType.EmptyTile };
                        break;
                    case MovementEnum.Down:
                        MapClass.MapProp[MapClass.HeroProp.Y - 1, MapClass.HeroProp.X] = new EmptyTile(MapClass.HeroProp.Y - 1, MapClass.HeroProp.X) { Type = Tile.TileType.EmptyTile };
                        break;
                    case MovementEnum.Left:
                        MapClass.MapProp[MapClass.HeroProp.Y, MapClass.HeroProp.X + 1] = new EmptyTile(MapClass.HeroProp.Y, MapClass.HeroProp.X + 1) { Type = Tile.TileType.EmptyTile };
                        break;
                    case MovementEnum.Right:
                        MapClass.MapProp[MapClass.HeroProp.Y, MapClass.HeroProp.X - 1] = new EmptyTile(MapClass.HeroProp.Y, MapClass.HeroProp.X - 1) { Type = Tile.TileType.EmptyTile };
                        break;
                    case MovementEnum.NoMovement:
                        MapClass.MapProp[MapClass.HeroProp.Y, MapClass.HeroProp.X] = new EmptyTile(MapClass.HeroProp.Y, MapClass.HeroProp.X){ Type = Tile.TileType.EmptyTile };
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
