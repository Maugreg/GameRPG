using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace GameRPG.Application.Commands.CharacterCommand
{
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, int>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IProfessionRepository _professionRepository;


        public CreateCharacterCommandHandler(ICharacterRepository characterRepository, IProfessionRepository professionRepository)
        {
            _characterRepository = characterRepository;
            _professionRepository = professionRepository;
        }

        public async Task<int> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {

            var entity = await _professionRepository.GetById(request.ProfessionId);

            return 1;
        }
    }
}
