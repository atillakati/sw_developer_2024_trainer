using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Klassen_Konstruktoren
{
    public class Teilnehmer
    {
        [BsonId]
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id;

        public string Vorname;
        public string Nachname;
        public string Ort;
        public int Plz;
        public DateTime Geburtstag;
    }
}
