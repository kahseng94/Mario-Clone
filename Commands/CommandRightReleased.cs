namespace Sprint5.Commands
{
    public class CommandRightReleased : ICommand
    {
        private Game1 game;

        public CommandRightReleased(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.RightReleased();
        }
    }
}
