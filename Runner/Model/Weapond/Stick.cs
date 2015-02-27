using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class Stick : Weapon
    {
        public Stick(string name) : base(name)
        {

        }
        

        public static void Shoot(string Name)
        {
            switch (Name)
            {
                case "StandardStick":
                    ShootsPattern.DefineShootPattern(1);
                    break;

                default :
                    break;
            }
        }

        
    }
}
