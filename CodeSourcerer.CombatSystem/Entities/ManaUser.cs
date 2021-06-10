using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSourcerer.CombatSystem.Entities
{
    /// <summary>
    /// This character is a mana user.
    /// </summary>
    public class ManaUser : LivingCharacter, IManaUser, ICharacter
    {
        public int Mana { get; set; }
        public int BaseMana
        {
            get => _baseMana;
            set
            {
                Mana = _baseMana = value;
                ReapplyStats();
            }
        }

        private int _baseMana;

        public ManaUser(StatManager statManager, IEnumerable<CharacterStat> startingStats)
            : base (statManager, startingStats)
        {
            StatMgr.Stats.OnStatCollectionChanged += Stats_OnStatCollectionChanged;
            BaseMana = 1;
        }

        private void Stats_OnStatCollectionChanged(object sender, StatCollectionChangedEventArgs e)
        {
            ReapplyStats();
        }

        public override void ReapplyStats()
        {
            base.ReapplyStats();
            //Console.WriteLine("ManaUser.reapplyState()");
            Mana = _baseMana;

            int totalInt = StatMgr.BaseStats[CharacterAttribute.Intellect] + StatMgr.Stats.Sum(s => s.Attribute == CharacterAttribute.Intellect ? s.Value : 0);
            StatMgr.StatModifier.ApplyStat(this, new CharacterStat(CharacterAttribute.Intellect, totalInt));
        }

        public override void DoUpdate()
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Mana: {Mana}";
        }
    }
}
