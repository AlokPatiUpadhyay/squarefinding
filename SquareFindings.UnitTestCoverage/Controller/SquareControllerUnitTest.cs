namespace SquareFindings.UnitTest
{
    public class SquareControllerUnitTest
    {
        private readonly Mock<IPointService> _pointService;
        private readonly Mock<ISquareService> _squareService;
        private readonly Mock<ILogger<SquareController>> _logger;
        private readonly SquareController _controller;
        private readonly Mock<IMapper> _mapper;

        public SquareControllerUnitTest()
        {
            _pointService = new Mock<IPointService>();
            _squareService = new Mock<ISquareService>();
            _logger = new Mock<ILogger<SquareController>>();
            _mapper = new Mock<IMapper>();

            _controller = new SquareController(
                _logger.Object, 
                _pointService.Object, 
                _squareService.Object,
                _mapper.Object);
        }

        [Fact]
        public void Import_Sucess()
        {
            // Arrange
            var points = new List<PointModel>
            {
                new PointModel{ X=1, Y=2 },
                new PointModel{ X=1, Y=3 }
            }; 

            _pointService.Setup(x => x.Import(It.IsAny<ICollection<PointEntity>>()));

            var result = _controller.Post(points);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
