using Library_C11K;

namespace TP_1_Caballeros_de_Charles_XI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] OptionsMenu = new string[] { "Play", "Controls", "Exit"} ;
            Tools.SelectableMenu("Menu Principal", OptionsMenu);        //this is going to return a value wich is ging to be the number option
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
    }
}