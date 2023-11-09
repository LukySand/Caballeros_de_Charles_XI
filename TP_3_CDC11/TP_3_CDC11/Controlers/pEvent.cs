using Library_C11K;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TP_3_CDC11.Entitys;


namespace TP_3_CDC11.Controlers
{
    internal class pEvent
    {
        public static void Print()
        {
            Console.Clear();
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Event");
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            obdr.Read();
            string[,] table = new string[obdr.GetInt32(0) + 1, 6];

            cmd = new SQLiteCommand("SELECT eve_id, eve_name, eve_date, eve_time, eve_duration, eve_place FROM Event");
            cmd.Connection = Conection.Connection;
            obdr = cmd.ExecuteReader();

            table[0, 0] = "Id";
            table[0, 1] = "Event Name";
            table[0, 2] = "Event Date";
            table[0, 3] = "Event Time";
            table[0, 4] = "Event Duration";
            table[0, 5] = "Event Place";

            int position = 1;
            while (obdr.Read())
            {
                table[position, 0] = obdr.GetInt32(0).ToString();
                table[position, 1] = obdr.GetString(1);
                table[position, 2] = obdr.GetString(2);
                table[position, 3] = obdr.GetString(3);
                table[position, 4] = obdr.GetDouble(4).ToString() + " Hours";
                table[position, 5] = obdr.GetString(5);

                position++;
            }
          
            Tools.DrawTable(table);
        }

        public static Event Select()
        {
            Event e = new Event();
            Print();
            Console.WriteLine("\nInput the event id: ");
            int EventId = Tools.ReadInt();
            SQLiteCommand cmd = new SQLiteCommand("SELECT eve_id, eve_name, eve_date, eve_time, eve_duration, eve_place FROM Event WHERE eve_id = @id");
            cmd.Parameters.Add(new SQLiteParameter("@id", EventId));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                e.Id = obdr.GetInt32(0);
                e.Name = obdr.GetString(1);
                e.Date = DateOnly.Parse(obdr.GetString(2));
                e.Time = TimeOnly.Parse(obdr.GetString(3));
                e.Duration = obdr.GetDouble(4);
                e.Place = obdr.GetString(5);
            }
            return e;

        }

        public static bool SuperPosed(DateOnly date, TimeOnly time, double duration)
        {
            bool exists = false;
            DateTime NewDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            
            int minuets = 0;
            SQLiteCommand cmd = new SQLiteCommand("SELECT eve_date, eve_time, eve_duration FROM Event");
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            int add;
            TimeSpan dif;

            while (obdr.Read())
            {
                DateTime OccupiedDateTime = new DateTime(
                    DateOnly.Parse(obdr.GetString(0)).Year,
                    DateOnly.Parse(obdr.GetString(0)).Month,
                    DateOnly.Parse(obdr.GetString(0)).Day,
                    TimeOnly.Parse(obdr.GetString(1)).Hour,
                    TimeOnly.Parse(obdr.GetString(1)).Minute,
                    TimeOnly.Parse(obdr.GetString(1)).Second
                );
                
                if (NewDateTime.Date == OccupiedDateTime.Date)
                {
                    dif = NewDateTime - OccupiedDateTime;
                    if (obdr.GetDouble(2) % 1 != 0)
                    {
                        minuets = 30;
                    }
                    add = (int)(obdr.GetDouble(2));
                    if ((NewDateTime > OccupiedDateTime && NewDateTime < OccupiedDateTime.AddHours(add).AddMinutes(minuets)) || (NewDateTime < OccupiedDateTime && duration > (dif.Hours + dif.Minutes) * -1))                      
                    {
                        exists = true;
                        break;
                    }
                    
                   
                            

                    
                }
            }
            return exists;
        }

        public static void Save(Event e)
        {
            Conection.OpenConnection();

            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Event(eve_name, eve_date, eve_time, eve_duration, eve_place) values( @name, @date, @time, @duration, @place)");
            cmd.Parameters.Add(new SQLiteParameter("@name", e.Name));
            cmd.Parameters.Add(new SQLiteParameter("@date", e.Date));
            cmd.Parameters.Add(new SQLiteParameter("@time", e.Time));
            cmd.Parameters.Add(new SQLiteParameter("@duration", e.Duration));
            cmd.Parameters.Add(new SQLiteParameter("@place", e.Place));
            cmd.Connection = Conection.Connection;
            cmd.ExecuteNonQuery(); // This preforms the insert operation into the data base
        }

        

        public static void GetEventsByMonth(int month)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Event WHERE strftime('%m', eve_date) = @month");
            cmd.Parameters.Add(new SQLiteParameter("@month", month.ToString("00"))); // Format the month to two digits
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            obdr.Read();
            string[,] table = new string[obdr.GetInt32(0) + 1, 5];

            cmd = new SQLiteCommand("SELECT eve_id, eve_name, eve_date, eve_time, eve_place FROM Event WHERE strftime('%m', eve_date) = @month");
            cmd.Parameters.Add(new SQLiteParameter("@month", month.ToString("00"))); // Format the month to two digits
            cmd.Connection = Conection.Connection;
            obdr = cmd.ExecuteReader();

            table[0, 0] = "Id";
            table[0, 1] = "Event Name";
            table[0, 2] = "Event Date";
            table[0, 3] = "Event Time";
            table[0, 4] = "Event Place";    

            int position = 1;
            while (obdr.Read())
            {
                table[position, 0] = obdr.GetInt32(0).ToString();
                table[position, 1] = obdr.GetString(1);
                table[position, 2] = obdr.GetString(2).ToString();
                table[position, 3] = obdr.GetString(3).ToString();
                table[position, 4] = obdr.GetString(4);
                position++;
            }

            Console.Clear();
            Tools.DrawTable(table);
        }

        public static void GetEventsByDay(DateOnly selectedDate)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT eve_name, eve_time, eve_duration FROM Event WHERE eve_date = @selectedDate");
            cmd.Parameters.Add(new SQLiteParameter("@selectedDate", selectedDate.ToString()));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            Dictionary<int, string> dailySchedule = new Dictionary<int, string>();

            for (int i = 0; i < 24; i++) //para que los horarios empiezen vacios, despues si alguno esta ocupado se le pone nombre
            {
                dailySchedule.Add(i, "Free");
            }

            while (obdr.Read()) //lee lo que hay y trae el evento y lo que dura
            {
                string eventName = obdr.GetString(0);
                TimeOnly eventTime = TimeOnly.Parse(obdr.GetString(1));
                double eventDuration = obdr.GetDouble(2);

                int startHour = eventTime.Hour;
                int endHour = startHour + (int)eventDuration;

                for (int i = startHour; i < endHour; i++) //actualiza el nombre del evento
                {
                    dailySchedule[i] = eventName;
                }
            }

            string[,] table = new string[48, 2]; //tabla para 24 horas, se divide en medias horas por eso 48

            

            Console.Clear();
            Tools.DrawTable(table);
        }

        public static List<Event> GetEventsFromDatabase()
        {
            List<Event> events = new List<Event>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT eve_id, eve_name, eve_date, eve_time, eve_place, eve_duration FROM Event");
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            while (obdr.Read())
            {
                Event e = new Event
                {
                    Id = obdr.GetInt32(0),
                    Name = obdr.GetString(1),
                    Date = DateOnly.Parse(obdr.GetString(2)),
                    Time = TimeOnly.Parse(obdr.GetString(3)),
                    Place = obdr.GetString(4)
                };
                events.Add(e);
            }
            return events;
        }

        public static void SaveContactEvent(int EventId, int ContactId)
        {
            Conection.OpenConnection();

            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO EventContact(event_id, contact_id) VALUES (@EventId, @ContactId)");
            cmd.Parameters.Add(new SQLiteParameter("@EventId", EventId));
            cmd.Parameters.Add(new SQLiteParameter("@ContactId", ContactId));
            cmd.Connection = Conection.Connection;
            cmd.ExecuteNonQuery();
        }

        public static void Modify(Event e, int option)
        {
            Console.Clear();
            switch (option)
            {
                case 1:
                    {
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Event SET eve_name = @Variable1 WHERE eve_id = @id");
                        Console.WriteLine("Input the events new name: ");
                        string Name = Console.ReadLine();                       
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", Name));
                        cmd.Parameters.Add(new SQLiteParameter("@id", e.Id));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();
                        break;
                    }

                case 2:
                    {
                        bool opcion = true;
                        DateOnly Date;
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Event SET eve_date = @Variable1 WHERE eve_id = @id");
                        while (opcion)
                        {
                            Console.Write("\nEnter the new Date of the event (Day/Month/Year): ");
                            Date = Tools.ReadDate();
                            opcion = SuperPosed(Date, e.Time, e.Duration);
                            if (opcion)
                            {
                                Console.Write("The time in the date inputted is already occupied, please enter a new date or time");
                            }
                        }
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", Date));
                        cmd.Parameters.Add(new SQLiteParameter("@id", e.Id));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();
                        break;
                    }
                case 3:
                    {
                        TimeOnly Time;
                        bool opcion = true;
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Event SET eve_time = @Variable1 WHERE eve_id = @id");
                        while (opcion)
                        {
                            Console.Write("\nEnter the new Time of the event (Hours-Min): ");
                            Time = Tools.ReadTime();
                            opcion = SuperPosed(e.Date, Time, e.Duration);
                            if (opcion)
                            {
                                Console.Write("The time inputted is already occupied, please enter a new date or time");
                            }
                        }
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", Time));
                        cmd.Parameters.Add(new SQLiteParameter("@id", e.Id));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();
                        break;
                    }
                case 4:
                    {
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Event SET eve_place = @Variable1 WHERE eve_id = @id");
                        Console.Write("Please enter a new place: ");
                        string Place = Console.ReadLine();
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", Place));
                        cmd.Parameters.Add(new SQLiteParameter("@id", e.Id));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();
                        break;
                    }
                case 5:
                    {
                        double Duration = 0; // It makes me give it a value for some reson
                        bool opcion = true;
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Event SET eve_duration = @Variable1 WHERE eve_id = @id");
                        while (opcion)
                        {
                            Console.Write("\nEnter the new Event Duration (on Hours, minutes): ");
                            Duration = double.Parse(Tools.ReadFloat(0, 24).ToString());
                            opcion = SuperPosed(e.Date, e.Time, Duration);
                            if (opcion)
                            {
                                Console.Write("The time inputted is already occupied, please enter a new date or time");
                            }
                        }
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", Duration));
                        cmd.Parameters.Add(new SQLiteParameter("@id", e.Id));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();
                        break;
                    }
                case 6:
                    {
                        nEvent.AddContactToEvent(e.Id);
                        break;
                    }
                case 7:
                    {
                        DeleteContactEvent(e);
                        break;
                    }

            }
        }

        //Console.Clear();
        //    SQLiteCommand cmd = new SQLiteCommand("UPDATE Contact SET @Variable2 = @Variable1 WHERE id = @id");
        //cmd.Parameters.Add(new SQLiteParameter("@id", e.Id)); 

        //    switch (option)
        //    {
        //        case 1:
        //            {
        //                Console.WriteLine("Input the events new name: ");
        //                string Name = Console.ReadLine();
        //string tri = "eve_name";
        //cmd.Parameters.Add(new SQLiteParameter("@Variable1", Name));
        //                cmd.Parameters.Add(new SQLiteParameter("@Variable2", "eve_name"));
        //                break;
        //            }
        // We tried this first but apperently you cant send variables in column names, so the code had to be made longer


        public static void DeleteContactEvent(Event e)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM EventContact");
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            GetContacts(e);
            Console.Write("Enter the contact id you would like to remove: ");
            int Id = Tools.ReadInt(0, null);
            cmd = new SQLiteCommand("DELETE FROM EventContact WHERE contact_id = @id");
            cmd.Parameters.Add(new SQLiteParameter("@id", Id));
            cmd.Connection = Conection.Connection;
            cmd.ExecuteNonQuery();
        }

        public static void GetContacts(Event e)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Contact C" +
                " JOIN EventContact EC ON C.con_id = EC.contact_id WHERE EC.event_id = @id_event");
            cmd.Parameters.Add(new SQLiteParameter("@id_event", e.Id));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            obdr.Read();
            string[,] table = new string[obdr.GetInt32(0) + 1, 5];

            cmd = new SQLiteCommand("SELECT con_id, con_firstName, con_lastName, con_phone, con_email FROM Contact C" +
                " JOIN EventContact EC ON C.con_id = EC.contact_id WHERE EC.event_id = @id_event");
            cmd.Parameters.Add(new SQLiteParameter("@id_event", e.Id));
            cmd.Connection = Conection.Connection;
            obdr = cmd.ExecuteReader();

            table[0, 0] = "Id";
            table[0, 1] = "Frist Name";
            table[0, 2] = "Last Name";
            table[0, 3] = "Phone";
            table[0, 4] = "Email";

            int position = 1;
            while (obdr.Read())
            {
                table[position, 0] = obdr.GetInt32(0).ToString();
                table[position, 1] = obdr.GetString(1);
                table[position, 2] = obdr.GetString(2);
                table[position, 3] = obdr.GetInt32(3).ToString();
                table[position, 4] = obdr.GetString(4);
                position++;
            }

            Console.Clear();
            Tools.DrawTable(table);
        }
    }
}
