using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Wifi.MongoDbLibrary
{
    public class MongoDbRepository<T>
    {
        private readonly string _databaseName;
        private readonly string _collectionName;
        private IMongoCollection<T> _teilnehmerCollection;
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

        public IEnumerable<T> GetAll()
        {
            var filter = Builders<T>.Filter.Empty;

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).ToList();
        }

        public T GetByFilter(Expression<Func<T, bool>> filterExpression)
        {
            var filter = Builders<T>.Filter.Where(filterExpression);

            // Finds the newly inserted document by using the filter
            return _teilnehmerCollection.Find(filter).FirstOrDefault();
        }

        public void Write(T dataToWrite)
        {
            if (dataToWrite == null)
            {
                return;
            }

            _teilnehmerCollection.InsertOne(dataToWrite);
        }

        public bool Delete(Expression<Func<T, bool>> filterExpression)
        {
            // Creates a filter for all documents that have a "_id" value of id
            var filter = Builders<T>.Filter.Where(filterExpression);

            // Finds the newly inserted document by using the filter
            var result = _teilnehmerCollection.DeleteOne(filter);

            return result.IsAcknowledged;
        }

        private void Setup()
        {
            // Establishes the connection to MongoDB and accesses the restaurants database
            var mongoClient = new MongoClient(_connectionUri);

            var teilnehmerDb = mongoClient.GetDatabase(_databaseName);
            _teilnehmerCollection = teilnehmerDb.GetCollection<T>(_collectionName);
        }
    }
}