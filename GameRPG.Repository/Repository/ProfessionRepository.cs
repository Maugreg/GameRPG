using GameRPG.Domain.Entities;
using GameRPG.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameRPG.Repository.Repository
{
    public  class ProfessionRepository : IProfessionRepository
    {
        public async Task<List<Profession>> GetAll()
        {
            return Data.DataProfession().ToList();
        }


        public async Task<Profession> GetById(int id)
        {
            return Data.DataProfession().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
    }
}
