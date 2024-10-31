using RestSharp;
using Wifi.TeilnehmerVerwaltungV4.DemoDataProvider.Entities;

namespace Wifi.TeilnehmerVerwaltungV4.DemoDataProvider
{
    public class DataProvider
    {
        private readonly RestClientOptions _options;
        private readonly RestClient _client;
        private RestRequest _request;

        public DataProvider()
        {
            _options = new RestClientOptions("https://randomuser.me");
            _client = new RestClient(_options);
        }

        public RandomData GetRandomData()
        {
            _request = new RestRequest("/api");

            var randomData = _client.Get<RandomData>(_request);

            return randomData;
        }

        public RandomData GetRandomData(int count)
        {
            if (count < 1 || count > 5000)
            {
                return null;
            }

            _request = new RestRequest($"/api/?results={count}");

            var randomData = _client.Get<RandomData>(_request);

            return randomData;

        }
    }
}
