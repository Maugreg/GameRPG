using System;
using System.Collections.Generic;
using System.Text;

namespace GameRPG.Domain.Entities
{
    public class Attributes : BattleModifier
    {
        public int Life { get; set; }
        public int Strong { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

    }
}
