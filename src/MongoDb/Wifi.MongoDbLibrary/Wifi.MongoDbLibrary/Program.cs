using System;
using System.Linq;
using Wifi.MongoDbLibrary.DemoData;


namespace Wifi.MongoDbLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MongoDbRepository db = new MongoDbRepository("mongodb://admin:password@localhost:27017", "teilnehmer-db",
                "teilnehmer");

            bool result = db.DoesDbExist("teilnehmer-db");
            Console.WriteLine($"Datenbank gefunden: {result}");

            DemoDataHelper demoDataHelper = new DemoDataHelper();
            var demoPersons = demoDataHelper.GetRandomPersonList(2);

            foreach (var person in demoPersons)
            {
                db.WriteTeilnehmer(person);
            }

            Console.WriteLine($"{demoPersons.Count()} Personen wurden in die Datenbank geschrieben.");
        }

        //static void Main(string[] args)
        //{
        //    MongoDbRepository db = new MongoDbRepository("mongodb://admin:password@localhost:27017", "teilnehmer-db", "teilnehmer");

        //    bool result = db.DoesDbExist("teilnehmer-db");
        //    Console.WriteLine($"Datenbank gefunden: {result}");

        //    var data = db.GetAll();
        //    if (data != null && data.Any())
        //    {
        //        foreach (var teilnehmer in data)
        //        {
        //            ShowTeilnehmerData(teilnehmer);
        //        }

        //        return;
        //    }

        //    Teilnehmer[] teilnehmerListe = new Teilnehmer[]
        //    {
        //        new Teilnehmer
        //        {
        //            Vorname = "Gandalf",
        //            Nachname = "Sehralt",
        //            Ort = "Mittelerde",
        //            Plz = 6789,
        //            Geburtsdatum = new DateTime(1890, 5, 2)
        //        },
        //        new Teilnehmer
        //        {
        //            Vorname = "Max",
        //            Nachname = "Mustermann",
        //            Ort = "Musterort",
        //            Plz = 1234,
        //            Geburtsdatum = new DateTime(2001, 8, 20)
        //        }
        //    };

        //    Teilnehmer[] readTeilnehmerListe = new Teilnehmer[2];
        //    int count = 0;

        //    foreach (var teilnehmer in teilnehmerListe)
        //    {
        //        Teilnehmer existingTeilnehmer = db.GetTeilnehmerByNachname(teilnehmer.Nachname);

        //        if (existingTeilnehmer != null)
        //        {
        //            readTeilnehmerListe[count++] = existingTeilnehmer;
        //        }
        //        else
        //        {
        //            db.WriteTeilnehmer(teilnehmer);
        //        }
        //    }

        //    Teilnehmer foundTeilnehmer = db.GetTeilnehmerById(readTeilnehmerListe[0].Id);

        //}

        private static void ShowTeilnehmerData(Teilnehmer teilnehmer)
        {
            Console.WriteLine($"{teilnehmer.Vorname} {teilnehmer.Nachname} [{teilnehmer.Geburtstag.Year}] | {teilnehmer.Plz} {teilnehmer.Ort}");
        }
    }
}
