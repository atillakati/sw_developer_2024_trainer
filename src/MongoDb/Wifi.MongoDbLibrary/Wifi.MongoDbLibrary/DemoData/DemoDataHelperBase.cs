using System.Collections.Generic;
using RestSharp;
using Wifi.MongoDbLibrary.DemoData.Entities;


namespace Wifi.MongoDbLibrary.DemoData
{
    public abstract class DemoDataHelperBase<T>
    {
        private readonly string _baseUri;
        private readonly string _requestUri;
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public DemoDataHelperBase() : this("https://randomuser.me/", "api/?nat=de,gb,us,ch")
        {
        }

        public DemoDataHelperBase(string baseUri, string requestUri)
        {
            _baseUri = baseUri;
            _requestUri = requestUri;

            var options = new RestClientOptions(_baseUri);

            _client = new RestClient(options);
            _request = new RestRequest(_requestUri);
        }

        public string BaseUri => _baseUri;

        public string RequestUri => _requestUri;

        /// <summary>
        /// Returns a list of randomly received person data. Default source of data: https://randomuser.me/api/
        /// </summary>
        /// <param name="count">Count of persons to return</param>
        /// <returns></returns>
        public IEnumerable<T> GetRandomPersonList(int count)
        {
            var persons = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var person = GetRandomPerson();
                if (person == null)
                {
                    i--;
                    continue;
                }

                persons.Add(person);
            }

            return persons;
        }

        /// <summary>
        /// Returns a randomly received person data. Default source of data: https://randomuser.me/api/
        /// </summary>
        /// <returns></returns>
        public T GetRandomPerson()
        {
            var person = RetrieveRandomPerson();
            var mappedPersonType = MapResult(person);

            return mappedPersonType;
        }

        /// <summary>
        /// Maps received demo person data into custom data type T
        /// </summary>
        /// <param name="dataToMap"></param>
        /// <returns></returns>
        public abstract T MapResult(RandomPerson dataToMap);

        private RandomPerson RetrieveRandomPerson()
        {
            RandomPerson data = null;

            try
            {
                data = _client.Get<RandomPerson>(_request);
            }
            catch
            {
                data = null;
            }

            return data;
        }
    }
}
