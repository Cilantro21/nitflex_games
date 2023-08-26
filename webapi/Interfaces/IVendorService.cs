using webapi.Models;

namespace webapi.Interfaces
{
    public interface IVendorService
    {
        Task<Vendor> GetAllVendors();
        Task<Vendor> GetVendorById(int id);
        Task AddVendor(Vendor vendor);
        Task UpdateVendor(Vendor vendor, int id);
        Task DeleteVendor(int id);
    }
}
