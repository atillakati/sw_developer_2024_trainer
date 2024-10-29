using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTableExt;
using MongoDB.Driver;
using Wifi.MongoDbLibrary.MongoCustom;
using System.Configuration;
using MongoDB.Bson;

namespace Wifi.MongoDbLibrary.TestApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string serverUri = ConfigurationManager.AppSettings["server-uri"];
            string dbName = ConfigurationManager.AppSettings["database-name"];
            string collection = ConfigurationManager.AppSettings["collection-name"];

            if (string.IsNullOrEmpty(serverUri) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(collection))
            {
                Console.WriteLine("Please check your app settings. DB settings required.");
                return;
            }

            var db = new MongoDbRepository<Teilnehmer>(serverUri, dbName, collection);

            bool result = db.DoesDbExist(dbName);
            Console.WriteLine($"Datenbank gefunden: {result}");

            RandomLocation randomLocation = new RandomLocation();
            var geoDataList = randomLocation.GetRandomDataList(10);
            ShowData(geoDataList);

            RandomTeilnehmer helper = new RandomTeilnehmer();
            var demoPersons = helper.GetRandomDataList(10);

            Console.WriteLine($"Datenquelle: {helper.BaseUri}{helper.RequestUri}\n");

            foreach (var person in demoPersons)
            {
                db.Write(person);
            }

            ShowData(demoPersons);

            Console.WriteLine($"\n{demoPersons.Count()} Personen wurden in die Datenbank geschrieben.");

            var aPerson = helper.GetRandomData();
            if (aPerson != null)
            {
                ShowTeilnehmerData(aPerson);
            }

            Console.WriteLine("\nDelete person tests:");
            DeleteTests(db);

            Console.WriteLine("\nGetById tests:");
            GetByIdTests(db);
        }

        private static void GetByIdTests(MongoDbRepository<Teilnehmer> db)
        {
            ObjectId personId;


            Console.Write("Please enter a person id: ");
            try
            {
                personId = ObjectId.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return;
            }

            Console.WriteLine($"Seraching person by ID: {personId}...");
            var data = db.GetByFilter(x => x.Id == personId);

            ShowTeilnehmerData(data);
        }

        private static void DeleteTests(MongoDbRepository<Teilnehmer> db)
        {
            int counter = 0;
            var personList = db.GetAll().ToArray();

            foreach (var person in personList)
            {
                Console.Write($"Removing person {person.Vorname} {person.Nachname} ");
                if (db.Delete(x => x.Id == person.Id))
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

        //    Teilnehmer foundTeilnehmer = db.GetByFilter(readTeilnehmerListe[0].Id);

        //}

        private static void ShowTeilnehmerData(Teilnehmer teilnehmer)
        {
            if (teilnehmer == null)
            {
                return;
            }

            ShowData(new Teilnehmer[] { teilnehmer });
        }

        private static void ShowData<T>(IEnumerable<T> dataList) where T : class
        {
            var teilnehmers = dataList.ToList();

            if (!teilnehmers.Any())
            {
                return;
            }

            ConsoleTableBuilder
                .From(teilnehmers)
                .WithFormat(ConsoleTableBuilderFormat.Default)
                .ExportAndWriteLine();
        }
    }
}
