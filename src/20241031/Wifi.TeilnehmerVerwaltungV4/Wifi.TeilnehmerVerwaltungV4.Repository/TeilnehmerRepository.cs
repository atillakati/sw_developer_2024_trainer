using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Wifi.TeilnehmerVerwaltungV4.Core;
using Wifi.TeilnehmerVerwaltungV4.Repository.Entities;

namespace Wifi.MongoDbLibrary
{
    public class TeilnehmerRepository
    {
        private readonly string _databaseName;
        private readonly string _collectionName;
        private IMongoCollection<TeilnehmerEntity> _collection;
        private string _connectionUri = "mongodb://admin:password@localhost:27017";


        public TeilnehmerRepository(string connectionUri, string databaseName, string collectionName)
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

        public IEnumerable<Teilnehmer> GetAll()
        {
            var filter = Builders<TeilnehmerEntity>.Filter.Empty;

            var entityList = _collection.Find(filter).ToList();
            
            return TeilnehmerMapper.MapToDomain(entityList);
        }

        public Teilnehmer GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var objectId = ObjectId.Parse(id);
            var filter = Builders<TeilnehmerEntity>.Filter.Eq(x => x.Id, objectId);

            var entity = _collection.Find(filter).FirstOrDefault();

            return TeilnehmerMapper.MapToDomain(entity);
        }

        public void Write(Teilnehmer newTeilnehmer)
        {
            if (newTeilnehmer == null)
            {
                return;
            }

            var entity = TeilnehmerMapper.MapToEntity(newTeilnehmer);

            _collection.InsertOne(entity);
        }

        public bool Delete(Teilnehmer teilnehmerToDelete)
        {
            if (teilnehmerToDelete == null)
            {
                return false;
            }

            var id = ObjectId.Parse(teilnehmerToDelete.Id);

            var filter = Builders<TeilnehmerEntity>.Filter.Where(x => x.Id == id);
            var result = _collection.DeleteOne(filter);

            return result.IsAcknowledged;
        }


        private void Setup()
        {
            // Establishes the connection to MongoDB and accesses the database
            var mongoClient = new MongoClient(_connectionUri);

            var teilnehmerDb = mongoClient.GetDatabase(_databaseName);
            _collection = teilnehmerDb.GetCollection<TeilnehmerEntity>(_collectionName);
        }
    }
}