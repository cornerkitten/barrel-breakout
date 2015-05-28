using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout
{
    class KeyboardInputController : IController
    {
        private Dictionary<Keys, ICommand> inputMappings;
        private Keys[] oldPressedKeys;

        public KeyboardInputController()
        {
            this.inputMappings = new Dictionary<Keys, ICommand>();
            this.oldPressedKeys = Keyboard.GetState().GetPressedKeys();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            inputMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] newPressedKeys = Keyboard.GetState().GetPressedKeys();
            
            foreach (Keys key in newPressedKeys)
            {
                if (inputMappings.ContainsKey(key) && Array.IndexOf(oldPressedKeys, key) < 0)
                {
                    inputMappings[key].Execute();
                }
            }

            oldPressedKeys = newPressedKeys;
        }
    }
}
