namespace Sprint5.Commands
{
    public class CommandUp : ICommand
    {
        private Game1 game;

        public CommandUp(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Mario.Up(); 
        }
    }
}
