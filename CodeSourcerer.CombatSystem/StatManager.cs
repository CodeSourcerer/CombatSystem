using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public class StatManager
    {
        public StatCollection Stats { get; }
        public IStatModifier StatModifier { get; private set; }

        public StatManager(IStatModifier statModifier = null)
        {
            Stats = new StatCollection();
            StatModifier = statModifier ?? new StatModifier();
        }
    }
}
