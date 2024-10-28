using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Wifi.MongoDbLibrary.MongoCustom
{
    public class Teilnehmer
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Ort { get; set; }
        public int Plz { get; set; }
        public DateTime Geburtstag { get; set; }
    }
}