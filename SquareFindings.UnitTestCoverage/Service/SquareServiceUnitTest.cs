using System.Diagnostics;

namespace SquareFindings.UnitTestCoverage.Service
{
    public class SquareServiceUnitTest
    {
        private readonly SquareService _squareService;

        public SquareServiceUnitTest()
        {
            _squareService = new SquareService();
        }

        [Fact]
        public void Get_Squares_Success()
        {
            // Arrange
            var points = new Point[4];
            points[0] = new Point(-3, +1);
            points[1] = new Point(0, -2);
            points[2] = new Point(0, +1);
            points[3] = new Point(-3, -2);

            var result = _squareService.FindSquares(points);
            Assert.IsType<List<List<Point>>>(result);
            Assert.True(result.Any());
        }

        [Fact]
        public void Get_Squares_result_Less_Than_5_Second_Success()
        {
            Random rnd = new Random();

            // Arrange
            var points = new List<Point>();
            for (int i = 0; i < 4000; i++)
            {
                var X = rnd.Next(-100, 100);
                var Y = rnd.Next(-100, 100);

                var point = new Point(X, Y);

                //Check If Already Exists
                if (points.Any(x => x.X == X && x.Y == Y))
                    continue;

                points.Add(point);
            }

            var pointArray = points.Distinct().ToArray();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = _squareService.FindSquares(pointArray);
            stopwatch.Stop();
            var calculateTime = stopwatch.ElapsedMilliseconds;

            Assert.True(result.Any());
            Assert.True(calculateTime < 5_000);
        }
    }
}
