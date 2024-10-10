using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThirdParty.Json.LitJson;

namespace Wifi.MongoDbLibrary
{
    public class Teilnehmer
    {
        [BsonId]
        public Guid Id;

        public string Vorname;
        public string Nachname;
        public string Ort;
        public int Plz;
        public DateTime Geburtsdatum;
    }
}