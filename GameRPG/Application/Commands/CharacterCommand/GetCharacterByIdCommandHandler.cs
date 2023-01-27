using GameRPG.Application.Commands.ProfessionCommands;
using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace GameRPG.Application.Commands.CharacterCommand
{
    public class GetCharacterByIdCommandHandler : IRequestHandler<GetCharacterByIdCommand, Character>
    {
        private readonly ICharacterRepository _characterRepository;


        public GetCharacterByIdCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<Character> Handle(GetCharacterByIdCommand request, CancellationToken cancellationToken)
        {

            var entity = await _characterRepository.GetCharacterById(request.Id);

            return entity;
        }
    }
}
