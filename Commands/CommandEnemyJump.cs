using Sprint5.Entities.Enemies;
using Sprint5.Entities.Enemies.Goomba;
using Sprint5.Entities.Enemies.Koopa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint5.Commands
{
    class CommandEnemyJump : ICommand
    {
        private Game1 game;

        public CommandEnemyJump(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            foreach (IEnemy enemy in game.WorldLoader.Enemies)
            {
                Goomba goomba;
                Koopa koopa;
                if (enemy is Goomba)
                {
                    goomba = (Goomba)enemy;
                    goomba.ApplyForce();
                }
                else if (enemy is Koopa)
                {
                    koopa = (Koopa)enemy;
                    koopa.ApplyForce();
                }
            }
        }
    }
}
