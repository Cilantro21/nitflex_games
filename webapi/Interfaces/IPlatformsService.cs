using webapi.Models;

namespace webapi.Interfaces
{
    public interface IPlatformsService
    {
        Task<List<Platform>> GetAllPlatforms();
        Task<Platform> GetPlatformById(int id);
        Task AddPlatform(Platform pf);
        Task UpdatePlatform(Platform pf, int id);
        Task DeletePlatform(int id);
    }
}
