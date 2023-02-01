using System;
using System.Collections.Generic;
using System.Text;
using GameRPG.Domain.Entities;
using Microsoft.VisualBasic;

namespace GameRPG.Repository
{
    public static class Data
    {
        public static List<Domain.Entities.Profession> DataProfession()
        {
            var listProfession = new List<Domain.Entities.Profession>();

            listProfession.Add(new Domain.Entities.Profession { Id = 1, ProfessionName = "WARRIOR", Life = 20, Strong = 20, Dexterity = 5, Intelligence = 5, Velocity = Porcetagem(60,5) + Porcetagem(20, 5), Attack = Porcetagem(80, 20) + Porcetagem(20,5) }) ;

            listProfession.Add(new Domain.Entities.Profession { Id = 2, ProfessionName = "THIEF", Life = 15, Strong = 4, Dexterity = 10, Intelligence = 4, Velocity = Porcetagem(80, 10), Attack = Porcetagem(25, 4) + Porcetagem(100, 10) + Porcetagem(25, 4) });

            listProfession.Add(new Domain.Entities.Profession { Id = 3, ProfessionName = "MAGE", Life = 12, Strong = 5, Dexterity = 6, Intelligence = 10, Velocity = Porcetagem(20, 5) + Porcetagem(50, 10), Attack = Porcetagem(20, 5) + Porcetagem(50, 6) + Porcetagem(150, 10) });


            return listProfession;
        }


        public static double Porcetagem(int porcetagem, int value)
        { 
            return ((double)porcetagem / 100) * value; ;
        }
    }
}
