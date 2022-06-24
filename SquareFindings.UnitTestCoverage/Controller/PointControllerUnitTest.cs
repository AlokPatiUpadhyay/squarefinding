namespace SquareFindings.UnitTestCoverage
{
    public class PointControllerUnitTest
    {
        private readonly Mock<IPointService> _pointService;
        private readonly Mock<ILogger<PointController>> _logger;
        private readonly PointController _controller;
        private readonly Mock<IMapper> _mapper;

        public PointControllerUnitTest()
        {
            _pointService = new Mock<IPointService>();
            _logger = new Mock<ILogger<PointController>>();
            _mapper = new Mock<IMapper>();

            _controller = new PointController(
                        _logger.Object,
                        _pointService.Object,
                        _mapper.Object);
        }

        [Fact]
        public void Post_Success()
        {
            // Arrange
            var point = new PointModel { X = 1, Y = 2 };

            _pointService.Setup(x => x.Post(It.IsAny<PointEntity>()));

            var result = _controller.Post(point);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Success()
        {
            // Arrange
            var points = new List<PointEntity> { new PointEntity(1, 2) };

            _pointService.Setup(x => x.Get()).Returns(points);

            var result = _controller.Get();
            Assert.IsType<OkObjectResult>(result);
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

        [Fact]
        public void POST_WITH_Thread()
        {
            for (int i = 0; i < 100; i++)
            {
                new Thread(Post_Success).Start();
                new Thread(Get_Success).Start();
            }
        }
    }
}
