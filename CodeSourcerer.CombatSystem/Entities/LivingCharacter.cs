using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem.Entities
{
    /// <summary>
    /// Represents a character. Not necessarily a player, but could be.
    /// 
    /// By current design, this character may not have any weapons. I'm not sure how I feel about this.
    /// Normally this would sound weird, but maybe this could be an NPC that doesn't have a weapon?
    /// Maybe it's a stupid distinction that should go away. We'll see.
    /// </summary>
    /// <remarks>
    /// It's aliiiiiiive!!
    /// </remarks>
    public class LivingCharacter : IMelee, ICharacter
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

        public virtual void ReapplyStats()
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

        public virtual void DoUpdate()
        {

        }

        public override string ToString()
        {
            return $"Health: {Health}, Attack Power: {AttackPower}";
        }
    }
}
