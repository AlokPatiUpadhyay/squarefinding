using SquareFindings.Entities;

namespace SquareFindings.Services
{
    public interface IPointService
    {
        ICollection<PointEntity> Get();

        void Post(PointEntity point);

        void Import(ICollection<PointEntity> points);

        bool Delete(PointEntity point);
    }
}
