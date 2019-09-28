using System;

namespace Sprint5.Commands
{
    internal class CommandGoEnd : ICommand
    {
        private Game1 game;

        public CommandGoEnd(Game1 superMarioBros)
        {
            this.game = superMarioBros;
        }

        public void Execute()
        {
            game.Mario.Position = new Microsoft.Xna.Framework.Vector2(220, 10);
            Game1.Camera.Position = new Microsoft.Xna.Framework.Vector2(6400, 10);
        }
    }
}