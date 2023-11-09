using Library_C11K;
using System.Data.Common;

namespace TP_1_Caballeros_de_Charles_XI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.SetCursorPosition(Console.WindowWidth/3, Console.WindowHeight/3);
            *//*string[] OptionsMenu = new string[] { "Play", "Controls", "Exit" };
            Tools.SelectableMenu("Menu Principal", OptionsMenu);        //this is going to return a value wich is ging to be the number option*/

            /*string[,] matrizFrutas = new string[3, 3]
            {
                {"Manzana", "Banana", "Naranja"},
                {"Frutilla", "Uva", "Anana"},
                {"Cereza", "Mango", "Kiwi"}
            };
            DrawTable(matrizFrutas);*//*
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            DrawParking(8, 7);
            Console.SetCursorPosition(x, y);
            paintParking(1, 1,ConsoleColor.Yellow);
            paintParking(2, 4, ConsoleColor.Blue);
            paintParking(0, 6, ConsoleColor.DarkRed);
            paintParking(5, 2, ConsoleColor.Green);
            paintParking(4, 0, ConsoleColor.Magenta);
            paintParking(7, 5, ConsoleColor.Cyan);
            paintParking(4, 6, ConsoleColor.White);
            Console.ReadKey();*/
            //Console.Write("\n Enter the event Date (yyyy-mm-dd): ");
            Console.Write("\nEnter the Event Duration (on Hours: minutes): ");
            Console.WriteLine(ReadTime());
        }
        public static TimeOnly ReadTime()
        {
            bool repeat = false;
            DateTime time;
            string returnable = null;
            do
            {
                try
                {
                    returnable = Console.ReadLine();
                    time = DateTime.Parse(returnable);
                    repeat = false;
                }
                catch (FormatException)
                {
                    repeat = true;
                    Console.Write("\n Input a valid Time (hh:mm): ");
                }
            } while (repeat);
            return TimeOnly.Parse(returnable);
        }

        public static void DrawParking(int row, int column)
        {
            int y = Console.CursorTop;
            int x = Console.CursorLeft;
            if (column > 2)
            {
                for (int i = 0; i < column/2; i++)
                {
                    Console.SetCursorPosition(x + i * 10, y);
                    makeParking(row, 2);
                }
            }
            else
            {
                makeParking(row, column);
            }
            if (column != 1 && column % 2 == 1 )
            {
                Console.SetCursorPosition(x + (column / 2) * 10, y);    //en este caso el SetCursorPosition es x + (column / 2) * 10 ya que:
                                                                        //column/2 es la cantidad de parkings que tengo,  los multiplico por 10 porque es la cantidad de espacio que toma cada uno.
                makeParking(row,1);
            }
        }


        public static void paintParking(int row, int column, System.ConsoleColor color) //acordarse que esto hay que ponerlo justo en el mismo lugar en donde se dibuja el Parking :)
        {
            int y = Console.CursorTop;
            int x = Console.CursorLeft;

            Console.SetCursorPosition(x + 1 + (column * 4) + (column/2) *2, y + (row * 2) + 1);  //empieza en x + 1 porque hay que acordarse que la funcion de hacer parkings deriba de la de hacer matrices
                                                                            // y  No estamos haciendo las paredes y eso lleva un espacio jeje
            Console.BackgroundColor = color;
            Console.Write("   ");
            Console.ResetColor();
            Console.SetCursorPosition(x, y);    //i reset the position of the cursor in the place that it wtarted, so it can still be used to paint more spaces
        }

        public static void makeParking(int rowNumber, int columnNumber)
        {
            int y = Console.CursorTop;
            int x = Console.CursorLeft;

            char InitCharacter = ' ';   // this is what we`re going to use to switch the first character depending on what position we are.
            char EndCharacter = ' ';    // this is what we`re going to use to switch the last character depending on what position we are.


            if(columnNumber == 1)
            {
                Console.SetCursorPosition(x, y + (rowNumber * 2)); //this is the last line of the table
                Tools.HorizontalLine(4, '═');

                for (int row = 0; row < rowNumber; row++)   //lets remember that matrix.GetLength(0) returns the rows and matrix.GetLength(1) returns the columns of a matrix
                {
                    Console.SetCursorPosition(x, y + (row * 2));    //this is the position of the cursor for making the horizontal lines
                    Tools.HorizontalLine(4, '═'); //these are the horizontal lines of the table
                    for (int column = 1; column <= columnNumber; column++)   
                    {       // this is <= because we need to do the walls of the table 1 time more

                        if (row > 0 && row < rowNumber) // this is comparing if it`s a middle section of the table
                        {
                            InitCharacter = '╣';
                        }
                        if (row == 0)
                        {
                            InitCharacter = '╗';
                        }
                        if (row == rowNumber - 1)     // this is comparing if it reached the bottom end of the matrix
                        {
                            EndCharacter = '╝';     // the bottom character
                        }
                        else    // if none of the others conditions are true the end character will be the normal line.
                        {
                            EndCharacter = '║';   // the normal line
                        }

                        //aca vienen las columnas de la matriz

                        Console.SetCursorPosition(x + (column * 3) + 1, y + (row * 2));     //here i set the position of the vertical lines of the table
                        Tools.DownLine(3, '║', InitCharacter, EndCharacter);    //the lines have a height of 3 so they can overwrite themselves and have the perfect height for the las horizontal line
                    }
                }
            }
            else
            {
                Console.SetCursorPosition(x, y + (rowNumber * 2)); //this is the last line of the table
                Tools.HorizontalLine(8, '═');

                for (int row = 0; row < rowNumber; row++)   //lets remember that matrix.GetLength(0) returns the rows and matrix.GetLength(1) returns the columns of a matrix
                {
                    Console.SetCursorPosition(x, y + (row * 2));    //this is the position of the cursor for making the horizontal lines
                    Tools.HorizontalLine(8, '═'); //these are the horizontal lines of the table
                    for (int column = 1; column < columnNumber; column++)   //the variable column starts on 1 and repeats < columNumber because i dont want to draw the first 2 walls of the matrix.
                    {       // this is <= because we need to do the walls of the table 1 time more

                        if (column > 0 && column < columnNumber && row > 0 && row < rowNumber) // this is comparing if it`s a middle section of the table
                        {
                            InitCharacter = '╬';
                        }

                        if (row == 0 && (column > 0 && column < columnNumber))
                        {
                            InitCharacter = '╦';
                        }
                        if (row == rowNumber - 1)     // this is comparing if it reached the bottom end of the matrix
                        {
                            if (column > 0 && column < columnNumber)
                            {
                                EndCharacter = '╩';     // the bottom character
                            }
                        }
                        else    // if none of the others conditions are true the end character will be the normal line.
                        {
                            EndCharacter = '║';   // the normal line
                        }

                        //aca vienen las columnas de la matriz

                        Console.SetCursorPosition(x + (column * 3) + 1, y + (row * 2));     
                        Tools.DownLine(3, '║', InitCharacter, EndCharacter);
                    }
                }
            }
                       
            Console.SetCursorPosition(x, y + (rowNumber * 2) + 1); // i return the cursor 1 line down from the end of the table
        }
    }
}