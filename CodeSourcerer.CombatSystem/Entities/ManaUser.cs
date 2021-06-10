using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem.Entities
{
    /// <summary>
    /// This character is a mana user.
    /// </summary>
    public class ManaUser : IManaUser, ICharacter
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

        public int Health     { get => _character.Health;     set => _character.Health = value; }
        public int BaseHealth { get => _character.BaseHealth; set => _character.BaseHealth = value; }
        public StatManager StatMgr { get => _character.StatMgr; }

        private int _baseMana;
        private LivingCharacter _character;

        public ManaUser(StatManager statManager, IEnumerable<CharacterStat> startingStats)
        {
            _character = new LivingCharacter(statManager, startingStats);
            StatMgr.Stats.OnStatCollectionChanged += Stats_OnStatCollectionChanged;
            BaseMana = 1;
        }

        private void Stats_OnStatCollectionChanged(object sender, StatCollectionChangedEventArgs e)
        {
            ReapplyStats();
        }

        public void ReapplyStats()
        {
            //Console.WriteLine("ManaUser.reapplyState()");
            Mana = _baseMana;

            // We care about health and mana stats
            _character.StatMgr.Stats.ForEach(stat =>
            {
                if (stat.Attribute == CharacterAttribute.Intellect)
                    _character.StatMgr.StatModifier.ApplyStat(this, stat);

                if (stat.Attribute == CharacterAttribute.Stamina)
                    _character.ReapplyStats();
            });
        }

        public void DoUpdate()
        {
            
        }

        public override string ToString()
        {
            return $"{_character}, Mana: {Mana}";
        }
    }
}
