using System;

namespace Polymorphie_GL.VehicleTypes
{
    public class EScooter : IVehicle
    {
        private int _range;

        public EScooter(string description, int range, ConsoleColor color)
            : base(description, 30, DateTime.Now, color)
        {
            _range = range;
        }

        public int Range { get => _range; }


        //public override int Age
        //{
        //    get
        //    {
        //        return 2;
        //    }
        //} 

        public override void DisplayInfo()
        {
            Console.ForegroundColor = Color;
            Console.Write($"Escooter Range: {_range}km ");            
        }
    }
}
