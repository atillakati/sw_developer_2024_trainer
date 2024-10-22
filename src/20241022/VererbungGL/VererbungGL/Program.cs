using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VererbungGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vehicleList = new Vehicle[]
            {
                new Car("Badmobil V12 Black Edition", 350, new DateTime(1990,5,7), FuelType.Benzin_98o),
                new EScooter("Jumper Scooter light", 50, ConsoleColor.White),
                new Car("BMW i3",195, new DateTime(2022, 9,2), FuelType.Elektrisch)
            };

            foreach(var v in vehicleList)
            {
                ShowVehicle(v);
            }
        }

        private static void ShowVehicle(Vehicle vehicleToShow)
        {
            vehicleToShow.DisplayInfo();
            Console.WriteLine();
        }
    }
}
