using System;
using Microsoft.Xna.Framework;
using Sprint5.Physics.Vectors.Limits;

namespace Sprint5.Physics.Vectors
{
    public class LVector2 : LVector<Vector2>
    {
        public Vector2 Vector { get; set; }
        public float X { get { return Vector.X; } }
        public float Y { get { return Vector.Y; } }

        public static LVector2 NONE { get; } = new LVector2(Limit<Vector2>.NONE);

        private Limit<Vector2> limit;

        public LVector2(Vector2 vector, Limit<Vector2> limit)
        {
            this.Vector = vector;
            this.limit = limit;
        }

        public LVector2(float x, float y, Limit<Vector2> limit)
        {
            this.Vector = new Vector2(x, y);
            this.limit = limit;
        }

        public LVector2(Limit<Vector2> limit)
        {
            this.Vector = new Vector2();
            this.limit = limit;
        }

        public void Set(Vector2 vector)
        {
            Vector2 vec = Vector;
            vec.X = vector.X;
            vec.Y = vector.Y;
            Vector = vec;
        }

        public void Add(Vector2 vector)
        {
            Vector2 vec = Vector;
            vec.X += vector.X;
            vec.Y += vector.Y;
            Vector = vec;
        }

        public void Scl(Vector2 vector)
        {
            Vector2 vec = Vector;
            vec.X *= vector.X;
            vec.Y *= vector.Y;
            Vector = vec;
        }

        public void Limit()
        {
            if (!limit.Test(Vector))
            {
                Vector = limit.Apply(Vector);
            }
        }
    }
}
