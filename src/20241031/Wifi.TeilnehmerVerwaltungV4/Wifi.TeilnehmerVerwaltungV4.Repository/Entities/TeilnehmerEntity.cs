using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Wifi.TeilnehmerVerwaltungV4.Repository.Entities
{
    public class TeilnehmerEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Plz { get; set; }
        public string Ort { get; set; }
        public DateTime Geburtsdatum { get; set; }
    }
}
