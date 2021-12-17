using System;

namespace API.Models
{
    public class DataPoint
    {
        public Guid Id { get; set; }

        public Device Device { get; set; }

        public DataPointType Type { get; set; }

        public string Value { get; set; }
    }
}