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
            mapClass = new Map(7, 12, 7, 12, 8, 4);
        }
        public bool MovePlayer(MovementEnum direction)
        {
            if (mapClass.HeroProp.ReturnMove(direction) == direction)
            {

                switch (direction)
                {
                    case MovementEnum.Up:
                        Item? item = MapClass.GetItemAtPoint(MapClass.HeroProp.X, MapClass.HeroProp.Y - 1);
                        if (item is Gold)
                        {
                            MapClass.HeroProp.GoldCount += ((Gold)item).AmountGold;
                        }
                        break;
                    case MovementEnum.Down:
                        Item? item2 = MapClass.GetItemAtPoint(MapClass.HeroProp.X, MapClass.HeroProp.Y + 1);
                        if (item2 is Gold)
                        {
                            MapClass.HeroProp.GoldCount += ((Gold)item2).AmountGold;
                        }
                        break;
                    case MovementEnum.Left:
                        Item? item3 = MapClass.GetItemAtPoint(MapClass.HeroProp.X - 1, MapClass.HeroProp.Y);
                        if (item3 is Gold)
                        {
                            MapClass.HeroProp.GoldCount += ((Gold)item3).AmountGold;
                        }
                        break;
                    case MovementEnum.Right:
                        Item? item4 = MapClass.GetItemAtPoint(MapClass.HeroProp.X + 1, MapClass.HeroProp.Y);
                        if (item4 is Gold)
                        {
                            MapClass.HeroProp.GoldCount += ((Gold)item4).AmountGold;
                        }
                        break;
                }

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
