using Sprint5.Entities;
using Sprint5.Entities.Collision;
using Sprint5.Entities.Enemies.Lakitu;
using Sprint5.Entities.Movement;
using Sprint5.World.Blocks;

namespace Sprint5.Entities.Projectiles
{
    class LakituProjectileCollision : ICollision
    {
        public void Handle(IEntity entity, IEntity target, Side side)
        {
            LakituBall lakituBall = (LakituBall) entity;

            if(target is IBlock)
            {
                IBlock block = (IBlock)target;
                if (!(block.Type == "HiddenBlock"))
                {
                    lakituBall.Bounce();
                    if (!(side == Side.TOP))
                    {
                        lakituBall.ChangeDirection();
                    }
                }
            }
        }
    }
}
