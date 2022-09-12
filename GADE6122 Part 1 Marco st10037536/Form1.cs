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
        }

        private void txtMap_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.Up);
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.Down);
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.Left);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            gameEngine.MovePlayer(Character.MovementEnum.Right);
        }

    }
}
