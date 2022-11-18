using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiWithRedis.Services
{
    public interface IOmdbService
    {
        Task<ICollection<MovieInfo>> SearchByName(string nameMovie);
    }
}