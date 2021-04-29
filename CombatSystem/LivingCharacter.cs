using System;
using System.Collections.Generic;
using System.Text;
using CodeSourcerer.CombatSystem;

namespace CombatSystem
{
    /// <summary>
    /// Represents a character. Not necessarily a player, but could be.
    /// </summary>
    public class LivingCharacter : IHasHealth, IMelee, IHasStats
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
        public int AttackPower { get; set; }
        public int BaseAttackPower
        {
            get => _baseAttackPower;
            set
            {
                AttackPower = _baseAttackPower = value;
                ReapplyStats();
            }
        }
        public StatManager StatMgr { get; private set; }

        private int _baseHealth;
        private int _baseAttackPower;


        public LivingCharacter(StatManager statManager, IEnumerable<CharacterStat> startingStats)
        {
            StatMgr = statManager;
            StatMgr.Stats.OnStatCollectionChanged += Stats_OnStatCollectionChanged;
            StatMgr.Stats.AddRange(startingStats);
            BaseHealth = 1;
            AttackPower = 1;
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
                if (stat.Attribute == CharacterAttribute.Stamina)
                {
                    StatMgr.StatModifier.ApplyStat(this, stat);
                }
            });
        }

        public override string ToString()
        {
            return $"Health: {Health}, Attack Power: {AttackPower}";
        }
    }
}
