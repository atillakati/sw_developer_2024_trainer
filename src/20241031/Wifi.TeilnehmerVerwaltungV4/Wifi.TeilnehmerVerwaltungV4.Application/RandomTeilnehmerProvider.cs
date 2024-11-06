using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.TeilnehmerVerwaltungV4.Core;
using Wifi.TeilnehmerVerwaltungV4.DemoDataProvider;
using Wifi.TeilnehmerVerwaltungV4.DemoDataProvider.Entities;

namespace Wifi.TeilnehmerVerwaltungV4.Application
{
    internal class RandomTeilnehmerProvider : DataProvider<Teilnehmer>
    {
        public override IEnumerable<Teilnehmer> Map(RandomData data)
        {
            int plz = 0;
            var teilnehmerListe = new List<Teilnehmer>();

            if (data == null)
            {
                return Array.Empty<Teilnehmer>();
            }

            foreach (var person in data.results)
            {
                if (int.TryParse(person.location.postcode.ToString(), out plz))
                {
                    var newTeilnehmer = new Teilnehmer
                    {
                        Vorname = person.name.first,
                        Nachname = person.name.last,
                        Geburtsdatum = person.dob.date,
                        Ort = person.location.city,
                        Plz = plz
                    };

                    teilnehmerListe.Add(newTeilnehmer);
                }
            }

            return teilnehmerListe;
        }
    }
}
