using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SquareFindings.Entities;
using SquareFindings.Models;
using SquareFindings.Services;
using System.Collections.Generic;

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
        public IActionResult Get()
        {
            _logger.LogInformation($"fetching information from database");
            var points = _pointService.Get();

            var entities = _mapper.Map<ICollection<PointModel>>(points);

            return Ok(entities);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(PointModel point)
        {
            var entity = _mapper.Map<PointEntity>(point);
            _pointService.Post(entity);

            return Ok(point);
        }


        [HttpDelete]
        public IActionResult Delete(PointModel point)
        {
            var entity = _mapper.Map<PointEntity>(point);
            _pointService.Delete(entity);

            return Ok(point);
        }
    }
}
