using System;

namespace Polymorphie_GL.VehicleTypes
{
    public class Car : Vehicle
    {
        private FuelType _fuel;
        private int _seatCount;

        public Car(string description, int maxSpeed, DateTime dateOfManufacture, FuelType fuel)
            : base(description, maxSpeed, dateOfManufacture, ConsoleColor.Yellow)
        {
            _seatCount = 5;
            _fuel = fuel;

            ////nicht effizient!!!!
            //Color = ConsoleColor.Yellow;
        }


        public FuelType Fuel
        {
            get { return _fuel; }
        }

        public int SeatCount { get => _seatCount; set => _seatCount = value; }

        public override void DisplayInfo()
        {
            Console.ForegroundColor = Color;

            Console.Write($"{Description}: {CurrentSpeed} / {MaxSpeed} km/h ");
            Console.WriteLine($"Treibstoff: {_fuel} Sitzplätze: {_seatCount}");

            Console.ResetColor();                        
        }
    }
}
