namespace Sprint5.Commands
{
    public class CommandLeft : ICommand
    {
        private Game1 game;

        public CommandLeft(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.Left(); 
        }
    }
}
