using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class Sword : Weapon
    {
        public Sword(string name) : base(name)
        {
        }

        public static void Slash(string Name)
        {
            switch (Name)
            {
                case "BasicSword" :
                    SwordShock.DefineSwordPattern(1);
                    break;

                default :
                    break;
            }
        }
    }
}
