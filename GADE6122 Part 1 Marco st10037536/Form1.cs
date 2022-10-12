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
            gameEngine = new GameEngine();
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.Up);
            txtMap.Text = gameEngine.MapClass.ToString();
            infoTextBox.Text = gameEngine.MapClass.HeroProp.ToString();
            gameEngine.MapClass.UpdateVision();

        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.Down);
            txtMap.Text = gameEngine.MapClass.ToString();
            infoTextBox.Text = gameEngine.MapClass.HeroProp.ToString();
            gameEngine.MapClass.UpdateVision();

        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.Left);
            txtMap.Text = gameEngine.MapClass.ToString();
            infoTextBox.Text = gameEngine.MapClass.HeroProp.ToString();
            gameEngine.MapClass.UpdateVision();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.Right);
            txtMap.Text = gameEngine.MapClass.ToString();
            infoTextBox.Text = gameEngine.MapClass.HeroProp.ToString();
            gameEngine.MapClass.UpdateVision();
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



        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.NoMovement);
            txtMap.Text = gameEngine.MapClass.ToString();
            infoTextBox.Text = gameEngine.MapClass.HeroProp.ToString();
            gameEngine.MapClass.UpdateVision();
        }
    }
}
