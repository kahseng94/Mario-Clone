using Microsoft.Xna.Framework;
using System;

namespace Sprint5.Physics.Vectors.Limits
{
    public class LengthLimit : Limit<Vector2>
    {
        private float limitSquared;

        public LengthLimit(float length)
        {
            limitSquared = length * length;
        }

        public override bool Test(Vector2 value)
        {
            return limitSquared >= value.LengthSquared();
        }

        public override Vector2 Apply(Vector2 value)
        {
            float scale = (float)Math.Sqrt(limitSquared / value.LengthSquared());
            value.X *= scale;
            value.Y *= scale;
            return value;
        }
    }
}
