using System;
using System.Collections.Generic;
using System.Text;

namespace CombatSystem.Menu
{
    public class ActionMenu
    {
        public List<MenuItem> MenuItems { get; set; }

        public ActionMenu()
        {
            MenuItems = new List<MenuItem>();
        }

        public ActionMenu(IEnumerable<MenuItem> menuItems)
            : this()
        {
            MenuItems.AddRange(menuItems);
        }

        public MenuItem GetItemFromSelection(int selection)
        {
            return MenuItems.Find(mi => mi.Value == selection);
        }

        public override string ToString()
        {
            StringBuilder sbMenu = new StringBuilder(512);
            MenuItems.ForEach(mi => sbMenu.AppendLine($"{mi.Value}. {mi.Display}"));
            return sbMenu.ToString();
        }
    }
}
