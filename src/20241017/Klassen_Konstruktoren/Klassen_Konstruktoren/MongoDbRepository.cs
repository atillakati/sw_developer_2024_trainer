using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace Klassen_Konstruktoren
{
    public class MongoDbRepository
    {
        private IMongoCollection<Teilnehmer> _myCollection;
        private string _connectionUri;
        private string _dbName;
        private string _collectionName;

        //std. Konstruktor
        /// <summary>
        /// Konstruktor um mit der teilnehmer-db Teilnehmerdaten zu bearbeiten.
        /// </summary>
        public MongoDbRepository()
        {
            _connectionUri = "mongodb://admin:password@127.0.0.1:27017";
            _dbName = "teilnehmer-db";
            _collectionName = "teilnehmer";

            Init();
        }

        //benutzerspezifische Konstruktor
        public MongoDbRepository(string databaseName, string collectionName)
        {
            _connectionUri = "mongodb://admin:password@127.0.0.1:27017";
            _dbName = databaseName;
            _collectionName = collectionName;

            Init();
        }

        
        public string DbName
        {
            get
            {
                return _dbName;
            }

            //set
            //{
            //    if(value != string.Empty)
            //    {
            //        DbName = value;
            //    }
            //}
        }

        public void Init()
        {
            MongoClient dbClient = new MongoClient(_connectionUri);
            var database = dbClient.GetDatabase(_dbName);
            _myCollection = database.GetCollection<Teilnehmer>(_collectionName);
        }

        public void Insert(Teilnehmer teilnehmerToSave)
        {
            _myCollection.InsertOne(teilnehmerToSave);
        }

        public Teilnehmer[] GetAll()
        {            
            var filter = Builders<Teilnehmer>.Filter.Empty;

            return _myCollection.Find(filter).ToList().ToArray();
        }
    }
}
