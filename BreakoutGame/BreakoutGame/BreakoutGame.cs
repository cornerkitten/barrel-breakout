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

        public BreakoutGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = BreakoutGame.WindowWidth;
            graphics.PreferredBackBufferHeight = BreakoutGame.WindowHeight;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            collisionController = new CollisionController();
            gameEntityController = new GameEntityController();
            keyboardInputController = new KeyboardInputController();
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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

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

        private void CreateGameEntities()
        {
            gameEntityController.AddGameEntity(new JungleBackground());

            for (int i = 105 + 16; i < WindowWidth - 105 - 32; i += 64)
            {
                for (int j = 32; j < WindowHeight / 2 - 64; j += 64)
                {
                    gameEntityController.AddGameEntity(new Barrel(this, new Vector2(i, j)));
                }
            }
            Paddle paddle = new Paddle(this, new Vector2(WindowWidth / 2, WindowHeight - 64));
            gameEntityController.AddGameEntity(paddle);
            gameEntityController.AddGameEntity(new DonkeyKong(this, new Vector2(WindowWidth / 2, WindowHeight / 2)));
            gameEntityController.AddGameEntity(new LevelBoundary(this));

            RegisterKeyboardCommands(paddle);
        }

        private void RegisterKeyboardCommands(Paddle paddle)
        {
            ICommand moveLeftCommand = new MoveLeftCommand(paddle);
            ICommand moveRightCommand = new MoveRightCommand(paddle);
            ICommand stopMovingCommand = new StopMovingCommand(paddle);
            ICommand moveUpCommand = new MoveUpCommand(paddle);
            ICommand moveDownCommand = new MoveDownCommand(paddle);
            keyboardInputController.RegisterCommand(Keys.Left, moveLeftCommand);
            keyboardInputController.RegisterCommand(Keys.A, moveLeftCommand);
            keyboardInputController.RegisterCommand(Keys.Right, moveRightCommand);
            keyboardInputController.RegisterCommand(Keys.D, moveRightCommand);
            keyboardInputController.RegisterCommand(Keys.Space, stopMovingCommand);
            //keyboardInputController.RegisterCommand(Keys.S, stopMovingCommand);
            keyboardInputController.RegisterCommand(Keys.Down, moveDownCommand);
            keyboardInputController.RegisterCommand(Keys.S, moveDownCommand);
            keyboardInputController.RegisterCommand(Keys.Up, moveUpCommand);
            keyboardInputController.RegisterCommand(Keys.W, moveUpCommand);

            ICommand quitGameCommand = new QuitGameCommand(this);
            keyboardInputController.RegisterCommand(Keys.Q, quitGameCommand);
        }
    }
}
