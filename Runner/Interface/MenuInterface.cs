#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Linq;
#endregion

namespace Runner
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MenuInterface : Game
    {
        #region Variable
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Rectangle PlayingArea;
        Rectangle LeaveArea;

        Texture2D play;
        Texture2D leave;

        int posX;
        int posY;
        #endregion

        public MenuInterface()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 1280;

            PlayingArea = new Rectangle(210, 200, 300, 100);

            LeaveArea = new Rectangle(210, 350, 300, 100);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);
            play = Content.Load<Texture2D>("jouer");
            leave = Content.Load<Texture2D>("quitter");

            // TODO: use this.Content to load your game content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.IsMouseVisible = true;

            // TODO: Add your update logic here

            MouseState mouseState = Mouse.GetState();

            posX = mouseState.Position.X;

            posY = mouseState.Position.Y;

            bool isMouseLeftClick = mouseState.LeftButton == ButtonState.Pressed;

            if(isMouseLeftClick)
            {
                if (Enumerable.Range(210, 500).Contains(posX) && Enumerable.Range(350, 450).Contains(posY))
                {
                    InterfaceManager.Launcher("Leave");
                }
                else if(Enumerable.Range(210, 500).Contains(posX) && Enumerable.Range(200, 300).Contains(posY))
                {
                    Exit();
                    InterfaceManager.Launcher("InGame");
                }
            }
            else { }

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(play, PlayingArea, Color.White);

            spriteBatch.Draw(leave, LeaveArea, Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
