using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public interface IHasStats
    {
        StatManager StatMgr { get; }
    }
}
