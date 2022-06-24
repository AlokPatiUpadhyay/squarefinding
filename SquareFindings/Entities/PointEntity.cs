namespace SquareFindings.Entities
{
    public class PointEntity
    {
        public PointEntity(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

    }
}
