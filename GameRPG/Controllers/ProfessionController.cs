using GameRPG.Application.Commands.ProfessionCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GameRPG.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessionController(
          IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetProfession()
        {

            var commandResult = await _mediator.Send(new GetProfessionCommand()).ConfigureAwait(false);

            if (!commandResult.Any())
            {
                return NotFound();
            }

            return Ok(commandResult);
        }
    }
}
