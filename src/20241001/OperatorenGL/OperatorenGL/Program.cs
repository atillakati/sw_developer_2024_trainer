using System;
using System.Dynamic;

namespace OperatorenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //arithmetischen Operatoren
            //+ - * / %
            // A = a * b

            int flaecheRechteck = 0;
            int seiteA = 22;
            int seiteB = 10;
            int radius = 10;
            double kreisFlaeche = 0;

            //Berechnung
            flaecheRechteck = (seiteA + 5) * seiteB - 10;
            kreisFlaeche = 2 * radius * Math.PI;

            //Ausgabe
            Console.WriteLine("Fläche: " + flaecheRechteck);

            //zusamengesetzte Operatoren
            int eineZahl = 1;

            eineZahl = eineZahl + 5;
            eineZahl += 5;
            eineZahl -= 5;
            eineZahl *= 5;
            eineZahl /= 5;

            eineZahl = eineZahl + 1;
            eineZahl += 1;
            eineZahl++;   // (Post) Inkrement
            ++eineZahl;   // (Pre) Inkrement

            eineZahl = 5;

            eineZahl++;
            Console.WriteLine("Ein Zahl = " + eineZahl);     //5

            Console.WriteLine("Ein Zahl = " + eineZahl++);   //6
            Console.WriteLine("Ein Zahl = " + eineZahl++);   //6
            Console.WriteLine("Ein Zahl = " + ++eineZahl);   //
            Console.WriteLine("Ein Zahl = " + eineZahl++);

            //Vergleichsoperatoren
            // < > <= >= == !=

            bool isEqual = eineZahl < "Gandalf".Length;

            //logische Operatoren
            // & | ! && ||

            bool isInRange = eineZahl > 0 || eineZahl < 10;
            isEqual = !isInRange;


        }
    }
}
