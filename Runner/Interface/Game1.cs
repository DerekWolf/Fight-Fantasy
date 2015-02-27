#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Runner
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        #region All Variable
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Hero hero;
        ShootsPattern ShootAttack;
        SwordShock SlashAttack;
        Enemy BadGuy;
        SpriteFont font;
        Vector2 PosHero;
        Vector2 PosClick;

        public bool InJump;
        public bool InFury;
        public bool shooting;
        public bool isClickable = true;
        public int Counter = 0;
        public int TimeEnemySpawn = 95;
        public int TimeBeforeShoot = 35;
        public int PosShootX;
        public int PosShootY;

        List<Enemy> BadGuys = new List<Enemy>();
        List<Enemy> EnemyToDelete = new List<Enemy>();
        List<ShootsPattern> Shoots = new List<ShootsPattern>();
        List<Vector2> ListDirectionShoot;
        List<ShootsPattern> ShootToDelete = new List<ShootsPattern>();
        #endregion All Variable

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 1280;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("SpriteFont");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hero = new Hero(Content);
            BadGuy = new Enemy(Content);
            ShootAttack = new ShootsPattern(Content, PosHero, PosClick);
            SlashAttack = new SwordShock(Content);
            ListDirectionShoot = new List<Vector2>();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.IsMouseVisible = true;

            // TODO: Add your update logic here
            #region Keyboard state
            KeyboardState keyBoardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();


            bool isKeyQDown = keyBoardState.IsKeyDown(Keys.Q);
            bool isKeyDDown = keyBoardState.IsKeyDown(Keys.D);
            bool isKeyZDown = keyBoardState.IsKeyDown(Keys.Z);
            bool isKeyXDown = keyBoardState.IsKeyDown(Keys.X);
            bool isMouseLeftClick = mouseState.LeftButton == ButtonState.Pressed;
            bool isMouseRightClick = mouseState.RightButton == ButtonState.Pressed;
            #endregion Keyboard state

            #region Counter and Action
            Counter++;

            //Timer Enemy Spawn
            if(Counter == TimeEnemySpawn)
            {
                BadGuy = new Enemy(Content);
                BadGuys.Add(BadGuy);
                TimeEnemySpawn = Counter + 55;
            }
            else { }

            //Timer Mouse
            if(isClickable == false)
            {
                TimeBeforeShoot -= 1;
            }
            else { }
            
            if(TimeBeforeShoot == 0)
            {
                isClickable = true;
                TimeBeforeShoot = 10;
            }
            else { }

            #endregion Counter and Action

            #region MOUVEMENT
            //Tire
            if(isMouseLeftClick)
            {
                hero.DistantAttack();   
            }
            //Gauche
            if (isKeyQDown)
            {
                hero.MoveLeft();
            }
            // Droite
            if (isKeyDDown)
            {
                hero.MoveRight();
            }
            // Saut
            if (isKeyZDown)
            {
                InJump = true;
            }
            // Fonction de saut
            if(InJump)
            {
                InJump = hero.Jump(InJump);
            }
            #endregion MOUVEMENT

            #region Fury
            if (isKeyXDown)
            {
                InFury = true;
            }
            // Fonction du mode furieux
            if (InFury)
            {
                InFury = hero.Fury(InFury);
            }
            #endregion Fury

            #region Attack
            if (isMouseLeftClick && isClickable == true)
            {
                shooting = true;
                isClickable = false;

                PosHero = new Vector2(hero.getPositionHero().X, hero.getPositionHero().Y);
                PosClick = new Vector2(mouseState.Position.X, mouseState.Position.Y);
            }
            else { }

            if (isMouseRightClick)
            {
                hero.SwordAttack();
            }
            else { }

            
            if (shooting)
            {
                ShootAttack = new ShootsPattern(Content,PosHero,PosClick);
                Shoots.Add(ShootAttack);
                hero.DistantAttack();
                shooting = false;
            }
            else
            {

            }
            #endregion Attack

            #region Movement and hit
            foreach (var badguy in BadGuys)
            {
                if (badguy.getPositionEnemy().Intersects(hero.getPositionHero()) && badguy.returnLife() > 0)
                {
                    hero.takeDamage();
                }
            }

            foreach (var badguy in BadGuys)
            {
                foreach (var shoot in Shoots)
                {
                    if (badguy.getPositionEnemy().Intersects(shoot.getPositionShoot()))
                    {
                        if(shoot.GetDuration() > 0 && badguy.returnLife() > 0)
                        {
                            badguy.takeDamage();
                            shoot.Shocked();
                        }
                    }
                }
            }

            if(hero.HeroLife() == 0)
            {
                hero.HeroFall();
                Exit();
                //InterfaceManager.Launcher("MenuP");
            }

            foreach(var badguy in BadGuys)
            {
                badguy.MoveEnemy();
            }

            for (int i = 0; i < Shoots.Count; i++ )
            {
                Shoots[i].MoveAttack();
            }
     
            #endregion Movement and hit

            #region Delete
            // Delete Shoot unused
            foreach (var shoot in Shoots)
            {
                if (shoot.GetDuration() < 1)
                {
                    ShootToDelete.Add(shoot);
                }
            }

            foreach (var toDelete in ShootToDelete)
            {
                Shoots.Remove(toDelete);
            }

            //Delete Enemy unused
            foreach (var badguy in BadGuys)
            {
                if (badguy.returnLife() < 1)
                {
                    EnemyToDelete.Add(badguy);
                }
            }

            foreach (var toDelete in EnemyToDelete)
            {
                BadGuys.Remove(toDelete);
            }
            #endregion Delete


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            hero.Draw(spriteBatch);
            spriteBatch.DrawString(font, "Compteur = " + Counter, new Vector2(10, 50), Color.Blue);
            spriteBatch.DrawString(font, "Nombre de vie = " + hero.HeroLife(), new Vector2(10, 100), Color.Red);
            SlashAttack.Draw(spriteBatch);

            foreach(var badguy in BadGuys)
            {
                badguy.Draw(spriteBatch);
            }

            foreach (var shoot in Shoots)
            {
                shoot.Draw(spriteBatch);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
