using GameRPG.Application.Commands.BattleCommands;
using GameRPG.Application.Commands.CharacterCommand;
using GameRPG.Application.Commands.ProfessionCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GameRPG.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BattleController(
          IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }



        [HttpPost("")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Battle(BattleCommand request)
        {

            var commandResult = await _mediator.Send(request).ConfigureAwait(false);

            return Ok(commandResult);
        }
    }
}
