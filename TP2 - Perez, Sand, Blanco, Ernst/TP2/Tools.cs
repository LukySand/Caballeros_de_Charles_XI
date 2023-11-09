using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    internal class Tools
    {
        public static DateTime ReadDateTime(DateTime? minDate = null, DateTime? maxDate = null)
        {
            while (true)
            {
                Console.WriteLine("Enter a date and time, it has to be from the current date(yyyy-MM-dd HH:mm:ss): ");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime date))
                {
                    if ((minDate == null || date >= minDate) && (maxDate == null || date <= maxDate))
                    {
                        return date;
                    }
                    else
                    {
                        Console.WriteLine("The entered date is not within the specified limits.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date and time format. Please enter a valid date and time.");
                }
            }
        }

        public static int ReadINT(int Min, int Max)
        {
            int opc = -1;
            bool Exeption = true;
            while(Exeption)
            {
                Console.Write("Enter an Integer: ");
                
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    Exeption = false;
                }
                catch (System.FormatException)
                {                 
                    Console.WriteLine("Please enter an integer: ");
                    Exeption = true;
                }
                if (Exeption == false)
                {
                    if (opc < Min || opc > Max)
                    {
                        Exeption = true;
                        Console.WriteLine($"Please enter a number between {Min} and {Max} ");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return opc;
        }

        public static float ReadFloat(int Min, int Max)
        {
            float opc = -1;
            bool Exeption = true;
            while (Exeption)
            {
                Console.Write("Enter a number with a dot: ");

                try
                {
                    opc = float.Parse(Console.ReadLine());
                    Exeption = false;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter a number with a comma: ");
                    Exeption = true;
                }
                if (Exeption == false)
                {
                    if (opc < Min || opc > Max)
                    {
                        Exeption = true;
                        Console.WriteLine($"Please enter a number between {Min} and {Max} ");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return opc;
        }

            

        public static void DrawMenu(string title, string[] Array)
        {
            int num = 0;

            for (int i = 0; i < Array.Length; i++)
            {
                if (num < Array[i].Length)
                {
                    num = Array[i].Length;
                }
            }
            if (title.Length > num)
            {
                num = title.Length;
            }
            num = num + 4; // We add the 4 to include the 4 spaces that are taken up by the numbers in the beggining of the table
            int y = Console.CursorTop + 1;
            int x = Console.CursorLeft;

            for (int i = 0; i < Array.Length + 4; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(x, y - 1);
                    Console.Write("╔");
                    for (int j = 0; j < num + 2; j++)
                    {
                        Console.Write("═");
                    }
                    Console.Write("╗");
                    Console.SetCursorPosition(x, y);
                }

                else if (i == 1)
                {
                    Console.Write("║");
                    Console.SetCursorPosition(x + ((num + 3) / 2) - title.Length / 2, y);
                    Console.Write(title);
                    Console.SetCursorPosition(x + num + 3, y);
                    Console.Write("║");
                    Console.SetCursorPosition(x, y);
                }
                else if (i == 2)
                {
                    y++;
                    Console.SetCursorPosition(x + 1, y);
                    for (int j = 0; j < num + 2; j++)
                    {
                        if (j == 2)
                        {
                            Console.Write("╦");
                        }
                        else
                        {
                            Console.Write("═");
                        }
                    }
                    Console.SetCursorPosition(x, y);
                    Console.Write("╠");
                    Console.SetCursorPosition(x + num + 3, y);
                    Console.Write("╣");
                }
                else if (i == Array.Length + 3)
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("╚");
                    for (int j = 0; j < num + 2; j++)
                    {
                        if (j == 2)
                        {
                            Console.Write("╩");
                        }
                        else
                        {
                            Console.Write("═");
                        }
                    }
                    Console.Write("╝");
                    Console.SetCursorPosition(x, y);
                }
                else
                {
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write("║");
                    if (i < Array.Length + 3)
                    {
                        Console.Write(i - 2 + ".");
                    }

                    Console.SetCursorPosition(x + 3, y + 1);
                    Console.Write("║");
                    if (i < Array.Length + 3)
                    {
                        Console.SetCursorPosition(x + 5, y + 1);
                        Console.Write(Array[i - 3]);
                    }
                    Console.SetCursorPosition(x + num + 3, y + 1);
                    Console.Write("║");
                    y++;
                }

            }
            //Console.SetCursorPosition(x, y + 10);
            // Console.Write(num); If you want to check that its acctually grabbing the correct length
        }


        public static void MiniRefresh(int x, int y, int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(x + j, y + i);
                    Console.Write(" ");
                }
            }
        }

        public static int SelectableMenu(string title, string[] options)        //this returns a Menu and the number of the option you selected
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;      //
            int plus = 0; //ths is the plus variable we are going to use it for knowing at what option we are going to return
            bool loops = true;
            // Iniciar una tarea asincrónica para manejar la entrada de usuario en segundo plano
            var inputTask = Task.Run(() =>
            {
                ConsoleKeyInfo key = new ConsoleKeyInfo(); //we iniciate the consoleKey tath we`re going to use for knowing what the user selects.
                while (loops)
                {
                    key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow && plus > 0)
                    {
                        plus--;
                    }
                    if (key.Key == ConsoleKey.DownArrow && plus < options.Length - 1)   // ths is minus one, because we need to remember that we do the miniRefresh + plus, and that starts on 0 because it needs to write in the spot.
                    {
                        plus++;
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        //Console.SetCursorPosition(15,15);
                        //Console.Write(plus + 1);
                        loops = false;

                    }
                }
            });
            while (loops)
            {
                Console.SetCursorPosition(x, y);
                DrawMenu(title, options);
                Thread.Sleep(250);
                MiniRefresh(x + 1, y + 3 + plus, 2, 1);
                Thread.Sleep(250);
            }
            inputTask.Wait();       //these come right after the while (loops) because if the while(loops) ends we need to end the funcion.
            return plus + 1;        //i have to return plus + 1 because remember that plus starts on 0
        }
        public static void UpLine(int height, char character, char? InitLine = null, char? EndLine = null)
        {
            int y = Console.CursorTop;      //esto guarda las variable y cuando empieza la funcion
            int x = Console.CursorLeft;     //esto guarda las variable x cuando empieza la funcion

            if (InitLine != null && EndLine != null)        //FIRST CASE
            {
                Console.CursorTop = y;
                Console.Write(EndLine);     //pongo aca el endline porque hay que acorarse que estoy escribiendo de abajo para arriba y por eso este va a ser el primero
                Console.CursorLeft = x;

                for (int i = 1; i < (height - 1); i++)      // aclaracion empieza en 1 por el caracter inicial que le paso y le resto 1 para que lo haga 2 veces menos ya que tenemos caracter de incio y de final.
                {
                    Console.CursorTop = y - i;
                    Console.Write(character);
                    Console.CursorLeft = x;
                }

                Console.CursorTop = y - height + 1; // esto funciona porque el for es con '<' y no con '<=' (aclaracion se le suma +1 porque se empieza desde la posicion 0 del piso y bueno sino me sobra 1 lugar)
                Console.Write(InitLine);        //y como este va a ser el ultimo en escribirse y voy de abajo para arriba va a ser el primero

            }
            if (InitLine == null)       //SECOND CASE
            {
                Console.CursorTop = y;
                Console.Write(EndLine);     //idem del comentario del if anterior
                Console.CursorLeft = x;

                for (int i = 1; i < height; i++)      //Fijarse que aca hay un '<' en vez de un '<=' de vuelta porque solo quiero repetir el ciclo 1 vez menos ya que tengo el caracter de final nadamas
                {
                    Console.CursorTop = y - i;
                    Console.Write(character);
                    Console.CursorLeft = x;
                }

            }
            if (EndLine == null)        //THIRD CASE
            {
                for (int i = 0; i < height; i++)      //Fijarse que lo empiezo en 0 porque tengo solo el caracter de inicio, ademas le resto uno por lo mismo que el anterior
                {
                    Console.CursorTop = y - i;
                    Console.Write(character);
                    Console.CursorLeft = x;
                }

                Console.CursorTop = y - height + 1; // esto funciona porque el for es con '<' y no con '<=' se le agraga 1 porque la funcion empieza desde el 0 y para no hacer un especio de mas.
                Console.Write(InitLine);        //y como este va a ser el ultimo en escribirse y voy de abajo para arriba va a ser el primero

            }
            if (InitLine == null && EndLine == null)        //FORTH CASE
            {
                for (int i = 0; i < height; i++)      //este es el mas simple de todos solo hace una linea de caracteres para arriba
                {
                    Console.CursorTop = y - i;
                    Console.Write(character);
                    Console.CursorLeft = x;
                }
            }
        }

        public static void DownLine(int height, char character, char? InitLine = null, char? EndLine = null)
        {
            int y = Console.CursorTop;      //esto guarda las variable y cuando empieza la funcion
            int x = Console.CursorLeft;     //esto guarda las variable x cuando empieza la funcion

            if (InitLine != null && EndLine != null)        //FIRST CASE
            {
                Console.CursorTop = y;
                Console.Write(InitLine);     //pongo aca el endline porque hay que acorarse que estoy escribiendo de abajo para arriba y por eso este va a ser el primero
                Console.CursorLeft = x;

                for (int i = 1; i < (height - 1); i++)      // aclaracion empieza en 1 por el caracter inicial que le paso y le resto 1 para que lo haga 2 veces menos ya que tenemos caracter de incio y de final.
                {
                    Console.CursorTop = y + i;
                    Console.Write(character);
                    Console.CursorLeft = x;
                }

                Console.CursorTop = y + height - 1; // esto funciona porque el for es con '<' y no con '<=' (aclaracion se le suma +1 porque se empieza desde la posicion 0 del piso y bueno sino me sobra 1 lugar)
                Console.Write(EndLine);        //y como este va a ser el ultimo en escribirse y voy de abajo para arriba va a ser el primero

            }
            if (EndLine == null)       //SECOND CASE
            {
                Console.CursorTop = y;
                Console.Write(InitLine);     //idem del comentario del if anterior
                Console.CursorLeft = x;

                for (int i = 1; i < height; i++)      //Fijarse que aca hay un '<' en vez de un '<=' de vuelta porque solo quiero repetir el ciclo 1 vez menos ya que tengo el caracter de final nadamas
                {
                    Console.CursorTop = y + i;
                    Console.Write(character);
                    Console.CursorLeft = x;
                }

            }
            if (InitLine == null)        //THIRD CASE 
            {
                for (int i = 0; i < height; i++)      //Fijarse que lo empiezo en 0 porque tengo solo el caracter de inicio, ademas le resto uno por lo mismo que el anterior
                {
                    Console.CursorTop = y + i;
                    Console.Write(character);
                    Console.CursorLeft = x;
                }

                Console.CursorTop = y + height - 1; // esto funciona porque el for es con '<' y no con '<=' se le resta 1 porque la funcion empieza desde el 0 y para hacer espacio para el caracter inicial.
                Console.Write(EndLine);        //y como este va a ser el ultimo en escribirse y voy de abajo para arriba va a ser el primero

            }
            if (InitLine == null && EndLine == null)        //FORTH CASE
            {
                for (int i = 0; i < height; i++)      //este es el mas simple de todos solo hace una linea de caracteres para arriba
                {
                    Console.CursorTop = y + i;
                    Console.Write(character);
                    Console.CursorLeft = x;
                }
            }
        }

        public static void HorizontalLine(int width, char character)
        {
            int x = Console.CursorLeft;  //esto guarda las variable x cuando empieza la funcion
            for (int i = 1; i < width; i++)   // en este for lo hago con width - 2 por las esquinas de los edificios, para que sea el largo correcto.
            {
                Console.CursorLeft = x + i;
                Console.Write(character);
            }
        }

        public static void DrawBox(int x, int y, int width, int height)
        {
            Console.SetCursorPosition(x, y);    // |
            DownLine(height, '║', '╔', '╚');
            Console.SetCursorPosition(x, y);    // -
            HorizontalLine(width, '═');
            Console.SetCursorPosition(x + width, y);    // |
            DownLine(height, '║', '╗', '╝');
            Console.SetCursorPosition(x, y + height - 1);    // -
            HorizontalLine(width, '═');
            Console.SetCursorPosition(x, y + height + 1);    //i make this so the mesage 
        }

        public static void DrawTable(string[,] matrix)
        {
            int LongestWord = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)   //lets remember that matrix.GetLength(0) returns the rows and matrix.GetLength(1) returns the columns of a matrix
            {
                for (int j = 0; j < matrix.GetLength(1); j++)   //lets remember that matrix.GetLength(0) returns the rows and matrix.GetLength(1) returns the columns of a matrix
                {
                    if (matrix[i, j].Length > LongestWord)
                    {
                        LongestWord = matrix[i, j].Length;
                    }
                }
            }

            int y = Console.CursorTop;
            int x = Console.CursorLeft;

            char InitCharacter = ' ';   // this is what we`re going to use to switch the first character depending on what position we are.
            char EndCharacter = '║';    // this is what we`re going to use to switch the last character depending on what position we are.

            Console.SetCursorPosition(x, y + (matrix.GetLength(0) * 2)); //this is the last line of the table
            HorizontalLine(matrix.GetLength(1) * (LongestWord + 4), '═');

            for (int row = 0; row < matrix.GetLength(0); row++)   //lets remember that matrix.GetLength(0) returns the rows and matrix.GetLength(1) returns the columns of a matrix
            {
                Console.SetCursorPosition(x, y + (row * 2));    //this is the position of the cursor for making the horizontal lines
                Tools.HorizontalLine(matrix.GetLength(1) * (LongestWord + 4), '═'); //these are the horizontal lines of the table
                for (int column = 0; column <= matrix.GetLength(1); column++)   //lets remember that matrix.GetLength(0) returns the rows and matrix.GetLength(1) returns the columns of a matrix
                {       // this is <= because we need to do the walls of the table 1 time more

                    if (column > 0 && column < matrix.GetLength(1) && row > 0 && row < matrix.GetLength(0)) // this is comparing if it`s a middle section of the table
                    {
                        InitCharacter = '╬';
                    }
                    else    //if it`s not a middle section of the matrix we need a special character
                    {
                        if (column == 0)     //this is comparing if it`s on the right limit of the matrix
                        {
                            if (row == 0)   //top right corner
                            {
                                InitCharacter = '╔';
                            }
                            if (row > 0)    // just the right border
                            {
                                InitCharacter = '╠';
                            }
                        }
                        if (column == matrix.GetLength(1))   // this is comparing if it reached the left limit of the matrix
                        {
                            if (row == 0)
                            {
                                InitCharacter = '╗';    // just the top left corner
                            }
                            if (row > 0)
                            {
                                InitCharacter = '╣';    // just the left border
                            }
                        }
                    }
                    if (row == 0 && (column > 0 && column < matrix.GetLength(1)))
                    {
                        InitCharacter = '╦';
                    }
                    if (row == matrix.GetLength(0) - 1)     // this is comparing if it reached the bottom end of the matrix
                    {
                        if (column > 0 && column < matrix.GetLength(1))
                        {
                            EndCharacter = '╩';     // the bottom character
                        }
                        else    // if it didn`t go trough the first if it`s because its one of the 2 bottom corners of the matrix.
                        {
                            if (column == matrix.GetLength(1))
                            {
                                EndCharacter = '╝';     // just the right bottom corner
                            }
                            if (column == 0)
                            {
                                EndCharacter = '╚';     // just the left bottom corner
                            }
                        }
                    }
                    else    // if none of the others conditions are true the end character will be the normal line.
                    {
                        EndCharacter = '║';   // the normal line
                    }


                    //aca vienen las columnas de la matriz

                    Console.SetCursorPosition(x + (column * (LongestWord + 4)), y + (row * 2));     //here i set the position of the vertical lines of the table
                    Tools.DownLine(3, '║', InitCharacter, EndCharacter);    //the lines have a height of 3 so they can overwrite themselves and have the perfect height for the las horizontal line
                    if (column < matrix.GetLength(1))   //this if is here because column goes up to matrix.GetLength(1), and that gives me an arrayOutOfIndex.
                    {
                        Console.SetCursorPosition(x + ((LongestWord - matrix[row, column].Length) / 2) + 3 + (column * (LongestWord + 4)), y + (row * 2) + 1);
                        //this is basic chinesee but ir basicaly sums x division of the diference of the longest word with the word we want to print
                        // to that we add 3 because 2 of those 3 spaces are because we leave at least 2 spaces to the begining of heach word
                        // and the space remaining is for the 1 space that the vertical line takes, and to that i add the space between heach word.
                        if (row == 0)   //if we`re at the first row it changes the color of the characters
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write(matrix[row, column]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(matrix[row, column]);
                        }
                    }
                }
            }
            Console.SetCursorPosition(x, y + (matrix.GetLength(0) * 2) + 1); // i return the cursor 1 line down from the end of the table
        }
    }
    
}
