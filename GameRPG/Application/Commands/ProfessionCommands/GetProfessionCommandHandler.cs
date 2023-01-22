using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using MediatR;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace GameRPG.Application.Commands.ProfessionCommands
{
    public class GetProfessionCommandHandler : IRequestHandler<GetProfessionCommand, List<Profession>>
    {
        private readonly IProfessionRepository _professionRepository;


        public GetProfessionCommandHandler(IProfessionRepository professionRepository)
        {
            _professionRepository = professionRepository;
        }

        public async Task<List<Profession>> Handle(GetProfessionCommand request, CancellationToken cancellationToken)
        {

            var entity = await _professionRepository.GetAll();

            return entity;
        }
    }
}
