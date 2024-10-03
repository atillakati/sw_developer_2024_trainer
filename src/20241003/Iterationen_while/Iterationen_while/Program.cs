using System;

namespace Iterationen_while
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eingabe = string.Empty;

            Console.WriteLine($"Time: {DateTime.Now.Second}");

            while (DateTime.Now.Second > 30 && DateTime.Now.Second < 35)
            {
                Console.WriteLine($"Time: {DateTime.Now.Second}");
            }

            do
            {
                Console.Write("Geben Sie was ein: ");
                eingabe = Console.ReadLine();
            }
            while (eingabe.Length < 5);
        }
    }
}
