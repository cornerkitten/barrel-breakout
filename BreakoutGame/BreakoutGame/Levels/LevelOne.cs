using Mabv.Breakout.Collisions;
using Mabv.Breakout.Commands;
using Mabv.Breakout.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Levels
{
    public class LevelOne : ILevel
    {
        private BreakoutGame game;
        private View view;
        private Player player;
        private EntityController entityController;
        private CollisionController collisionController;
        private KeyboardController keyboardController;
        private bool hasRestartRequest;
        private Paddle paddle;

        public LevelOne(BreakoutGame game, View view, Player player, EntityController entityController, CollisionController collisionController, KeyboardController keyboardController)
        {
            this.game = game;
            this.view = view;
            this.player = player;
            this.entityController = entityController;
            this.collisionController = collisionController;
            this.keyboardController = keyboardController;
            this.hasRestartRequest = false;
        }

        public void Start()
        {
            populate();
            registerControls();

            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(Songs.IslandSwing);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void Quit()
        {
            deregisterControls();
            unpopulate();
        }

        public void Restart()
        {
            hasRestartRequest = true;
        }

        public void Update()
        {
            if (hasRestartRequest)
            {
                Quit();
                
                hasRestartRequest = false;

                Start();
            }

            keyboardController.Update();
            entityController.Update();
            collisionController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            entityController.Draw(spriteBatch);
        }

        private void populate()
        {
            entityController.AddEntity(new JungleBackground());

            for (int i = 105 + 16; i < view.Width - 105 - 32; i += 64)
            {
                for (int j = 32; j < view.Height / 2 - 64; j += 64)
                {
                    entityController.AddEntity(new BananaBunch(new Vector2(i + 8, j + 8), player, entityController, collisionController));

                    entityController.AddEntity(new Barrel(new Vector2(i, j), entityController, collisionController));
                }
            }

            paddle = new Paddle(new Vector2(view.Width / 2, view.Height - 64), collisionController);
            entityController.AddEntity(paddle);
            entityController.AddEntity(new DonkeyKong(new Vector2(view.Width / 2, view.Height / 2), this, collisionController));
            entityController.AddEntity(new LevelBoundary(collisionController));
            entityController.AddEntity(new PerishZone(view, collisionController));

            Hud hud = new Hud(player.Score);
            entityController.AddEntity(hud);
            player.Hud = hud;
        }

        private void unpopulate()
        {
            player.Hud = null;

            foreach(IEntity entity in entityController.Entities)
            {
                entity.Destroy();
            }
            entityController.RemoveAll();

            collisionController.Flush();
            entityController.Flush();
        }

        private void registerControls()
        {
            ICommand moveLeftCommand = new MoveLeftCommand(paddle);
            ICommand moveRightCommand = new MoveRightCommand(paddle);
            ICommand stopMovingCommand = new StopMovingCommand(paddle);
            ICommand moveUpCommand = new MoveUpCommand(paddle);
            ICommand moveDownCommand = new MoveDownCommand(paddle);
            keyboardController.RegisterCommandKeyDown(Keys.Left, moveLeftCommand);
            keyboardController.RegisterCommandKeyDown(Keys.A, moveLeftCommand);
            keyboardController.RegisterCommandKeyDown(Keys.Right, moveRightCommand);
            keyboardController.RegisterCommandKeyDown(Keys.D, moveRightCommand);
            keyboardController.RegisterCommandKeyUp(Keys.Left, stopMovingCommand);
            keyboardController.RegisterCommandKeyUp(Keys.A, stopMovingCommand);
            keyboardController.RegisterCommandKeyUp(Keys.Right, stopMovingCommand);
            keyboardController.RegisterCommandKeyUp(Keys.D, stopMovingCommand);
            // DEBUG
            //keyboardInputController.RegisterCommandKeyDown(Keys.Space, stopMovingCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.S, stopMovingCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.Down, moveDownCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.S, moveDownCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.Up, moveUpCommand);
            //keyboardInputController.RegisterCommandKeyDown(Keys.W, moveUpCommand);

            ICommand quitGameCommand = new QuitGameCommand(game);
            ICommand resetLevelCommand = new RestartLevelCommand(this);
            ICommand quitLevelCommand = new QuitLevelCommand(this);
            keyboardController.RegisterCommandKeyDown(Keys.Q, quitGameCommand);
            keyboardController.RegisterCommandKeyDown(Keys.R, resetLevelCommand);
            keyboardController.RegisterCommandKeyDown(Keys.T, quitLevelCommand);
        }

        private void deregisterControls()
        {
            keyboardController.DeregisterAllCommands();
        }
    }
}
