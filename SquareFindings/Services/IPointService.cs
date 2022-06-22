using SquareFindings.Entities;
using System.Collections.Generic;

namespace SquareFindings.Services
{
    public interface IPointService
    {
        ICollection<PointEntity> Get();

        void Post(PointEntity point);

        void Import(ICollection<PointEntity> points);

        void Delete(PointEntity point);
    }
}
