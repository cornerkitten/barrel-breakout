using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Mabv.Breakout.Collisions;
using Mabv.Breakout.GameEntities;

namespace Mabv.Breakout
{
    public class BreakoutGame : Microsoft.Xna.Framework.Game
    {
        private const int WindowWidth = 640;
        private const int WindowHeight = 480;
        public CollisionController CollisionController
        {
            get { return (CollisionController)collisionController; }
        }
        public GameEntityController GameEntityController
        {
            get { return gameEntityController; }
        }
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private IController collisionController;
        private GameEntityController gameEntityController;

        public BreakoutGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = BreakoutGame.WindowWidth;
            graphics.PreferredBackBufferHeight = BreakoutGame.WindowHeight;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            collisionController = new CollisionController();
            gameEntityController = new GameEntityController();
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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Textures.LoadContent(Content);
            CreateGameEntities();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            gameEntityController.Update();
            collisionController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            gameEntityController.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        private void CreateGameEntities()
        {
            for (int i = 32; i < WindowWidth - 64; i += 64)
            {
                for (int j = 32; j < WindowHeight / 2 - 64; j += 64)
                {
                    gameEntityController.AddGameEntity(new Barrel(this, new Vector2(i, j)));
                }
            }
            GameEntityController.AddGameEntity(new Paddle(this, new Vector2(WindowWidth / 2, WindowHeight - 64)));
            GameEntityController.AddGameEntity(new DonkeyKong(this, new Vector2(WindowWidth / 2, WindowHeight / 2)));
        }
    }
}
