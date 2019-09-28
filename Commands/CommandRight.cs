namespace Sprint5.Commands
{
    public class CommandRight : ICommand
    {
        private Game1 game;

        public CommandRight(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.Right(); 
        }
    }
}
