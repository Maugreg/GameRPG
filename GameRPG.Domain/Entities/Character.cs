using System;
using System.Collections.Generic;
using System.Text;

namespace GameRPG.Domain.Entities
{
    public class Character : Profession
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
