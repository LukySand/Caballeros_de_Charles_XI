using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Practico_4.Controlers;

namespace Trabajo_Practico_4
{
    public partial class Difficulty : Form
    {
        public Difficulty()
        {
            InitializeComponent();
        }

        private void btEasy_Click(object sender, EventArgs e)
        {
            LiveGame liveGame = new LiveGame();
            Levels.Easy_1(liveGame.MatrixGame);
            Panel_difficultity.Hide();
            liveGame.Show();
            Game.StartGame();
        }

        private void btMedium_Click(object sender, EventArgs e)
        {
            LiveGame liveGame = new LiveGame();
            Levels.Medium_2(liveGame.MatrixGame);
            Panel_difficultity.Hide();
            liveGame.Show();
            Game.StartGame();
        }

        private void btHard_Click(object sender, EventArgs e)
        {
            LiveGame liveGame = new LiveGame();
            Levels.Hard_3(liveGame.MatrixGame);
            Panel_difficultity.Hide();
            liveGame.Show();
            Game.StartGame();
        }
    }
}
