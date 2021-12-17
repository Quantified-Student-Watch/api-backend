using System;
using System.Threading.Tasks;
using API.Data.Repository;
using API.Models;

namespace API.Services
{
    public interface IDeviceService
    {
        public Device CreateDevice(User user, string name, string productNumber);
        public Task<Device> GetDevice(Guid id);
    }
    
    
    public class DeviceService: IDeviceService
    {
        private IDeviceRepository _deviceRepository;
        
        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public Device CreateDevice(User user, string name, string productNumber)
        {
            return _deviceRepository.CreateDevice(user, name, productNumber);
        }

        public async Task<Device> GetDevice(Guid id)
        {
            return await _deviceRepository.GetDeviceAsync(id);
        }
    }
}