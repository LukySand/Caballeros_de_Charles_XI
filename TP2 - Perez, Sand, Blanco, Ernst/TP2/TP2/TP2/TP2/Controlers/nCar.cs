using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Controlers;

namespace TP2.Entitys
{
    internal class nCar
    {
        public static Car Create()
        {
            Car car = new Car();
            Console.Write("Enter car brand: ");
            car.Brand = Console.ReadLine();
            Console.Write("Enter car model: ");
            car.Model = Console.ReadLine();
            Console.Write("Enter the car license plate: ");
            car.LicencePlate = Console.ReadLine();
            Save(car);
            return car;
        }
        public static void Save(Car c)
        {
            StreamWriter sw = File.AppendText("car.txt");
            sw.WriteLine($"{c.Brand};{c.Model};{c.LicencePlate}");
            sw.Close();
        }
        public static void Print(Ticket ticket)
        {
            Console.WriteLine($"{ticket.Car.Brand} - {ticket.Car.Model}, {ticket.Car.LicencePlate}"); 
        }
        //public static int Select()
        //{
        //    Console.WriteLine();
        //    Print(nTicket.Select());
        //    Console.Write("Seleccione un Auto: ");
        //    int s = Tools.ReadINT(1, Program.cars.Count); 
        //    return s - 1;
        //}
        //public static void Change(int p)
        //{
        //    Console.Write($"Ingrese una nueva marca para {Program.cars[p].Brand}: ");
        //    Program.cars[p].Brand = Console.ReadLine();
        //    Console.Write($"Ingrese un nuevo modelo para {Program.cars[p].Model}: ");
        //    Program.cars[p].Model = Console.ReadLine();
        //    Console.Write($"Ingrese una nueva patente para {Program.cars[p].LicencePlate}");
        //    Program.cars[p].LicencePlate = Console.ReadLine();
        //}
        //public static void Delete()
        //{
        //    if (Program.cars.Count > 0)
        //    {
        //        int i = Select();
        //        Program.cars.RemoveAt(i);
        //    }
        //    else
        //    {
        //        Console.WriteLine("No hay datos para eliminar"); 
        //        Console.ReadKey(true);
        //    }

        //}
        //public static void Menu()
        //{
        //    string[] op = new string[] { "Crear", "Modificar", "Eliminar", "Listar", "Volver" };
        //    Console.Clear();
        //    int seleccion = Tools.SelectableMenu("Autos", op);
        //    Console.WriteLine();
        //    Console.Clear();
        //    switch (seleccion)
        //    {
        //        case 1: Create(); Menu(); break;
        //        case 2: Change(Select()); Menu(); break;
        //        case 3: Delete(); Menu(); break;
        //        case 4: Print(); Console.ReadKey(); Menu(); break;
        //        case 5: Program.Menu(); break;
        //    }
        //}
    }
}