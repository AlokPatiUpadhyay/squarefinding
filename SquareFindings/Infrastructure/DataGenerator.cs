using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SquareFindings.Entities;
using System;
using System.Linq;

namespace SquareFindings.Infrastructure
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                if (context.Points.Any())
                {
                    return;  
                }

                context.Points.AddRange(
                   new PointEntity(-1, 1) { Id = 1 },
                   new PointEntity(-1, -1) { Id = 2 },
                   new PointEntity(1, -1) { Id = 3 },
                   new PointEntity(1, 1) { Id = 4 },
                   new PointEntity(-3, 1) { Id = 5 },
                   new PointEntity(-7, -1) { Id = 6 },
                   new PointEntity(-4, -1) { Id = 7 },
                   new PointEntity(-3, -1) { Id = 8 }
               );
                context.SaveChanges();
            }
        }
    }
}
