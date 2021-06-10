using System;
using System.Collections.Generic;
using System.Text;

namespace CombatSystem.Menu
{
    public struct MenuItem
    {
        public int Value { get; set; }
        public string Display { get; set; }
        public Action Action { get; set; }
    }
}
