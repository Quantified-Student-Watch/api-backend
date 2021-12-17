using System;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Data.Repository
{
    public interface IDeviceRepository
    {
        public Task<Device> GetDeviceAsync(Guid id);
        public Device CreateDevice(User user, string name, string productNumber);
    }
    
    
    public class DeviceRepository : IDeviceRepository
    {
        private DbSet<Device> _devices;
        private QsContext _context; 
        public DeviceRepository(QsContext context)
        {
            _context = context;
        }

        public async Task<Device> GetDeviceAsync(Guid id)
        {
            return await _context.Devices.Where(x => x.Id == id).FirstAsync();
        }

        public Device CreateDevice(User user, string name, string productNumber)
        {
            Device device = new Device()
            {
                Name = name,
                ProductNumber = productNumber,
                User = user
            };

            EntityEntry<Device> result = _context.Add(device);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}