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
            var log = new List<string>();

            while (true)
            {
                character1.GenerateSpeed(0, character1.Profession.Velocity);
                character2.GenerateSpeed(0, character2.Profession.Velocity);

                if (!character1.Profession.Velocity.Equals(character2.Profession.Velocity)) 
                break;
            }



            var logInitialAtack = InitialAtack(character1, character2);
            log.Add(logInitialAtack);


            while (true)
            {
                if(character1.IsAttack)
                {
                    var damage = GenerateAttack(0, character1.Profession.Attack);
                    if(character2.RemoveLife(damage) <= 0)
                    {
                        character2.Profession.Life = 0;
                        var logAttackFinish = $"{character1.Name} atacou {character2.Name} com {damage} de dano, {character2.Name} com {character2.Profession.Life} pontos de vida restantes";
                        log.Add(logAttackFinish);

                        var logWin = $"{character1.Name} venceu a batalha! {character1.Name} ainda tem {character1.Profession.Life} pontos de vida restantes!";
                        log.Add(logWin);

                        break;
                    }
                    character1.IsAttack = false;
                    character2.IsAttack = true;

                    var logAttack = $"{character1.Name} atacou {character2.Name} com {damage} de dano, {character2.Name} com {character2.Profession.Life} pontos de vida restantes";
                    log.Add(logAttack);
                }
                else
                {
                    var damage = GenerateAttack(0, character2.Profession.Attack);
                    if (character1.RemoveLife(damage) <= 0)
                    {
                        character1.Profession.Life = 0;
                        var logAttackFinish = $"{character2.Name} atacou {character1.Name} com {damage} de dano, {character1.Name} com {character1.Profession.Life} pontos de vida restantes";
                        log.Add(logAttackFinish);

                        var logWin = $"{character2.Name} venceu a batalha!{character2.Name} ainda tem {character2.Profession.Life} pontos de vida restantes!";
                        log.Add(logWin);

                        break;
                    }

                    character2.IsAttack = false;
                    character1.IsAttack = true;

                    var logAttack = $"{character2.Name} atacou {character1.Name} com {damage} de dano, {character1.Name} com {character2.Profession.Life} pontos de vida restantes";
                    log.Add(logAttack);
                }

            }

            return log;
        }

        private string InitialAtack(Character character1, Character character2)
        {
            if (character1.Profession.Velocity > character2.Profession.Velocity)
            {
                character1.IsAttack = true;
                return $"{character1.Name} Velocidade: {character1.Profession.Velocity} foi mais veloz que o {character2.Name} Velocidade: {character2.Profession.Velocity}, e irá começar!";
            }
            else
            {
                character2.IsAttack = true;
                return $"{character2.Name} Velocidade: {character2.Profession.Velocity} foi mais veloz que o {character1.Name} Velocidade: { character1.Profession.Velocity}, e irá começar!";
            }
        }

        private int GenerateAttack(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
