using System;
using System.Collections.Generic;
using System.Text;
using GameRPG.Domain.Entities;

namespace GameRPG.Repository
{
    public static class Data
    {
        public static List<Domain.Entities.Profession> DataProfession()
        {
            var listProfession = new List<Domain.Entities.Profession>();

            listProfession.Add(new Domain.Entities.Profession { Id = 1, ProfessionName = "WARRIOR", Life = 20, Strong = 20, Dexterity = 5, Intelligence = 5, Velocity = 50, Attack = 70 }) ;

            listProfession.Add(new Domain.Entities.Profession { Id = 2, ProfessionName = "THIEF", Life = 15, Strong = 4, Dexterity = 10, Intelligence = 4, Velocity = 50, Attack = 70 });

            listProfession.Add(new Domain.Entities.Profession { Id = 3, ProfessionName = "MAGE", Life = 12, Strong = 5, Dexterity = 6, Intelligence = 10, Velocity = 50, Attack = 70 });


            return listProfession;
        }
    }
}
