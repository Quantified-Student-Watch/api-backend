using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public interface IQsContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<DataPoint> DataPoints { get; set; }
        public DbSet<User> Users { get; set; }
    }
    public class QsContext :  DbContext, IQsContext
    {
        public QsContext(DbContextOptions<QsContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<DataPoint> DataPoints { get; set; }
        public DbSet<User> Users { get; set; }
    }
}