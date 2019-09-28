using Sprint5.Entities.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5.Entities.Enemies
{
    public interface ILakituState : IEnemyState
    {
        bool thrown { get; set; }

        void AboveMario(Vector2 location);

        bool AboveMario();
    }
}
