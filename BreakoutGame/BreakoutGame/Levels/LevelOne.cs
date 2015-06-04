using Mabv.Breakout.Commands;
using Mabv.Breakout.GameEntities;
using Microsoft.Xna.Framework;
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
        private GameEntityController gameEntityController;
        private KeyboardInputController keyboardInputController;
        private Paddle paddle;
        private Hud hud;

        public LevelOne(BreakoutGame game, View view, Player player, GameEntityController gameEntityController, KeyboardInputController keyboardInputController)
        {
            this.game = game;
            this.view = view;
            this.player = player;
            this.gameEntityController = gameEntityController;
            this.keyboardInputController = keyboardInputController;
        }

        public void Start()
        {
            populate();
            registerControls();

            MediaPlayer.Play(Songs.IslandSwing);
            MediaPlayer.IsRepeating = true;
        }

        private void populate()
        {
            gameEntityController.AddGameEntity(new JungleBackground());

            for (int i = 105 + 16; i < view.Width - 105 - 32; i += 64)
            {
                for (int j = 32; j < view.Height / 2 - 64; j += 64)
                {
                    gameEntityController.AddGameEntity(new BananaBunch(game, player, new Vector2(i + 8, j + 8)));

                    gameEntityController.AddGameEntity(new Barrel(game, new Vector2(i, j)));
                }
            }

            paddle = new Paddle(game, new Vector2(view.Width / 2, view.Height - 64));
            gameEntityController.AddGameEntity(paddle);
            gameEntityController.AddGameEntity(new DonkeyKong(game, new Vector2(view.Width / 2, view.Height / 2)));
            gameEntityController.AddGameEntity(new LevelBoundary(game));

            Hud hud = new Hud();
            gameEntityController.AddGameEntity(hud);
            player.Hud = hud;
        }

        private void registerControls()
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

            ICommand quitGameCommand = new QuitGameCommand(game);
            keyboardInputController.RegisterCommandKeyDown(Keys.Q, quitGameCommand);
        }
    }
}
