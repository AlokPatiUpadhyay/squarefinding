using SquareFindings.Entities;
using System.Text;

namespace SquareFindings.Services
{
    public class SquareService : ISquareService
    {
        public IEnumerable<IEnumerable<Point>> FindSquares(Point[] points)
        {
            HashSet<string> squarePoints = new HashSet<string>();
            List<List<Point>> result = new List<List<Point>>();

            HashSet<string> inputPointList = new HashSet<string>();
            foreach (var point in points)
                inputPointList.Add(point.ToString());

            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    //For each Point i, Point j, check if b&d exist in set.
                    Point[]? DiagVertex = GetRestPoints(points[i], points[j]);
                    if (DiagVertex == null)
                        continue;

                    if (inputPointList.Contains(DiagVertex[0].ToString()) && inputPointList.Contains(DiagVertex[1].ToString()))
                    {
                        var estimatedSquarePoints = new List<Point> {
                                    points[i],
                                    DiagVertex[0],
                                    points[j],
                                    DiagVertex[1]
                                };
                        if (IsPointsAlreadyExists(squarePoints, estimatedSquarePoints))
                            continue;

                        result.Add(estimatedSquarePoints);
                    }
                }
            }
            return result;

        }

        private bool IsPointsAlreadyExists(HashSet<string> source, List<Point> points)
        {
            var squarePoints = points.OrderBy(x => x.X).ThenBy(x => x.Y);
            var key = new StringBuilder();
            foreach (var item in squarePoints)
            {
                key.Append($"({item.X},{item.Y}), ");
            }
            var keyString = key.ToString();
            if (!source.Contains(keyString))
            {
                source.Add(keyString);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method to find other points b & d
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private Point[]? GetRestPoints(Point a, Point c)
        {
            Point[]? res = null;

            // find mid point of point a and c
            float midX = (float)(a.X + c.X) / 2;
            float midY = (float)(a.Y + c.Y) / 2;

            // calculate point b
            float Ax = a.X - midX;
            float Ay = a.Y - midY;
            float bX = midX - Ay;
            float bY = midY + Ax;

            // calculate point d
            float cX = (c.X - midX);
            float cY = (c.Y - midY);
            float dX = midX - cY;
            float dY = midY + cX;

            if (!IsInt(bX) || !IsInt(bY) || !IsInt(dX) || !IsInt(dY))
            {
                // if points X or Y axis are float then skip calculated points
                return res;
            }

            res = new Point[2];
            Point b = new Point((int)bX, (int)bY);
            Point d = new Point((int)dX, (int)dY);

            res[0] = b;
            res[1] = d;

            return res;
        }

        private bool IsInt(float input)
        {
            // Convert float value
            // of input to integer
            int integerValue = (int)input;

            float temp2 = input - integerValue;

            // If input is not equivalent
            // to any integer
            if (temp2 > 0)
            {
                return false;
            }
            return true;
        }
    }
}
