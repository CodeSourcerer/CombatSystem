using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public class Weapon : IWeapon
    {
        public WeaponType TypeOfWeapon { get; set; }
        public StatCollection Stats { get; }
        public (int Low, int High) Damage { get; set; }
        public float Speed { get; set; }
    }
}
