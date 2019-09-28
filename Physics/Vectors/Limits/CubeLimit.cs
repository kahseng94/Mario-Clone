using Microsoft.Xna.Framework;

namespace Sprint5.Physics.Vectors.Limits
{
    public class CubeLimit : Limit<Vector3>
    {
        private Vector3 min;
        private Vector3 max;

        public CubeLimit(Vector3 min, Vector3 max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool Test(Vector3 value)
        {
            return !(value.X < min.X || value.Y < min.Y || value.Z < min.Z || value.X > max.X || value.Y > max.Y || value.Z > max.Z);
        }

        public override Vector3 Apply(Vector3 value)
        {
            value.X = MathHelper.Clamp(value.X, min.X, max.X);
            value.Y = MathHelper.Clamp(value.Y, min.Y, max.Y);
            value.Z = MathHelper.Clamp(value.Z, min.Z, max.Z);
            return value;
        }
    }
}
