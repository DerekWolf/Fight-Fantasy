using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class InterfaceManager
    {
        static string InterfaceLaunch;

        public static void Launcher(string interfaceLaunch)
        {
            InterfaceLaunch = interfaceLaunch;
            using (var game = new GameInterface())
                game.Run();
        }

        public static void Navigate(string menu)
        {
            InterfaceLaunch = menu;

            switch (InterfaceLaunch)
            {
                case ("MainMenu"):
                    InterfaceLaunch = menu;
                    break;

                case ("GameTime"):
                    InterfaceLaunch = menu;
                    break;

                case ("Option"):

                    break;

                default:
                    InterfaceLaunch = menu;
                    break;
            }
        }

        public static string GiveInterface()
        { return InterfaceLaunch; }
    }
}