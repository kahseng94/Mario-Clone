using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Commands
{
    public class CommandPause : ICommand
    {
        private SuperMarioBros _game;
        public CommandPause(SuperMarioBros game)
        {
            _game = game;
        }
        public void Execute()
        {
            _game.isPaused = !_game.isPaused;
            // remember to pause sound
            //Sound.TogglePause();
        }
    }
}
