using Sprint5.Entities.Movement;

namespace Sprint5.Entities.Collision
{
    public interface ICollision
    {
        void Handle(IEntity entity, IEntity target, Side side);
    }
}
