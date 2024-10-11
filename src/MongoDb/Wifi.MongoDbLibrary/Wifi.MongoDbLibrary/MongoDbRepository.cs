using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Wifi.MongoDbLibrary
{
    public class MongoDbRepository
    {
        private readonly string _databaseName;
        private readonly string _collectionName;
        private IMongoCollection<Teilnehmer> _teilnehmerCollection;
        private string _connectionUri = "mongodb://admin:password@localhost:27017";

        public MongoDbRepository(string connectionUri, string databaseName, string collectionName)
        {
            _databaseName = databaseName;
            _collectionName = collectionName;

            if (connectionUri != null)
            {
                _connectionUri = connectionUri;
            }

            Setup();
        }

        public Teilnehmer GetTeilnehmerByNachname(string teilnehmerNachname)
        {
            // Creates a filter for all documents that have a "name" value of "Mongo's Pizza"
            var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Nachname, teilnehmerNachname);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<Teilnehmer> GetAll()
        {
            // Creates a filter for all documents that have a "name" value of "Mongo's Pizza"
            var filter = Builders<Teilnehmer>.Filter.Empty;

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).ToList();
        }

        public Teilnehmer GetTeilnehmerById(Guid id)
        {
            // Creates a filter for all documents that have a "name" value of "Mongo's Pizza"
            var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Id, id);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).FirstOrDefault();
        }

        public void WriteTeilnehmer(Teilnehmer teilnehmer)
        {
            _teilnehmerCollection.InsertOne(teilnehmer);
        }

        private void Setup()
        {
            // Establishes the connection to MongoDB and accesses the restaurants database
            var mongoClient = new MongoClient(_connectionUri);

            var teilnehmerDb = mongoClient.GetDatabase(_databaseName);
            _teilnehmerCollection = teilnehmerDb.GetCollection<Teilnehmer>(_collectionName);
        }
    }
}