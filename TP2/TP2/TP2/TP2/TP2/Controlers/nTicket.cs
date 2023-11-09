using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Entitys;
using TP2.Controlers;


namespace TP2.Controlers
{
    internal class nTicket
    {
        public static List<Car> cars;
        /*private static int lastTicketId = 1;*/

        public static void Create()
        {
            Ticket ticket = new Ticket();
            ParkingSquare parkingsquare = nParkingSquare.Select();

            if (nParkingSquare.FreeSpaces(parkingsquare.Spaces, false)[0] == 0)
            {
                Console.WriteLine("The parking lot is full. Cannot add more tickets.");
                return;
            }

            ticket.ParkingSpace = nParkingSquare.Park(parkingsquare.Spaces);
            ticket.Id = parkingsquare.lastTicketId++;
            Console.WriteLine();
            Console.Write("Enter the Day and Time of entry: ");
            ticket.CheckInTime = Tools.ReadDateTime(DateTime.Now);
            Console.WriteLine();
            ticket.Car = nCar.Create();
            Console.WriteLine();
            ticket.Price = parkingsquare.Price;
            parkingsquare.Tickets.Add(ticket);
            parkingsquare.Spaces[ticket.ParkingSpace[0], ticket.ParkingSpace[1]] = new List<bool> { true, true, true, true }; ;
        }

        public static void List(ParkingSquare parking, bool save = false)
        {   
            if (parking.Tickets.Count == 0)
            {
                Console.Write("There are no tickets loaded, do you want to load? ");
                string[] options = new string[] { "Yes", "No" };
                int election = Tools.SelectableMenu("Options", options);
                switch(election)
                {

                    case 1: Console.Clear(); Create(); Menu(); break;
                    case 2: Console.Clear(); Menu(); break;
                }

            }
            string[,] tickets = new string[parking.Tickets.Count() + 1, 8];
            tickets[0, 0] = "Id";
            tickets[0, 1] = "Place";
            tickets[0, 2] = "Check-in time";
            tickets[0, 3] = "Departure time";
            tickets[0, 4] = "Amount";
            tickets[0, 5] = "Brand";
            tickets[0, 6] = "Model";
            tickets[0, 7] = "Licence Plate";
            
            foreach (Ticket ticket in parking.Tickets)
            {
                if (save)
                {
                    Save(parking, ticket);
                }
                tickets[parking.Tickets.IndexOf(ticket) + 1, 0] = ticket.Id.ToString();
                tickets[parking.Tickets.IndexOf(ticket) + 1, 1] = $"Row {ticket.ParkingSpace[0]} - Column {ticket.ParkingSpace[1]}";
                tickets[parking.Tickets.IndexOf(ticket) + 1, 2] = ticket.CheckInTime.ToString();
                tickets[parking.Tickets.IndexOf(ticket) + 1, 3] = ticket.CheckOutTime.ToString();
                tickets[parking.Tickets.IndexOf(ticket) + 1, 4] = PriceCalc(ticket.CheckInTime, ticket, ticket.CheckOutTime).ToString();
                tickets[parking.Tickets.IndexOf(ticket) + 1, 5] = ticket.Car.Brand;
                tickets[parking.Tickets.IndexOf(ticket) + 1, 6] = ticket.Car.Model;
                tickets[parking.Tickets.IndexOf(ticket) + 1, 7] = ticket.Car.LicencePlate;
            }
            Tools.DrawTable(tickets);
        }

        public static void ListCar()
        {
            Ticket ticket = Select();
            string[,] tickets = new string[3, 4];
            tickets[0, 0] = "Brand";
            tickets[0, 1] = "Model";
            tickets[0, 2] = "Licence Plate";

            tickets[1, 0] = ticket.Car.Brand;
            tickets[1, 1] = ticket.Car.Model;
            tickets[1, 2] = ticket.Car.LicencePlate;
        }

        public static void ExitTime()
        {
            Ticket ticket = Select();
            DateTime datetime = Tools.ReadDateTime(ticket.CheckInTime);
            ticket.CheckOutTime = datetime;
        }

        public static Ticket Select()
        {
            ParkingSquare ps = nParkingSquare.Select();
            bool condition = false;
            Ticket t = new Ticket();
            int id;
            while (true)
            {
                List(ps);
                Console.Write("Choose the Ticket Id: ");
                id = Tools.ReadINT(1, ps.Tickets.Count());
                foreach (Ticket ticket in ps.Tickets)
                {
                    if (ticket.Id == id)
                    {
                        t = ticket;
                        condition = true;
                        break;
                    }
                }
                if (condition)
                {
                    return t;
                }
                else
                {
                    Console.WriteLine("Input a valid Id");
                }
            }
        }

        public static void Menu()
        {
            string[] options = new string[] { "Create", "Departure Time", "List", "Save Data", "Return" };
            Console.Clear();
            int selection = Tools.SelectableMenu("Tickets", options);
            Console.WriteLine();
            switch (selection)
            {
                case 1: Create(); Menu(); break;
                case 2: ExitTime(); Menu(); break;
                case 3:
                    {
                        List(nParkingSquare.Select());
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Menu();
                    }
                    break;
                case 4:
                    {
                        List(nParkingSquare.Select(), true);
                        Console.WriteLine("Data Saved. ");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Menu();
                    } break;
                case 5: Program.Menu(); break;
            }
        }

        public static void Save(ParkingSquare ps, Ticket ticket)
        {
            StreamWriter sw = File.AppendText("Tickets.txt");
            sw.WriteLine($"Parking Id: {ps.Id}, Ticket Id: {ticket.Id}, Price: {ticket.Price}, Check-in time: {ticket.CheckInTime}, Departure Time: {ticket.CheckOutTime}, Car Brand: {ticket.Car.Brand}, Car Model: {ticket.Car.Model}, Car Licence Plate: {ticket.Car.LicencePlate}");
            sw.Close();
        }

        public static float PriceCalc(DateTime intime, Ticket ticket, DateTime? outtime = null)
        {
            if (!outtime.HasValue)
            {
                return 0; // No se ha realizado el check-out, el precio es 0.
            }

            //Ticket ticket = Select();
            double dt = (outtime.Value - intime).TotalHours;
            float price = (float)(dt * ticket.Price);

            return price;
        }
    }
}
