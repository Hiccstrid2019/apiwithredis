using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace WebApiWithRedis.Services
{
    public class OmbdService : IOmdbService
    {
        private readonly HttpClient _client;
        private readonly IDatabase _redis;
        private readonly OmdbConfig _config;

        public OmbdService(HttpClient client, IConnectionMultiplexer muxer, IOptions<OmdbConfig> config)
        {
            _client = client;
            _redis = muxer.GetDatabase();
            _config = config.Value;
        }
        public async Task<ICollection<MovieInfo>> SearchByName(string nameMovie)
        {
            string value;
            value = await _redis.StringGetAsync(nameMovie);
            if (string.IsNullOrEmpty(value))
            {
                var url = $"http://www.omdbapi.com/?apikey={_config.ApiKey}&s={nameMovie}";
                var result = await _client.GetAsync(url);
                value = await result.Content.ReadAsStringAsync();
                var setTask = await _redis.StringSetAsync(nameMovie, value);
                var expireTask = await _redis.KeyExpireAsync(nameMovie, TimeSpan.FromSeconds(3600));
            }

            JObject json = JObject.Parse(value);
            if (json["Error"] != null)
            {
                return new List<MovieInfo>();
            }
            return JsonConvert.DeserializeObject<IList<MovieInfo>>(json["Search"].ToString());
        }
    }
}