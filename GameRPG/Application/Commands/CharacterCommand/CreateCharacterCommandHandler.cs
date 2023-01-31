using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using System.Linq;
using Serilog;
using GameRPG.Application.Commands.BattleCommands;

namespace GameRPG.Application.Commands.CharacterCommand
{
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, int>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IProfessionRepository _professionRepository;
        private readonly ILogger _logger;

        public CreateCharacterCommandHandler(ICharacterRepository characterRepository, IProfessionRepository professionRepository, ILogger logger)
        {
            _characterRepository = characterRepository;
            _professionRepository = professionRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            _logger.Information("Begin Create Character"); 

            var entityProfession = await _professionRepository.GetById(request.ProfessionId);

            Character character = new Character(entityProfession, request.Name);

            var listCharacter = await _characterRepository.GetAllCharacter();

            character.AddId(listCharacter);

            _logger.Information($"Character AddId {character.Id}");

            listCharacter.Add(character);

            await _characterRepository.CreateCharacter(listCharacter);

            _logger.Information("Finish Create Character");

            return character.Id;
        }
    }
}
