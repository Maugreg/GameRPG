using GameRPG.Application.Commands.CharacterCommand;
using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using MediatR;
using System;
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

        async Task<List<string>> IRequestHandler<BattleCommand, List<string>>.Handle(BattleCommand request, CancellationToken cancellationToken)
        {
            var character1 = await  _characterRepository.GetCharacterById(request.IdCharacter1);
            var character2 = await _characterRepository.GetCharacterById(request.IdCharacter2);

            character1.GenerateSpeed(0, character1.Profession.Velocity);
            character2.GenerateSpeed(0, character2.Profession.Velocity);

            character1.GenerateAttack(0, character1.Profession.Attack);
            character2.GenerateAttack(0, character2.Profession.Attack);

            InitialAtack(character1, character2);


            int i = 0;

            while (i < 10) // condition
            {
                if(character1.IsAttack)
                {
                    character2.RemoveLife(character1.Profession.Attack);
                    character1.IsAttack = false;
                    character2.IsAttack = true;
                }
                else
                {
                    character1.RemoveLife(character1.Profession.Attack);
                    character2.IsAttack = false;
                    character1.IsAttack = true;
                }

                character1.IsAttack = false;
            }

            return new List<string>();
        }

        private void InitialAtack(Character character1, Character character2)
        {
            if (character1.Profession.Velocity > character2.Profession.Velocity)
            {
                character1.IsAttack = true;
            }
            else
            {
                character2.IsAttack = true;
            }
        }
    }
}
