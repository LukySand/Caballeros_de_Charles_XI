using Trabajo_Practico_4.Controlers;
using Trabajo_Practico_4.Entitys;

namespace Trabajo_Practico_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bPlay_Click(object sender, EventArgs e)
        {
            //LiveGame liveGame = new LiveGame();
            Difficulty difficulty = new Difficulty();
            Panel_Menu.Hide();
            difficulty.Show();
            //Game.StartGame();
        }
    }
}