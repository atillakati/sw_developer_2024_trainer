using System;
using Wifi.ConsoleTools;
using Wifi.TeilnehmerVerwaltung.CoreTypes;
using Wifi.TeilnehmerVerwaltung.Storage;

namespace Wifi.TeilnehmerVerwaltung.Application
{

    internal class Program
    {
        static void Main()
        {
            //instanz anlegen
            MongoDbRepository db = new MongoDbRepository();

            //Zustandsinformationen initialisieren
            //mongodb://[user:password]@[server-ip]:27017
            db.ConnectionUri = "mongodb://admin:password@127.0.0.1:27017";
            db.DbName = "teilnehmer-db";
            db.CollectionName = "teilnehmer";

            db.Init();

            //instanz anlegen & initialisieren
            Teilnehmer newT = new Teilnehmer
            {
                Vorname = "Gandalf",
                Nachname = "Sehralt",
                Ort = "Mittelerde",
                Plz = 6879,
                Geburtstag = new DateTime(1890, 8, 15)
            };            

            db.Insert(newT);

            Teilnehmer[] meineTeilnehmer = db.GetAll();
            DisplayTeilnehmerData(meineTeilnehmer);
        }

        //static void Main(string[] args)
        //{
        //    //Teilnehmer Verwaltung V3
        //    // - die Applikation soll eine beliebige Anzahl von Teilnehmern mit folgenden Daten einlesen:
        //    //   Vorname, Nachname, Wohnort, Plz, Geburtsdatum (DateTime)
        //    // - zu Begin soll der User die Anzahl der Teilnehmer definieren können
        //    // - "schön" formatierte Ein- und Ausgabe
        //    // - Console.Clear(), Console.ForegroundColor

        //    Teilnehmer[] teilnehmerListe;

        //    string inputString = string.Empty;
        //    int countofStudents = 0;            

        //    //clear screen and create header
        //    Helper.CreateHeader();            

        //    //get count of Teilnehmer
        //    countofStudents = Helper.GetIntValue("\nGeben Sie die Anzahl der Teilnehmer ein: ");

        //    //dimension the required array
        //    teilnehmerListe = new Teilnehmer[countofStudents];

        //    //retrieve data from user
        //    Console.WriteLine("\nBitte geben Sie nun die Teilnehmerdaten ein!");

        //    for (int i = 0; i < countofStudents; i++)
        //    {
        //        Console.WriteLine($"\nTeilnehmer {i + 1}:");
        //        teilnehmerListe[i] = ReadTeilnehmerDataFromUserInput();
        //    }

        //    //output data
        //    DisplayTeilnehmerData(teilnehmerListe);
        //}


        static void DisplayTeilnehmerData(Teilnehmer[] teilnehmerListe)
        {
            Console.WriteLine("\nTEILNEHMER DATEN");

            foreach (Teilnehmer t in teilnehmerListe)
            {
                Console.WriteLine($"\n\tName: \t\t{t.Vorname} {t.Nachname} [{t.Id}]");
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

            newTeilnehmer.Plz = Helper.GetIntValue("\tPlz: \t\t");
            newTeilnehmer.Geburtstag = Helper.GetDateTimeValue("\tGeburtsdatum: \t");
            
            return newTeilnehmer;
        }

        
    }
}
