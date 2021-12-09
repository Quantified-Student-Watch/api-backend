using System;
using System.Collections.Generic;

namespace API.Models
{
    public class SmartBand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public string ProductNumber { get; set; }

        public List<DataPointType> AcceptedDataPointTypes { get; set; }
    }
}