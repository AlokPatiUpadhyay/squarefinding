using SquareFindings.Entities;
using SquareFindings.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace SquareFindings.Services
{
    public class PointService : IPointService
    {
        private readonly ApiContext apiContext;

        public PointService(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        public ICollection<PointEntity> Get()
        {
            return apiContext.Points.ToList();
        }

        public void Post(PointEntity point)
        {
            if (apiContext.Points.Any(x => 
                                x.X == point.X 
                                && x.Y == point.Y))
                return;

            apiContext.Add(point);
            apiContext.SaveChanges();
        }

        public void Import(ICollection<PointEntity> points)
        {
            //remove duplicate points
            //code to remove duplicate points

            apiContext.Points.AddRange(points);
            apiContext.SaveChanges();
        }

        public void Delete(PointEntity point)
        {
            var item = apiContext.Points
                            .FirstOrDefault(x => 
                                x.X == point.X 
                                && x.Y == point.Y);
            apiContext.Points.Remove(item);
        }
    }
}
