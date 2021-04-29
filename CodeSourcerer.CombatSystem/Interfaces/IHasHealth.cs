using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public interface IHasHealth
    {
        int Health      { get; set; }
        int BaseHealth  { get; set; }
    }
}
