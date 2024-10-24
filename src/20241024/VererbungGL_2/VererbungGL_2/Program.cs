using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VererbungGL_2.VehicleTypes;

namespace VererbungGL_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Car("Batmobil", 200, DateTime.Now, FuelType.Elektrisch);

            if (!car.IsMediaPlayerOn)
            {
                car.SetMediaPlayerState(true);
                car.MakeSound();
            }
        }
    }
}
