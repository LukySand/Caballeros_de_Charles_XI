using System.ComponentModel.Design;
using TP2.Controlers;
using TP2.Entitys;

namespace TP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(1000, 400);
            Console.WindowWidth = 240;
            Console.WindowHeight = 60;
            Data();
            importData();
            Menu();
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine();
            string[] options = new string[] { "Parkings", "Tickets", "Exit" };
            int choice = Tools.SelectableMenu("Parking System", options);  

            switch (choice)
            {
                case 1: nParkingSquare.Menu(); Menu();  break;
                case 2: nTicket.Menu();  Menu();  break;
                case 3: GoOut(); break;
            }
        }

        public static void GoOut()
        {
            Environment.Exit(0);
        }

        public static void importData()
        {

            StreamReader sr = new StreamReader("ParkingSpaces.txt");
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] data = line.Split(';');
                nParkingSquare.ParkingSquares.Add(new ParkingSquare(nParkingSquare.lastParkingSquareId++, float.Parse(data[0]), nParkingSquare.CreateListMatrix(int.Parse(data[1]), int.Parse(data[2])), int.Parse(data[1]) * int.Parse(data[2])));
                line = sr.ReadLine();
            }
            sr.Close();
        }

        private static void Data()
        {
            //parkings
            nParkingSquare.ParkingSquares.Add(new ParkingSquare(nParkingSquare.lastParkingSquareId++, 5, nParkingSquare.CreateListMatrix(3, 3), 3 * 3));
            nParkingSquare.ParkingSquares.Add(new ParkingSquare(nParkingSquare.lastParkingSquareId++, float.Parse("8.50"), nParkingSquare.CreateListMatrix(3, 5), 3 * 5));  //for some reason i cant parse from duble to float, but i can from string to float, idk.
            nParkingSquare.ParkingSquares.Add(new ParkingSquare(nParkingSquare.lastParkingSquareId++, float.Parse("11.25"), nParkingSquare.CreateListMatrix(2, 6), 2 * 6));
            nParkingSquare.ParkingSquares.Add(new ParkingSquare(nParkingSquare.lastParkingSquareId++, float.Parse("100"), nParkingSquare.CreateListMatrix(1, 1), 1 * 1));

            //tickets
            nParkingSquare.ParkingSquares[0].Tickets.Add(new Ticket(nParkingSquare.ParkingSquares[0].lastTicketId++, DateTime.Parse("2024-01-01 10:00:00"), new int[] { 0, 0 }, nParkingSquare.ParkingSquares[0].Price, null, new Car("Volkswagen","Golf gti","ab 1862 xd")));
            nParkingSquare.ParkingSquares[0].Spaces[0,0] = new List<bool> { true, true, true, true };
            nParkingSquare.ParkingSquares[0].Tickets.Add(new Ticket(nParkingSquare.ParkingSquares[0].lastTicketId++, DateTime.Parse("2024-01-01 14:00:00"), new int[] { 2, 2 }, nParkingSquare.ParkingSquares[0].Price, null, new Car("Mazda ", "RX-7", "AB 500 JR")));
            nParkingSquare.ParkingSquares[0].Spaces[2, 2] = new List<bool> { true, true, true, true };
            nParkingSquare.ParkingSquares[1].Tickets.Add(new Ticket(nParkingSquare.ParkingSquares[1].lastTicketId++, DateTime.Parse("2024-01-01 15:00:00"), new int[] { 2, 4 }, nParkingSquare.ParkingSquares[1].Price, null, new Car("Lexus", "LFA", "MAG 336")));
            nParkingSquare.ParkingSquares[1].Spaces[2, 4] = new List<bool> { true, true, true, true };
            nParkingSquare.ParkingSquares[2].Tickets.Add(new Ticket(nParkingSquare.ParkingSquares[2].lastTicketId++, DateTime.Parse("2024-01-01 16:00:00"), new int[] { 1, 5 }, nParkingSquare.ParkingSquares[2].Price, null, new Car("Porsche", "912", "ian 204")));
            nParkingSquare.ParkingSquares[2].Spaces[1, 5] = new List<bool> { true, true, true, true };
            nParkingSquare.ParkingSquares[3].Tickets.Add(new Ticket(nParkingSquare.ParkingSquares[3].lastTicketId++, DateTime.Parse("2024-01-01 16:00:00"), new int[] { 0, 0 }, nParkingSquare.ParkingSquares[2].Price, null, new Car("Renault", "Twingo (planchado)", "RKT 999")));
            nParkingSquare.ParkingSquares[3].Spaces[0, 0] = new List<bool> { true, true, true, true };
        }
    }
}




