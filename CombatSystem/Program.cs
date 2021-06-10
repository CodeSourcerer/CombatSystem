using System;
using System.Collections.Generic;
using CodeSourcerer.CombatSystem;
using CodeSourcerer.CombatSystem.Entities;

namespace CombatSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            new CombatSystem().Run();

            //List<CharacterStat> startingStats = new List<CharacterStat>();
            //startingStats.Add(new CharacterStat(CharacterAttribute.Stamina, 10));
            //var statMgr = new StatManager();

            //ManaUser dagen = new ManaUser(statMgr, startingStats);
            //Console.WriteLine($"Character before BaseHealth set: {dagen}");

            //dagen.BaseHealth = 100;
            //Console.WriteLine($"Character after BaseHealth set: {dagen}");

            //var newStat = new CharacterStat(CharacterAttribute.Stamina, 1);
            //dagen.StatMgr.Stats.Add(newStat);
            //Console.WriteLine($"Character after adding {newStat}: {dagen}");

            //dagen.StatMgr.Stats.Add(new CharacterStat(CharacterAttribute.Intellect, 5));
            //Console.WriteLine($"Character with: \n{dagen.StatMgr.Stats}{dagen}");

            //MeleeClass aggromagnet = new MeleeClass(statMgr, startingStats);
            //Console.WriteLine($"Before base stats set: {aggromagnet}");
            
            //aggromagnet.BaseHealth = 120;
            //aggromagnet.BaseAttackPower = 20;
            //Console.WriteLine($"After base stats set: {aggromagnet}");

            //var bigSwordStat = new CharacterStat(CharacterAttribute.Strength, 10);
            //aggromagnet.StatMgr.Stats.Add(bigSwordStat);
            //Console.WriteLine($"After equipping big sword: {aggromagnet}");
        }
    }
}
