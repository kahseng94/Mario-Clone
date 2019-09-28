namespace Sprint5.Commands
{
    public class CommandUpReleased : ICommand
    {
        private Game1 game;

        public CommandUpReleased(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.UpReleased();
        }
    }
}
