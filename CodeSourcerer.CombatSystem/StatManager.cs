using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public class StatManager
    {
        public StatCollection Stats { get; }
        public IStatModifier StatModifier { get; private set; }

        public StatManager(IStatModifier statModifier)
        {
            Stats = new StatCollection();
            StatModifier = statModifier;

            //Stats.OnStatCollectionChanged += _stats_OnStatCollectionChanged;
        }
        
        //private void _stats_OnStatCollectionChanged(object sender, StatCollectionChangedEventArgs e)
        //{
        //    ReapplyStats();
        //}

        //public abstract void ReapplyStats();
    }
}
