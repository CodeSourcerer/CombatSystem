using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    /// <summary>
    /// Something with health and character stats.
    /// </summary>
    public interface ICharacter : IHasHealth, IHasStats
    {
    }
}
