using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class SwordShock
    {
        #region Initialize Variable
        protected int AttackPositionWidth;
        protected int AttackPositionHeight;

        protected int SlashWidth = 40;
        protected int SlashHeight = 55;

        Rectangle HitBoxSlash;

        Texture2D SlashPattern;

        protected static int pattern;
        #endregion Initialize Variable

        public void MoveAttack()
        {
            if (HitBoxSlash.X < 720)
            {
                HitBoxSlash.X += 2;
            }

        }

        public Rectangle getPositionShoot()
        {
            return HitBoxSlash;
        }

        public static void DefineSwordPattern(int AttackSelection)
        {
            pattern = AttackSelection;
        }

        public SwordShock(ContentManager content)
        {
            AttackPositionWidth = Hero.GetHeroPositionWidth() + SlashWidth;
            AttackPositionHeight = Hero.GetHeroPositionHeight();

            HitBoxSlash = new Rectangle(AttackPositionWidth, AttackPositionHeight, SlashWidth, SlashHeight);

            SlashPattern = content.Load<Texture2D>("FirstSlash");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (pattern)
            {
                case 1:
                    spriteBatch.Draw(SlashPattern, HitBoxSlash, Color.White);
                    break;

                default:
                    break;
            }
            
            
        }

    }
}
