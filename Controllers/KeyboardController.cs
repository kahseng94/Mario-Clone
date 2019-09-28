using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Sprint5.Commands;

namespace Sprint5.Controllers
{
    public class KeyboardController : IController
    {
        private Dictionary<IKeyStatus, ICommand> keys;
        private HashSet<Keys> keyPressed = new HashSet<Keys>();
        private Game1 _game;
        private CheatReader cheatQuery;

        public KeyboardController(Game1 game)
        {
            _game = game;
            cheatQuery = new CheatReader(game);
            keys = new Dictionary<IKeyStatus, ICommand>();
        }

        public void RegisterKeyPressed(Keys k, ICommand command)
        {
            keys.Add(new KeyPressed(k), command);
        }

        public void RegisterKeyReleased(Keys k, ICommand command)
        {
            keys.Add(new KeyReleased(k), command);
        }

        public void ClearKeyMapping()
        {
            keys.Clear();
        }

        public void RegisterKeys(Game1 game)
        {
            RegisterKeyPressed(Keys.Up, new CommandUp(game));
            RegisterKeyPressed(Keys.W, new CommandUp(game));
            RegisterKeyPressed(Keys.Z, new CommandUp(game));
            RegisterKeyPressed(Keys.Down, new CommandDown(game));
            RegisterKeyPressed(Keys.S, new CommandDown(game));
            RegisterKeyPressed(Keys.Left, new CommandLeft(game));
            RegisterKeyPressed(Keys.A, new CommandLeft(game));
            RegisterKeyPressed(Keys.Right, new CommandRight(game));
            RegisterKeyPressed(Keys.D, new CommandRight(game));
            RegisterKeyReleased(Keys.Up, new CommandUpReleased(game));
            RegisterKeyReleased(Keys.W, new CommandUpReleased(game));
            RegisterKeyReleased(Keys.Z, new CommandUpReleased(game));
            RegisterKeyReleased(Keys.Down, new CommandDownReleased(game));
            RegisterKeyReleased(Keys.S, new CommandDownReleased(game));
            RegisterKeyReleased(Keys.Left, new CommandLeftReleased(game));
            RegisterKeyReleased(Keys.A, new CommandLeftReleased(game));
            RegisterKeyReleased(Keys.Right, new CommandRightReleased(game));
            RegisterKeyReleased(Keys.D, new CommandRightReleased(game));
            RegisterKeyReleased(Keys.P, new CommandPause(game));
            RegisterKeyPressed(Keys.X, new CommandUse(game));
            RegisterKeyPressed(Keys.Q, new CommandQuit(game));
            RegisterKeyPressed(Keys.R, new CommandReset(game));
            RegisterKeyPressed(Keys.End, new CommandGoEnd(game));
            RegisterKeyPressed(Keys.Space, new CommandEnemyJump(game));
            RegisterKeyPressed(Keys.B, new CommandEnemySpeedUp(game));
            RegisterKeyPressed(Keys.M, new CommandEnemySlowDown(game));
            RegisterKeyReleased(Keys.N, new CommandEnemyChangeDirection(game));
        }
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            foreach (IKeyStatus key in keys.Keys)
            {
                if (_game.IsPaused && key.Key != Keys.P) continue;
                if (key is KeyPressed && state.IsKeyDown(key.Key))
                {
                    keys[key].Execute();
                    cheatQuery.CheatCheck(key.Key);
                }
                else if (key is KeyReleased)
                {
                    if (state.IsKeyDown(key.Key))
                    {
                        if (!keyPressed.Contains(key.Key)) keyPressed.Add(key.Key);
                    }
                    else if (state.IsKeyUp(key.Key))
                    {
                        if (keyPressed.Contains(key.Key))
                        {
                            keyPressed.Remove(key.Key);
                            keys[key].Execute();
                        }
                    }
                }
            }
        }
    }
}
