using Sprint5.Entities.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5.Commands
{
    class CommandEnemySpeedUp : ICommand
    {
        private Game1 game;

        public CommandEnemySpeedUp(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            foreach (IEnemy enemy in game.WorldLoader.Enemies)
            {
                enemy.Speed *= 1.1f;
            }
        }
    }
}
