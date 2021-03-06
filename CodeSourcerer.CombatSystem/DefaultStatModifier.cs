using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public class DefaultStatModifier : IStatModifier
    {
        public void ApplyStat(IHasHealth target, CharacterStat stat)
        {
            if (stat.Attribute == CharacterAttribute.Stamina)
            {
                if (stat.IsPercentage)
                    target.Health += target.BaseHealth * (stat.Value / 100);
                else
                    target.Health += stat.Value * 10;
            }
        }

        public void ApplyStat(IManaUser target, CharacterStat stat)
        {
            if (stat.Attribute == CharacterAttribute.Intellect)
            {
                if (stat.IsPercentage)
                    target.Mana += target.BaseMana * (stat.Value / 100);
                else
                    target.Mana += stat.Value * 15;
            }
        }

        public void ApplyStat(IMelee target, CharacterStat stat)
        {
            if (stat.Attribute == CharacterAttribute.Strength)
            {
                if (stat.IsPercentage)
                    target.AttackPower += target.BaseAttackPower * (stat.Value / 100);
                else
                    target.AttackPower += stat.Value * 2;
            }
        }

        public void ApplyStat(object target, CharacterStat stat)
        {
            if (target is IHasHealth && stat.Attribute == CharacterAttribute.Stamina)
            {
                ApplyStat((IHasHealth)target, stat);
            }

            if (target is IManaUser && stat.Attribute == CharacterAttribute.Intellect)
            {
                ApplyStat((IManaUser)target, stat);
            }

            if (target is IMelee && stat.Attribute == CharacterAttribute.Strength)
            {
                ApplyStat((IMelee)target, stat);
            }
        }
    }
}
