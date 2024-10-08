using System;


namespace TeilnehmerVerwaltung_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listOfNames = new string[] { "Gandalf", "Sauron", "Alf", "Eomer" };

            //for(int i =0; i < listOfNames.Length; i++)
            //{
            //    Console.WriteLine(listOfNames[i]);
            //}

            foreach(string name in listOfNames)
            {
                Console.WriteLine(name);
                //name = "Atilla";
            }
        }

        static void MainDemo(string[] args)
        {
            //Teilnehmer Verwaltung V2
            // - die Applikation soll eine beliebige Anzahl von Teilnehmern mit folgenden Daten einlesen:
            //   Vorname, Nachname, Wohnort, Plz, Geburtsdatum (DateTime)
            // - zu Begin soll der User die Anzahl der Teilnehmer definieren können
            // - "schön" formatierte Ein- und Ausgabe
            // - Console.Clear(), Console.ForegroundColor

            string[] vornamen;
            string[] nachnamen;
            string[] residencies;
            int[] postalCodes;
            DateTime[] birthdays;
            string inputString = string.Empty;
            int countofStudents = 0;

            //clear screen and create header
            Console.Clear();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Textart generated with https://tools.picsart.com/text/font-generator/text-art/
            Console.WriteLine("  _______   _ _            _                      __      __                     _ _                            ___  \r\n |__   __| (_) |          | |                     \\ \\    / /                    | | |                          |__ \\ \r\n    | | ___ _| |_ __   ___| |__  _ __ ___   ___ _ _\\ \\  / /__ _ ____      ____ _| | |_ _   _ _ __   __ _  __   __ ) |\r\n    | |/ _ \\ | | '_ \\ / _ \\ '_ \\| '_ ` _ \\ / _ \\ '__\\ \\/ / _ \\ '__\\ \\ /\\ / / _` | | __| | | | '_ \\ / _` | \\ \\ / // / \r\n    | |  __/ | | | | |  __/ | | | | | | | |  __/ |   \\  /  __/ |   \\ V  V / (_| | | |_| |_| | | | | (_| |  \\ V // /_ \r\n    |_|\\___|_|_|_| |_|\\___|_| |_|_| |_| |_|\\___|_|    \\/ \\___|_|    \\_/\\_/ \\__,_|_|\\__|\\__,_|_| |_|\\__, |   \\_/|____|\r\n                                                                                                    __/ |            \r\n                                                                                                   |___/             ");

            Console.ResetColor();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));

            //get count of Teilnehmer
            Console.Write("\nGeben Sie die Anzahl der Teilnehmer ein: ");
            inputString = Console.ReadLine();
            countofStudents = int.Parse(inputString);

            //dimension the required arrays
            vornamen = new string[countofStudents];
            nachnamen = new string[countofStudents];
            residencies = new string[countofStudents];
            postalCodes = new int[countofStudents];
            birthdays = new DateTime[countofStudents];

            //retrieve data from user
            Console.WriteLine("\nBitte geben Sie nun die Teilnehmerdaten ein!");

            for (int i = 0; i < countofStudents; i++)
            {
                Console.WriteLine($"\nTeilnehmer {i + 1}:");
                Console.Write("\tVorname: \t");
                vornamen[i] = Console.ReadLine();

                Console.Write("\tNachname: \t");
                nachnamen[i] = Console.ReadLine();

                Console.Write("\tWohnort: \t");
                residencies[i] = Console.ReadLine();

                try
                {
                    Console.Write("\tPlz: \t\t");
                    inputString = Console.ReadLine();
                    postalCodes[i] = int.Parse(inputString);

                    Console.Write("\tGeburtsdatum: \t");
                    inputString = Console.ReadLine();
                    birthdays[i] = DateTime.Parse(inputString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\aFEHLER: " + ex.Message);
                }
            }

            //output data
            Console.WriteLine("\nTEILNEHMER DATEN");

            for (int i = 0; i < countofStudents; i++)
            {
                Console.WriteLine($"\n\tName: \t\t{vornamen[i]} {nachnamen[i]}");
                Console.WriteLine($"\tWohnort: \t{postalCodes[i]} {residencies[i]}");
                Console.WriteLine($"\tGeburtsdatum: \t{birthdays[i]}");
            }
        }
    }
}