using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameRPG.Domain.Entities
{
    public class Character 
    {
        public Character(Profession profession, string name)
        {
            Name = name;
            Profession = profession;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Profession Profession { get; set; }
        public bool IsAttack { get; set; }


        public void AddId(List<Character> characters)
        {
            if (!characters.Any())
            {
                this.Id = 1;
            }
            else
            {
                var lastId = characters.Last();
                this.Id = lastId.Id + 1;
            }
        }

        public void GenerateSpeed(int min, int max)
        {
            Random rnd = new Random();
            Profession.Velocity = rnd.Next(min, max);
        }


        public int RemoveLife(int Attack)
        {
           return this.Profession.Life = this.Profession.Life - Attack;
        }

    }
}
