using System;
using System.Collections.Generic;
using CodeSourcerer.CombatSystem;

namespace CombatSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CharacterStat> startingStats = new List<CharacterStat>();
            startingStats.Add(new CharacterStat(CharacterAttribute.Stamina, 10));
            var statMgr = new StatManager(new StatModifier());

            ManaUser c = new ManaUser(statMgr, startingStats);
            Console.WriteLine($"Character before BaseHealth set: {c}");

            c.BaseHealth = 100;
            Console.WriteLine($"Character after BaseHealth set: {c}");

            var newStat = new CharacterStat(CharacterAttribute.Stamina, 1);
            c.StatMgr.Stats.Add(newStat);
            Console.WriteLine($"Character after adding {newStat}: {c}");

            c.StatMgr.Stats.Add(new CharacterStat(CharacterAttribute.Intellect, 5));
            Console.WriteLine($"Character with: \n{c.StatMgr.Stats}{c}");
        }
    }
}
