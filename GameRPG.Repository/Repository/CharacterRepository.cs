using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRPG.Repository.Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IMemoryCache _cache;
        private readonly string _cacheKey = "listCharacter";

        public CharacterRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<List<Character>> GetAllCharacter()
        {
            if (!_cache.TryGetValue(_cacheKey, out List<Character> listCharacter))
            {
                return new List<Character>();
            }
            else
            {
                return (List<Character>)_cache.Get(_cacheKey);
            };
        }


        public async Task<Character> GetCharacterById(int Id)
        {
            var list = await GetAllCharacter();
            return list.FirstOrDefault(x => x.Id == Id);
        }


        public async Task CreateCharacter(List<Character> character)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                SlidingExpiration = TimeSpan.FromMinutes(2)
            };
            _cache.Set(_cacheKey, character, cacheExpiryOptions);
        }

    }
}
