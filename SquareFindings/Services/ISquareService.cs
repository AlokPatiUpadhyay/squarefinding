using SquareFindings.Entities;

namespace SquareFindings.Services
{
    public interface ISquareService
    {
        IEnumerable<IEnumerable<Point>> FindSquares(Point[] points);
    }
}
