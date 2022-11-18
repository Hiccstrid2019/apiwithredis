namespace WebApiWithRedis.Services
{
    public interface IOmdbService
    {
        MovieInfo SearchByName(string nameMovie);
    }
}