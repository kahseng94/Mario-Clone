using Microsoft.Xna.Framework;
using Sprint5.Entities.Movement;

namespace Sprint5.Physics.Forces
{
    public interface Force
    {
        Vector2 Calculate(IMoving entity, float delta);
    }
}
