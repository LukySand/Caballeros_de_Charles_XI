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
using System.Data.SQLite;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trabajo_Practico_4
{
    public partial class LiveGame : Form
    {
        public TextBox[,] MatrixGame;

        public int IdEG { get; set; }

        public LiveGame()
        {
            InitializeComponent();
            Conection.OpenConnection();
            LoadTBMatrix();
            //pGame.GetGame(MatrixGame);
            Levels.Easy_1(MatrixGame);
            PinStarters();

        }
        public LiveGame(int Ideg)
        {
            InitializeComponent();
            Conection.OpenConnection();
            LoadTBMatrix();
            //pGame.GetGame(MatrixGame);
            Levels.Easy_1(MatrixGame);
            PinStarters();
            IdEG = Ideg;
        }

        private void LiveGame_Load(object sender, EventArgs e)
        {

        }
        private void LiveGame_Validating(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (TB_Validation(textBox))
            {
                if ((Game.checkArray(SplitMatrix(textBox)) || Game.checkArray(SplitRow(textBox)) || Game.checkArray(SplitColumn(textBox))) == true)
                {
                    textBox.ForeColor = Color.DarkRed;
                }
                else
                {
                    textBox.ForeColor = Color.DarkBlue;
                }
            }
        }


        public void LoadTBMatrix()
        {
            MatrixGame = new TextBox[9, 9]
            {
                {TB_00, TB_01, TB_02, TB_03, TB_04, TB_05, TB_06, TB_07, TB_08 },
                {TB_10, TB_11, TB_12, TB_13, TB_14, TB_15, TB_16, TB_17, TB_18 },
                {TB_20, TB_21, TB_22, TB_23, TB_24, TB_25, TB_26, TB_27, TB_28 },
                {TB_30, TB_31, TB_32, TB_33, TB_34, TB_35, TB_36, TB_37, TB_38 },
                {TB_40, TB_41, TB_42, TB_43, TB_44, TB_45, TB_46, TB_47, TB_48 },
                {TB_50, TB_51, TB_52, TB_53, TB_54, TB_55, TB_56, TB_57, TB_58 },
                {TB_60, TB_61, TB_62, TB_63, TB_64, TB_65, TB_66, TB_67, TB_68 },
                {TB_70, TB_71, TB_72, TB_73, TB_74, TB_75, TB_76, TB_77, TB_78 },
                {TB_80, TB_81, TB_82, TB_83, TB_84, TB_85, TB_86, TB_87, TB_88 }
            };
        }

        public int[] SplitMatrix(TextBox TB)
        {
            int[] returnableArray = new int[9];

            int row = int.Parse(TB.Name.Substring(3, 1));//this makes a substring of the position of the button and then it truns it into a integer
            int column = int.Parse(TB.Name.Substring(4, 1));//this makes a substring of the position of the button and then it truns it into a integer

            row = (row / 3) * 3 + 3;
            column = (column / 3) * 3 + 3;

            int index = 0;

            for (int x = row - 3; x < row; x++)
            {
                for (int y = column - 3; y < column; y++)
                {
                    returnableArray[index] = pGame.parseTB(MatrixGame[x, y].Text);
                    index++;
                }
            }

            return returnableArray; //que epico metodo que hice -lucas 4/11, 22:56:48 
        }


        public bool TB_Validation(TextBox tb)
        {
            try
            {
                int number = int.Parse(tb.Text);

                if (number < 1 || number > 9)
                {
                    //MessageBox.Show("Invalid input. Please enter a number between 1 and 9.");
                    tb.Clear();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                // MessageBox.Show("Invalid input. Please enter a valid number.");
                tb.Clear();
                return false;
            }
        }

        public int[] SplitRow(TextBox TB)
        {
            int[] returnableArray = new int[9];

            int row = int.Parse(TB.Name.Substring(3, 1));//this makes a substring of the position of the button and then it truns it into a integer


            for (int column = 0; column < 9; column++)
            {
                returnableArray[column] = pGame.parseTB(MatrixGame[row, column].Text);
            }

            return returnableArray; //que epico metodo que hice -lucas 4/11, 22:56:48 
        }

        public int[] SplitColumn(TextBox TB)
        {
            int[] returnableArray = new int[9];

            int column = int.Parse(TB.Name.Substring(4, 1));//this makes a substring of the position of the button and then it truns it into a integer


            for (int row = 0; row < 9; row++)
            {
                returnableArray[row] = pGame.parseTB(MatrixGame[row, column].Text);
            }

            return returnableArray; //que epico metodo que hice -lucas 4/11, 22:56:48 
        }

        public void PinStarters()
        {
            foreach (TextBox TB in MatrixGame)
            {
                if (!string.IsNullOrEmpty(TB.Text)) //no podemos usar != null porque nos da cualquier cosa, esto compara si NO es nulo.
                {
                    TB.ForeColor = Color.Black;
                    TB.ReadOnly = true;
                }
                else
                {
                    TB.ReadOnly = false;
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            pGame.UpdateGame(MatrixGame);
        }

        public bool EndgameValidation()     //this is the function that validates if the game is in a situation to end and returns a bool
        {
            foreach (TextBox TB in MatrixGame)
            {
                if (string.IsNullOrEmpty(TB.Text) || TB.ForeColor == Color.DarkRed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
