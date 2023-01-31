using GameRPG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameRPG.Test
{
    public static class Scenario
    {
        public static Profession profession = new Profession()
        {
            Id = 1,
            ProfessionName = "WARRIOR",
            Life = 20,
            Strong = 20,
            Dexterity = 5,
            Intelligence = 5,
            Velocity = 50,
            Attack = 70
        };


        public static Character character = new Character(profession, "teste")
        {
           Id= 1,   
           IsAttack= true, 
        };
    }
}
