using System;


namespace Vehicle_Kapselung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Vehicle("BadMobil V3 Neutro", 250, new DateTime(1970,5,1));
            car.Color = ConsoleColor.Red;

            car.DisplayInfo();

            for (int i = 0; i < 5; i++)
            {
                //Fahrzeug beschleunigen
                car.SpeedUp(55);
                //Zustand darstellen
                car.DisplayInfo();                
            }

            Console.WriteLine($"Baujahr: {car.DateOfManufacture} Alter: {car.Age}");
        }
    }
}
