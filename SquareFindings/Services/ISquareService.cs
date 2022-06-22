using SquareFindings.Entities;
using System.Collections.Generic;

namespace SquareFindings.Services
{
    public interface ISquareService
    {
        IEnumerable<IEnumerable<Point>> FindSquares(Point[] points);
    }
}
