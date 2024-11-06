using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Wifi.TeilnehmerVerwaltung.CoreTypes
{
    public class Teilnehmer
    {
        [BsonId]
        public Guid Id;

        public string Vorname;
        public string Nachname;
        public string Ort;
        public int Plz;
        public DateTime Geburtstag;
    }
}
