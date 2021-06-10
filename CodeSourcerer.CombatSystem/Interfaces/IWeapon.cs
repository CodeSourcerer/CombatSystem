using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public interface IWeapon
    {
        WeaponType TypeOfWeapon { get; set; }
        StatCollection Stats { get; }
        (int Low, int High) Damage { get; set; }
        float Speed { get; set; }
    }
}
