using Microsoft.Xna.Framework;
using Sprint5.Entities.Movement;

namespace Sprint5.Physics.Forces
{
    public class SimpleForce : Force
    {
        public static readonly Force gravity = new SimpleForce(0, -0.75f);

        private Vector2 force;
        private Vector2 vector = new Vector2();

        public SimpleForce(Vector2 force)
        {
            this.force = force;
        }

        public SimpleForce(float x, float y)
        {
            this.force = new Vector2(x, y);
        }

        public Vector2 Calculate(IMoving entity, float delta)
        {
            vector.X = force.X;
            vector.Y = force.Y;
            return vector;
        }
    }
}
