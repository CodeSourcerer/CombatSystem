using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public class StatManager
    {
        public Dictionary<CharacterAttribute, int> BaseStats { get; } = new Dictionary<CharacterAttribute, int>(5);
        public StatCollection Stats { get; } = new StatCollection();
        public IStatModifier StatModifier { get; private set; }

        public StatManager(IStatModifier statModifier = null)
        {
            StatModifier = statModifier ?? new DefaultStatModifier();
        }
    }
}
