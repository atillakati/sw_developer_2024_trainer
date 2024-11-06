using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Wifi.TeilnehmerVerwaltung.CoreTypes;

namespace Wifi.TeilnehmerVerwaltung.Storage
{
    public class MongoDbRepository
    {
        public IMongoCollection<Teilnehmer> MyCollection;
        public string ConnectionUri;
        public string DbName;
        public string CollectionName;

        public void Init()
        {
            MongoClient dbClient = new MongoClient(ConnectionUri);
            var database = dbClient.GetDatabase(DbName);
            MyCollection = database.GetCollection<Teilnehmer>(CollectionName);
        }

        public void Insert(Teilnehmer teilnehmerToSave)
        {
            MyCollection.InsertOne(teilnehmerToSave);
        }

        public Teilnehmer[] GetAll()
        {
            var teilnehmerListe = MyCollection.Find(new BsonDocument()).ToList();

            return teilnehmerListe.ToArray();
        }
    }
}
