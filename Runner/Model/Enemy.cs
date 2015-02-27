using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Runner
{
    class Enemy
    {
        #region INITIALISE VARIABLE
        protected int NumberOfLife = 1;
        protected int Speed = 3;

        protected int position_en_X = 395;
        protected int position_en_Y = 720;

        protected int hauteur_enemy = 85;
        protected int largueur_enemy = 55;

        Texture2D EnemyTexture;
        Rectangle EnemyHitBox;

        #endregion INITIALISE VARIABLE

        public Enemy(ContentManager content)
        {
            EnemyTexture = content.Load<Texture2D>("mechant");
            EnemyHitBox = new Rectangle(position_en_Y, position_en_X, largueur_enemy, hauteur_enemy);
        }

        public void MoveEnemy()
        {
            if (EnemyHitBox.X > 0)
            {
                EnemyHitBox.X -= Speed;
            }
            else
            {
                NumberOfLife -= 1;
            }
            
        }

        public Rectangle getPositionEnemy()
        {
            return EnemyHitBox;
        }

        public void takeDamage()
        {
            NumberOfLife -= 1;
        }

        public int returnLife()
        {
            return NumberOfLife;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(NumberOfLife > 0)
            {
                spriteBatch.Draw(EnemyTexture, EnemyHitBox, Color.White);
            }
            else { }
            
        }
    }
}
