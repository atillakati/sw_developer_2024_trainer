using System;

namespace EingabeGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            int alter = 0;
            int geburtsJahr = 0;
            string input = string.Empty;

            //Eingabe Name
            Console.Write("Bitte Name eingeben: ");
            name = Console.ReadLine();

            Console.WriteLine("Hallo " + name + "!");
           
            //Eingabe Geburtsjahr
            Console.Write("Bitte Geburtsjahr eingeben: ");
            input = Console.ReadLine();
            geburtsJahr = int.Parse(input);

            //Berechnung
            alter = DateTime.Now.Year - geburtsJahr;

            //Ausgabe
            Console.WriteLine(name + ", du bist " + alter + " Jahre alt.");
        }
    }
}
