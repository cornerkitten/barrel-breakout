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
using Mabv.Breakout.Entities;
using Mabv.Breakout.Commands;
using Mabv.Breakout.Levels;

namespace Mabv.Breakout
{
    public class BreakoutGame : Microsoft.Xna.Framework.Game
    {
        private const int WindowWidth = 800;
        private const int WindowHeight = 600;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private CollisionController collisionController;
        private EntityController entityController;
        private KeyboardController keyboardController;
        private View view;
        private Player player;
        private ILevel level;
        
        public BreakoutGame()
        {
            this.collisionController = new CollisionController();
            this.entityController = new EntityController();
            this.keyboardController = new KeyboardController();
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

            level = new LevelOne(this, view, player, entityController, collisionController, keyboardController);
            level.Start();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            entityController.Update();
            collisionController.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            entityController.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
