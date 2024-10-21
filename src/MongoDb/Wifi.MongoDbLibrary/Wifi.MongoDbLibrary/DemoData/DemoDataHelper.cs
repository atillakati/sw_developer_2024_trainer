using System;
using System.Collections.Generic;
using RestSharp;


namespace Wifi.MongoDbLibrary.DemoData
{
    public class DemoDataHelper
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public DemoDataHelper()
        {
            var options = new RestClientOptions("https://randomuser.me/");
            
            _client = new RestClient(options);
            _request = new RestRequest("api/");
        }
        /// <summary>
        /// //Source of demo data: https://randomuser.me/api/
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<Teilnehmer> GetRandomPersonList(int count)
        {
            var persons = new List<Teilnehmer>();

            for (int i = 0; i < count; i++)
            {
                var person = GetRandomPerson();
                if (person != null)
                {
                    persons.Add(person);
                }
            }

            return persons;
        }

        /// <summary>
        /// //Source of demo data: https://randomuser.me/api/
        /// </summary>
        /// <returns></returns>
        public Teilnehmer GetRandomPerson()
        {
            Teilnehmer data = null;

            try
            {
                var response = _client.Get<Rootobject>(_request);

                if (response == null || response.results[0].name.first.Contains("?"))
                {
                    return null;
                }

                data = new Teilnehmer
                {
                    Vorname = response.results[0].name.first,
                    Nachname = response.results[0].name.last,
                    Plz = response.results[0].location.postcode,
                    Ort = response.results[0].location.city,
                    Geburtstag = response.results[0].dob.date
                };

                Console.WriteLine($"Create {data.Vorname} {data.Nachname}...");
            }
            catch
            {
                data = null;
            }

            return data;
        }
    }
}
