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
        public GameEngine()
        {
            mapClass = new Map(7, 12, 7, 12, 4, 4);
        }
        public Map MapClass { get { return mapClass; } }

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
                MapClass.MapProp[MapClass.HeroProp.Y, MapClass.HeroProp.X] = new Hero(MapClass.HeroProp.Y, MapClass.HeroProp.X, MapClass.HeroProp.HP, 99) { Type = Tile.TileType.Hero };
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
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveEnemies()
        {
            MovementEnum direction;
            for (int i = 0; i < mapClass.EnemiesProp.Length; i++)
            {
                if (MapClass.EnemiesProp[i].IsDead())
                {
                    MapClass.MapProp[MapClass.EnemiesProp[i].Y, MapClass.EnemiesProp[i].X] = new EmptyTile(MapClass.EnemiesProp[i].X, MapClass.EnemiesProp[i].Y) { Type = Tile.TileType.EmptyTile };
                    return;
                }

                direction = mapClass.EnemiesProp[i].ReturnMove();
                if (mapClass.EnemiesProp[i].ReturnMove() == direction)
                {

                    switch (direction)
                    {
                        case MovementEnum.Up:
                            Item? item = MapClass.GetItemAtPoint(MapClass.EnemiesProp[i].X, MapClass.EnemiesProp[i].Y - 1);
                            if (item is Gold)
                            {
                                MapClass.EnemiesProp[i].GoldCount += ((Gold)item).AmountGold;
                            }
                            break;
                        case MovementEnum.Down:
                            Item? item2 = MapClass.GetItemAtPoint(MapClass.EnemiesProp[i].X, MapClass.EnemiesProp[i].Y + 1);
                            if (item2 is Gold)
                            {
                                MapClass.EnemiesProp[i].GoldCount += ((Gold)item2).AmountGold;
                            }
                            break;
                        case MovementEnum.Left:
                            Item? item3 = MapClass.GetItemAtPoint(MapClass.EnemiesProp[i].X - 1, MapClass.EnemiesProp[i].Y);
                            if (item3 is Gold)
                            {
                                MapClass.EnemiesProp[i].GoldCount += ((Gold)item3).AmountGold;
                            }
                            break;
                        case MovementEnum.Right:
                            Item? item4 = MapClass.GetItemAtPoint(MapClass.EnemiesProp[i].X + 1, MapClass.EnemiesProp[i].Y);
                            if (item4 is Gold)
                            {
                                MapClass.EnemiesProp[i].GoldCount += ((Gold)item4).AmountGold;
                            }
                            break;
                    }

                    mapClass.EnemiesProp[i].Move(direction);
                    switch (MapClass.EnemiesProp[i])
                    {
                        case Swamp_Creature:
                            MapClass.MapProp[MapClass.EnemiesProp[i].Y, MapClass.EnemiesProp[i].X] = new Swamp_Creature(MapClass.EnemiesProp[i].X, MapClass.EnemiesProp[i].Y) { Type = Tile.TileType.Enemy };
                            break;
                        case Mage:
                            MapClass.MapProp[MapClass.EnemiesProp[i].Y, MapClass.EnemiesProp[i].X] = new Mage(MapClass.EnemiesProp[i].X, MapClass.EnemiesProp[i].Y) { Type = Tile.TileType.Enemy };
                            break;
                    }
                    switch (direction)
                    {
                        case MovementEnum.Up:
                            MapClass.MapProp[MapClass.EnemiesProp[i].Y + 1, MapClass.EnemiesProp[i].X] = new EmptyTile(MapClass.EnemiesProp[i].Y + 1, MapClass.EnemiesProp[i].X) { Type = Tile.TileType.EmptyTile };
                            break;
                        case MovementEnum.Down:
                            MapClass.MapProp[MapClass.EnemiesProp[i].Y - 1, MapClass.EnemiesProp[i].X] = new EmptyTile(MapClass.EnemiesProp[i].Y - 1, MapClass.EnemiesProp[i].X) { Type = Tile.TileType.EmptyTile };
                            break;
                        case MovementEnum.Left:
                            MapClass.MapProp[MapClass.EnemiesProp[i].Y, MapClass.EnemiesProp[i].X + 1] = new EmptyTile(MapClass.EnemiesProp[i].Y, MapClass.EnemiesProp[i].X + 1) { Type = Tile.TileType.EmptyTile };
                            break;
                        case MovementEnum.Right:
                            MapClass.MapProp[MapClass.EnemiesProp[i].Y, MapClass.EnemiesProp[i].X - 1] = new EmptyTile(MapClass.EnemiesProp[i].Y, MapClass.EnemiesProp[i].X - 1) { Type = Tile.TileType.EmptyTile };
                            break;
                    }
                }
            }
        }

        public void AttackingEnemies()
        {
            for (int i = 0; i < mapClass.EnemiesProp.Length; i++)
            {
                if (mapClass.EnemiesProp[i].IsDead()) continue;
                switch (mapClass.EnemiesProp[i])
                {
                    case Swamp_Creature:
                        mapClass.EnemiesProp[i].Attack(mapClass.HeroProp);
                        break;
                    case Mage:
                        mapClass.EnemiesProp[i].Attack(mapClass.HeroProp);

                        for (int j = 0; j < mapClass.EnemiesProp.Length; j++)
                        {
                            if (mapClass.EnemiesProp[i] == mapClass.EnemiesProp[j]) continue;

                            mapClass.EnemiesProp[i].Attack(mapClass.EnemiesProp[j]);
                        }
                        break;
                }
                if (mapClass.EnemiesProp[i].IsDead())
                {
                    mapClass.MapProp[mapClass.EnemiesProp[i].Y, mapClass.EnemiesProp[i].X] = new EmptyTile(mapClass.EnemiesProp[i].X, mapClass.EnemiesProp[i].Y) { Type = Tile.TileType.EmptyTile };
                }
            }

        }
    }
}
