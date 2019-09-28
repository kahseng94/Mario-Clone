using Microsoft.Xna.Framework.Media;
using Sprint5.World.Sounds;

namespace Sprint5.Commands
{
    public class CommandPause : ICommand
    {
        private Game1 _game;
        public CommandPause(Game1 game)
        {
            _game = game;
        }
        public void Execute()
        {
            _game.IsPaused = !_game.IsPaused;
            SoundEffects.Instance.PlayPauseSound();
            if (MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Resume();
            }
            else
            {
                MediaPlayer.Pause();
            }
        }
    }
}
