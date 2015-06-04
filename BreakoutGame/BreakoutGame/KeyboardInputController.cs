using Mabv.Breakout.Commands;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> inputMappingsKeyDown;
        private Dictionary<Keys, ICommand> inputMappingsKeyUp;
        private Keys[] oldPressedKeys;

        public KeyboardController()
        {
            this.inputMappingsKeyDown = new Dictionary<Keys, ICommand>();
            this.inputMappingsKeyUp = new Dictionary<Keys, ICommand>();
            this.oldPressedKeys = Keyboard.GetState().GetPressedKeys();
        }

        public void RegisterCommandKeyDown(Keys key, ICommand command)
        {
            inputMappingsKeyDown.Add(key, command);
        }

        public void RegisterCommandKeyUp(Keys key, ICommand command)
        {
            inputMappingsKeyUp.Add(key, command);
        }

        public void DeregisterAllCommands()
        {
            inputMappingsKeyDown.Clear();
            inputMappingsKeyUp.Clear();
        }

        public void Update()
        {
            Keys[] newPressedKeys = Keyboard.GetState().GetPressedKeys();
            
            foreach (Keys key in newPressedKeys)
            {
                if (inputMappingsKeyDown.ContainsKey(key) && Array.IndexOf(oldPressedKeys, key) < 0)
                {
                    inputMappingsKeyDown[key].Execute();
                }
            }

            foreach (Keys key in inputMappingsKeyUp.Keys)
            {
                if (Array.IndexOf(newPressedKeys, key) < 0 && Array.IndexOf(oldPressedKeys, key) >= 0)
                {
                    Console.WriteLine("key " + key + " up detected");
                    inputMappingsKeyUp[key].Execute();
                }
            }

            oldPressedKeys = newPressedKeys;
        }
    }
}
