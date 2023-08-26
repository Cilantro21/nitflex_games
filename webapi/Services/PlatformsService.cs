using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class PlatformsService : IPlatformsService
    {
        private readonly AppDbContext _context;

        public PlatformsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Platform>> GetAllPlatforms()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task<Platform> GetPlatformById(int id)
        {
            var pf = await _context.Platforms.FindAsync(id);
            return pf;
        }

        public async Task AddPlatform(Platform pf)
        {
            await _context.Platforms.AddAsync(pf);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlatform(Platform pf, int id)
        {
            var currentPf = await _context.Platforms.FindAsync(id);
            if (currentPf != null) { 
                currentPf.Name = pf.Name ;
                currentPf.Description = pf.Description ;
                currentPf.Manufacturer = pf.Manufacturer ;
                currentPf.ReleaseDate = pf.ReleaseDate ;
                currentPf.EndOfSupport = pf.EndOfSupport;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlatform(int id)
        {
            var currentPf = await _context.Platforms.FindAsync(id);
            if(currentPf != null) {
                _context.Platforms.Remove(currentPf);
            }
        }
    }
}
