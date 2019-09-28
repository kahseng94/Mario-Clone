using Microsoft.Xna.Framework;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Mario;
using Sprint5.Entities.Movement;
using Sprint5.World.Blocks;

namespace Sprint5.Entities.Items
{
    public class ItemCollision : ICollision
    {
        public void Handle(IEntity entity, IEntity target, Side side)
        {
            // Item is colliding into a player
            if (target is IPlayer)
            {
                // Player consumes the item
                ((IItem)entity).Consume((IPlayer)target);
            }
            else if (target is IBlock)
            {
                if (side == Side.LEFT || side == Side.RIGHT)
                {
                    ((IItem)entity).XDirection *= -1;
                    ((IItem)entity).Velocity.Scl(new Vector2(-1, 1));
                }
            }
        }
    }
}
