using System;
using Sprint5.Entities;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;

namespace Sprint5.World.Blocks
{
    public class BlockCollision : ICollision
    {
        public void Handle(IEntity entity, IEntity target, Side side)
        {
            // This could be implemented in the future for moving blocks, for now it does nothing
        }
    }
}
