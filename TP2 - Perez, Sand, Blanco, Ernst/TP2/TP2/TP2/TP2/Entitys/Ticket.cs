using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Library_C11K;
using TP2.Controlers;


namespace TP2.Entitys
{
    internal class Ticket
    {
        public int Id { get; set; }
        //public List<int> ParkingSpace { get; set; }
        public float Price { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public int[] ParkingSpace { get; set; }
        public Car Car { get; set; }
        //public int Amount { get; set; }


        public Ticket()
        {
            //ParkingSpace = new List<int>();
            Car = new Car();
            ParkingSpace = new int[2];
        }

        public Ticket(int id, DateTime checkInTime, int[] parkingSpace, float price, DateTime? checkOutTime = null,Car? car = null)
        {
            Id = id;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            //Amount = amount;
            ParkingSpace = parkingSpace;
            Price = price;
            //ParkingSpace = new List<int> { id };
            Car = new Car();
            Car = car;
        }
    }
}
//Lista de playones, dentro de cada playon esta el objeto ticket, donde se guarda, lugar, horaq de entrada/salida, auto, e importe
//