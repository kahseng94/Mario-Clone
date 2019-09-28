namespace Sprint5.Commands
{
    public class CommandReset : ICommand
    {
        private Game1 game;

        public CommandReset(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Reset();
        }
    }
}
