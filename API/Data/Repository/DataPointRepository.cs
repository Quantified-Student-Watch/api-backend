using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Data.Repository
{
    interface IDataPointRepository
    {
        public Task<List<DataPoint>> GetAllDataPointsFromUserAsync(User user);
        public Task<List<DataPoint>> GetAllDataPointsFromUserAndDeviceAsync(User user, Device device);

        public DataPoint CreateDataPoint(User user, Device device, DataPointType dataPointType,string value);
    }
    
    
    public class DataPointRepository: IDataPointRepository
    {
        private QsContext _context;
        public DataPointRepository(QsContext context)
        {
            _context = context;
        }

        public Task<List<DataPoint>> GetAllDataPointsFromUserAsync(User user)
        {
            return  _context.DataPoints.Where(x => x.User.Id == user.Id).ToListAsync();
        }

        public Task<List<DataPoint>> GetAllDataPointsFromUserAndDeviceAsync(User user, Device device)
        {
            return _context.DataPoints
                .Where(x => x.Device.Id == device.Id)
                .Where(x => x.User.Id == user.Id).ToListAsync();
        }

        public DataPoint CreateDataPoint(User user, Device device, DataPointType dataPointType, string value)
        {
            DataPoint dataPoint = new DataPoint()
            {
                User = user,
                Device = device,
                Type = dataPointType,
                Value = value
            };

            EntityEntry<DataPoint> result = _context.DataPoints.Add(dataPoint);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}