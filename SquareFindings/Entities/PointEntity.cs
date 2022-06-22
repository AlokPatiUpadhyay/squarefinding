namespace SquareFindings.Entities
{
    public class PointEntity
    {
        public PointEntity(float x, float y)
        {
            X = x;
            Y = y;
        }
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

    }
}
