using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class ShootsPattern
    {
        #region Initialize Variable

        protected int ShootWidth = 40;
        protected int ShootHeight = 40;

        protected int Duration = 1;

        Vector2 Position;
        Vector2 PositionDep;
        Vector2 PositionClick;
        Vector2 Direction;

        Texture2D ShootPattern;
        Rectangle RecShoot;

        protected float RotationAngle { get; set; }
        protected static int pattern;
        protected int Speed = 3;
        protected double X;
        protected double Y;
        protected double angleInDegrees;
        #endregion Initialize Variable

        public void MoveAttack()
        {
            Y = PositionClick.Y - PositionDep.Y;
            X = PositionClick.X - PositionDep.X;
            angleInDegrees = Math.Atan2(Y, X) * 180 / 3.14;
            RotationAngle = MathHelper.ToRadians((float)angleInDegrees);

            if (Position.X < 820 && Position.Y < 500 && Position.X > -50 && Position.Y > -50)
            {
                Direction = new Vector2((float)Math.Cos(RotationAngle),
                                    (float)Math.Sin(RotationAngle));
                Direction.Normalize();
                Position += Direction * Speed;
            }
            else
            {
                Duration -= 1;
            }

        }

        public Rectangle getPositionShoot()
        {
            return RecShoot = new Rectangle((int)Position.X, (int)Position.Y, ShootWidth, ShootHeight);
        }

        public void Shocked()
        {
            Duration -= 1;
        }

        public static void DefineShootPattern(int AttackSelection)
        {
            pattern = AttackSelection;
        }

        public ShootsPattern(ContentManager content, Vector2 posHero, Vector2 posSouris)
        {
            PositionDep = posHero;
            PositionClick = posSouris;

            Position = new Vector2(Hero.GetHeroPositionWidth() - ShootWidth / 2, Hero.GetHeroPositionHeight() - ShootHeight /2);

            ShootPattern = content.Load<Texture2D>("bouleEneregie");
        }

        public int GetDuration()
        {
            return Duration;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Duration > 0)
            {
                switch (pattern)
                {
                    case 1:
                        spriteBatch.Draw(ShootPattern, Position, Color.White);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
