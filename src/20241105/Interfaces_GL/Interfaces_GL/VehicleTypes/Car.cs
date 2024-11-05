using System;

namespace Polymorphie_GL.VehicleTypes
{
    public class Car : IVehicle
    {
        private FuelType _fuel;
        private int _seatCount;

        public Car(string description, int maxSpeed, DateTime dateOfManufacture, FuelType fuel)            
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

        public DateTime DateOfManufacture => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public ConsoleColor Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int MaxSpeed => throw new NotImplementedException();

        public int CurrentSpeed => throw new NotImplementedException();

        public void DisplayInfo()
        {
            Console.ForegroundColor = Color;

            Console.Write($"{Description}: {CurrentSpeed} / {MaxSpeed} km/h ");
            Console.WriteLine($"Treibstoff: {_fuel} Sitzplätze: {_seatCount}");

            Console.ResetColor();
        }

        public void MakeSound()
        {
            throw new NotImplementedException();
        }

        public void SetMediaPlayerState(bool isOn)
        {
            throw new NotImplementedException();
        }

        public void SpeedUp(int deltaSpeed)
        {
            throw new NotImplementedException();
        }
    }
}
