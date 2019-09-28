using Sprint5.Entities.Collision;
using Sprint5.World.Blocks;
using Sprint5.Entities.Movement;

namespace Sprint5.Entities.Enemies
{
    public class EnemyCollision : ICollision
    {
        public void Handle(IEntity entity, IEntity target, Side side)
        {
            IEnemy enemy = (IEnemy)entity;
            // Enemy is colliding into another enemy
            if (target is IEnemy)
            {
                IEnemy tEnemy = (IEnemy)target;
                if (tEnemy.IsAlive())
                {
                    enemy.ChangeDirection();
                }
            }
            // Enemy is colliding into a block
            else if (target is IBlock)
            {
                if (side == Side.LEFT || side == Side.RIGHT)
                {
                    // Enemy changes direction
                    enemy.ChangeDirection();
                }
            }
        }
    }
}
