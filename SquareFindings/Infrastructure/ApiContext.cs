using Microsoft.EntityFrameworkCore;
using SquareFindings.Entities;

namespace SquareFindings.Infrastructure
{
    public class ApiContext : DbContext
    {
        public DbSet<PointEntity> Points { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }
    }
}
