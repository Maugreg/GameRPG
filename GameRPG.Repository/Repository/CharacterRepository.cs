using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.Repository.Repository
{
    public class CharacterRepository : ICharacterRepository
    {

        public async Task<List<Character>> GetAllCharacter()
        {
            return GetDataCharacter("teste");
        }


        public List<Character> GetDataCharacter(string keyName)
        {
            return new List<Character>();
        }
    }
}
