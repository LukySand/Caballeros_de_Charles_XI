using Library_C11K;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_3_CDC11.Entitys;

namespace TP_3_CDC11.Controlers
{
    internal class nEvent
    {
        public static void Create()
        {
            bool occupied = true;
            Console.Clear();

            Event eve = new Event();
            Console.Write("Enter the Event Name: ");
            eve.Name = Console.ReadLine();
            while (occupied)
            {
                Console.Write("\nEnter the Date of the event (Day, Month. Year): ");
                DateOnly Date = Tools.ReadDate();
                Console.Write("\nEnter the Time of the event (Hours:Min): ");
                TimeOnly Time = Tools.ReadTime();
                Console.Write("\nEnter the Event Duration (on Hours:Min): ");
                double Duration = double.Parse(Tools.ReadFloat(0, 24).ToString());
                
                occupied = pEvent.SuperPosed(Date, Time, Duration);
                if (occupied)
                {
                    Console.WriteLine("Esa fecha o hora ya esta ocupada, por favor ingrese una nueva.");
                }
                else
                {
                    eve.Date = Date;
                    eve.Time = Time;
                    eve.Duration = Duration;
                }
            }                            
            Console.Write("\nEnter the Event Place: ");
            eve.Place = Console.ReadLine();
            pEvent.Save(eve);
            if(1 == Tools.SelectableMenu("Would you like to Add Contacts to the Event? ", new string[] { "Yes", "No" }))
            {
                AddContactToEvent(eve.Id);
            }
        }

        public static void Menu()
        {
            string[] options = new string[] { "Create", "Print", "Contacts by Event", "Month Calendar", "Day Calendar", "Modify Event", "Exit" };
            Console.Clear();
            int selection = 0;
            Console.WriteLine();
            selection = Tools.SelectableMenu("Events", options);
            switch (selection)
            {
                case 1: Create(); Menu(); break;
                case 2: pEvent.Print();Console.ReadKey(); Menu(); break;
                case 3: pEvent.GetContacts(pEvent.Select()); Console.ReadKey(); Menu(); break;
                case 4: Console.Clear(); SelectByMonth(); Menu(); break;
                case 5: Console.Clear(); SelectByDay(); Console.ReadKey(); Menu(); break;
                case 6: Console.Clear(); ModifyEvent(); Menu(); break; 
                case 7: Program.Menu(); break;
            }
        }

        public static void ModifyEvent()
        {
            Event eve = pEvent.Select();
            string[] options = new string[] { "Modify Name", "Modify Date", "Modify Time", "Modify Place", "Modify Duration", "Add Contacts", "Delete Contacts" };
            Console.Clear();
            Console.WriteLine();
            int selection = Tools.SelectableMenu("Event", options);
            Console.WriteLine();
            pEvent.Modify(eve, selection);
        }
        public static void SelectByMonth()
        {
            if (pEvent.GetEventsFromDatabase() == null) Console.WriteLine("empty event list");
            Console.WriteLine("Enter the year (YYYY): ");
            if (int.TryParse(Console.ReadLine(), out int year) && year >= 1 && year <= 9999)
            {
                Console.WriteLine("Enter the month (1-12): ");
                if (int.TryParse(Console.ReadLine(), out int month) && month >= 1 && month <= 12)
                {
                    ShowCalendar(pEvent.GetEventsFromDatabase(), month, year);
                }
                else
                {
                    Console.WriteLine("Invalid month. Must be a number between 1 and 12.");
                }
            }
            else
            {
                Console.WriteLine("Invalid year. Please enter a valid year (for example, 2023).");
            }
        }

        public static void ShowCalendar(List<Event> events, int month, int year)
        {
            if (events == null)
            {
                Console.WriteLine("Event list is null.");
                return;
            }

            Console.WriteLine($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}");

            DateOnly firstDay = new DateOnly(year, month, 1);
            DateOnly lastDay = firstDay.AddMonths(1).AddDays(-1);

            List<Event> eventsMonth = events.Where(e => e.Date >= firstDay && e.Date <= lastDay).ToList();

            Console.WriteLine("Dom  Lun  Mar  Mie  Jue  Vie  Sab");

            int daysInMonth = DateTime.DaysInMonth(year, month);
            int currentDay = 1;
            int weekday = (int)firstDay.DayOfWeek;

            while (currentDay <= daysInMonth)
            {
                for (int i = 0; i < weekday; i++)
                {
                    Console.Write("     "); 
                }

                while (weekday < 7 && currentDay <= daysInMonth)
                {
                    string day = currentDay.ToString("D2");
                    var eventsDay = eventsMonth.Where(e => e.Date.Day == currentDay).ToList();

                    if (eventsDay.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    Console.Write($"{day}   ");

                    if (eventsDay.Any())
                    {
                        Console.ResetColor();
                    }

                    weekday++;
                    currentDay++;
                }

                weekday = 0;
                Console.WriteLine();
            }

            foreach (var eve in eventsMonth)
            {
                Console.WriteLine($"{eve.Date} - {eve.Name} ({eve.Place})");
            }
            Console.ReadKey();
        }

        public static void SelectByDay()
        {
            Console.Clear();

            if (pEvent.GetEventsFromDatabase() == null)
            {
                Console.WriteLine("Empty event list");
            }
            else
            {
                Console.WriteLine("Enter the year (YYYY): ");
                if (int.TryParse(Console.ReadLine(), out int year) && year >= 1 && year <= 9999)
                {
                    Console.WriteLine("Enter the month (1-12): ");
                    if (int.TryParse(Console.ReadLine(), out int month) && month >= 1 && month <= 12)
                    {
                        Console.WriteLine("Enter the day (1-31): ");
                        if (int.TryParse(Console.ReadLine(), out int day) && day >= 1 && day <= 31)
                        {
                            DateOnly dateOnly = new DateOnly(year, month, day);
                            DayEvents(pEvent.GetEventsFromDatabase(), dateOnly);
                        }
                        else
                        {
                            Console.WriteLine("Invalid day. Must be a number between 1 and 31.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid month. Must be a number between 1 and 12.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid year. Please enter a valid year.");
                }
            }
        }

        public static void DayEvents(List<Event> events, DateOnly selectedDate)
        {
            if (events == null)
            {
                Console.WriteLine("La lista de eventos es nula.");
                return;
            }

            Console.WriteLine($"Agenda para el {selectedDate:MM-dd-yyyy}");

            List<Event> eventsOfDay = events.Where(e => e.Date == selectedDate).OrderBy(e => e.Time).ToList();

            if (eventsOfDay.Count == 0)
            {
                Console.WriteLine("No hay eventos programados para este día.");
                return;
            }

            string[,] table = new string[eventsOfDay.Count + 1, 5];
            table[0, 0] = "Id";
            table[0, 1] = "Event Name";
            table[0, 2] = "Event Time";
            table[0, 3] = "Event Duration";
            table[0, 4] = "Event Place";

            for (int i = 0; i < eventsOfDay.Count; i++)
            {
                table[i + 1, 0] = eventsOfDay[i].Id.ToString();
                table[i + 1, 1] = eventsOfDay[i].Name;
                table[i + 1, 2] = eventsOfDay[i].Time.ToString();
                table[i + 1, 3] = eventsOfDay[i].Duration.ToString() + " Hours";
                table[i + 1, 4] = eventsOfDay[i].Place;
            }

            Tools.DrawTable(table);

            Console.ReadKey();
        }

        public static void AddContactToEvent(int EventId)
        {
            int loop = 0;
            int option = 0;
            int ContactId;
            do
            {
                Console.WriteLine("\n\n\n");
                option = Tools.SelectableMenu("Do you want to Add existing Contacts or Create one?", new string[] { "Add", "Create" });
                if (option == 1)
                {
                    if (pContact.PrintNotInEvent(EventId) == true)  //this prints the amount of conacts that are not invited on a certain event, and returns a bool if the amount is 0
                    {
                        Console.Write("\nEnter the Id of the contact you want to Add: ");
                        ContactId = Tools.ReadInt();
                    }
                    else
                    {
                        Console.WriteLine("\n\n\n\nThere are no Aviable contacts to Add\n\n");
                        option = Tools.SelectableMenu("Would you like to Create one?", new string[] { "Yes", "No" });
                        if(option == 1)
                        {
                            nContact.Create();
                            Contact c = pContact.BringLastContact();
                            ContactId = c.Id;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    nContact.Create();
                    Contact c = pContact.BringLastContact();
                    ContactId = c.Id;
                }

                pEvent.SaveContactEvent(EventId, ContactId);
                
                Console.WriteLine("\n\n");
                loop = Tools.SelectableMenu("Do you want to Add more Contacts?", new string[] { "Yes", "No" });
            } while (loop == 1);
        }
    }
}
