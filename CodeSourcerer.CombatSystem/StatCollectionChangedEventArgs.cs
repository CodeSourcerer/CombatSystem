using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSourcerer.CombatSystem
{
    public class StatCollectionChangedEventArgs : EventArgs
    {
        public CharacterStat Stat { get; }

        public StatCollectionChangedEventArgs(CharacterStat stat)
            : base()
        {
            Stat = stat;
        }
    }
}
