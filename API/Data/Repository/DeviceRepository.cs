using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    interface IDeviceRepository
    {
        public Device GetDevice(string id);
    }
    
    
    public class DeviceRepository : IDeviceRepository
    {
        private DbSet<Device> _devices;
        public DeviceRepository(IQsContext context)
        {
            _devices = context.Devices;
        }

        public Device GetDevice(string id)
        {
            return _devices.Find(id);
        }
    }
}