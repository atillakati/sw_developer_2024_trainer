using System;

namespace If_Grundlagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 2;

            if(zahl < 5 && zahl > 0)
            {
                Console.WriteLine("Diese Zahl ist kleiner 5 und positiv.");
            }
            else
            {
                Console.WriteLine("Leider ist die Zahl nicht kleiner als 5.");
            }
        }
    }
}
