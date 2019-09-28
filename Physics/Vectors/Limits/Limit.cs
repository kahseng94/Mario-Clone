using Microsoft.Xna.Framework;

namespace Sprint5.Physics.Vectors.Limits
{
    public class Limit<T>
    {
        public static Limit<T> NONE { get; } = new Limit<T>();

        public virtual bool Test(T value)
        {
            return true;
        }

        public virtual T Apply(T value)
        {
            return value;
        }
    }
}
