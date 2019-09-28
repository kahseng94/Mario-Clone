using Sprint5.Entities.Enemies;

namespace Sprint5.Entities.Projectiles
{
    public interface IProjectile : IEntity
    {
        void Bounce();

        void Boom();

        void Attack(IEnemy enemy);
    }
}
