using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool Attacking { get; set; }
        private DateTime _lastAttackTimeMainHand { get; set; } = DateTime.Now;
        private DateTime _lastAttackTimeOffHand { get; set; } = DateTime.Now;
        private ICharacter _attackTarget;

        public MeleeClass(StatManager statManager, IEnumerable<CharacterStat> startingStats)
            : base (statManager, startingStats)
        {
            StatMgr.Stats.OnStatCollectionChanged += Stats_OnStatCollectionChanged;
        }

        private void Stats_OnStatCollectionChanged(object sender, StatCollectionChangedEventArgs e)
        {
            ReapplyStats();
        }

        /// <summary>
        /// Attack!!!!
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        /// <remarks>
        /// At some point, maybe I want to be able to specify a type of attack.
        /// </remarks>
        public void Attack(ICharacter target)
        {
            _attackTarget = target;

            Attacking = _attackTarget != null;
        }

        public override void ReapplyStats()
        {
            //Console.WriteLine("LivingCharacter.reapplyState()");
            base.ReapplyStats();
        }

        public override void DoUpdate()
        {
            base.DoUpdate();

            if (Attacking)
            {
                if ((DateTime.Now - _lastAttackTimeMainHand).TotalSeconds >= MainHand.Speed)
                {
                    // Calculate damage
                    // Deal damage to _attackTarget
                    _lastAttackTimeMainHand = DateTime.Now;
                }

                if ((DateTime.Now - _lastAttackTimeOffHand).TotalSeconds >= OffHand.Speed)
                {
                    // Calculate damage
                    // Deal damage to _attackTarget
                    _lastAttackTimeOffHand = DateTime.Now;
                }
            }
        }

        public override string ToString()
        {
            // TODO: Show off our shiny weapons here.
            return base.ToString();
        }
    }
}
