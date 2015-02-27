using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class Weapon
    {
        protected int Damage = 1;
        protected string Name;

        public Weapon(string name)
        {
            Name = name;
        }
    }
}