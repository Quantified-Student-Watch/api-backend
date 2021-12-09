using System;

namespace API.Models
{
    public class DataPoint
    {
        public Guid Id { get; set; }

        public SmartBand SmartBand { get; set; }

        public User User { get; set; }

        public DataPointType Type { get; set; }

        public string Value { get; set; }
    }
}