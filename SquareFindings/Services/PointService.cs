using SquareFindings.Entities;
using SquareFindings.Infrastructure;

namespace SquareFindings.Services
{
    public class PointService : IPointService
    {
        private readonly ApiContext apiContext;

        public PointService(ApiContext _apiContext)
        {
            apiContext = _apiContext;
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
            //code to remove duplicate points

            //import points
            apiContext.Points.AddRange(points);
            apiContext.SaveChanges();
        }

        public bool Delete(PointEntity point)
        {
            var item = apiContext.Points
                            .FirstOrDefault(x =>
                                x.X == point.X
                                && x.Y == point.Y);
            if (item == null)
                return false;
            else
            {
                apiContext.Points.Remove(item);
                apiContext.SaveChanges();
                return true;
            }
        }
    }
}
