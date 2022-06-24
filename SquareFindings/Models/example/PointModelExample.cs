using Swashbuckle.AspNetCore.Filters;

namespace SquareFindings.Models.example
{
    public class PointModelExample : IExamplesProvider<PointModel>
    {
        public PointModel GetExamples()
        {
            return new PointModel
            {
                X = 10,
                Y = 20,
            };
        }
    }
}
