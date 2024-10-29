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
    internal class Program
    {
        static void Main(string[] args)
        {
            var demoData = new DataProvider();

            var data = demoData.GetRandomData(500);

            Teilnehmer[] teilnehmerListe = MapDemoDataToTeilnehmer(data);
        }

        private static Teilnehmer[] MapDemoDataToTeilnehmer(RandomData data)
        {
            var teilnehmerListe = new List<Teilnehmer>();

            if (data == null)
            {
                return null;
            }

            foreach (var person in data.results)
            {
                int plz = 0;

                try
                {
                    plz = int.Parse(person.location.postcode.ToString());
                }
                catch
                {
                    continue;
                }

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

            return teilnehmerListe.ToArray();
        }
    }
}
