using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Data.Repository
{
    interface IDeviceRepository
    {
        public Device GetDevice(string id);
        public Device CreateDevice(string name, string productNumber);
    }
    
    
    public class DeviceRepository : IDeviceRepository
    {
        private DbSet<Device> _devices;
        private QsContext _context; 
        public DeviceRepository(QsContext context)
        {
            _context = context;
        }

        public Device GetDevice(string id)
        {
            return _devices.Find(id);
        }

        public Device CreateDevice(string name, string productNumber)
        {
            Device device = new Device()
            {
                Name = name,
                ProductNumber = productNumber
            };

            EntityEntry<Device> result = _context.Add(device);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}