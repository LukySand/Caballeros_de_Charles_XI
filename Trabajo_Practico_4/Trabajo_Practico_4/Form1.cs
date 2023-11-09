using System.Data.SQLite;
using Trabajo_Practico_4.Controlers;
using Trabajo_Practico_4.Entitys;

namespace Trabajo_Practico_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EGamePanel.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (pGame.CheckGame())
            {
                btContinue.Enabled = true;
            }
            else
            {
                btContinue.Enabled = false;
            }
        }

        private void bPlay_Click(object sender, EventArgs e)
        {
            LiveGame liveGame = new LiveGame();
            Panel_Menu.Hide();
            liveGame.Show();
            Game.StartGame();
        }


        private void btContinue_Click(object sender, EventArgs e)
        {
            EGamePanel.Show();
            this.Width += 150;
            ContinueGamesPrint();
        }

        public void ContinueGamesPrint()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT GG_Id, Status, Name FROM GameGeneral");
            //cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            int Top = 0;
            while (obdr.Read())
            {
                if (obdr.GetInt32(1) == 1)
                {

                    ButtonGames bt = new ButtonGames();
                    bt.Width = 100;
                    bt.Height = 45;
                    bt.Top = Top * bt.Height;
                    bt.Text = obdr.GetString(2);
                    bt.Name = "bt_" + obdr.GetInt32(0).ToString();
                    bt.Click += LoadGamesButton;
                    EGamePanel.Controls.Add(bt);
                    Top++;
                }

            }
        } // Wanted to do this in the pGame, but makes it 10x more complicated casue i need to initilize the form1

        public void LoadGamesButton(object sender, EventArgs e)
        {
            ButtonGames bt = (ButtonGames)sender;
            LiveGame liveGame = new LiveGame(bt.Id);
            Panel_Menu.Hide();
            liveGame.Show();
            Game.StartGame();
        }

        private void EGamePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}