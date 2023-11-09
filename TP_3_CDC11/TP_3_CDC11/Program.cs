using TP_3_CDC11.Controlers;
using Library_C11K;

namespace TP_3_CDC11
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Console.SetBufferSize(1000, 400);
            Console.WindowWidth = 240;
            Console.WindowHeight = 60;
            //Console.WriteLine("Welcome to the Planner tp3");

            Conection.OpenConnection();
            //pContact.TEST();
            //pContact.Print();
            Menu();
            
        }

        public static void Menu()
        {

            Console.Clear();
            Console.WriteLine();
            string[] options = new string[] { "Events", "Contact", "Exit" };
            int choice = Tools.SelectableMenu("Personal Agenda", options);
            switch (choice)
            {
                case 1: nEvent.Menu(); break;
                case 2: nContact.Menu(); break;
                case 3: Conection.CloseConnection(); Environment.Exit(0); break;
            }
        }
    }
}