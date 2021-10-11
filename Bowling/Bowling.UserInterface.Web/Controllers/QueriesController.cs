using Bowling.Application;
using Bowling.Application.AggregateModels;
using Bowling.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowling.UserInterface.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<QueriesController> _logger;

        public QueriesController(IMediator mediator, ILogger<QueriesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetCurrentGame")]
        public async Task<IActionResult> GetCurrentGame()
        {
            return Ok(await _mediator.Send(new GetCurrentGame.Query()));
        }

        [HttpGet("IsThereAnActiveGame")]
        public async Task<IActionResult> IsThereAnActiveGame()
        {
            return Ok(await _mediator.Send(new IsThereAnActiveGame.Query()));
        }

        [HttpGet("WhosTurnIsIt")]
        public async Task<IActionResult> WhosTurnIsIt()
        {
            return Ok(await _mediator.Send(new WhosTurnIsIt.Query()));
        }
    }
}
