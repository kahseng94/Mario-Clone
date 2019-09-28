using Sprint5.Entities.Enemies;

namespace Sprint5.Commands
{
    class CommandEnemySlowDown : ICommand
    {
        private Game1 game;

        public CommandEnemySlowDown(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            foreach (IEnemy enemy in game.WorldLoader.Enemies)
            {
                enemy.Speed /= 1.1f;
            }
        }
    }
}
