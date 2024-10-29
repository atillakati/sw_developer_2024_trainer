using System.Linq;
using Wifi.MongoDbLibrary.DemoData;

namespace Wifi.MongoDbLibrary.MongoCustom
{
    public class RandomLocation : DemoDataHelperBase<GeoLocation>
    {
        public override GeoLocation MapResult(RandomPerson dataToMap)
        {
            
            if (dataToMap == null)
            {
                return null;
            }

            var person = dataToMap.results.FirstOrDefault();

            try
            {
                return new GeoLocation
                {
                    Latitude = double.Parse(person.location.coordinates.latitude),
                    Longitude = double.Parse(person.location.coordinates.longitude),
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
