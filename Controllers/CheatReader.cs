using Microsoft.Xna.Framework.Input;
using Sprint5.World.Sounds;
using Sprint5.Entities.Mario;

namespace Sprint5.Controllers
{
    class CheatReader
    {
        private KeyboardState currentState;
        private KeyboardState oldState;
        private Game1 cheatGame;
        public CheatReader(Game1 game)
        {
            cheatGame = game;
        }


        public void CheatCheck(Keys key)
        {
            oldState = currentState;
            currentState = Keyboard.GetState();
            if (currentState.IsKeyDown(key) && oldState.IsKeyUp(key))
            {
                OneUpCheat(key);
                FireCheat(key);
                StarCheat(key);
            }
        }


        public void OneUpCheat(Keys key)
        {
            if (Keys.W.Equals(key) && currentState.IsKeyDown(Keys.A) && currentState.IsKeyDown(Keys.X))
            {
                SoundEffects.Instance.PlayOneUpSound();
                Game1.Lives++;
            }
        }
        public void FireCheat(Keys key)
        {
            if (Keys.Down.Equals(key) && currentState.IsKeyDown(Keys.A) && currentState.IsKeyDown(Keys.X))
            {
                SoundEffects.Instance.PlayPowerUpSound();
                cheatGame.Mario.ToFire();
            }
        }

        public void StarCheat(Keys key)
        {
            if (Keys.Up.Equals(key) && currentState.IsKeyDown(Keys.A) && currentState.IsKeyDown(Keys.X))
            {
                SoundEffects.Instance.PlayPowerUpSound();
                cheatGame.Mario = new MarioStar(cheatGame, cheatGame.Mario, 10000, true);
            }
        }
    }
}