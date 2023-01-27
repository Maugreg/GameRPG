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
                var lastId = characters.First();
                this.Id = lastId.Id + 1;
            }
        }

        public void GenerateSpeed(int min, int max)
        {
            Random rnd = new Random();
            Profession.Velocity = rnd.Next(min, max);
        }

        public void GenerateAttack(int min, int max)
        {
            Random rnd = new Random();
            Profession.Attack = rnd.Next(min, max);
        }

        public void RemoveLife(int Attack)
        {
            this.Profession.Life = this.Profession.Life - Attack;
        }

    }
}
