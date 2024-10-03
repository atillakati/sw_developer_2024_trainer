using System;


namespace Exercise_FailsafeInputs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Requirements:
            // - Name und Alter des Users einlesen
            // - Ungültige Eingaben führen nicht zu einer Exception
            //   und sollen wiederholt werden.
            // - Denken Sie an eine "gute" Benutzerführung

            string name = string.Empty;
            int alter = 0;
            bool inputIsNotValid = true;
            string inputString = string.Empty;

            Console.WriteLine("Bitte geben Sie folgende Daten ein:");
            Console.Write("\tName:  ");
            name = Console.ReadLine();

            do
            {
                try
                {
                    Console.Write("\tAlter: ");
                    inputString = Console.ReadLine();
                    alter = int.Parse(inputString);
                    inputIsNotValid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\tFehler: {ex.Message}");
                    inputIsNotValid = true;
                }
            }
            while (inputIsNotValid);

            Console.WriteLine($"Hallo {name}, dein Geburtsjahr ist {DateTime.Now.Year - alter}.");
        }
    }
}
