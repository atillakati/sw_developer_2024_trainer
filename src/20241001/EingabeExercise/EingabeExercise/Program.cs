using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EingabeExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kreisflächen Berechnung
            //==========================
            // Benutzer soll den Radius eingeben.
            // Applikation berechnet Fläche und gibt alle Daten (inkl. Eingaben) aus.

            double radius = 0.0;
            double flaecheKreis = 0.0;
            string input = string.Empty;

            //Eingabe
            Console.Write("Bitte den Radius eingeben (in cm): ");
            input = Console.ReadLine();
            radius = double.Parse(input);

            //Berechnung
            flaecheKreis = radius * radius * Math.PI;

            //Ausgabe            
            Console.WriteLine($"Ergebnis:\n\tRadius: {radius:f2} cm");
            Console.WriteLine($"\tFläche: {flaecheKreis:f2} cm²");
        }
    }
}
