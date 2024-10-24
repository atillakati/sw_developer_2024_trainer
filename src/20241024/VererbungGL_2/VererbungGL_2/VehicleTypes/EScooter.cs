using System;

namespace VererbungGL_2.VehicleTypes
{
    public class EScooter : Vehicle
    {
        private int _range;

        public EScooter(string description, int range, ConsoleColor color)
            : base(description, 30, DateTime.Now, color)
        {
            _range = range;
        }

        public int Range { get => _range; }
    }
}
