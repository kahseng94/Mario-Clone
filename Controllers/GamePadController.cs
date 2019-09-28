using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Sprint5.Commands;

namespace Sprint5.Controllers
{
    public class GamePadController : IController
    {
        private Dictionary<Buttons, ICommand> buttons;
        private Game1 _game;

        public GamePadController(Game1 game)
        {
            _game = game;
            buttons = new Dictionary<Buttons, ICommand>();
        }

        public void RegisterButton(Buttons button, ICommand command)
        {
            buttons.Add(button, command);
        }

        public void ClearKeyMapping()
        {
            buttons.Clear();
        }

        public void RegisterButtons(Game1 game)
        {
            RegisterButton(Buttons.DPadDown, new CommandDown(game));
            RegisterButton(Buttons.DPadLeft, new CommandLeft(game));
            RegisterButton(Buttons.DPadRight, new CommandRight(game));
            RegisterButton(Buttons.A, new CommandUp(game));
            RegisterButton(Buttons.B, new CommandUse(game));
        }
        public void Update()
        {
            if (_game.IsPaused) return;
            GamePadState state = GamePad.GetState(PlayerIndex.One);
            foreach (Buttons button in buttons.Keys)
            {
                if (state.IsButtonDown(button))
                {
                    buttons[button].Execute();
                }
            }
        }
    }
}
