using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Device
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public string ProductNumber { get; set; }

        // public List<DataPointType> SupportedTypes { get; set; }
    }
}