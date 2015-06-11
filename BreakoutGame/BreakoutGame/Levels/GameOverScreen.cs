using Mabv.Breakout.Collisions;
using Mabv.Breakout.Commands;
using Mabv.Breakout.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Levels
{
    public class GameOverScreen : ILevel
    {
        private BreakoutGame game;
        private EntityController entityController;
        private KeyboardController keyboardController;
        private CollisionController collisionController;
        private bool hasRestartRequest;

        public GameOverScreen(BreakoutGame game, EntityController entityController, KeyboardController keyboardController, CollisionController collisionController)
        {
            this.game = game;
            this.entityController = entityController;
            this.keyboardController = keyboardController;
            this.collisionController = collisionController;
            this.hasRestartRequest = false;
        }

        public void Start()
        {
            Populate();
            RegisterControls();

            MediaPlayer.Play(Songs.GameOver);
            MediaPlayer.IsRepeating = false;
        }

        public void Quit()
        {
            DeregisterControls();
            Unpopulate();
        }

        public void Restart()
        {
            hasRestartRequest = true;
        }

        public void ChangeToGameOver()
        {
            Quit();

            Start();
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

        private void Populate()
        {
            entityController.AddEntity(new GameOverBackground());
        }

        private void Unpopulate()
        {
            foreach (IEntity entity in entityController.Entities)
            {
                entity.Destroy();
            }
            entityController.RemoveAll();

            collisionController.Flush();
            entityController.Flush();
        }

        private void RegisterControls()
        {
            ICommand quitGameCommand = new QuitGameCommand(game);
            keyboardController.RegisterCommandKeyDown(Keys.Q, quitGameCommand);
        }

        private void DeregisterControls()
        {
            keyboardController.DeregisterAllCommands();
        }
    }
}
