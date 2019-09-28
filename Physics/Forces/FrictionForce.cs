using Microsoft.Xna.Framework;
using Sprint5.Entities.Movement;
using Sprint5.Physics.Vectors;

namespace Sprint5.Physics.Forces
{
    public class FrictionForce : Force
    {
        private Vector2 force;
        private Vector2 vector = new Vector2();

        public FrictionForce(Vector2 force)
        {
            this.force = force;
        }

        public FrictionForce(float x, float y)
        {
            this.force = new Vector2(x, y);
        }

        public Vector2 Calculate(IMoving entity, float delta)
        {
            vector.X = entity.Acceleration.X == 0 ? (entity.Velocity.X * force.X * -1) : 0;
            vector.Y = entity.Acceleration.Y == 0 ? (entity.Velocity.Y * force.Y * -1) : 0;
            return vector;
        }
    }
}
