using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Data.Repository
{
    public interface IDataPointRepository
    {
        public Task<List<DataPoint>> GetAllDataPointsFromDeviceAsync(Device device);

        public DataPoint CreateDataPoint(Device device, DataPointType dataPointType,string value);
    }
    
    
    public class DataPointRepository: IDataPointRepository
    {
        private readonly QsContext _context;
        public DataPointRepository(QsContext context)
        {
            _context = context;
        }

        public Task<List<DataPoint>> GetAllDataPointsFromDeviceAsync(Device device)
        {
            return _context.DataPoints
                .Where(x => x.Device.Id == device.Id).ToListAsync();
        }

        public DataPoint CreateDataPoint(Device device, DataPointType dataPointType, string value)
        {
            DataPoint dataPoint = new DataPoint()
            {
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