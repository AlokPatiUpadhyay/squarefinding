using Swashbuckle.AspNetCore.Filters;

namespace SquareFindings.Models.example
{
    public class PointModelListExample : IExamplesProvider<ICollection<PointModel>>
    {
        public ICollection<PointModel> GetExamples()
        {
            return new List<PointModel>{
                        new PointModel
                        {
                            X = 10,
                            Y = 20,
                        }
            };
        }
    }
}
