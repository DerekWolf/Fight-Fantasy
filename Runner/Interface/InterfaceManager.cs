using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class InterfaceManager
    {
        public static void Launcher(string menu)
        {
            switch (menu)
            {
                case("InGame"):
                using (var game = new Game1())
                    game.Run();
                break;

                case ("MenuP"):;
                using (var MenuP = new MenuInterface())
                    MenuP.Run();
                break;

                case ("Leave"):
                using (var menuP = new MenuInterface())
                    menuP.Exit();
                break;

                default:
                using (var menuP = new MenuInterface())
                    menuP.Run();
                break;
            }
        }
    }
}
