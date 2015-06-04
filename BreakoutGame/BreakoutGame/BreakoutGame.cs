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
using Mabv.Breakout.Commands;
using Mabv.Breakout.Levels;

namespace Mabv.Breakout
{
    public class BreakoutGame : Microsoft.Xna.Framework.Game
    {
        private const int WindowWidth = 800;
        private const int WindowHeight = 600;
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
        private KeyboardInputController keyboardInputController;
        private View view;
        private Player player;
        private ILevel level;
        
        public BreakoutGame()
        {
            this.collisionController = new CollisionController();
            this.gameEntityController = new GameEntityController();
            this.keyboardInputController = new KeyboardInputController();
            this.view = new View(BreakoutGame.WindowWidth, BreakoutGame.WindowHeight);
            this.player = new Player();

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = view.Width;
            graphics.PreferredBackBufferHeight = view.Height;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Textures.LoadContent(Content);
            SoundEffects.LoadContent(Content);
            Songs.LoadContent(Content);
            Fonts.LoadContent(Content);

            level = new LevelOne(this, view, player, gameEntityController, keyboardInputController);
            level.Start();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardInputController.Update();
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
    }
}
