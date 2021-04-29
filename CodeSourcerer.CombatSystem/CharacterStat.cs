using System;

namespace CodeSourcerer.CombatSystem
{
    public class CharacterStat
    {
        public CharacterAttribute Attribute     { get; set; }
        public int                Value         { get; set; }
        public bool               IsPercentage  { get; set; }

        public CharacterStat(CharacterAttribute attribute, int value, bool isPercentage = false)
        {
            Attribute = attribute;
            Value = value;
            IsPercentage = isPercentage;
        }

        public override string ToString()
        {
            return $"+{Value} {this.Attribute}";
        }
    }
}
