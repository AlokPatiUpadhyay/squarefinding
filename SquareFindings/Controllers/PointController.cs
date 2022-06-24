using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SquareFindings.Entities;
using SquareFindings.Models;
using SquareFindings.Models.example;
using SquareFindings.Services;
using Swashbuckle.AspNetCore.Filters;

namespace SquareFindings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointController : ControllerBase
    {
        private readonly IPointService _pointService;
        private readonly ILogger<PointController> _logger;
        private readonly IMapper _mapper;

        public PointController(ILogger<PointController> logger,
            IPointService pointService,
            IMapper mapper
            )
        {
            _logger = logger;
            _pointService = pointService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PointModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            _logger.LogInformation($"fetching information from database");
            var points = _pointService.Get();

            var models = _mapper.Map<ICollection<PointModel>>(points);

            return Ok(models);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(PointModel), typeof(PointModelExample))]
        public IActionResult Post(PointModel point)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var entity = _mapper.Map<PointEntity>(point);
            _pointService.Post(entity);

            return Created($"/point/{entity.Id}", entity);
        }

        [HttpPost("import")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(ICollection<PointModel> points)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var entities = _mapper.Map<ICollection<PointEntity>>(points);
            _pointService.Import(entities);

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(PointModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(PointModel point)
        {
            var entity = _mapper.Map<PointEntity>(point);
            var result = _pointService.Delete(entity);
            if (result)
                return Ok(point);
            else
                return NotFound();
        }
    }
}
