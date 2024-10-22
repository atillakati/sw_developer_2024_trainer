using System;
using System.Linq;
using Wifi.MongoDbLibrary.DemoData;


namespace Wifi.MongoDbLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MongoDbRepository db = new MongoDbRepository("mongodb://admin:password@localhost:27017", "teilnehmer-db", "teilnehmer");

            bool result = db.DoesDbExist("teilnehmer-db");
            Console.WriteLine($"Datenbank gefunden: {result}");

            RandomTeilnehmer helper = new RandomTeilnehmer();
            var demoPersons = helper.GetRandomPersonList(10);

            Console.WriteLine($"Datenquelle: {helper.BaseUri}{helper.RequestUri}\n");

            foreach (var person in demoPersons)
            {
                db.Write(person);
                ShowTeilnehmerData(person);
            }

            Console.WriteLine($"\n{demoPersons.Count()} Personen wurden in die Datenbank geschrieben.");

            var aPerson = helper.GetRandomPerson();
            if (aPerson != null)
            {
                ShowTeilnehmerData(aPerson);
            }

            Console.WriteLine("\nDelete person tests:");
            DeleteTests(db);

            Console.WriteLine("\nGetById tests:");
            GetByIdTests(db);
        }

        private static void GetByIdTests(MongoDbRepository db)
        {
            var personList = db.GetAll();
            foreach (var person in personList)
            {
                var data = db.GetById(person.Id);
                ShowTeilnehmerData(data);
            }
        }

        private static void DeleteTests(MongoDbRepository db)
        {
            int counter = 0;
            var personList = db.GetAll().ToArray();

            foreach (var person in personList)
            {
                Console.Write($"Removing person {person.Vorname} {person.Nachname} ");
                if (db.Delete(person.Id))
                {
                    Console.WriteLine("..done.");
                }
                else
                {
                    Console.WriteLine("..failed.");
                }

                counter++;
                if (counter > 5)
                {
                    break;
                }
            }
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
        //        Teilnehmer existingTeilnehmer = db.GetByNachname(teilnehmer.Nachname);

        //        if (existingTeilnehmer != null)
        //        {
        //            readTeilnehmerListe[count++] = existingTeilnehmer;
        //        }
        //        else
        //        {
        //            db.Write(teilnehmer);
        //        }
        //    }

        //    Teilnehmer foundTeilnehmer = db.GetById(readTeilnehmerListe[0].Id);

        //}

        private static void ShowTeilnehmerData(Teilnehmer teilnehmer)
        {
            if (teilnehmer == null)
            {
                return;
            }

            Console.WriteLine($"{teilnehmer.Vorname} {teilnehmer.Nachname} [{teilnehmer.Geburtstag.Year}] | {teilnehmer.Plz} {teilnehmer.Ort}");
        }
    }
}
