using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class Hero
    {
        #region INITIALISE VARIABLE
        private String Name;
        protected int Viehero = 5;
        private const int FuryTime = 250;
        private bool isAlive = true;

        private int HauteurHero = 95;
        private int LargeurHero = 75;

        private int PositionLargeurHero = 0;
        private int PositionHauteurHero = 385;

        protected static int AttackPositionWidth;
        protected static int AttackPositionHeight;

        private int A = 0;
        private int B = 0;
        private int i = 0;

        Texture2D HeroTexture;
        Texture2D FuryTexture;
        static Rectangle HeroHitBox;

        public bool FuryOn;
        #endregion INITIALISE VARIABLE

        protected List<String> Equipment;
        

        public Hero(ContentManager content)
        {
            HeroTexture = content.Load<Texture2D>("Goku");
            FuryTexture = content.Load<Texture2D>("ssj");
            HeroHitBox = new Rectangle(PositionLargeurHero, PositionHauteurHero, LargeurHero, HauteurHero);
            Equipment = new List<String>();
            Equipment.Add("StandardStick");
            Equipment.Add("BasicSword");
        }

        public void DefineName(String newName)
        {
            Name = newName;
        }

        public void MoveLeft()
        {
            if (HeroHitBox.X > 0)
            {
                HeroHitBox.X -= 5;
            }else { }
        }

        public void MoveRight()
        {
            if (HeroHitBox.X < 650)
            {
                HeroHitBox.X += 5;
            }
            else { }
        }

        public bool Jump(bool inJump)
        {
            if (inJump == true && A < 13 && B == 0)
            {
                A += 1;
                HeroHitBox.X += A;
                HeroHitBox.Y = HeroHitBox.Y - (A * 2 + 1);
                return true;
            }
            else if (inJump == true && A == 13 && B < 13)
            {
                B += 1;
                HeroHitBox.X += B;
                HeroHitBox.Y = HeroHitBox.Y + (B * 2 + 1);
                return true;
            }
            else if (inJump == true && A == 13 && B == 13)
            {
                A = 0;
                B = 0;
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool Fury(bool inFury)
        {
            if(inFury && i < FuryTime)
            {
                i++;
                FuryOn = true;
                return true;
            }
            else if(inFury && i == FuryTime)
            {
                i = 0;
                FuryOn = false;
                return false;
            }
            else
            {
                return false;
            }
        }

        public void DistantAttack()
        {
            Stick.Shoot(Equipment[0]);
        }

        public void SwordAttack()
        {
            Sword.Slash(Equipment[1]);
        }

        public int HeroLife()
        {
            return Viehero;
        }

        public Rectangle getPositionHero()
        {
            return HeroHitBox;
        }

        public void HeroFall()
        {
            isAlive = false;
        }

        public void takeDamage()
        {
            Viehero -= 1;
        }

        public static int GetHeroPositionWidth()
        {
            AttackPositionWidth = HeroHitBox.X;
            return AttackPositionWidth;
        }

        public static int GetHeroPositionHeight()
        {
            AttackPositionHeight = HeroHitBox.Y + HeroHitBox.Height / 2;
            return AttackPositionHeight;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(isAlive)
            {
                if (FuryOn == false)
                {
                    spriteBatch.Draw(HeroTexture, HeroHitBox, Color.White);
                }
                else if (FuryOn == true)
                {
                    spriteBatch.Draw(FuryTexture, HeroHitBox, Color.White);
                }
            }
            else
            {

            }
            
        }        
    }
}
