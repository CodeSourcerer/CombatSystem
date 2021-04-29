using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public interface IManaUser
    {
        int Mana     { get; set; }
        int BaseMana { get; set; }
    }
}
