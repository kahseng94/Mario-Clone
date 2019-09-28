using Microsoft.Xna.Framework;
using Sprint5.Physics.Vectors.Limits;

namespace Sprint5.Physics.Vectors
{
    public class LVector3 : LVector<Vector3>
    {
        public Vector3 Vector { get; set; }
        public float X { get { return Vector.X; } }
        public float Y { get { return Vector.Y; } }
        public float Z { get { return Vector.Z; } }
        
        private Limit<Vector3> limit;

        public LVector3(Vector3 vector, Limit<Vector3> limit)
        {
            this.Vector = vector;
            this.limit = limit;
        }

        public LVector3(float x, float y, float z, Limit<Vector3> limit)
        {
            this.Vector = new Vector3(x, y, z);
            this.limit = limit;
        }

        public LVector3(Limit<Vector3> limit)
        {
            this.Vector = new Vector3();
            this.limit = limit;
        }

        public void Set(Vector3 vector)
        {
            Vector3 vec = Vector;
            vec.X = vector.X;
            vec.Y = vector.Y;
            vec.Z = vector.Z;
            Vector = vec;
        }

        public void Add(Vector3 vector)
        {
            Vector3 vec = Vector;
            vec.X += vector.X;
            vec.Y += vector.Y;
            vec.Z += vector.Z;
            Vector = vec;
        }

        public void Scl(Vector3 vector)
        {
            Vector3 vec = Vector;
            vec.X *= vector.X;
            vec.Y *= vector.Y;
            vec.Z *= vector.Z;
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
