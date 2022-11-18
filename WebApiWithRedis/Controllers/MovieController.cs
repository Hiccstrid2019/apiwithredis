using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiWithRedis.Services;

namespace WebApiWithRedis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IOmdbService _omdbService;

        public MovieController(IOmdbService service)
        {
            _omdbService = service;
        }
        
        [HttpGet("search")]
        public async Task<ICollection<MovieInfo>> Search([FromQuery] string name)
        {
            var result = await _omdbService.SearchByName(name);
            return result;
        }
    }
}