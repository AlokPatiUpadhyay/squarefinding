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


    }
}
