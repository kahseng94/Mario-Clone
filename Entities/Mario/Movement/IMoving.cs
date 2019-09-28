using Sprint5.Physics.Forces;
using Sprint5.Physics.Vectors;

namespace Sprint5.Entities.Movement
{
    public interface IMoving : IEntity
    {
        IMovement Movement { get; set; }

        LVector2 Velocity { get; set; }

        LVector2 Acceleration { get; set; }

        void ApplyForce(Force force);
    }
}
