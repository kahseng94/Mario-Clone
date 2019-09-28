using Microsoft.Xna.Framework;
using Sprint5.Entities.Movement;

namespace Sprint5.Physics.Forces
{
    public class Impulse : Force
    {
        private Vector2 force;
        private Vector2 vector = new Vector2();

        public Impulse(Vector2 force)
        {
            this.force = force;
        }

        public Impulse(float x, float y)
        {
            this.force = new Vector2(x, y);
        }

        public Vector2 Calculate(IMoving entity, float delta)
        {
            vector.X = force.X / delta;
            vector.Y = force.Y / delta;
            return vector;
        }
    }
}
