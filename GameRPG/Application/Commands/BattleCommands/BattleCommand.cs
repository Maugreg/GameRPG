using MediatR;
using System.Collections.Generic;

namespace GameRPG.Application.Commands.BattleCommands
{
    public class BattleCommand : IRequest<List<string>>
    {
        public int IdCharacter1 { get; set; }
        public int IdCharacter2 { get; set; }
    }
}
