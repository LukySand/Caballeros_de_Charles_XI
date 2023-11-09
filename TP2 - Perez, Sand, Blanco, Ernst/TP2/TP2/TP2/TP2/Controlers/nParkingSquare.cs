using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Entitys;

namespace TP2.Controlers
{
    internal class nParkingSquare
    {
        public static List<ParkingSquare> ParkingSquares = new List<ParkingSquare>();

        public static List<Ticket> tickets = new List<Ticket>();

        public static int lastParkingSquareId = 1; 

        public static void Create()
        {
            ParkingSquare parkingsquare = new ParkingSquare();
            parkingsquare.Id = lastParkingSquareId++;
            Console.Write("Enter the hourly price of the parking (1 - 100): ");
            parkingsquare.Price = Tools.ReadFloat(0, 100);
            Console.Write("Enter the number of rows of the parking, then the number of columns: ");
            parkingsquare.Spaces = CreateListMatrix(Tools.ReadINT(1, 30), Tools.ReadINT(1, 30));
            ParkingSquares.Add(parkingsquare);
        }

        public static List<bool>[,] CreateListMatrix(int rows, int column)
        {
            List<bool>[,] list = new List<bool>[rows, column];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    
                    list[i, j] = new List<bool> { false, false, false, false }; // Initialize each element with a list of false values
                }
            }
            return list;
        }

        public static void Print(bool draw = false, bool save = false)
        {
            
             Console.Clear();
            //Console.WriteLine();
            if (ParkingSquares.Count == 0)
            {
                Console.Write("There are no parking spaces loaded, do you want to load? ");
                string[] options = new string[] { "Yes", "No" };
                int election = Tools.SelectableMenu("Options", options);
                Console.Clear();
                switch (election)
                {
                    case 1: Console.Clear(); Create(); break;
                    case 2: Console.Clear(); Menu(); break;
                }

            }
            //Console.Clear();
            string[,] parkingtable = new string[ParkingSquares.Count + 1, 4];
            parkingtable[0, 0] = "Id";
            parkingtable[0, 1] = "Price";
            parkingtable[0, 2] = "Occupied";
            parkingtable[0, 3] = "Free";
            Console.SetCursorPosition(1, 1);
            foreach (ParkingSquare p in ParkingSquares)
            {
                if (save)
                {
                    Save(p, FreeSpaces(p.Spaces, false));
                }

                int[] Lugares = FreeSpaces(p.Spaces, draw);
                parkingtable[ParkingSquares.IndexOf(p) + 1, 0] = p.Id.ToString();
                parkingtable[ParkingSquares.IndexOf(p) + 1, 1] = p.Price.ToString();
                parkingtable[ParkingSquares.IndexOf(p) + 1, 2] = Lugares[1].ToString();
                parkingtable[ParkingSquares.IndexOf(p) + 1, 3] = Lugares[0].ToString();
            }
            
            Tools.DrawTable(parkingtable);  
            
        }

        public static void Save(ParkingSquare ps, int[] lugares)
        {
            StreamWriter sw = File.AppendText("ParkingSquare.txt");
            sw.WriteLine($"Id: {ps.Id} Price: {ps.Price} Free Places: {lugares[0]} Busy Places: {lugares[1]}");
            sw.Close();
        }

        public static int[] FreeSpaces(List<bool>[,] list, bool draw)
        {
            int[] Spaces = new int[] { 0, 0 };
            
            int x = Console.CursorLeft; //i save the initial position, so i can use it to paint the parking spaces.
            int y = Console.CursorTop;  //top idem but on the y values.
            if (draw)
            {
                DrawParking(list.GetLength(0), list.GetLength(1));
            }
            
            Console.SetCursorPosition(x, y);    //i reset the cursor position, because the last function leaves it under the drawing.
            for (int i = 0; i < list.GetLength(0); i++)
            {
                for (int j = 0; j < list.GetLength(1); j++)
                {
                    if (list[i, j].Contains(false))
                    {
                        Spaces[0] += 1;
                        if (draw)
                        {
                            paintParking(i, j, ConsoleColor.Green);
                        }
                        
                    }
                    else
                    {
                        Spaces[1] += 1;
                        if (draw) 
                        {
                            paintParking(i, j, ConsoleColor.DarkRed);
                        }
                        
                    }
                }
            }
            if (draw)
            {
                Console.CursorTop = y + 2 * list.GetLength(0) + 1; //i leave the top spaces bellow the matrix plus 1 so it doesn`t interfere with anything else. It is left in the if(draw) because it moves the cursor even when we just want to find put how many free spaces there is
            }
            
            
            return Spaces;
        }

        public static int[] Park(List<bool>[,] list)
        {

            int[] Spaces = new int[2] {-1, -1};
            string place = "";

            int x = Console.CursorLeft; //i save the initial position, so i can use it to paint the parking spaces.
            int y = Console.CursorTop;  //top idem but on the y values.
           
            Console.SetCursorPosition(x, y);    //i reset the cursor position, because the last function leaves it under the drawing.
            for (int i = 0; i < list.GetLength(0); i++)
            {
                for (int j = 0; j < list.GetLength(1); j++)
                {
                    if (list[i, j].Contains(false))
                    {
                        Spaces[0] = i;
                        Spaces[1] = j;
                        Console.CursorTop = y + 2 * list.GetLength(0) + 1; //i leave the top spaces bellow the matrix plus 1 so it doesn`t interfere with anything else.
                    }
                }
            }
                        return Spaces;
        }
    

        public static void Menu()
        {
            string[] opciones = new string[] { "Create", "Modify", "Delete", "List By Price", "Order By Free Spaces", "Save Data in txt", "Draw", "Return" };
            Console.Clear();
            int seleccion = Tools.SelectableMenu("Parking", opciones);
            Console.WriteLine();
            Console.Clear();
            switch (seleccion)
            {
                case 1: Create(); Menu(); break;
                case 2: Modify(); Menu(); break;
                case 3: Delete(); Menu(); break;
                case 4: OrderByPrice(); Print(); Console.ReadKey(); Menu(); break;
                case 5: OrderByFreeSpaces(); Print(); Console.ReadKey(); Menu(); break;
                case 6: Print(false, true); Console.WriteLine("Saved Data"); Console.ReadKey(); Menu(); break;
                case 7: Print(true); Console.ReadKey(); Menu(); break;
                case 8: Program.Menu(); break;
            }
        }


        public static ParkingSquare Select()
        {
            Print();
            Console.WriteLine("Choose the parking by id");
            int id = Tools.ReadINT(1, ParkingSquares.Count());
            return ParkingSquares[id - 1];
        }

        public static void Delete()
        {
            ParkingSquare square = Select();
            ParkingSquares.Remove(square);
        }

        public static void Modify()
        {
            Console.Clear();
            ParkingSquare parkingSquare = Select();
            string[] opciones = new string[] { "Price", "Places", "Return" };
            Console.Clear();
            int seleccion = Tools.SelectableMenu("Modify", opciones);
            Console.SetCursorPosition(0, 7);
            int[] Lugares = FreeSpaces(parkingSquare.Spaces, false);
            Console.Write(Lugares[1]);
            switch (seleccion)
            {
                case 1: ModifyPrice(parkingSquare); Menu(); break;
                case 2:
                    {
                        
                        if (Lugares[1] > 0)
                        {
                            Console.WriteLine("\nYou can not modify a parking with cars inside");
                            Console.Write("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            Menu();
                            break;
                        }
                        else
                        {
                            ModifySize(parkingSquare); Console.Clear(); Menu(); break;
                        }
                        
                    }
                    
                case 3: Menu(); break;

            }
        }

        public static void ModifyPrice(ParkingSquare ps)
        {
            float newprice = Tools.ReadFloat(1, 100);
            ps.Price = newprice;
        }

        public static void ModifySize(ParkingSquare ps)
        {
            Console.Clear();
            Console.WriteLine("Enter the number of rows: ");
            int rows = Tools.ReadINT(1, 50);
            Console.WriteLine("\nEnter the number of columns: ");
            int column = Tools.ReadINT(1, 50);

            List<bool>[,] list = new List<bool>[rows, column];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    list[i, j] = new List<bool> { false, false, false, false }; // Initialize each element with a list of false values
                }
            }
            ps.Spaces = list;

        }

        public static void DrawParking(int row, int column)
        {
            int y = Console.CursorTop;
            int x = Console.CursorLeft;
            if (column > 2)
            {
                for (int i = 0; i < column / 2; i++)
                {
                    Console.SetCursorPosition(x + i * 10, y);
                    makeParking(row, 2);
                }
            }
            else
            {
                makeParking(row, column);
            }
            if (column != 1 && column % 2 == 1)
            {
                Console.SetCursorPosition(x + (column / 2) * 10, y);    //en este caso el SetCursorPosition es x + (column / 2) * 10 ya que:
                                                                        //column/2 es la cantidad de parkings que tengo,  los multiplico por 10 porque es la cantidad de espacio que toma cada uno.
                makeParking(row, 1);
            }
        }


        public static void paintParking(int row, int column, System.ConsoleColor color) //acordarse que esto hay que ponerlo justo en el mismo lugar en donde se dibuja el Parking :)
        {
            int y = Console.CursorTop;
            int x = Console.CursorLeft;

            Console.SetCursorPosition(x + 1 + (column * 4) + (column / 2) * 2, y + (row * 2) + 1);  //empieza en x + 1 porque hay que acordarse que la funcion de hacer parkings deriba de la de hacer matrices
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


            if (columnNumber == 1)
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
        public static List<ParkingSquare> OrderByPrice()
        {
            Console.SetCursorPosition(5, 5);
            ParkingSquares = ParkingSquares.OrderBy(a => a.Price).ToList();
            return ParkingSquares;
        }
        public static List<ParkingSquare> OrderByFreeSpaces()
        {
            //Console.SetCursorPosition(5, 5);
            bool draw = false;                     
            foreach (ParkingSquare p in ParkingSquares)
            {
                int[] Lugares = FreeSpaces(p.Spaces, draw);
                p.LugaresLibres = Lugares[0];                            
            }
            ParkingSquares = ParkingSquares.OrderBy(a => a.LugaresLibres).ToList();
            return ParkingSquares;
        }
    }
}
