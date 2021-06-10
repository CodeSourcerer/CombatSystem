using System;
using System.Collections.Generic;
using System.Text;
using CodeSourcerer.CombatSystem.Entities;

namespace CodeSourcerer.CombatSystem
{
    /// <summary>
    /// Describes something that wields weapons! We will assume our wielder only possesses two hands...for now.
    /// </summary>
    public interface IWeaponWielder : IMelee
    {
        IWeapon MainHand { get; set; }
        IWeapon OffHand { get; set; }
        bool Attacking { get; set; }

        /// <summary>
        /// Attack a target
        /// </summary>
        /// <param name="target"></param>
        void Attack(ICharacter target);
    }
}
