using System;


namespace TeilnehmerVerwaltung_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Teilnehmer Verwaltung V1
            // - "schön" formatierte Ein- und Ausgabe
            //Console.Clear(), Console.ForegroundColor
            // - Vorname, Nachname, Wohnort, Plz, Geburtsdatum (DateTime)

            string vorname = string.Empty;
            string nachname = string.Empty;
            string ort = string.Empty;
            string inputString = string.Empty;
            int plz = 0;
            DateTime birthday = DateTime.Now;

            //clear screen and create header
            Console.Clear();
            Console.WriteLine(new string('#', Console.WindowWidth-1));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  _______   _ _            _                      __      __                     _ _                            __ \r\n |__   __| (_) |          | |                     \\ \\    / /                    | | |                          /_ |\r\n    | | ___ _| |_ __   ___| |__  _ __ ___   ___ _ _\\ \\  / /__ _ ____      ____ _| | |_ _   _ _ __   __ _  __   _| |\r\n    | |/ _ \\ | | '_ \\ / _ \\ '_ \\| '_ ` _ \\ / _ \\ '__\\ \\/ / _ \\ '__\\ \\ /\\ / / _` | | __| | | | '_ \\ / _` | \\ \\ / / |\r\n    | |  __/ | | | | |  __/ | | | | | | | |  __/ |   \\  /  __/ |   \\ V  V / (_| | | |_| |_| | | | | (_| |  \\ V /| |\r\n    |_|\\___|_|_|_| |_|\\___|_| |_|_| |_| |_|\\___|_|    \\/ \\___|_|    \\_/\\_/ \\__,_|_|\\__|\\__,_|_| |_|\\__, |   \\_/ |_|\r\n                                                                                                    __/ |          \r\n                                                                                                   |___/           ");
            //Console.WriteLine("      TEILNEHMER VERWALTUNG v1.0");
            Console.ResetColor();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));

            //retrieve data from user
            Console.WriteLine("\nBitte geben Sie die Teilnehmerdaten ein!\n");
            Console.Write("Vorname: \t");
            vorname = Console.ReadLine();

            Console.Write("Nachname: \t");
            nachname= Console.ReadLine();

            Console.Write("Wohnort: \t");
            ort = Console.ReadLine();

            Console.Write("Plz: \t\t");
            inputString = Console.ReadLine();
            plz = int.Parse(inputString);

            Console.Write("Geburtsdatum: \t");
            inputString = Console.ReadLine();
            birthday = DateTime.Parse(inputString);

            //output data
            Console.WriteLine("\nTEILNEHMER DATEN\n");
            Console.WriteLine($"\tName: \t\t{vorname} {nachname}");
            Console.WriteLine($"\tWohnort: \t{plz} {ort}");
            Console.WriteLine($"\tGeburtsdatum: \t{birthday.ToLongDateString()}");
        }
    }
}
