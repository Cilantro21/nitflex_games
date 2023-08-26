using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class VendorsService : IVendorService
    {
        private readonly AppDbContext _context;

        public VendorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vendor>> GetAllVendors()
        {
            return await _context.Vendors.ToListAsync();
        }

        public async Task<Vendor> GetVendorById(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            return vendor;
        }

        public async Task AddVendor(Vendor vendor)
        {
            await _context.Vendors.AddAsync(vendor);
            _context.SaveChanges();
        }
    }
}
