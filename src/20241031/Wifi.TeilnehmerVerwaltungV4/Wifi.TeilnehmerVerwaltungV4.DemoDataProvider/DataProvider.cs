using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using Wifi.TeilnehmerVerwaltungV4.Core;
using Wifi.TeilnehmerVerwaltungV4.DemoDataProvider.Entities;

namespace Wifi.TeilnehmerVerwaltungV4.DemoDataProvider
{
    public abstract class DataProvider<T>
    {
        private readonly RestClientOptions _options;
        private readonly RestClient _client;
        private RestRequest _request;

        public DataProvider()
        {
            _options = new RestClientOptions("https://randomuser.me");
            _client = new RestClient(_options);
        }

        public T GetRandomData()
        {
            IEnumerable<T> teilnehmerList;

            _request = new RestRequest("/api");

            do
            {
                //retrieve data from server
                var randomData = _client.Get<RandomData>(_request);

                //map into domain object            
                teilnehmerList = Map(randomData);
            }
            while (!teilnehmerList.Any());

            return teilnehmerList.FirstOrDefault();
        }

        public IEnumerable<T> GetRandomData(int count)
        {
            var teilnehmerList = new List<T>();

            if (count < 1 || count > 5000)
            {
                return null;
            }

            _request = new RestRequest($"/api/?results={count}");

            do
            {
                //retrieve data from server
                var randomData = _client.Get<RandomData>(_request);

                //map into domain object            
                var mappedTeilnehmer = Map(randomData);

                //add to extisting Teilnehmer list
                teilnehmerList.AddRange(mappedTeilnehmer);
            }
            while (teilnehmerList.Count < count);

            return teilnehmerList.GetRange(0, count);
        }

        public abstract IEnumerable<T> Map(RandomData data);        
    }
}
