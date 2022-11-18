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
        public MovieInfo Search([FromQuery] string nameMovie)
        {
            var result = _omdbService.SearchByName(nameMovie);
            return result;
        }
    }
}