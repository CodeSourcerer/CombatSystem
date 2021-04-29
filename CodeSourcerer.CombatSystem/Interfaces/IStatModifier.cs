using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public interface IStatModifier
    {
        void ApplyStat(object target, CharacterStat stat);
    }
}
