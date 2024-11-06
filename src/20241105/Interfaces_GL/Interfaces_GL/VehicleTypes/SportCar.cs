using Polymorphie_GL.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphy_II.VehicleTypes
{
    public class SportCar : IVehicle
    {
        public override DateTime DateOfManufacture => throw new NotImplementedException();

        public override string Description => throw new NotImplementedException();

        public override ConsoleColor Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int MaxSpeed => throw new NotImplementedException();

        public override int CurrentSpeed => throw new NotImplementedException();

        public override void DisplayInfo()
        {
            throw new NotImplementedException();
        }

        public override void MakeSound()
        {
            throw new NotImplementedException();
        }

        public override void SetMediaPlayerState(bool isOn)
        {
            throw new NotImplementedException();
        }

        public override void SpeedUp(int deltaSpeed)
        {
            throw new NotImplementedException();
        }
    }
}
