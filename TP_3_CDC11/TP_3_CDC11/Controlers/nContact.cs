using Library_C11K;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_3_CDC11.Entitys;

namespace TP_3_CDC11.Controlers
{
    internal class nContact
    {
        public static Contact Create()
        {
            Console.Clear();
            Contact contact = new Contact();
            Console.WriteLine("Enter the Contact First Name: ");
            contact.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the Contact Last Name: ");
            contact.LastName = Console.ReadLine();
            Console.WriteLine("Enter the Contact Phone Number: ");
            contact.phoneNum = Tools.ReadInt();
            Console.WriteLine("Enter the Contact Email: ");
            contact.Email = Console.ReadLine();
            

            //Conection.OpenConnection();
            pContact.Save(contact);     //What we basically do is we upload the contact to the DB           
            //Conection.CloseConnection();
            return contact;
        }

        public static void Menu()
        {
            string[] options = new string[] { "Create", "Print", "Events by Contact", "Modify", "Delete", "Exit" };
            Console.Clear();
            int selection = 0;
            Console.WriteLine();
            selection = Tools.SelectableMenu("Contact", options);
            switch(selection)
            {
                case 1: Create(); Menu(); break;
                case 2: pContact.Print(); Console.ReadKey(); Menu(); break;
                case 3: pContact.GetEvents(pContact.Select()); Console.ReadKey(); Menu(); break;
                case 4: Modify(); Menu(); break;
                case 5: pContact.Delete(pContact.Select()); Menu(); break;
                case 6: Program.Menu(); break;
            }
        }

        public static void Modify()
        {
            Console.Clear();
            Contact c = pContact.Select();
            Console.Clear();
            Console.Write("What field do you wish to modify?: ");
            string[] options = new string[] { "Name", "Last Name", "Phone", "Email" };
            
            Console.Clear();
            Console.SetCursorPosition(2, 2);
            int selection = Tools.SelectableMenu("Modify", options);
            pContact.ModifyContact(c, selection);
        }
    }
}
