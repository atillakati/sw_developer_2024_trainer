using MongoDB.Driver;
using SharpCompress.Readers.Rar;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Wifi.MongoDbLibrary
{
    internal class Program
    {
        private static IMongoCollection<Teilnehmer> _teilnehmerCollection;
        const string connectionUri = "mongodb://admin:password@localhost:27017";

        static void Main(string[] args)
        {
            Setup();

            var data = GetAll();
            if (data != null && data.Any())
            {
                foreach (var teilnehmer in data)
                {
                    ShowTeilnehmerData(teilnehmer);
                }

                return;
            }

            Teilnehmer[] teilnehmerListe = new Teilnehmer[]
            {
                new Teilnehmer
                {
                    Vorname = "Gandalf",
                    Nachname = "Sehralt",
                    Ort = "Mittelerde",
                    Plz = 6789,
                    Geburtsdatum = new DateTime(1890, 5, 2)
                },
                new Teilnehmer
                {
                    Vorname = "Max",
                    Nachname = "Mustermann",
                    Ort = "Musterort",
                    Plz = 1234,
                    Geburtsdatum = new DateTime(2001, 8, 20)
                }
            };

            Teilnehmer[] readTeilnehmerListe = new Teilnehmer[2];
            int count = 0;

            foreach (var teilnehmer in teilnehmerListe)
            {
                Teilnehmer existingTeilnehmer = GetTeilnehmerByNachname(teilnehmer.Nachname);

                if (existingTeilnehmer != null)
                {
                    readTeilnehmerListe[count++] = existingTeilnehmer;
                }
                else
                {
                    WriteTeilnehmer(teilnehmer);
                }
            }

            Teilnehmer foundTeilnehmer = GetTeilnehmerById(readTeilnehmerListe[0].Id);

        }

        private static void ShowTeilnehmerData(Teilnehmer teilnehmer)
        {
            Console.WriteLine($"{teilnehmer.Vorname} {teilnehmer.Nachname} [{teilnehmer.Geburtsdatum.Year}] | {teilnehmer.Plz} {teilnehmer.Ort}");
        }

        private static Teilnehmer GetTeilnehmerByNachname(string teilnehmerNachname)
        {
            // Creates a filter for all documents that have a "name" value of "Mongo's Pizza"
            var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Nachname, teilnehmerNachname);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).FirstOrDefault();
        }

        private static IEnumerable<Teilnehmer> GetAll()
        {
            // Creates a filter for all documents that have a "name" value of "Mongo's Pizza"
            var filter = Builders<Teilnehmer>.Filter.Empty;

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).ToList();
        }

        private static Teilnehmer GetTeilnehmerById(Guid id)
        {
            // Creates a filter for all documents that have a "name" value of "Mongo's Pizza"
            var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Id, id);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).FirstOrDefault();
        }

        private static void WriteTeilnehmer(Teilnehmer teilnehmer)
        {
            _teilnehmerCollection.InsertOne(teilnehmer);
        }

        private static void Setup()
        {
            // Establishes the connection to MongoDB and accesses the restaurants database
            var mongoClient = new MongoClient(connectionUri);
            var teilnehmerDb = mongoClient.GetDatabase("teilnehmer-db");
            _teilnehmerCollection = teilnehmerDb.GetCollection<Teilnehmer>("teilnehmer");
        }
    }
}
