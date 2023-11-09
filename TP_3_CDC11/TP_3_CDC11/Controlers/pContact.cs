using Library_C11K;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_3_CDC11.Entitys;

namespace TP_3_CDC11.Controlers
{
    internal class pContact
    {
        public static void Print()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Contact");
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            obdr.Read();
            string[,] table = new string[obdr.GetInt32(0) + 1,5];
            

            cmd = new SQLiteCommand("SELECT con_id, con_firstName, con_lastName, con_phone, con_email FROM Contact");
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

        public static Contact Select()
        {
            Console.Clear();
            Contact c = new Contact();
            Print();
            Console.Write("\nEnter the Contact id: ");
            int ContactId = Tools.ReadInt();

            SQLiteCommand cmd = new SQLiteCommand("SELECT con_id, con_firstName, con_lastName, con_phone, con_email FROM Contact WHERE con_id = @id");
            cmd.Parameters.Add(new SQLiteParameter("@id", ContactId));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            obdr.Read(); //we only read it once since we`re only returning one contact
            c.Id = obdr.GetInt32(0);
            c.FirstName = obdr.GetString(1);
            c.LastName = obdr.GetString(2);
            c.phoneNum = obdr.GetInt32(3);
            c.Email = obdr.GetString(4);

            return c;
        }

        public static void GetEvents(Contact c)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Event E " +
                    "JOIN EventContact EC " +
                        "ON E.eve_id = EC.event_id " +
                    "JOIN Contact C " +
                        "ON C.con_id = EC.contact_id " +
                    "WHERE EC.contact_id = @id;");

            cmd.Parameters.Add(new SQLiteParameter("@id", c.Id));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            obdr.Read();
            string[,] table = new string[obdr.GetInt32(0) + 1, 6];


            cmd = new SQLiteCommand("SELECT eve_id, eve_name, eve_date, eve_time, eve_duration, eve_place FROM Event E " +
                    "JOIN EventContact EC " +
                        "ON E.eve_id = EC.event_id " +
                    "JOIN Contact C " +
                        "ON C.con_id = EC.contact_id " +
                    "WHERE EC.contact_id = @id;"
                );

            cmd.Parameters.Add(new SQLiteParameter("@id", c.Id));
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

        public static void Save(Contact c)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Contact(con_firstName, con_lastName, con_phone, con_email) values( @firstname, @lastname, @phone, @email)");
            cmd.Parameters.Add(new SQLiteParameter("@firstname", c.FirstName));
            cmd.Parameters.Add(new SQLiteParameter("@lastname", c.LastName));
            cmd.Parameters.Add(new SQLiteParameter("@phone", c.phoneNum));
            cmd.Parameters.Add(new SQLiteParameter("@email", c.Email));
            cmd.Connection = Conection.Connection;
            cmd.ExecuteNonQuery(); // This preforms the insert operation into the data base
        }

        public static void ModifyContact(Contact c, int opcion)
        {
            Console.Clear();           
            switch (opcion)
            {
                case 1:
                    {
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Contact SET con_firstName = @Variable1 WHERE con_id = @id");
                        cmd.Parameters.Add(new SQLiteParameter("@id", c.Id));
                        Console.WriteLine("Input the contacts new name: ");
                        string Name = Console.ReadLine();
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", Name));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();
                        break;
                    }

                case 2:
                    {
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Contact SET con_lastName = @Variable1 WHERE con_id = @id");                        
                        Console.WriteLine("Input the contacts new las name: ");
                        string Name = Console.ReadLine();
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", Name));
                        cmd.Parameters.Add(new SQLiteParameter("@id", c.Id));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();

                        break;
                    }
                case 3:
                    {
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Contact SET con_phone = @Variable1 WHERE con_id = @id");                        
                        Console.WriteLine("Input the contacts new phone number: ");
                        int pn = Tools.ReadInt();
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", pn));
                        cmd.Parameters.Add(new SQLiteParameter("@id", c.Id));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();
                        break;
                    }
                case 4:
                    {
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE Contact SET con_email = @Variable1 WHERE con_id = @id");                       
                        Console.WriteLine("Input the contacts new email: ");
                        string email = Console.ReadLine();
                        cmd.Parameters.Add(new SQLiteParameter("@id", c.Id));
                        cmd.Parameters.Add(new SQLiteParameter("@Variable1", email));
                        cmd.Connection = Conection.Connection;
                        cmd.ExecuteNonQuery();
                        break;
                    }
            }
            
        }


        public static void Delete(Contact c)
        {
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Contact WHERE con_id = @id");
            cmd.Parameters.Add(new SQLiteParameter("@id", c.Id));
            cmd.Connection = Conection.Connection;
            cmd.ExecuteNonQuery();       
        }

        public static Contact BringLastContact()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT con_id, con_firstName, con_lastName, con_phone, con_email FROM Contact WHERE con_id = (SELECT MAX(con_id) FROM Contact)");
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            obdr.Read();
            Contact contact = new Contact();
            contact.Id = obdr.GetInt32(0);
            contact.FirstName = obdr.GetString(1);
            contact.LastName = obdr.GetString(2);
            contact.phoneNum = obdr.GetInt32(3);
            contact.Email = obdr.GetString(4);

            return contact;
        }

        public static bool PrintNotInEvent(int EventId)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM Contact WHERE con_id NOT IN " +
                "(SELECT contact_id FROM EventContact WHERE event_id = @id);");
            cmd.Parameters.Add(new SQLiteParameter("@id", EventId));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();

            obdr.Read();
            if (obdr.GetInt32(0) == 0)
            {
                return false;
            }
            string[,] table = new string[obdr.GetInt32(0) + 1, 5];


            cmd = new SQLiteCommand("SELECT con_id, con_firstName, con_lastName, con_phone, con_email FROM Contact WHERE con_id NOT IN " +
                "(SELECT contact_id FROM EventContact WHERE event_id = @id);");
            cmd.Parameters.Add(new SQLiteParameter("@id", EventId));
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
            return true;
        }
    }
}
