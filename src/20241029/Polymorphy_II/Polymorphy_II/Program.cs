using Polymorphie_GL.VehicleTypes;
using System;

namespace Polymorphy_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vehicleList = new Vehicle[]
            {
                //new Vehicle("Ein Fahrzeug", 80, DateTime.Now, ConsoleColor.Red),
                new Car("Super Car V6i", 250, DateTime.Now, FuelType.Diesel),
                new EScooter("Jumper Super Light", 50, ConsoleColor.Cyan)
            };

            foreach (var vehicle in vehicleList)
            {
                vehicle.DisplayInfo();
            }
        }

        private static void DoSomething(Vehicle vehicle)
        {
            vehicle.SetMediaPlayerState(true);
            vehicle.SpeedUp(50);

            vehicle.DisplayInfo();
        }
    }
}
