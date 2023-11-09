using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Entitys
{
    internal class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicencePlate { get; set; }
        

        public Car() { }

        public Car(string brand, string model, string licenceplate)
        {
            Brand = brand;
            Model = model;
            LicencePlate = licenceplate;
        }

        public override string ToString()
        {
            return ($"{Brand} - {Model} - {LicencePlate}");
        }
    }
}
