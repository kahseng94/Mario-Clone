namespace Sprint5.Commands
{
    public class CommandLeftReleased : ICommand
    {
        private Game1 game;

        public CommandLeftReleased(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.LeftReleased();
        }
    }
}
