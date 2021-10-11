using Bowling.Application;
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
    public class CommandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CommandsController> _logger;

        public CommandsController(IMediator mediator, ILogger<CommandsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CreateGame")]
        public async Task<IActionResult> CreateGame(CreateGame.Command command)
        {
            var gameId = await _mediator.Send(command);
            return Ok(gameId);
        }

        [HttpPost("ThrowBall")]
        public async Task<IActionResult> ThrowBall(ThrowBall.Command command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
