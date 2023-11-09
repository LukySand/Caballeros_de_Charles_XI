using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_3_CDC11.Entitys
{
    internal class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int phoneNum { get; set; }
        public string Email { get; set; }

        public Contact() { }
        public Contact(string firstname, string lastname, int phonenum, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            phoneNum = phonenum;
            Email = email;
        }
    }
}
