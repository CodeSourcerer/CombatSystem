using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public interface IMelee
    {
        int AttackPower     { get; set; }
        int BaseAttackPower { get; set; }
    }
}
