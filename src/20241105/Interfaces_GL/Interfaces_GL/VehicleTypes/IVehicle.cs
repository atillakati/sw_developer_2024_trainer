using System;

namespace Polymorphie_GL.VehicleTypes
{
    public interface IVehicle
    {                
        DateTime DateOfManufacture { get; }
                
        string Description { get; }

        ConsoleColor Color { get; set; }

        int MaxSpeed { get; }

        int CurrentSpeed { get; }


        void SetMediaPlayerState(bool isOn);

        void MakeSound();

        void DisplayInfo();

        void SpeedUp(int deltaSpeed);        
    }
}
