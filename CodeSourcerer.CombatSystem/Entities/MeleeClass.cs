using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem.Entities
{
    /// <summary>
    /// This is a character wielding TWO weapons, yo.
    /// </summary>
    public class MeleeClass : LivingCharacter, IWeaponWielder
    {
        public IWeapon MainHand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWeapon OffHand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MeleeClass(StatManager statManager, IEnumerable<CharacterStat> startingStats)
            : base (statManager, startingStats)
        {
            StatMgr.Stats.OnStatCollectionChanged += Stats_OnStatCollectionChanged; ;
            StatMgr.Stats.AddRange(startingStats);
            BaseHealth = 1;
            AttackPower = 1;
        }

        private void Stats_OnStatCollectionChanged(object sender, StatCollectionChangedEventArgs e)
        {
            ReapplyStats();
        }

        /// <summary>
        /// Attack!!!!
        /// </summary>
        /// <param name="target"></param>
        /// <param name="weapon"></param>
        /// <returns></returns>
        /// <remarks>
        /// At some point, maybe I want to be able to specify a type of attack.
        /// </remarks>
        public int Attack(ICharacter target, IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public override void ReapplyStats()
        {
            //Console.WriteLine("LivingCharacter.reapplyState()");
            base.ReapplyStats();

            StatMgr.Stats.ForEach(stat =>
            {
                if (stat.Attribute == CharacterAttribute.Strength)
                {
                    StatMgr.StatModifier.ApplyStat(this, stat);
                }
            });
        }

        public override string ToString()
        {
            // TODO: Show off our shiny weapons here.
            return base.ToString();
        }
    }
}
