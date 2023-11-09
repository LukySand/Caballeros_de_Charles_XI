using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_3_CDC11.Entitys
{
    internal class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public double Duration { get; set; }
        public string Place { get; set; }
        public List<Contact> EventContacts { get; set; }


        public Event() 
        {
            EventContacts = new List<Contact>();
        }
        public Event(string name, DateOnly date, TimeOnly time,int duration, string place)
        {
            Name = name;
            Date = date;
            Time = time;
            Duration = duration;
            Place = place;

            EventContacts = new List<Contact>();
        }
    }
}
