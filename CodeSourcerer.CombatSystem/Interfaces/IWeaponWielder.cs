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

        /// <summary>
        /// Attack a target with the given weapon
        /// </summary>
        /// <param name="target"></param>
        /// <param name="weapon"></param>
        /// <returns>The damage dealt</returns>
        int Attack(ICharacter target, IWeapon weapon);
    }
}
