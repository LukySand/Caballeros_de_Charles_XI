using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Entitys
{
    internal class ParkingSquare
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public List<bool>[,] Spaces { get; set; } 
        public List<float> Paid { get; set; }
        public List<Ticket> Tickets { get; set; }
        public int LugaresLibres { get; set; }
        public int lastTicketId = 1;
        

        public ParkingSquare()
        {
            Paid = new List<float>();
            Tickets = new List<Ticket>();
        } 
        

        public ParkingSquare(int id, float price, List<bool>[,] spaces, int lugareslibres)
        {
            Id = id;
            Price = price;
            Spaces = spaces;
            Paid = new List<float>();
            Tickets = new List<Ticket>();
            LugaresLibres = lugareslibres;
        }

    }
}



