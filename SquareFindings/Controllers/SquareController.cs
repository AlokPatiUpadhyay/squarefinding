using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SquareFindings.Entities;
using SquareFindings.Services;

namespace SquareFindings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SquareController : ControllerBase
    {
        private readonly IPointService _pointService;
        private readonly ISquareService _squareService;
        private readonly ILogger<SquareController> _logger;
        private readonly IMapper _mapper;

        public SquareController(ILogger<SquareController> logger,
            IPointService cacheService,
            ISquareService squareService,
            IMapper mapper)
        {
            _logger = logger;
            _pointService = cacheService;
            _squareService = squareService;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            _logger.LogInformation($"finding squares from given list of points");
            var points = _mapper.Map<ICollection<Point>>(_pointService.Get());

            var squarePoints = _squareService.FindSquares(points.ToArray());

            return Ok(squarePoints);
        }


    }
}
