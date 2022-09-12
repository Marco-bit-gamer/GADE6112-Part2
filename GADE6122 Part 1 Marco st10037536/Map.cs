using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_Part_1_Marco_st10037536
{
    internal class Map
    {
        Tile[,] MAP = new Tile[8, 15];
        public Tile[,] MapProp { get { return MAP; } }

        Hero hero;
        public Hero HeroProp {  get { return hero; } }

        Enemy[] enemies;
        public Enemy[] EnemiesProp { get { return enemies; } set { enemies = value; } }
        
        Random rand = new Random();
        int mapWidth, mapHeight;
        public static readonly string HERO = "H", SWAMP_CREATURE = "☻", EMPTY = "_", OBSTACLE = "•";

        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyCount)
        {
            mapWidth = rand.Next(minWidth, maxWidth);
            mapHeight = rand.Next(minHeight, maxHeight);

            enemies = new Enemy[enemyCount];
            MAP = new Tile[mapHeight, mapWidth];

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if ((i == 0 || i == mapHeight - 1) || (j == 0 || j == mapWidth - 1))
                    {
                        MAP[i, j] = new Obstacle(i, j) { Type = Tile.TileType.Obstacle };
                    }
                    else
                    {
                        MAP[i, j] = new EmptyTile(i, j) { Type = Tile.TileType.EmptyTile };
                    }
                }
            }
            
            hero = (Hero)Create(Tile.TileType.Hero);
            hero.Type = Tile.TileType.Hero;
            for (int i = 0; i < enemies.Length; i++)
            {
                Create(Tile.TileType.Enemy);
            }
        }
        

        public void UpdateVision()
        {
            hero.TileSight[0] = MapProp[hero.Y - 1, hero.X];
            hero.TileSight[1] = MapProp[hero.Y + 1, hero.X];
            hero.TileSight[2] = MapProp[hero.Y, hero.X - 1];
            hero.TileSight[3] = MapProp[hero.Y, hero.X + 1];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].TileSight[0] = MapProp[enemies[i].Y - 1, enemies[i].X];
                enemies[i].TileSight[1] = MapProp[enemies[i].Y + 1, enemies[i].X];
                enemies[i].TileSight[2] = MapProp[enemies[i].Y, enemies[i].X - 1];
                enemies[i].TileSight[3] = MapProp[enemies[i].Y, enemies[i].X + 1];
            }
        }

        private Tile Create(Tile.TileType type)
        {
            bool loop;
            int randomX, randomY;
            do
            {
                randomX = rand.Next(1, mapWidth - 1);
                randomY = rand.Next(1, mapHeight - 1);
                if (MAP[randomY, randomX] is EmptyTile) loop = false;
                else loop = true;
            } while (loop);

            switch (type)
            {
                case Tile.TileType.Hero:
                    Hero theHero = new Hero(randomX, randomY, 100, 100) { Type = Tile.TileType.Hero };
                    MAP[randomY, randomX] = theHero;
                    hero = theHero;
                    return theHero;
                case Tile.TileType.Enemy:
                    Swamp_Creature theEnemy = new Swamp_Creature(randomX, randomY) { Type = Tile.TileType.Enemy };
                    MAP[randomY, randomX] = theEnemy;
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        if (enemies[i] is null)
                        {
                            enemies[i] = theEnemy;
                            break;
                        }
                    }
                    return theEnemy;
                case Tile.TileType.Gold:
                    break;
                case Tile.TileType.Weapon:
                    break;
                default:
                    break;
            }
            return new EmptyTile(randomX, randomY) { Type = Tile.TileType.EmptyTile };
        }
        public override string ToString()
        {
            string mapStr = "";
            for (int i = 0; i < MAP.GetLength(0); i++)
            {
                for (int j = 0; j < MAP.GetLength(1); j++)
                {
                    switch (MAP[i, j])
                    {
                        case Obstacle:
                            mapStr += OBSTACLE;
                            break;
                        case EmptyTile:
                            mapStr += EMPTY;
                            break;
                        case Hero:
                            mapStr += HERO;
                            break;
                        case Swamp_Creature:
                            mapStr += SWAMP_CREATURE;
                            break;
                        default:
                            break;
                    }
                    mapStr += " ";
                }
                mapStr += Environment.NewLine;
            }
            return mapStr;
        }
    }
}
