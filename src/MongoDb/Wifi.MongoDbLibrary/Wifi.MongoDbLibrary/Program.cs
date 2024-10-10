using MongoDB.Driver;
using SharpCompress.Readers.Rar;
using System;


namespace Wifi.MongoDbLibrary
{
    internal class Program
    {
        private static IMongoCollection<Teilnehmer> _teilnehmerCollection;
        const string connectionUri = "mongodb://admin:password@localhost:27017";

        static void Main(string[] args)
        {
            Setup();

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
                Teilnehmer existingTeilnehmer = ReadEntryByNachname(teilnehmer.Nachname);

                if (existingTeilnehmer != null)
                {
                    readTeilnehmerListe[count++] = existingTeilnehmer;
                }
                else
                {
                    WriteEntry(teilnehmer);
                }
            }

            Teilnehmer foundTeilnehmer = ReadEntryById(readTeilnehmerListe[0].Id);

        }

        private static Teilnehmer ReadEntryByNachname(string teilnehmerNachname)
        {
            // Creates a filter for all documents that have a "name" value of "Mongo's Pizza"
            var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Nachname, teilnehmerNachname);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).FirstOrDefault();
        }

        private static Teilnehmer ReadEntryById(Guid id)
        {
            // Creates a filter for all documents that have a "name" value of "Mongo's Pizza"
            var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Id, id);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).FirstOrDefault();
        }

        private static void WriteEntry(Teilnehmer teilnehmer)
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
