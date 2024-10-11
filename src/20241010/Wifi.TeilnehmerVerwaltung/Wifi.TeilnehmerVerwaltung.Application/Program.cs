using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.TeilnehmerVerwaltung.Application
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //Teilnehmer Verwaltung V3
            // - die Applikation soll eine beliebige Anzahl von Teilnehmern mit folgenden Daten einlesen:
            //   Vorname, Nachname, Wohnort, Plz, Geburtsdatum (DateTime)
            // - zu Begin soll der User die Anzahl der Teilnehmer definieren können
            // - "schön" formatierte Ein- und Ausgabe
            // - Console.Clear(), Console.ForegroundColor

            Teilnehmer[] teilnehmerListe;

            string inputString = string.Empty;
            int countofStudents = 0;

            //clear screen and create header
            CreateHeader();

            //get count of Teilnehmer
            countofStudents = GetIntValue("\nGeben Sie die Anzahl der Teilnehmer ein: ");

            //dimension the required array
            teilnehmerListe = new Teilnehmer[countofStudents];

            //retrieve data from user
            Console.WriteLine("\nBitte geben Sie nun die Teilnehmerdaten ein!");

            for (int i = 0; i < countofStudents; i++)
            {
                Console.WriteLine($"\nTeilnehmer {i + 1}:");
                teilnehmerListe[i] = ReadTeilnehmerDataFromUserInput();
            }

            //output data
            DisplayTeilnehmerData(teilnehmerListe);
        }


        static void DisplayTeilnehmerData(Teilnehmer[] teilnehmerListe)
        {
            Console.WriteLine("\nTEILNEHMER DATEN");

            foreach (Teilnehmer t in teilnehmerListe)
            {
                Console.WriteLine($"\n\tName: \t\t{t.Vorname} {t.Nachname}");
                Console.WriteLine($"\tWohnort: \t{t.Plz} {t.Ort}");
                Console.WriteLine($"\tGeburtsdatum: \t{t.Geburtstag.ToLongDateString()}");
            }
        }

        static Teilnehmer ReadTeilnehmerDataFromUserInput()
        {
            Teilnehmer newTeilnehmer = new Teilnehmer();

            Console.Write("\tVorname: \t");
            newTeilnehmer.Vorname = Console.ReadLine();

            Console.Write("\tNachname: \t");
            newTeilnehmer.Nachname = Console.ReadLine();

            Console.Write("\tWohnort: \t");
            newTeilnehmer.Ort = Console.ReadLine();

            newTeilnehmer.Plz = GetIntValue("\tPlz: \t\t");
            newTeilnehmer.Geburtstag = GetDateTimeValue("\tGeburtsdatum: \t");
            
            return newTeilnehmer;
        }

        static DateTime GetDateTimeValue(string inputPrompt)
        {
            string inputString = string.Empty;
            bool inputIsNotValid = true;
            DateTime inputValue = DateTime.MinValue;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();

                try
                {
                    inputValue = DateTime.Parse(inputString);
                    inputIsNotValid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\aERROR: " + ex.Message);
                    inputIsNotValid = true;
                }
            }
            while (inputIsNotValid);

            return inputValue;
        }

        static int GetIntValue(string inputPrompt)
        {
            string inputString = string.Empty;
            bool inputIsNotValid = true;
            int inputValue = 0;

            do
            {
                Console.Write(inputPrompt);
                inputString = Console.ReadLine();

                try
                {
                    inputValue = int.Parse(inputString);
                    inputIsNotValid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\aERROR: " + ex.Message);
                    inputIsNotValid = true;
                }
            }
            while (inputIsNotValid);

            return inputValue;
        }

        static void CreateHeader()
        {
            Console.Clear();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Textart generated with https://tools.picsart.com/text/font-generator/text-art/
            Console.WriteLine("  _______   _ _            _                      __      __                     _ _                            ___  \r\n |__   __| (_) |          | |                     \\ \\    / /                    | | |                          |__ \\ \r\n    | | ___ _| |_ __   ___| |__  _ __ ___   ___ _ _\\ \\  / /__ _ ____      ____ _| | |_ _   _ _ __   __ _  __   __ ) |\r\n    | |/ _ \\ | | '_ \\ / _ \\ '_ \\| '_ ` _ \\ / _ \\ '__\\ \\/ / _ \\ '__\\ \\ /\\ / / _` | | __| | | | '_ \\ / _` | \\ \\ / // / \r\n    | |  __/ | | | | |  __/ | | | | | | | |  __/ |   \\  /  __/ |   \\ V  V / (_| | | |_| |_| | | | | (_| |  \\ V // /_ \r\n    |_|\\___|_|_|_| |_|\\___|_| |_|_| |_| |_|\\___|_|    \\/ \\___|_|    \\_/\\_/ \\__,_|_|\\__|\\__,_|_| |_|\\__, |   \\_/|____|\r\n                                                                                                    __/ |            \r\n                                                                                                   |___/             ");

            Console.ResetColor();
            Console.WriteLine(new string('#', Console.WindowWidth - 1));
        }
    }
}
