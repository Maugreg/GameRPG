using System;
using System.Collections.Generic;
using System.Text;

namespace GameRPG.Domain.Entities
{
    public class Profession : Attributes
    {
        public int Id { get; set; }
        public string ProfessionName { get; set; }
    }
}
