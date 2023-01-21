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

            listProfession.Add(new Domain.Entities.Profession { ProfessionName = "WARRIOR", Life = 20, Strong = 20, Dexterity = 5, Intelligence = 5 }) ;

            listProfession.Add(new Domain.Entities.Profession { ProfessionName = "THIEF", Life = 15, Strong = 4, Dexterity = 10, Intelligence = 4 });

            listProfession.Add(new Domain.Entities.Profession { ProfessionName = "MAGE", Life = 12, Strong = 5, Dexterity = 6, Intelligence = 10 });


            return listProfession;
        }
    }
}
