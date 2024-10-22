using Wifi.MongoDbLibrary.DemoData.Entities;

namespace Wifi.MongoDbLibrary.DemoData
{
    public class RandomTeilnehmer : DemoDataHelperBase<Teilnehmer>
    {
        public override Teilnehmer MapResult(RandomPerson dataToMap)
        {
            Teilnehmer data = null;

            if (dataToMap == null || dataToMap.results[0].name.first.Contains("?"))
            {
                return null;
            }

            data = new Teilnehmer
            {
                Vorname = dataToMap.results[0].name.first,
                Nachname = dataToMap.results[0].name.last,
                Plz = dataToMap.results[0].location.postcode,
                Ort = dataToMap.results[0].location.city,
                Geburtstag = dataToMap.results[0].dob.date
            };

            return data;
        }
    }
}
