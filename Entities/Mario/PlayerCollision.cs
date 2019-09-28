using Sprint5.Entities.Collision;
using Sprint5.Entities.Enemies;
using Sprint5.Entities.Enemies.Koopa;
using Sprint5.Entities.Items;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Forces;
using Sprint5.World.Blocks;
using Sprint5.World.Pipes;
using Sprint5.World.Sounds;

namespace Sprint5.Entities.Mario
{
    public class PlayerCollision : ICollision
    {
        private static Force stomp = new Impulse(0, 1);

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
                else if (target is Pipe && side == ((Pipe)target).Side)
                {
                    target.Collision.Handle(player, target, side);
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
                IEnemy enemy = (IEnemy)target;
                if (enemy.IsAlive())
                {
                    if (side == Side.TOP)
                    {
                        if (player.State.Name != "Dead")
                        {
                            // Player stomps the enemy from the top
                            SoundEffects.Instance.PlayStompSound();
                            enemy.BeStomped();

                            player.ApplyForce(stomp);
                        }
                    }
                    else
                    {
                        // Player got damaged progressively
                        player.CauseDamage();
                    }
                }
                else if (enemy is Koopa && ((Koopa)enemy).State is KoopaStompedState)
                {
                    SoundEffects.Instance.PlayStompSound();
                    enemy.BeStomped();
                    if (side == Side.TOP)
                    {
                        player.ApplyForce(stomp);
                    }
                }
            }
        }
    }
}
