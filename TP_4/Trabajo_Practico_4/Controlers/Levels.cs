using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Practico_4.Controlers;


namespace Trabajo_Practico_4.Controlers
{
    internal class Levels
    {

        public static void Easy_1(TextBox[,] MatrixEasy)
        {           
            MatrixEasy[1, 0].Text = "3";
            MatrixEasy[2, 0].Text = "4";
            MatrixEasy[3, 0].Text = "9";
            MatrixEasy[4, 0].Text = "5";
            MatrixEasy[6, 0].Text = "6";
            MatrixEasy[8, 0].Text = "2";
            MatrixEasy[1, 1].Text = "8";
            MatrixEasy[3, 1].Text = "3";
            MatrixEasy[6, 1].Text = "7";
            MatrixEasy[4, 2].Text = "7";
            MatrixEasy[6, 2].Text = "3";
            MatrixEasy[7, 2].Text = "5";
            MatrixEasy[2, 3].Text = "8";
            MatrixEasy[7, 3].Text = "9";
            MatrixEasy[0, 4].Text = "1";
            MatrixEasy[1, 4].Text = "9";
            MatrixEasy[2, 4].Text = "7";
            MatrixEasy[3, 4].Text = "8";
            MatrixEasy[8, 4].Text = "4";
            MatrixEasy[1, 5].Text = "4";
            MatrixEasy[2, 5].Text = "2";
            MatrixEasy[4, 5].Text = "9";
            MatrixEasy[7, 5].Text = "6";
            MatrixEasy[8, 5].Text = "7";
            MatrixEasy[1, 6].Text = "2";
            MatrixEasy[2, 6].Text = "6";
            MatrixEasy[3, 6].Text = "7";
            MatrixEasy[5, 6].Text = "1";
            MatrixEasy[7, 6].Text = "3";
            MatrixEasy[1, 7].Text = "5";
            MatrixEasy[2, 7].Text = "1";
            MatrixEasy[3, 7].Text = "4";
            MatrixEasy[7, 7].Text = "7";
            MatrixEasy[8, 7].Text = "6";
            MatrixEasy[0, 8].Text = "4";
            MatrixEasy[2, 8].Text = "3";
            MatrixEasy[3, 8].Text = "5";
            MatrixEasy[6, 8].Text = "9";
        }

        public static void Medium_2(TextBox[,] MatrixMedium)
        {
            MatrixMedium[0, 0].Text = "1";
            MatrixMedium[4, 0].Text = "8";
            MatrixMedium[6, 0].Text = "7";
            MatrixMedium[7, 0].Text = "5";
            MatrixMedium[8, 0].Text = "3";
            MatrixMedium[2, 1].Text = "2";
            MatrixMedium[3, 1].Text = "7";
            MatrixMedium[7, 1].Text = "9";
            MatrixMedium[1, 2].Text = "4";
            MatrixMedium[4, 2].Text = "9";
            MatrixMedium[0, 3].Text = "9";
            MatrixMedium[2, 3].Text = "4";
            MatrixMedium[5, 3].Text = "6";
            MatrixMedium[8, 3].Text = "1";
            MatrixMedium[0, 4].Text = "2";
            MatrixMedium[3, 4].Text = "1";
            MatrixMedium[4, 4].Text = "3";
            MatrixMedium[8, 4].Text = "9";
            MatrixMedium[5, 5].Text = "5";
            MatrixMedium[6, 5].Text = "8";
            MatrixMedium[1, 6].Text = "6";
            MatrixMedium[6, 6].Text = "3";
            MatrixMedium[0, 7].Text = "4";
            MatrixMedium[2, 7].Text = "9";
            MatrixMedium[5, 7].Text = "7";
            MatrixMedium[7, 7].Text = "8";
            MatrixMedium[0, 8].Text = "3";
            MatrixMedium[3, 8].Text = "5";
            MatrixMedium[5, 8].Text = "4";
            MatrixMedium[8, 8].Text = "2";
        }

        public static void Hard_3(TextBox[,] MatrixHard)
        {
            MatrixHard[1, 0].Text = "9";
            MatrixHard[3, 0].Text = "1";
            MatrixHard[4, 0].Text = "7";
            MatrixHard[5, 0].Text = "8";
            MatrixHard[7, 0].Text = "4";
            MatrixHard[0, 1].Text = "7";
            MatrixHard[7, 1].Text = "9";
            MatrixHard[8, 2].Text = "6";
            MatrixHard[0, 3].Text = "8";
            MatrixHard[2, 3].Text = "5";
            MatrixHard[1, 4].Text = "7";
            MatrixHard[3, 4].Text = "8";
            MatrixHard[5, 4].Text = "5";
            MatrixHard[8, 4].Text = "2";
            MatrixHard[3, 5].Text = "4";
            MatrixHard[7, 5].Text = "3";
            MatrixHard[8, 5].Text = "8";
            MatrixHard[5, 6].Text = "4";
            MatrixHard[6, 6].Text = "9";
            MatrixHard[7, 6].Text = "1";
            MatrixHard[8, 6].Text = "3";
            MatrixHard[0, 7].Text = "9";
            MatrixHard[2, 7].Text = "7";
            MatrixHard[4, 7].Text = "8";
            MatrixHard[6, 7].Text = "2";
            MatrixHard[1, 8].Text = "3";
            MatrixHard[4, 8].Text = "1";
            MatrixHard[7, 8].Text = "8";
        }
    }
}
