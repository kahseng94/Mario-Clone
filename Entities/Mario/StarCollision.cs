using Sprint5.Entities.Collision;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Items;
using Sprint5.Entities.Movement;
using Sprint5.World.Blocks;

namespace Sprint5.Entities.Mario
{
    public class StarCollision : ICollision
    {
        public void Handle(IEntity entity, IEntity target, Side side)
        {
            IPlayer player = (IPlayer)entity;
            // Player is colliding into a block
            if (target is IBlock)
            {
                IBlock block = (IBlock)target;
                // Blocks can only be hit from the bottom
                if (side == Side.BOTTOM)
                {
                    // Player hits the block
                    block.Hit(player);
                }
            }
            // Player is colliding into an item
            else if (target is IItem)
            {
                // Player consumes the item
                ((IItem)target).Consume(player);
            }
            // Player is colliding into an enemy
            else if (target is IEnemy)
            {
                // Player kills the enemy from any direction
                ((IEnemy)target).BeFlipped();
            }
        }
    }
}
