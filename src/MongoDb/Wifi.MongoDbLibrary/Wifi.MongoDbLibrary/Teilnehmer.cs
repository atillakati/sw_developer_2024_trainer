using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Wifi.MongoDbLibrary
{
    public class Teilnehmer
    {
        [BsonId]
        public ObjectId Id;

        public string Vorname;
        public string Nachname;
        public string Ort;
        public int Plz;
        public DateTime Geburtstag;
    }
}