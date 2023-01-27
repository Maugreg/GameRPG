using GameRPG.Application.Commands.CharacterCommand;
using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GameRPG.Application.Commands.BattleCommands
{
    public class BattleCommandHandler : IRequestHandler<BattleCommand, List<string>>
    {
        private readonly ICharacterRepository _characterRepository;
        public BattleCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        Task<List<string>> IRequestHandler<BattleCommand, List<string>>.Handle(BattleCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
