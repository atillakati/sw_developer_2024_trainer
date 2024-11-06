using System.Collections.Generic;
using Wifi.TeilnehmerVerwaltungV4.DemoDataProvider;
using Wifi.TeilnehmerVerwaltungV4.DemoDataProvider.Entities;

namespace Wifi.TeilnehmerVerwaltungV4.Application
{
    internal class GeoPositionProvider : DataProvider<GeoPosition>
    {
        public override IEnumerable<GeoPosition> Map(RandomData data)
        {
            List<GeoPosition> positions = new List<GeoPosition>();

            foreach (var item in data.results)
            {
                var geoPosition = new GeoPosition
                {
                    Country = item.location.country,
                    Latitude = item.location.coordinates.latitude,
                    Longitude = item.location.coordinates.longitude
                };

                positions.Add(geoPosition);
            }

            return positions;
        }
    }
}
