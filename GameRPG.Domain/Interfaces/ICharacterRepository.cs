using GameRPG.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MemoryCache = System.Runtime.Caching.MemoryCache;

namespace GameRPG.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        public Task<List<Character>> GetAllCharacter();
        public Task CreateCharacter(List<Character> character);
        public Task<Character> GetCharacterById(int Id);
    }
}
