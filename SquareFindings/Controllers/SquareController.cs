using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SquareFindings.Entities;
using SquareFindings.Models;
using SquareFindings.Services;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("find-squares")]
        public IActionResult Get()
        {
            _logger.LogInformation($"finding squares from given list of points");
            var points = _mapper.Map<ICollection<Point>>(_pointService.Get());

            var squarePoints = _squareService.FindSquares(points.ToArray());

            return Ok(squarePoints);
        }

        [HttpPost("import")]
        public IActionResult Post(ICollection<PointModel> points)
        {
            var entities = _mapper.Map<ICollection<PointEntity>>(points);
            _pointService.Import(entities);

            return Ok(points);
        }
    }
}
