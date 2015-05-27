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

namespace Breakout
{
    public class BreakoutGame : Microsoft.Xna.Framework.Game
    {
        public CollisionController CollisionController
        {
            get { return (CollisionController)collisionController; }
        }
        public GameEntityController GameEntityController
        {
            get { return (GameEntityController)gameEntityController; }
        }
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private IController collisionController;
        private IController gameEntityController;

        public BreakoutGame()
        {
            graphics = new GraphicsDeviceManager(this);
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
            GraphicsDevice.Clear(Color.Black);

            ((GameEntityController)gameEntityController).Draw(spriteBatch);

            base.Draw(gameTime);
        }

        private void CreateGameEntities()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ((GameEntityController)gameEntityController).AddGameEntity(new Barrel(this, new Vector2(32 + 64 * i, 32 + 64 * j)));
                }
            }
            ((GameEntityController)gameEntityController).AddGameEntity(new DonkeyKong(this, new Vector2(32, 32 * 4)));
        }
    }
}
