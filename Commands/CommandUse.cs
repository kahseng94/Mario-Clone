namespace Sprint5.Commands
{
    public class CommandUse : ICommand
    {
        private Game1 game;

        public CommandUse(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.Use();
        }
    }
}
