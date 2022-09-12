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
                        MAP[i, j] = new Obstacle(i, j);
                    }
                    else
                    {
                        MAP[i, j] = new EmptyTile(i, j);
                    }
                }
            }
            
            hero = (Hero)Create(Tile.TileType.Hero);
            for (int i = 0; i < enemies.Length; i++)
            {
                Create(Tile.TileType.Enemy);
            }
        }
        

        public void UpdateVision()
        {

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
                    Hero theHero = new Hero(randomX, randomY, 100, 100);
                    MAP[randomY, randomX] = theHero;
                    hero = theHero;
                    return theHero;
                case Tile.TileType.Enemy:
                    Swamp_Creature theEnemy = new Swamp_Creature(randomX, randomY);
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
            return new EmptyTile(randomX, randomY);
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
