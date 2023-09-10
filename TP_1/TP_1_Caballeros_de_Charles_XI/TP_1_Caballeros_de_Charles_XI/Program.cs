using Library_C11K;
using System.Text.RegularExpressions;

namespace TP_1_Caballeros_de_Charles_XI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] OptionsMenu = new string[] { "Play", "Controls", "Exit"} ;

            
            

            Tools.SelectableMenu("Menu Principal", OptionsMenu);        //this is going to return a value wich is ging to be the number option
            /*for (int j = 0; j < Console.WaindowHeight; j++)
            {
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }


            MiniRefresh(4, 4, 1, 10);
            Console.ReadKey();*/
        }

        public static void MiniRefresh(int x, int y, int width, int height)
        {
            for (int i = 0;i < height;i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < width; j++)
                {
                    Console.SetCursorPosition(x + j, y + i);
                    Console.Write(" ");
                }
            }
        }

        /*public static async Task<int> SelectableMenu(string title, string[] options)
        { 
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
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
                Tools.MenuMaker(title, options);
                Thread.Sleep(250);
                MiniRefresh(1, 3 + plus, 2, 1);
                MiniRefresh(4, 3 + plus, 2, 1);
                Thread.Sleep(250);
            }
            await Task.Delay(10);
            return plus + 1;        //these come right after the while (loops) because if the while(loops) ends we need to end the funcion.
        }*/
    }
}