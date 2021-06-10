using System;
using System.Collections.Generic;
using System.Text;
using CodeSourcerer.CombatSystem;
using CodeSourcerer.CombatSystem.Entities;
using CombatSystem.Menu;

namespace CombatSystem
{
    public class CombatSystem
    {
        private StatManager _statManager;
        private ActionMenu _menu;
        private MenuItem _optionQuit;
        private Dictionary<string, ICharacter> _characters = new Dictionary<string, ICharacter>();

        private List<CharacterStat> meleeStartStats = new List<CharacterStat>();

        public CombatSystem()
        {
            _statManager = new StatManager();
            meleeStartStats.Add(new CharacterStat(CharacterAttribute.Stamina, 10));
            _characters["Aggromagnet"] = new MeleeClass(_statManager, meleeStartStats);

            _optionQuit = new MenuItem { Value = 1, Display = "Quit", Action = null };
        }

        public void Run()
        {
            _menu = CreateMenu();
            int userInput;
            MenuItem selectedItem = new MenuItem();

            do
            {
                Console.WriteLine(_menu);
                Console.Write("Enter your selection: ");
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    selectedItem = _menu.GetItemFromSelection(userInput);
                    selectedItem.Action?.Invoke();
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            } while (!selectedItem.Equals(_optionQuit));
        }

        public ActionMenu CreateMenu()
        {
            var mainMenu = new ActionMenu();
            var modifyStatsMenu = new ActionMenu();

            var mainMenuItems = new List<MenuItem>
            {
                new MenuItem { Value = 1, Display = "Display character stats", Action = () => Console.WriteLine($"{_characters["Aggromagnet"]}") },
                new MenuItem { Value = 2, Display = "Modify stat", Action = () => { _menu = modifyStatsMenu; } }
            };

            var modifyStatsMenuItems = new List<MenuItem>
            {
                new MenuItem { Value = 1, Display = "Stamina", Action = () => modifyStat("Aggromagnet", CharacterAttribute.Stamina) },
                new MenuItem { Value = 2, Display = "Strength", Action = () => modifyStat("Aggromagnet", CharacterAttribute.Strength) },
                new MenuItem { Value = 3, Display = "Back", Action = () => _menu = mainMenu }
            };

            _optionQuit.Value = mainMenuItems.Count + 1;
            mainMenuItems.Add(_optionQuit);
            mainMenu.MenuItems.AddRange(mainMenuItems);
            modifyStatsMenu.MenuItems.AddRange(modifyStatsMenuItems);

            return mainMenu;
        }

        private void modifyStat(string character, CharacterAttribute attr)
        {
            int amount;
            bool validInput = false;
            do
            {
                Console.WriteLine($"Current value: {_characters[character].StatMgr.Stats[attr]}");
                Console.Write("Enter new amount: ");
                try
                {
                    amount = int.Parse(Console.ReadLine());
                    if (amount <= 0) throw new ArgumentOutOfRangeException();
                    
                    validInput = true;
                    _characters[character].StatMgr.Stats[CharacterAttribute.Stamina] = amount;
                }
                catch
                {
                    Console.WriteLine("Invalid amount");
                }
            } while (!validInput);
        }
    }
}
