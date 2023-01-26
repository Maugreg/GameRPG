using GameRPG.Application.Commands.ProfessionCommands;
using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace GameRPG.Application.Commands.CharacterCommand
{
    public class GetCharacterCommandHandler : IRequestHandler<GetCharacterCommand, List<Character>>
    {
        private readonly ICharacterRepository _characterRepository;


        public GetCharacterCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<List<Character>> Handle(GetCharacterCommand request, CancellationToken cancellationToken)
        {

            var entity = await _characterRepository.GetAllCharacter();

            return entity;
        }
    }
}
