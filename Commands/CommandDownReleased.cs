namespace Sprint5.Commands
{
    public class CommandDownReleased : ICommand
    {
        private Game1 game;

        public CommandDownReleased(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.DownReleased();
        }
    }
}
