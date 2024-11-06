using System;

namespace Polymorphie_GL.VehicleTypes
{
    public abstract class Vehicle
    {                
        public abstract DateTime DateOfManufacture { get; }
                
        public abstract string Description { get; }

        public abstract ConsoleColor Color { get; set; }

        public abstract int MaxSpeed { get; }

        public abstract int CurrentSpeed { get; }


        public abstract void SetMediaPlayerState(bool isOn);

        public abstract void MakeSound();

        public abstract void DisplayInfo();

        public abstract void SpeedUp(int deltaSpeed);
        
    }
}
