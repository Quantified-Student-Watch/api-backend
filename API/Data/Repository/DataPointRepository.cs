using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    interface IDataPointRepository
    {
        public Task<List<DataPoint>> GetAllDataPointsFromUserAsync(User user);
        public Task<List<DataPoint>> GetAllDataPointsFromUserAndDeviceAsync(User user, Device device);
    }
    
    
    public class DataPointRepository: IDataPointRepository
    {
        private DbSet<DataPoint> _dataPoint;
        public DataPointRepository(IQsContext context)
        {
            _dataPoint = context.DataPoints;
        }

        public Task<List<DataPoint>> GetAllDataPointsFromUserAsync(User user)
        {
            return  _dataPoint.Where(x => x.User.Id == user.Id).ToListAsync();
        }

        public Task<List<DataPoint>> GetAllDataPointsFromUserAndDeviceAsync(User user, Device device)
        {
            return _dataPoint
                .Where(x => x.Device.Id == device.Id)
                .Where(x => x.User.Id == user.Id).ToListAsync();
        }
    }
}