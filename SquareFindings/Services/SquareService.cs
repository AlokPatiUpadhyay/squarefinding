using SquareFindings.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SquareFindings.Services
{
    public class SquareService : ISquareService
    {
        public IEnumerable<IEnumerable<Point>> FindSquares(Point[] points)
        {
            List<List<Point>> result = new List<List<Point>>();

            HashSet<string> set = new HashSet<string>();
            foreach (var point in points)
                set.Add(point.ToString());

            for (int i = 0; i < points.Length-1; i++)
            {
                for (int j = i+1; j < points.Length; j++)
                {
                    //For each Point i, Point j, check if b&d exist in set.
                    Point[] DiagVertex = GetRestPints(points[i], points[j]);

                    var squarePoints = new List<Point> {
                                    points[i],
                                    DiagVertex[0],
                                    points[j],
                                    DiagVertex[1]
                                };
                    
                    if (IsPointsAlreadyExists(result, squarePoints))
                        continue;

                    if (set.Contains(DiagVertex[0].ToString()) && set.Contains(DiagVertex[1].ToString()))
                    {
                        result.Add(new List<Point> {
                                    points[i],
                                    DiagVertex[0],
                                    points[j],
                                    DiagVertex[1]
                                });
                    }
                }
            }
            return result;

        }

        private bool IsPointsAlreadyExists(List<List<Point>> source, List<Point> points)
        {
            return source.Any(x =>  x.Any(y => y.X == points[0].X && y.Y == points[0].Y)
                                    && x.Any(y => y.X == points[1].X && y.Y == points[1].Y)
                                    && x.Any(y => y.X == points[2].X && y.Y == points[2].Y)
                                    && x.Any(y => y.X == points[3].X && y.Y == points[3].Y)
                                        );
        }

        private Point[] GetRestPints(Point a, Point c)
        {
            Point[] res = new Point[2];

            float midX = (a.X + c.X) / 2;
            float midY = (a.Y + c.Y) / 2;
            
            float Ax = a.X - midX;
            float Ay = a.Y - midY;
            float bX = midX - Ay;
            float bY = midY + Ax;
            Point b = new Point(bX, bY);

            float cX = (c.X - midX);
            float cY = (c.Y - midY);
            float dX = midX - cY;
            float dY = midY + cX;
            Point d = new Point(dX, dY);

            res[0] = b;
            res[1] = d;
            return res;
        }
    }
}
