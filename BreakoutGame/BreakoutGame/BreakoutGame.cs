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
        private GameData gameData;
        private Hud hud;
        
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
            gameData = new GameData();
        }

        public void IncreaseScore()
        {
            int scoreIncrement = 10;
            gameData.Score += scoreIncrement;
            hud.IncreaseScore(scoreIncrement);

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

            MediaPlayer.Play(Songs.IslandSwing);
            MediaPlayer.IsRepeating = true;

            CreateGameEntities();
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

        private void CreateGameEntities()
        {
            gameEntityController.AddGameEntity(new JungleBackground());

            for (int i = 105 + 16; i < WindowWidth - 105 - 32; i += 64)
            {
                for (int j = 32; j < WindowHeight / 2 - 64; j += 64)
                {
                    gameEntityController.AddGameEntity(new BananaBunch(this, new Vector2(i + 8, j + 8)));

                    gameEntityController.AddGameEntity(new Barrel(this, new Vector2(i, j)));
                }
            }
            
            Paddle paddle = new Paddle(this, new Vector2(WindowWidth / 2, WindowHeight - 64));
            gameEntityController.AddGameEntity(paddle);
            gameEntityController.AddGameEntity(new DonkeyKong(this, new Vector2(WindowWidth / 2, WindowHeight / 2)));
            gameEntityController.AddGameEntity(new LevelBoundary(this));

            hud = new Hud(this);
            gameEntityController.AddGameEntity(hud);

            RegisterKeyboardCommands(paddle);
        }

        private void RegisterKeyboardCommands(Paddle paddle)
        {
            ICommand moveLeftCommand = new MoveLeftCommand(paddle);
            ICommand moveRightCommand = new MoveRightCommand(paddle);
            ICommand stopMovingCommand = new StopMovingCommand(paddle);
            ICommand moveUpCommand = new MoveUpCommand(paddle);
            ICommand moveDownCommand = new MoveDownCommand(paddle);
            keyboardInputController.RegisterCommandKeyDown(Keys.Left, moveLeftCommand);
            keyboardInputController.RegisterCommandKeyDown(Keys.A, moveLeftCommand);
            keyboardInputController.RegisterCommandKeyDown(Keys.Right, moveRightCommand);
            keyboardInputController.RegisterCommandKeyDown(Keys.D, moveRightCommand);
            keyboardInputController.RegisterCommandKeyUp(Keys.Left, stopMovingCommand);
            keyboardInputController.RegisterCommandKeyUp(Keys.A, stopMovingCommand);
            keyboardInputController.RegisterCommandKeyUp(Keys.Right, stopMovingCommand);
            keyboardInputController.RegisterCommandKeyUp(Keys.D, stopMovingCommand);
            // DEBUG
            //keyboardInputController.RegisterCommandKeyDown(Keys.Space, stopMovingCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.S, stopMovingCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.Down, moveDownCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.S, moveDownCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.Up, moveUpCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.W, moveUpCommand);

            ICommand quitGameCommand = new QuitGameCommand(this);
            keyboardInputController.RegisterCommandKeyDown(Keys.Q, quitGameCommand);
        }
    }
}
