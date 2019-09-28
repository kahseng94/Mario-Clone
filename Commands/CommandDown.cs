namespace Sprint5.Commands
{
    public class CommandDown : ICommand
    {
        private Game1 game;

        public CommandDown(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.Down(); 
        }
    }
}
