using System;

namespace DatenGL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dekalaration: Datentyp Variablenbezeichnung;
            string userName;

            //Initialisierung
            userName = "Gandalf";

            //Dekalaration & Initialisierung
            string einAndererUserName = string.Empty;
            string einUserName = "Sauron";            
    
            Console.WriteLine("Mein Name: " + userName);
            Console.WriteLine("Ein Name:  " + einUserName);

            //Dekalaration & Initialisierung
            bool isPowerOn = false;

            int aNumber = 150;
            Console.WriteLine("int Max: " + int.MaxValue);
            Console.WriteLine("int Min: " + int.MinValue);

            double carWeight = 1850.654;
            Console.WriteLine("Gewicht: " + carWeight);

            decimal artikelPreis = 15.99m;
        }
    }
}
