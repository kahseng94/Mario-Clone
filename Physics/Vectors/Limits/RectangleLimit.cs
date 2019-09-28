using Microsoft.Xna.Framework;

namespace Sprint5.Physics.Vectors.Limits
{
    public class RectangleLimit : Limit<Vector2>
    {
        private Vector2 min;
        private Vector2 max;

        public RectangleLimit(Vector2 min, Vector2 max)
        {
            this.min = min;
            this.max = max;
        }

        public RectangleLimit(Vector2 max)
        {
            this.min = new Vector2(-max.X, -max.Y);
            this.max = max;
        }

        public RectangleLimit(float x, float y)
        {
            this.min = new Vector2(-x, -y);
            this.max = new Vector2(x, y);
        }

        public override bool Test(Vector2 value)
        {
            return !(value.X < min.X || value.Y < min.Y || value.X > max.X || value.Y > max.Y);
        }

        public override Vector2 Apply(Vector2 value)
        {
            value.X = MathHelper.Clamp(value.X, min.X, max.X);
            value.Y = MathHelper.Clamp(value.Y, min.Y, max.Y);
            return value;
        }
    }
}
