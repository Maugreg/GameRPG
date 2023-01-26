using GameRPG.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GameRPG.Application.Commands.CharacterCommand
{
    public class CreateCharacterCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int ProfessionId { get; set; }
    }
}
