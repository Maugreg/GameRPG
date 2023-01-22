using MediatR;
using System.Collections.Generic;

namespace GameRPG.Application.Commands.ProfessionCommands
{
    public class GetProfessionCommand : IRequest<List<GameRPG.Domain.Entities.Profession>>
    {
    }
}
