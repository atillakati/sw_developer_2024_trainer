using System;

namespace Klassen_Konstruktoren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MongoDbRepository db = new MongoDbRepository();

            var teilnehmerList = db.GetAll();
            
            db.

            Console.WriteLine("Aktuelle Datenbank: " + db.DbName);

            //db.DatabaseName = "myGeoDb";
            //var geoData = db.GetAll();

            Console.WriteLine("Aktuelle Datenbank: " + db.DbName);
        }
    }
}
