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
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
