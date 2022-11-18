using System.Net.Http;
using StackExchange.Redis;

namespace WebApiWithRedis.Services
{
    public class OmbdService : IOmdbService
    {
        private readonly HttpClient _client;
        private readonly IDatabase _redis;

        public OmbdService(HttpClient client, IConnectionMultiplexer muxer)
        {
            _client = client;
            _redis = muxer.GetDatabase();
        }
        public MovieInfo SearchByName(string nameMovie)
        {
            
        }
    }
}