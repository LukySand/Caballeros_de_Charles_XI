    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Practico_4.Entitys;

namespace Trabajo_Practico_4.Controlers
{
    internal class Game
    {
        public static void StartGame()
        {
            //SudokuGen s = new SudokuGen();
        }

        public static void CreateGrid()
        {

        }

        public static bool checkArray(int[] line) //esto hay que checkear que al hacer el box to array no se repita el valor con el que se quiere comparar si esta en la linea 2 veces.
        {
            Array.Sort(line);

            for(int value = 0; value < line.Length - 1; value++)
            {
                if (line[value] != 0 && line[value] == line[value + 1])
                {
                    return true;
                }
            }
            //esto es asi porque por alguna razon podria haber mas de 2, ej: que se repita 3 veces el num, la gente es boba
            
            return false;
        }
    

        public static bool BoxCheck(int[,] matrix, int value)
        {
            int returnable = 0;
            for(int row = 0; row > matrix.GetLength(0); row++)
            {
                for (int column = 0; column > matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] == value)
                    {
                        returnable += 1;
                    }
                }
            }
            if (returnable >= 2)    //esto es asi porque por alguna razon podria haber mas de 2, ej: que se repita 3 veces el num, la gente es boba
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool LineCheck(int[,] matrix_1, int[,] matrix_2, int[,] matrix_3, int line, int value)
        {
            int returnable = 0;
            for (int x = 0; x > matrix_1.GetLength(1); x++)
            {
                if (matrix_1[line, x] == value || matrix_2[line, x] == value || matrix_3[line, x] == value)
                {
                    returnable += 1;
                }
            }
            if (returnable >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ColumnCheck(int[,] matrix_1, int[,] matrix_2, int[,] matrix_3, int column, int value)
        {
            int returnable = 0;
            for (int x = 0; x > matrix_1.GetLength(0); x++)
            {
                if (matrix_1[x, column] == value || matrix_2[x, column] == value || matrix_3[x, column] == value)
                {
                    returnable += 1;
                }
            }
            if (returnable >= 2)
            {
                return true;
            }
            else
            {
                return false;   
            }
        }

        public static bool GameWin(int[,] matrix_1, int[,] matrix_2, int[,] matrix_3, int row, int column) //se fija que no haya ningun valor en las filas y columnas para saber si se completo 
        {
            for (row = 0; row < matrix_1.GetLength(0); row++)
            {
                for (column = 0; column < matrix_1.GetLength(1); column++)
                {
                    if (matrix_1[row, column] == 0 || matrix_2[row, column] == 0 || matrix_3[row, column] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
