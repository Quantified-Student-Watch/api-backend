using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.Repository;
using API.Models;

namespace API.Services
{
    public interface IDataPointService
    {
        public DataPoint Create(Device device, DataPointType type, string value);
        public Task<List<DataPoint>> GetDataPointsFromDevice(Device device);
    }
    
    
    public class DataPointService: IDataPointService
    {
        private readonly IDataPointRepository _dataPointRepository;
        public DataPointService(IDataPointRepository dataPointRepository)
        {
            _dataPointRepository = dataPointRepository;
        }
        
        public DataPoint Create(Device device, DataPointType type, string value)
        {
            return _dataPointRepository.CreateDataPoint(device, type, value);
        }

        public Task<List<DataPoint>> GetDataPointsFromDevice(Device device)
        {
            return _dataPointRepository.GetAllDataPointsFromDeviceAsync(device);
        }
    }
}