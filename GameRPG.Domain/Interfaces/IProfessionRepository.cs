using GameRPG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.Domain.Interfaces
{
    public interface IProfessionRepository
    {
        public Task<List<Profession>> GetAll();
        public Task<Profession> GetById(int id);
    }
}
