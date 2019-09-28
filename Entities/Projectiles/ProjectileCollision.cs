using Sprint5.Entities.Collision;
using Sprint5.Entities.Movement;
using Sprint5.World.Blocks;
using Sprint5.Entities.Enemies;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Projectiles
{
    class ProjectileCollision : ICollision
    {
        public void Handle(IEntity entity, IEntity target, Side side)
        {
            IProjectile fireball = (IProjectile)entity;
            // Fireball is colliding into a block
            if (target is IBlock)
            {
                IBlock block = (IBlock)target;
                // Fireball bounces on the top side of all kinds of blocks except hidden block
                if (side == Side.TOP && block.Type != "HiddenBlock")
                {
                    fireball.Bounce();
                }
                // Fire booms when colliding into a block if it is not a hidden block
                else if (block.Type != "HiddenBlock") {
                    SoundEffects.Instance.PlayBumpSound();
                    fireball.Boom();
                }
            }
            // Fireball is colliding into an enemy
            else if (target is IEnemy)
            {
                IEnemy enemy = (IEnemy)target;
                fireball.Attack(enemy);
                SoundEffects.Instance.PlayKickSound();
                fireball.Boom();
            }
        }
    }
}
