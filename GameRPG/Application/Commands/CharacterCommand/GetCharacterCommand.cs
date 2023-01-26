using GameRPG.Application.Commands.ProfessionCommands;
using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace GameRPG.Application.Commands.CharacterCommand
{
    public class GetCharacterCommand : IRequest<List<Character>>
    {

    }
}
