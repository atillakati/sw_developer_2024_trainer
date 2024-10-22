using System;
using System.Collections.Generic;
using MongoDB.Bson;
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

        public bool DoesDbExist(string databaseName)
        {
            var mongoClient = new MongoClient(_connectionUri);
            var dbList = mongoClient.ListDatabases().ToList();

            foreach (var dbInfo in dbList)
            {
                var element = dbInfo.GetElement("name");
                if (element.Value.ToString() == databaseName)
                {
                    return true;    
                }
            }

            return false;
        }

        public Teilnehmer GetByNachname(string teilnehmerNachname)
        {
            // Creates a filter for all documents that have a "Nachname" value of teilnehmerNachname
            var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Nachname, teilnehmerNachname);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<Teilnehmer> GetAll()
        {
            var filter = Builders<Teilnehmer>.Filter.Empty;

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).ToList();
        }

        public Teilnehmer GetById(ObjectId id)
        {
            //var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Id == id);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Write(Teilnehmer teilnehmer)
        {
            if (teilnehmer == null)
            {
                return;
            }

            _teilnehmerCollection.InsertOne(teilnehmer);
        }

        public bool Delete(ObjectId id)
        {
            // Creates a filter for all documents that have a "_id" value of id
            var filter = Builders<Teilnehmer>.Filter.Eq(r => r.Id, id);

            // Finds the newly inserted document by using the filter
            var result = _teilnehmerCollection.DeleteOne(filter);

            return result.IsAcknowledged;
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