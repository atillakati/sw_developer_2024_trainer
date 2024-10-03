using System;

namespace Iterationen_for
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxCount = 10;

            //Initialisierung; Abbruchbedingung; Reinitialisierung
            for (int i = 0; i < maxCount; i++)
            {
                Console.WriteLine($"{i+1}. Lauf: {i}");
                
                //man. Abbruch
                //break;
            }

            //for (int i = 156; i >= 28; i-=3)
            //{
            //    Console.WriteLine($"Lauf: {i}");
            //}
        }
    }
}
