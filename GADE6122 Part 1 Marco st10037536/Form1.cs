using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace GADE6122_Part_1_Marco_st10037536
{
    public partial class HvsS : Form
    {
        GameEngine gameEngine;
        public HvsS()
        {
            InitializeComponent();
            gameEngine = new GameEngine(7, 12, 7, 12);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMap.Text = gameEngine.MapClass.ToString();
            gameEngine.MapClass.UpdateVision();
            
            enemiesDropDown.Items.Clear();
            for (int i = 0; i < gameEngine.MapClass.EnemiesProp.Length; i++)
            {
                enemiesDropDown.Items.Add(gameEngine.MapClass.EnemiesProp[i].ToString());
            }
        }

        private void txtMap_TextChanged(object sender, EventArgs e)
        {


        }
        private void DirectionHandler(Character.MovementEnum direction)
        {
            gameEngine.MovePlayer(direction);
            infoTextBox.Text = gameEngine.MapClass.HeroProp.ToString();
            gameEngine.MapClass.UpdateVision();

            gameEngine.MoveEnemies();
            gameEngine.AttackingEnemies();
            UpdateMap();
        }

        private void UpdateMap()
        {
            txtMap.Text = gameEngine.MapClass.ToString();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.MovementEnum.Up);

        }


        private void btnDown_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.MovementEnum.Down);


        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.MovementEnum.Left);

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.MovementEnum.Right);

        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            if (gameEngine.MapClass.EnemiesProp[enemiesDropDown.SelectedIndex].IsDead())
            {
                gameEngine.MapClass.MapProp[
                    gameEngine.MapClass.EnemiesProp[enemiesDropDown.SelectedIndex].Y,
                    gameEngine.MapClass.EnemiesProp[enemiesDropDown.SelectedIndex].X
                    ]
                    = new EmptyTile(
                        gameEngine.MapClass.EnemiesProp[enemiesDropDown.SelectedIndex].X,
                        gameEngine.MapClass.EnemiesProp[enemiesDropDown.SelectedIndex].Y
                        ) { Type = Tile.TileType.EmptyTile };
                txtMap.Text = gameEngine.MapClass.ToString();
                return;
            }
            gameEngine.MapClass.HeroProp.Attack(gameEngine.MapClass.EnemiesProp[enemiesDropDown.SelectedIndex]);
            infoTextBox.Text = gameEngine.MapClass.EnemiesProp[enemiesDropDown.SelectedIndex].ToString();


            gameEngine.AttackingEnemies();
            UpdateMap();
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            DirectionHandler(Character.MovementEnum.NoMovement);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataSet.Tables.Add(dataTable);

            dataTable.Columns.Add("ObjectTypes", typeof(string));
            dataTable.Columns.Add("X", typeof(int));
            dataTable.Columns.Add("Y", typeof(int));
            dataTable.Columns.Add("HP", typeof(int));
            dataTable.Columns.Add("MaxHp", typeof(int));
            dataTable.Columns.Add("Gold", typeof(int));

            dataTable.Rows.Add("Hero", gameEngine.MapClass.HeroProp.X, gameEngine.MapClass.HeroProp.Y, gameEngine.MapClass.HeroProp.HP, gameEngine.MapClass.HeroProp.Max_HP, gameEngine.MapClass.HeroProp.GoldCount);
            for (int i = 0; i < gameEngine.MapClass.EnemiesProp.Length; i++)
            {
                switch (gameEngine.MapClass.EnemiesProp[i])
                {
                    case Mage:
                        dataTable.Rows.Add("Mage", gameEngine.MapClass.EnemiesProp[i].X, gameEngine.MapClass.EnemiesProp[i].Y, gameEngine.MapClass.EnemiesProp[i].HP, gameEngine.MapClass.EnemiesProp[i].Max_HP, gameEngine.MapClass.EnemiesProp[i].GoldCount);
                        break;
                    case Swamp_Creature:
                        dataTable.Rows.Add("Swamp Creature", gameEngine.MapClass.EnemiesProp[i].X, gameEngine.MapClass.EnemiesProp[i].Y, gameEngine.MapClass.EnemiesProp[i].HP, gameEngine.MapClass.EnemiesProp[i].Max_HP, gameEngine.MapClass.EnemiesProp[i].GoldCount);

                        break;
                }
            }
            for (int i = 0; i < gameEngine.MapClass.Items.Length; i++)
            {
                switch (gameEngine.MapClass.Items[i])
                {
                    case Gold:
                        //if (gameEngine.MapClass.Items[i] is null) break;
                        dataTable.Rows.Add("Gold", gameEngine.MapClass.Items[i].X, gameEngine.MapClass.Items[i].Y, -1, -1, ((Gold)gameEngine.MapClass.Items[i]).AmountGold);
                        break;
                }
            }

            dataSet.WriteXml("Data.xml");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            gameEngine = new GameEngine(gameEngine.MapClass.MapWidth, gameEngine.MapClass.MapWidth, gameEngine.MapClass.MapHeight, gameEngine.MapClass.MapHeight);
            gameEngine.MapClass.Items = new Item[gameEngine.MapClass.Items.Length];
            gameEngine.MapClass.EnemiesProp = new Enemy[gameEngine.MapClass.EnemiesProp.Length];

            for (int i = 1; i < gameEngine.MapClass.MapHeight - 1; i++)
            {
                for (int j = 1; j < gameEngine.MapClass.MapWidth - 1; j++)
                {
                    gameEngine.MapClass.MapProp[i, j] = new EmptyTile(j, i) { Type = Tile.TileType.EmptyTile };
                }
            }

            DataSet loadSet = new DataSet();
            loadSet.ReadXml("Data.xml");

            foreach (DataRow row in loadSet.Tables[0].Rows)
            {
                string objectType = (string)row["ObjectTypes"];
                int xPos = Convert.ToInt32(row["X"]);
                int yPos = Convert.ToInt32(row["Y"]);
                int hp = Convert.ToInt32(row["HP"]);
                int maxHp = Convert.ToInt32(row["MaxHp"]);
                int gold = Convert.ToInt32(row["Gold"]);

                switch (objectType)
                {
                    case "Hero":
                        gameEngine.MapClass.MapProp[gameEngine.MapClass.HeroProp.Y, gameEngine.MapClass.HeroProp.X] = new EmptyTile(xPos, yPos) { Type = Tile.TileType.EmptyTile };

                        Hero hero = new Hero(xPos, yPos, hp, maxHp) { GoldCount = gold };
                        gameEngine.MapClass.HeroProp = hero;
                        gameEngine.MapClass.MapProp[yPos, xPos] = hero;
                        break;
                    case "Mage":
                        for (int i = 0; i < gameEngine.MapClass.EnemiesProp.Length; i++)
                        {
                            if (gameEngine.MapClass.EnemiesProp[i] is null)
                            {
                                Mage mage = new Mage(xPos, yPos, hp) { Type = Tile.TileType.Enemy, GoldCount = gold };
                                gameEngine.MapClass.EnemiesProp[i] = mage;
                                gameEngine.MapClass.MapProp[yPos, xPos] = mage;
                                break;
                            }
                        }
                        break;
                    case "Swamp Creature":
                        for (int i = 0; i < gameEngine.MapClass.EnemiesProp.Length; i++)
                        {
                            if (gameEngine.MapClass.EnemiesProp[i] is null)
                            {
                                Swamp_Creature swampCreature = new Swamp_Creature(xPos, yPos, hp) { Type = Tile.TileType.Enemy, GoldCount = gold };
                                gameEngine.MapClass.EnemiesProp[i] = swampCreature;
                                gameEngine.MapClass.MapProp[yPos, xPos] = swampCreature;
                                break;
                            }
                        }
                        break;
                    case "Gold":
                        Gold _gold = new Gold(xPos, yPos) { Type = Tile.TileType.Gold, AmountGold = gold };
                        for (int i = 0; i < gameEngine.MapClass.Items.Length; i++)
                        {
                            if (gameEngine.MapClass.Items[i] is null)
                            {
                                gameEngine.MapClass.Items[i] = _gold;
                            }
                        }
                        gameEngine.MapClass.MapProp[yPos, xPos] = _gold;
                        break;
                    default:
                        break;
                }
            }
            UpdateMap();
            gameEngine.MapClass.UpdateVision();
        }
    }
}
