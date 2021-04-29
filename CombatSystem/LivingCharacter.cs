using System;
using System.Collections.Generic;
using System.Text;
using CodeSourcerer.CombatSystem;

namespace CombatSystem
{
    /// <summary>
    /// Represents a character. Not necessarily a player, but could be.
    /// </summary>
    public class LivingCharacter : IHasHealth, IHasStats
    {
        public int Health { get; set; }
        public int BaseHealth
        {
            get => _baseHealth;
            set
            {
                Health = _baseHealth = value;
                ReapplyStats();
            }
        }

        private int _baseHealth;
        public StatManager StatMgr { get; private set; }

        public LivingCharacter(StatManager statManager, IEnumerable<CharacterStat> startingStats)
        {
            StatMgr = statManager;
            StatMgr.Stats.OnStatCollectionChanged += Stats_OnStatCollectionChanged;
            StatMgr.Stats.AddRange(startingStats);
            BaseHealth = 1;
        }

        private void Stats_OnStatCollectionChanged(object sender, StatCollectionChangedEventArgs e)
        {
            ReapplyStats();
        }

        public void ReapplyStats()
        {
            //Console.WriteLine("LivingCharacter.reapplyState()");
            Health = _baseHealth;
            StatMgr.Stats.ForEach(stat =>
            {
                // We only care about health stats
                if (stat.Attribute == CharacterAttribute.Stamina)
                {
                    StatMgr.StatModifier.ApplyStat(this, stat);
                }
            });
        }

        public override string ToString()
        {
            return $"Health: {Health}";
        }
    }
}
