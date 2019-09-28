using System;
using Microsoft.Xna.Framework;
using Sprint5.Entities.Movement;

namespace Sprint5.Physics.Forces
{
    public class StoppingForce : Impulse
    {
        public StoppingForce(Vector2 force) : base(force)
        {
        }

        public StoppingForce(float x, float y) : base(x, y)
        {
        }

        public new Vector2 Calculate(IMoving entity, float delta)
        {
            Vector2 vector = base.Calculate(entity, delta);
            vector.X *= -entity.Velocity.X;
            vector.Y *= -entity.Velocity.Y;
            return vector;
        }
    }
}
